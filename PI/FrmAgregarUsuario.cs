
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    public partial class FrmAgregarUsuario : Form
    {
        public int CodUsu { get; private set; }
        public int NroSocio { get; private set; }
        public FrmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();

            // Validar campos obligatorios.
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show(
                    "Complete nombre, apellido y DNI.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud.
            if (nombre.Length > 20 || apellido.Length > 30)
            {
                MessageBox.Show(
                    "El nombre admite hasta 20 caracteres y el apellido hasta 30.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validar DNI.
            if (dni.Length < 7 || dni.Length > 8 ||
                !System.Text.RegularExpressions.Regex.IsMatch(
                    dni, @"^\d+$"))
            {
                MessageBox.Show(
                    "Ingrese un DNI válido de 7 u 8 dígitos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDni.Focus();
                return;
            }

            // Validar apto médico.
            if (!chkAptoMedico.Checked)
            {
                MessageBox.Show(
                    "Debe confirmar que el socio presentó el apto médico.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand("AltaSocio", cn))
                    {
                        cmd.CommandType =
                            System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_Nombre", nombre);
                        cmd.Parameters.AddWithValue("@p_Apellido", apellido);
                        cmd.Parameters.AddWithValue("@p_DNI", dni);
                        cmd.Parameters.AddWithValue("@p_AptoMedico", true);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                CodUsu = Convert.ToInt32(reader["CodUsu"]);
                                NroSocio = Convert.ToInt32(reader["NroSocio"]);

                                MessageBox.Show(
                                    "Socio registrado correctamente.\n\n" +
                                    "Número de socio: " + NroSocio,
                                    "Alta de socio",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "El procedimiento no devolvió los datos del socio.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1644)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Validación de datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo registrar el socio.\n\n" + ex.Message,
                        "Error al guardar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error inesperado:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
