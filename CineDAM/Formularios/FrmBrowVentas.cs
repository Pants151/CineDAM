using CineDAM.Modelos;
using System.Data;
using System.Text; // Para CSV

namespace CineDAM.Formularios
{
    public partial class FrmBrowVentas : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        public FrmBrowVentas()
        {
            InitializeComponent();
            _tabla = new Tabla(Program.appCine.LaConexion);
            _bs = new BindingSource();
        }

        private void FrmBrowVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            string sql = @"
                SELECT 
                    v.id_venta,
                    v.fecha_venta, 
                    p.titulo AS Pelicula, 
                    sa.nombre AS Sala, 
                    s.hora_inicio AS Sesion,
                    CONCAT('Fila ', v.fila, ' - Asiento ', v.columna) AS Butaca,
                    s.precio AS Precio
                FROM venta v
                JOIN sesion s ON v.id_sesion = s.id_sesion
                JOIN pelicula p ON s.id_pelicula = p.id_pelicula
                JOIN sala sa ON s.id_sala = sa.id_sala
                ORDER BY v.fecha_venta DESC";

            if (_tabla.InicializarDatos(sql))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgVentas.DataSource = _bs;
                PersonalizarGrid();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Error al cargar el historial de ventas.");
            }
        }

        private void PersonalizarGrid()
        {
            // 1. Columnas
            if (dgVentas.Columns.Contains("id_venta")) dgVentas.Columns["id_venta"].Visible = false;

            dgVentas.Columns["fecha_venta"].HeaderText = "FECHA";
            dgVentas.Columns["Pelicula"].HeaderText = "PELÍCULA";
            dgVentas.Columns["Sala"].HeaderText = "SALA";
            dgVentas.Columns["Sesion"].HeaderText = "HORA";
            dgVentas.Columns["Butaca"].HeaderText = "ASIENTO";
            dgVentas.Columns["Precio"].HeaderText = "PRECIO";

            dgVentas.Columns["Pelicula"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgVentas.Columns["Butaca"].Width = 150;
            dgVentas.Columns["Precio"].Width = 100;
            dgVentas.Columns["fecha_venta"].Width = 150;

            // Formatos
            if (dgVentas.Columns.Contains("fecha_venta"))
                dgVentas.Columns["fecha_venta"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dgVentas.Columns.Contains("Sesion"))
                dgVentas.Columns["Sesion"].DefaultCellStyle.Format = "HH:mm";

            if (dgVentas.Columns.Contains("Precio"))
            {
                dgVentas.Columns["Precio"].DefaultCellStyle.Format = "0.00 €";
                dgVentas.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 2. Estilos Dark Mode
            dgVentas.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgVentas.GridColor = Color.FromArgb(45, 45, 48);

            // Cabeceras
            dgVentas.EnableHeadersVisualStyles = false;
            dgVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgVentas.ColumnHeadersHeight = 40;

            // Filas
            dgVentas.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgVentas.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dgVentas.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternancia
            dgVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 38);
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgVentas.Rows)
            {
                if (row.Cells["Precio"].Value != DBNull.Value) total += Convert.ToDecimal(row.Cells["Precio"].Value);
            }
            // CAMBIO AQUÍ:
            lblTotal.Text = $"Total Recaudado: {total:N2} €";
            lblTotal.ForeColor = Color.LightGreen;
        }

        // --- EXPORTACIÓN ---
        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK) Export_A_CSV(sfd.FileName);
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML|*.xml" };
            if (sfd.ShowDialog() == DialogResult.OK) Export_A_XML(sfd.FileName);
        }

        private void Export_A_CSV(string ruta)
        {
            try
            {
                DataTable dt = (DataTable)_bs.DataSource;
                List<string> lineas = new List<string>();
                lineas.Add(string.Join(";", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row in dt.Rows) lineas.Add(string.Join(";", row.ItemArray.Select(f => f?.ToString().Replace(";", ","))));
                File.WriteAllLines(ruta, lineas, Encoding.UTF8);
                MessageBox.Show("Exportado correctamente.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Export_A_XML(string ruta)
        {
            try
            {
                ((DataTable)_bs.DataSource).WriteXml(ruta, XmlWriteMode.WriteSchema);
                MessageBox.Show("Exportado correctamente.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}