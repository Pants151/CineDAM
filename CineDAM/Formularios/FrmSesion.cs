using CineDAM.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineDAM.Formularios
{
    public partial class FrmSesion : Form
    {

        private BindingSource _bs;
        private Tabla _tabla;
        public bool edicion;

        public FrmSesion(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;

        }

        public FrmSesion()
        {
            InitializeComponent();
            // No inicializamos _bs ni _tabla aquí porque haremos el INSERT manual
        }

        private void FrmSesion_Load(object sender, EventArgs e)
        {
            CargarCombos(); // ¡Importante cargar esto primero!

            // Solo enlazamos datos si NO estamos creando uno nuevo (es decir, si nos pasaron un binding source)
            if (_bs != null)
            {
                cmbPelicula.DataBindings.Add("SelectedValue", _bs, "id_pelicula");
                cmbSala.DataBindings.Add("SelectedValue", _bs, "id_sala");
                // Use overload that provides a fallback for DBNull (nullValue).
                dtpHora.DataBindings.Add("Value", _bs, "hora_inicio", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);
                txtPrecio.DataBindings.Add("Text", _bs, "precio"); 
            }
            
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (cmbPelicula.SelectedIndex == -1 || cmbSala.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar una película y una sala.");
                return;
            }

            int idPeli = (int)cmbPelicula.SelectedValue;
            int idSala = (int)cmbSala.SelectedValue;
            DateTime hora = dtpHora.Value;
            string precioStr = txtPrecio.Text.Replace(",", ".");

            string sql = "";
            int idSesion = -1; // guardamos aquí el id cuando estemos en modo edición

            // ¿CÓMO SABEMOS SI ES EDICIÓN?
            // Si _bs NO es null, significa que venimos del botón "Editar" (pasamos el BindingSource en el constructor).
            // Si _bs ES null, venimos del botón "Nuevo" (constructor vacío).

            if (_bs == null)
            {
                // MODO INSERTAR (Tu código actual)
                sql = $"INSERT INTO Sesion (id_pelicula, id_sala, hora_inicio, precio) " +
                      $"VALUES ({idPeli}, {idSala}, '{hora:yyyy-MM-dd HH:mm:ss}', {precioStr})";
            }
            else
            {
                // MODO ACTUALIZAR (Nuevo)
                // Necesitamos el ID de la sesión que estamos editando. 
                // Lo sacamos del BindingSource que nos pasaron.
                DataRowView filaActual = (DataRowView)_bs.Current;
                idSesion = (int)filaActual["id_sesion"];

                sql = $"UPDATE Sesion SET " +
                      $"id_pelicula = {idPeli}, " +
                      $"id_sala = {idSala}, " +
                      $"hora_inicio = '{hora:yyyy-MM-dd HH:mm:ss}', " +
                      $"precio = {precioStr} " +
                      $"WHERE id_sesion = {idSesion}";
            }

            // 4. Ejecutarla usando nuestra conexión global
            try
            {
                // Aseguramos que los cambios del binding se finalicen
                _bs?.EndEdit();

                // Creamos un comando MySQL
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Program.appCine.LaConexion))
                {
                    cmd.ExecuteNonQuery(); // Ejecuta el INSERT/UPDATE
                }

                // Si hemos editado (tenemos BindingSource), refrescamos la tabla y reposicionamos
                if (_bs != null && idSesion > 0)
                {
                    _tabla?.Refrescar();

                    if (_tabla?.LaTabla != null)
                    {
                        int idx = -1;
                        for (int i = 0; i < _tabla.LaTabla.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(_tabla.LaTabla.Rows[i]["id_sesion"]) == idSesion)
                            {
                                idx = i;
                                break;
                            }
                        }
                        if (idx >= 0) _bs.Position = idx;
                        else _bs.ResetBindings(false); // fallback si no encuentra la fila
                    }
                }

                // Si llegamos aquí, todo ha ido bien
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la sesión: " + ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private bool ValidarDatos()
        {
            /*
            if (string.IsNullOrWhiteSpace(txt_nifcif.Text))
            {
                MessageBox.Show("El campo NIF/CIF no puede estar vacío.");
                txt_nifcif.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_razonsocial.Text))
            {
                MessageBox.Show("El campo \"Nombre Comercial\" no puede estar vacío.");
                txt_razonsocial.Focus();
                return false;
            }

            //Validacion 2: Si el email no está vacio, que sea un email valido
            string email = txt_email.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) &&
                !System.Text.RegularExpressions.Regex.IsMatch(email,
                    @"^[a-zA-Z0-9._%-+]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El email introducido no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_email.Focus();
                return false;
            }

            //Validacion 3: NIF/CIF duplicado
            if (NifDuplicado(txt_nifcif.Text.Trim()))
            {
                return true;
            }
            else
            {
                MessageBox.Show("El NIF/CIF introducido ya existe en otro emisor. Por favor, introduce uno diferente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nifcif.Focus();
                return false;
            }*/

            return true;
        }

        private void CargarCombos()
        {
            // 1. Cargar Películas
            Tabla tPeliculas = new Tabla(Program.appCine.LaConexion);
            if (tPeliculas.InicializarDatos("SELECT id_pelicula, titulo FROM Pelicula"))
            {
                cmbPelicula.DataSource = tPeliculas.LaTabla;
                cmbPelicula.DisplayMember = "titulo";      // Lo que se ve
                cmbPelicula.ValueMember = "id_pelicula";   // Lo que se guarda (ID)
            }

            // 2. Cargar Salas
            Tabla tSalas = new Tabla(Program.appCine.LaConexion);
            if (tSalas.InicializarDatos("SELECT id_sala, nombre FROM Sala"))
            {
                cmbSala.DataSource = tSalas.LaTabla;
                cmbSala.DisplayMember = "nombre";
                cmbSala.ValueMember = "id_sala";
            }
        }
    }
}
