
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    public partial class FrmAgregarUsuario : Form
    {
        private int codCuotaMensual;
        private decimal importeCuotaMensual;

        public FrmAgregarUsuario()
        {
            InitializeComponent();

            txtCuota.ReadOnly = true;
            txtPeriodo.ReadOnly = true;
        }

        private void FrmAgregarUsuario_Load(object sender, EventArgs e)
        {
            // Mostrar el período actual.
            txtPeriodo.Text = DateTime.Today.ToString("MM/yyyy");

            // Consultar el importe de la cuota mensual.
            CargarCuotaMensual();
        }

        private void CargarCuotaMensual()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                        SELECT CodCuota, Importe
                        FROM cuota
                        WHERE TipoCuota = 'Mensual'
                          AND Vigente = 1
                        ORDER BY CodCuota DESC
                        LIMIT 1;";

                    using (MySqlCommand cmd =
                           new MySqlCommand(sql, cn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            codCuotaMensual =
                                Convert.ToInt32(reader["CodCuota"]);

                            importeCuotaMensual =
                                Convert.ToDecimal(reader["Importe"]);

                            txtCuota.Text =
                                importeCuotaMensual.ToString("N2");
                        }
                        else
                        {
                            txtCuota.Clear();

                            MessageBox.Show(
                                "No hay una cuota mensual vigente.",
                                "Cuota no disponible",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la cuota mensual:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void lblCuotaMensualVigente_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();

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

            if (nombre.Length > 20 || apellido.Length > 30)
            {
                MessageBox.Show(
                    "El nombre admite hasta 20 caracteres y " +
                    "el apellido hasta 30.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

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

            if (!chkAptoMedico.Checked)
            {
                MessageBox.Show(
                    "Debe confirmar que el socio presentó el apto médico.");
                return;
            }

            if (!chkPagoRecibido.Checked)
            {
                MessageBox.Show(
                    "Debe confirmar la recepción del pago inicial.");
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
                                int nroSocio =
                                    Convert.ToInt32(reader["NroSocio"]);

                                decimal importe =
                                    Convert.ToDecimal(reader["ImportePagado"]);

                                int mes =
                                    Convert.ToInt32(reader["PeriodoMes"]);

                                int anio =
                                    Convert.ToInt32(reader["PeriodoAnio"]);

                                MessageBox.Show(
                                    "Socio registrado correctamente.\n\n" +
                                    "Número de socio: " + nroSocio + "\n" +
                                    "Importe pagado: " + importe.ToString("C2") + "\n" +
                                    "Período: " + mes.ToString("00") + "/" + anio,
                                    "Alta de socio",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "No se pudo registrar el socio.\n\n" + ex.Message,
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void checkAptoMedico_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
