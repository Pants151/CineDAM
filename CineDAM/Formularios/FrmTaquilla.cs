using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace CineDAM.Formularios
{
    public partial class FrmTaquilla : Form
    {
        private int _idSesionActual = -1;
        private decimal _precioSesion = 0;
        private Point _asientoSeleccionado = new Point(-1, -1);
        private Button _botonSeleccionado = null;

        public FrmTaquilla()
        {
            InitializeComponent();
            // Conexión manual de eventos para asegurar funcionamiento
            this.Load += FrmTaquilla_Load;
            cmbPelicula.SelectedIndexChanged += cmbPelicula_SelectedIndexChanged;
            btnBuscar.Click += btnBuscar_Click;
        }

        private void FrmTaquilla_Load(object sender, EventArgs e)
        {
            CargarPeliculas();
            btnComprar.Enabled = false;
        }

        private void CargarPeliculas()
        {
            Tabla t = new Tabla(Program.appCine.LaConexion);
            if (t.InicializarDatos("SELECT id_pelicula, titulo FROM Pelicula"))
            {
                cmbPelicula.DataSource = t.LaTabla;
                cmbPelicula.DisplayMember = "titulo";
                cmbPelicula.ValueMember = "id_pelicula";

                if (cmbPelicula.Items.Count > 0)
                    CargarSesiones((int)cmbPelicula.SelectedValue);
            }
        }

        private void cmbPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPelicula.SelectedValue is int idPeli)
            {
                CargarSesiones(idPeli);
            }
        }

        private void CargarSesiones(int idPelicula)
        {
            Tabla t = new Tabla(Program.appCine.LaConexion);
            // Consulta para llenar el combo de sesiones
            string sql = $"SELECT s.id_sesion, s.precio, CONCAT(sa.nombre, ' - ', DATE_FORMAT(s.hora_inicio, '%H:%i')) as info " +
                         $"FROM Sesion s JOIN Sala sa ON s.id_sala = sa.id_sala " +
                         $"WHERE s.id_pelicula = {idPelicula} " +
                         $"ORDER BY s.hora_inicio";

            if (t.InicializarDatos(sql))
            {
                cmbSesion.DataSource = t.LaTabla;
                cmbSesion.DisplayMember = "info";
                cmbSesion.ValueMember = "id_sesion";

                // Limpiar área visual al cambiar de película
                pnSala.Controls.Clear();
                btnComprar.Enabled = false;
                lblPrecio.Text = "Precio: 0,00 €";
            }
            else
            {
                cmbSesion.DataSource = null;
                pnSala.Controls.Clear();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbSesion.SelectedValue == null) return;

            DataRowView row = (DataRowView)cmbSesion.SelectedItem;
            _idSesionActual = (int)row["id_sesion"];
            _precioSesion = Convert.ToDecimal(row["precio"]);

            lblPrecio.Text = $"Precio: {_precioSesion:C2}";

            DibujarSala(_idSesionActual);
        }

        private void DibujarSala(int idSesion)
        {
            pnSala.Controls.Clear();
            _asientoSeleccionado = new Point(-1, -1);
            btnComprar.Enabled = false;
            lblInfo.Text = "Selecciona un asiento...";

            // 1. Obtener dimensiones de la sala
            string sqlSala = $"SELECT sa.filas, sa.columnas FROM Sala sa JOIN Sesion s ON s.id_sala = sa.id_sala WHERE s.id_sesion = {idSesion}";
            DataTable dtSala = new DataTable();
            using (var cmd = new MySqlDataAdapter(sqlSala, Program.appCine.LaConexion)) { cmd.Fill(dtSala); }

            if (dtSala.Rows.Count == 0) return;

            int filas = Convert.ToInt32(dtSala.Rows[0]["filas"]);
            int cols = Convert.ToInt32(dtSala.Rows[0]["columnas"]);

            // 2. Obtener asientos ocupados
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

            // 3. Dibujar botones
            int btnSize = 45;
            int gap = 8;

            for (int f = 1; f <= filas; f++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(btnSize, btnSize);
                    btn.Location = new Point((c - 1) * (btnSize + gap) + 20, (f - 1) * (btnSize + gap) + 20);
                    btn.Text = $"{f}-{c}";
                    btn.Tag = new Point(c, f);

                    // Estilo Dark Mode
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 8);
                    btn.ForeColor = Color.Black;

                    // Verificar estado
                    if (ocupados.Contains(new Point(c, f)))
                    {
                        // OCUPADO
                        btn.BackColor = Color.IndianRed;
                        btn.Enabled = false; // IMPIDE CLICAR O RE-COMPRAR
                    }
                    else
                    {
                        // LIBRE
                        btn.BackColor = Color.DarkSeaGreen;
                        btn.Click += Asiento_Click;
                        btn.MouseDown += Asiento_MouseDown; // Habilita doble clic
                    }

                    pnSala.Controls.Add(btn);
                }
            }
        }

        private void Asiento_Click(object sender, EventArgs e)
        {
            Button btnClicado = (Button)sender;

            // Deseleccionar anterior si existe
            if (_botonSeleccionado != null && _botonSeleccionado != btnClicado)
            {
                _botonSeleccionado.BackColor = Color.DarkSeaGreen;
            }

            // Seleccionar nuevo
            _botonSeleccionado = btnClicado;
            _botonSeleccionado.BackColor = Color.Gold;
            _asientoSeleccionado = (Point)btnClicado.Tag;

            lblInfo.Text = $"SELECCIONADO: Fila {_asientoSeleccionado.Y} | Asiento {_asientoSeleccionado.X}";
            btnComprar.Enabled = true;
        }

        private void Asiento_MouseDown(object sender, MouseEventArgs e)
        {
            // Atajo: Doble clic izquierdo para comprar directamente
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                Asiento_Click(sender, e); // Aseguramos que se seleccione visualmente
                btnComprar.PerformClick(); // Ejecutamos la compra
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (_idSesionActual == -1 || _asientoSeleccionado.X == -1) return;

            if (MessageBox.Show("¿Confirmar venta de entrada?", "Confirmar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = $"INSERT INTO venta (id_sesion, fila, columna) VALUES " +
                                 $"({_idSesionActual}, {_asientoSeleccionado.Y}, {_asientoSeleccionado.X})";

                    using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("¡Venta realizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar sala para bloquear el asiento vendido
                    DibujarSala(_idSesionActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.appCine.RegistrarLog("Error Venta", ex.Message);

                    // Si hubo error, recargamos por seguridad (quizás alguien más lo compró antes)
                    DibujarSala(_idSesionActual);
                }
            }
        }
    }
}