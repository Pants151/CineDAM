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

        // Controlamos qué panel de película está seleccionado para resaltarlo
        private Panel _panelPeliculaSeleccionado = null;

        public FrmTaquilla()
        {
            InitializeComponent();
            this.Load += FrmTaquilla_Load;
            btnBuscar.Click += btnBuscar_Click;
        }

        private void FrmTaquilla_Load(object sender, EventArgs e)
        {
            CargarPeliculasVisual();

            if (Program.appCine.estadoApp == EstadoApp.AdminLogueado)
            {
                btnComprar.Visible = false;
                lblInfo.Text = "MODO CONSULTA (ADMIN)";
            }
            else
            {
                btnComprar.Enabled = false;
            }
        }

        // --- NUEVO: Carga visual de películas ---
        private void CargarPeliculasVisual()
        {
            Tabla t = new Tabla(Program.appCine.LaConexion);
            // Traemos también el poster_url
            if (t.InicializarDatos("SELECT id_pelicula, titulo, poster_url FROM Pelicula"))
            {
                flpPeliculas.Controls.Clear();

                foreach (DataRow row in t.LaTabla.Rows)
                {
                    int idPeli = Convert.ToInt32(row["id_pelicula"]);
                    string titulo = row["titulo"].ToString();
                    string poster = row["poster_url"].ToString();

                    // 1. Crear Contenedor (Tarjeta)
                    Panel pnlCard = new Panel();
                    pnlCard.Size = new Size(120, 180);
                    pnlCard.Margin = new Padding(10);
                    pnlCard.Cursor = Cursors.Hand;
                    pnlCard.Tag = idPeli; // Guardamos ID aquí
                    pnlCard.BackColor = Color.FromArgb(40, 40, 40);

                    // 2. Crear Imagen
                    PictureBox pb = new PictureBox();
                    pb.Dock = DockStyle.Top;
                    pb.Height = 140;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Tag = idPeli; // Para que el click funcione en la imagen también

                    // Cargar imagen segura
                    if (!string.IsNullOrEmpty(poster))
                    {
                        string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", poster);
                        if (File.Exists(ruta)) pb.Image = Image.FromFile(ruta);
                    }
                    // Si no hay imagen, podrías poner una por defecto o dejarla vacía

                    // 3. Crear Título
                    Label lbl = new Label();
                    lbl.Dock = DockStyle.Bottom;
                    lbl.Height = 40;
                    lbl.Text = titulo;
                    lbl.ForeColor = Color.White;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    lbl.Tag = idPeli; // Para el click en texto

                    // 4. Eventos Click
                    EventHandler clickEvent = (s, e) => SeleccionarPelicula(idPeli, pnlCard);
                    pnlCard.Click += clickEvent;
                    pb.Click += clickEvent;
                    lbl.Click += clickEvent;

                    // 5. Ensamblar
                    pnlCard.Controls.Add(pb);
                    pnlCard.Controls.Add(lbl);
                    flpPeliculas.Controls.Add(pnlCard);
                }
            }
        }

        private void SeleccionarPelicula(int idPelicula, Panel panelClicado)
        {
            // Efecto visual de selección
            if (_panelPeliculaSeleccionado != null)
                _panelPeliculaSeleccionado.BackColor = Color.FromArgb(40, 40, 40); // Reset anterior

            _panelPeliculaSeleccionado = panelClicado;
            _panelPeliculaSeleccionado.BackColor = Color.FromArgb(0, 122, 204); // Azul selección

            // Cargar sesiones de esa película
            CargarSesiones(idPelicula);
        }

        private void CargarSesiones(int idPelicula)
        {
            Tabla t = new Tabla(Program.appCine.LaConexion);
            string sql = $"SELECT s.id_sesion, s.precio, CONCAT(sa.nombre, ' - ', DATE_FORMAT(s.hora_inicio, '%H:%i')) as info " +
                         $"FROM Sesion s JOIN Sala sa ON s.id_sala = sa.id_sala " +
                         $"WHERE s.id_pelicula = {idPelicula} " +
                         $"ORDER BY s.hora_inicio";

            if (t.InicializarDatos(sql))
            {
                cmbSesion.DataSource = t.LaTabla;
                cmbSesion.DisplayMember = "info";
                cmbSesion.ValueMember = "id_sesion";

                // Resetear sala
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

            // 1. Obtener Sala
            string sqlSala = $"SELECT sa.filas, sa.columnas FROM Sala sa JOIN Sesion s ON s.id_sala = sa.id_sala WHERE s.id_sesion = {idSesion}";
            DataTable dtSala = new DataTable();
            using (var cmd = new MySqlDataAdapter(sqlSala, Program.appCine.LaConexion)) { cmd.Fill(dtSala); }

            if (dtSala.Rows.Count == 0) return;

            int filas = Convert.ToInt32(dtSala.Rows[0]["filas"]);
            int cols = Convert.ToInt32(dtSala.Rows[0]["columnas"]);

            // 2. Obtener Ocupados
            List<Point> ocupados = new List<Point>();
            string sqlOcupados = $"SELECT fila, columna FROM venta WHERE id_sesion = {idSesion}";
            using (var cmd = new MySqlCommand(sqlOcupados, Program.appCine.LaConexion))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) ocupados.Add(new Point(reader.GetInt32(1), reader.GetInt32(0)));
            }

            // 3. Dibujar Botones (Centrados si es posible)
            int btnSize = 45;
            int gap = 8;

            // Calculamos offset para centrar (opcional, pero queda mejor)
            int anchoTotal = cols * (btnSize + gap);
            int altoTotal = filas * (btnSize + gap);
            int startX = (pnSala.Width - anchoTotal) / 2;
            int startY = (pnSala.Height - altoTotal) / 2;
            if (startX < 20) startX = 20;
            if (startY < 20) startY = 20;

            for (int f = 1; f <= filas; f++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(btnSize, btnSize);
                    btn.Location = new Point(startX + (c - 1) * (btnSize + gap), startY + (f - 1) * (btnSize + gap));
                    btn.Text = $"{f}-{c}";
                    btn.Tag = new Point(c, f);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 8);
                    btn.ForeColor = Color.Black;

                    if (ocupados.Contains(new Point(c, f)))
                    {
                        btn.BackColor = Color.IndianRed;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.DarkSeaGreen;
                        btn.Click += Asiento_Click;
                        btn.MouseDown += Asiento_MouseDown;
                    }
                    pnSala.Controls.Add(btn);
                }
            }
        }

        private void Asiento_Click(object sender, EventArgs e)
        {
            Button btnClicado = (Button)sender;
            if (_botonSeleccionado != null) _botonSeleccionado.BackColor = Color.DarkSeaGreen;

            _botonSeleccionado = btnClicado;
            _botonSeleccionado.BackColor = Color.Gold;
            _asientoSeleccionado = (Point)btnClicado.Tag;

            lblInfo.Text = $"SELECCIONADO: Fila {_asientoSeleccionado.Y} | Asiento {_asientoSeleccionado.X}";
            if (Program.appCine.estadoApp != EstadoApp.AdminLogueado) btnComprar.Enabled = true;
        }

        private void Asiento_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && btnComprar.Enabled)
            {
                Asiento_Click(sender, e);
                btnComprar.PerformClick();
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (_idSesionActual == -1 || _asientoSeleccionado.X == -1) return;

            if (MessageBox.Show("¿Confirmar venta?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = $"INSERT INTO venta (id_sesion, fila, columna) VALUES ({_idSesionActual}, {_asientoSeleccionado.Y}, {_asientoSeleccionado.X})";
                    using (var cmd = new MySqlCommand(sql, Program.appCine.LaConexion)) { cmd.ExecuteNonQuery(); }

                    MessageBox.Show("¡Venta realizada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DibujarSala(_idSesionActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    Program.appCine.RegistrarLog("Error Taquilla", ex.Message);
                    DibujarSala(_idSesionActual);
                }
            }
        }
    }
}