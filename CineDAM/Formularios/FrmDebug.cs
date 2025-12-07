namespace CineDAM.Formularios
{
    public partial class FrmDebug : Form
    {
        // Timer para el refresco automático
        private System.Windows.Forms.Timer _timerLog;

        public FrmDebug()
        {
            InitializeComponent();
            ConfigurarTimer();
            ConfigurarEventos();
        }

        private void ConfigurarTimer()
        {
            _timerLog = new System.Windows.Forms.Timer();
            _timerLog.Interval = 5000; // 5000ms = 5 segundos
            _timerLog.Tick += TimerLog_Tick;
        }

        // Asignamos los eventos manualmente en el constructor para evitar
        // problemas si no se han vinculado desde el diseñador.
        private void ConfigurarEventos()
        {
            this.Load += FrmDebug_Load;
            btnRefrescar.Click += btnRefrescar_Click;
            chkRefrescar.CheckedChanged += chkRefrescar_CheckedChanged;
        }

        private void FrmDebug_Load(object sender, EventArgs e)
        {
            CargarDatosLog();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosLog();
        }

        private void chkRefrescar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefrescar.Checked)
            {
                _timerLog.Start();
            }
            else
            {
                _timerLog.Stop();
            }
        }

        private void TimerLog_Tick(object sender, EventArgs e)
        {
            CargarDatosLog();
        }

        private void CargarDatosLog()
        {
            if (Program.appCine != null && Program.appCine.debug != null)
            {
                // Guardamos la posición del scroll actual
                int selectionStart = txtDebug.SelectionStart;
                int selectionLength = txtDebug.SelectionLength;
                bool estabaAlFinal = selectionStart == txtDebug.Text.Length;

                // Leemos el contenido
                string contenido = Program.appCine.debug.LeerLog();

                // Actualizamos solo si ha cambiado para evitar parpadeos innecesarios
                if (txtDebug.Text != contenido)
                {
                    txtDebug.Text = contenido;

                    // Si el usuario no estaba seleccionando texto, hacemos autoscroll al final
                    // para ver los mensajes nuevos.
                    if (estabaAlFinal || string.IsNullOrEmpty(contenido))
                    {
                        txtDebug.SelectionStart = txtDebug.Text.Length;
                        txtDebug.ScrollToCaret();
                    }
                    else
                    {
                        // Restauramos la selección si el usuario estaba leyendo algo antiguo
                        txtDebug.SelectionStart = selectionStart;
                        txtDebug.SelectionLength = selectionLength;
                    }
                }
            }
            else
            {
                txtDebug.Text = "El sistema de depuración no está inicializado.";
            }
        }
    }
}