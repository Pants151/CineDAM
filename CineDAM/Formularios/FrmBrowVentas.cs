using CineDAM.Modelos;
using System.Data;

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
            // Consulta completa para traer nombres en vez de números
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
            // Ocultar ID
            if (dgVentas.Columns.Contains("id_venta"))
                dgVentas.Columns["id_venta"].Visible = false;

            // Formatos
            if (dgVentas.Columns.Contains("fecha_venta"))
                dgVentas.Columns["fecha_venta"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dgVentas.Columns.Contains("Sesion"))
                dgVentas.Columns["Sesion"].DefaultCellStyle.Format = "HH:mm"; // Solo hora, la fecha ya está en la venta

            if (dgVentas.Columns.Contains("Precio"))
            {
                dgVentas.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgVentas.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Anchos
            dgVentas.Columns["Pelicula"].Width = 200;
            dgVentas.Columns["Butaca"].Width = 150;

            // Estilos
            dgVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgVentas.EnableHeadersVisualStyles = false;
            dgVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgVentas.Rows)
            {
                if (row.Cells["Precio"].Value != DBNull.Value)
                {
                    total += Convert.ToDecimal(row.Cells["Precio"].Value);
                }
            }
            lblTotal.Text = $"Total Recaudado: {total:C2}";
            lblTotal.ForeColor = Color.DarkGreen;
        }
    }
}