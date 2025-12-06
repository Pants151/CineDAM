using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace CineDAM.Formularios
{
    public partial class FrmTaquilla : Form
    {
        // Variables para controlar el estado actual
        private int _idSesionActual = -1;
        private decimal _precioSesion = 0;

        // Para saber qué asiento ha clicado el usuario (fila, columna)
        private Point _asientoSeleccionado = new Point(-1, -1);
        private Button _botonSeleccionado = null;

        public FrmTaquilla()
        {
            InitializeComponent();
        }

        private void FrmTaquilla_Load(object sender, EventArgs e)
        {
            CargarPeliculas();
            // Desactivar botón de compra hasta que se seleccione algo
            btnComprar.Enabled = false;
        }

        // 1. Cargar el ComboBox de Películas
        private void CargarPeliculas()
        {
            Tabla t = new Tabla(Program.appCine.LaConexion);
            if (t.InicializarDatos("SELECT id_pelicula, titulo FROM Pelicula"))
            {
                cmbPelicula.DataSource = t.LaTabla;
                cmbPelicula.DisplayMember = "titulo";
                cmbPelicula.ValueMember = "id_pelicula";

                // Al cargar películas, cargamos las sesiones de la primera (si hay)
                if (cmbPelicula.Items.Count > 0)
                    CargarSesiones((int)cmbPelicula.SelectedValue);
            }
        }

        // 2. Al cambiar de película, cargamos sus sesiones
        private void cmbPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPelicula.SelectedValue is int idPeli)
            {
                CargarSesiones(idPeli);
            }
        }

        // 3. Cargar el ComboBox de Sesiones
        private void CargarSesiones(int idPelicula)
        {
            Tabla t = new Tabla(Program.appCine.LaConexion);
            // Traemos también el nombre de la sala y el precio para mostrarlo
            string sql = $"SELECT s.id_sesion, s.precio, CONCAT(sa.nombre, ' - ', DATE_FORMAT(s.hora_inicio, '%H:%i')) as info " +
                         $"FROM Sesion s JOIN Sala sa ON s.id_sala = sa.id_sala " +
                         $"WHERE s.id_pelicula = {idPelicula} AND s.hora_inicio > NOW() " +
                         $"ORDER BY s.hora_inicio";

            if (t.InicializarDatos(sql))
            {
                cmbSesion.DataSource = t.LaTabla;
                cmbSesion.DisplayMember = "info";
                cmbSesion.ValueMember = "id_sesion";

                // Limpiamos la sala visualmente si cambiamos de peli
                pnSala.Controls.Clear();
                btnComprar.Enabled = false;
            }
            else
            {
                // Si no hay sesiones, limpiar combo
                cmbSesion.DataSource = null;
            }
        }

        // 4. BOTÓN "CARGAR SALA"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbSesion.SelectedValue == null) return;

            // Obtenemos datos de la sesión seleccionada
            DataRowView row = (DataRowView)cmbSesion.SelectedItem;
            _idSesionActual = (int)row["id_sesion"];
            _precioSesion = Convert.ToDecimal(row["precio"]);

            lblPrecio.Text = $"Precio: {_precioSesion:C2}";

            DibujarSala(_idSesionActual);
        }

        // 5. EL NÚCLEO: DIBUJAR LOS ASIENTOS
        private void DibujarSala(int idSesion)
        {
            pnSala.Controls.Clear();
            _asientoSeleccionado = new Point(-1, -1);
            btnComprar.Enabled = false;

            // A) Obtener dimensiones de la sala (Filas y Columnas)
            string sqlSala = $"SELECT sa.filas, sa.columnas FROM Sala sa " +
                             $"JOIN Sesion s ON s.id_sala = sa.id_sala " +
                             $"WHERE s.id_sesion = {idSesion}";

            DataTable dtSala = new DataTable();
            using (var cmd = new MySqlDataAdapter(sqlSala, Program.appCine.LaConexion))
            {
                cmd.Fill(dtSala);
            }

            if (dtSala.Rows.Count == 0) return;

            int filas = Convert.ToInt32(dtSala.Rows[0]["filas"]);
            int cols = Convert.ToInt32(dtSala.Rows[0]["columnas"]);

            // B) Obtener asientos ocupados (Entradas vendidas)
            List<Point> ocupados = new List<Point>();
            string sqlOcupados = $"SELECT fila, columna FROM venta WHERE id_sesion = {idSesion}";
            using (var cmd = new MySqlCommand(sqlOcupados, Program.appCine.LaConexion))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ocupados.Add(new Point(reader.GetInt32(1), reader.GetInt32(0))); // X=Columna, Y=Fila
                }
            }

            // C) Generar botones dinámicamente
            int btnSize = 40; // Tamaño del botón
            int gap = 5;      // Espacio entre botones

            for (int f = 1; f <= filas; f++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(btnSize, btnSize);
                    btn.Location = new Point((c - 1) * (btnSize + gap) + 20, (f - 1) * (btnSize + gap) + 20);
                    btn.Text = $"{f}-{c}"; // Texto ej: "1-1"
                    btn.Tag = new Point(c, f); // Guardamos la coordenada en el Tag (Col, Fila)

                    // Verificar si está ocupado
                    Point pActual = new Point(c, f);
                    if (ocupados.Contains(pActual))
                    {
                        btn.BackColor = Color.Red;
                        btn.Enabled = false; // No se puede clicar
                    }
                    else
                    {
                        btn.BackColor = Color.LightGreen;
                        btn.Click += Asiento_Click; // Asignamos el evento click

                        // Evento MouseDown para detectar el doble clic
                        btn.MouseDown += Asiento_MouseDown;
                        // --------------------------
                    }

                    pnSala.Controls.Add(btn);
                }
            }
        }

        // 6. EVENTO AL CLICAR UN ASIENTO
        private void Asiento_Click(object sender, EventArgs e)
        {
            Button btnClicado = (Button)sender;

            // Si ya había uno seleccionado, lo volvemos a poner verde
            if (_botonSeleccionado != null)
            {
                _botonSeleccionado.BackColor = Color.LightGreen;
            }

            // Marcamos el nuevo como seleccionado (Azul/Amarillo)
            _botonSeleccionado = btnClicado;
            _botonSeleccionado.BackColor = Color.Yellow;
            _asientoSeleccionado = (Point)btnClicado.Tag;

            lblInfo.Text = $"Asiento seleccionado: Fila {_asientoSeleccionado.Y}, Columna {_asientoSeleccionado.X}";
            btnComprar.Enabled = true;
        }

        // Nuevo evento para gestionar el doble clic
        private void Asiento_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificamos si es un doble clic
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                // 1. Forzamos la selección del asiento (igual que si hiciera un click simple)
                // Esto asegura que _idSesionActual y _asientoSeleccionado estén actualizados
                Asiento_Click(sender, e);

                // 2. Ejecutamos la compra directamente
                // Llamamos al método del botón comprar o usamos PerformClick()
                btnComprar.PerformClick();
            }
        }

        // 7. BOTÓN "VENDER ENTRADA"
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (_idSesionActual == -1 || _asientoSeleccionado.X == -1) return;

            if (MessageBox.Show("¿Confirmar venta?", "Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                        string sql = $"INSERT INTO venta (id_sesion, fila, columna) VALUES " +
                            $"({_idSesionActual}, {_asientoSeleccionado.Y}, {_asientoSeleccionado.X})";

                    using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("¡Entrada vendida correctamente!");

                    // Recargamos la sala para que el asiento aparezca rojo
                    DibujarSala(_idSesionActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al vender: " + ex.Message);
                }
            }
        }
    }
}