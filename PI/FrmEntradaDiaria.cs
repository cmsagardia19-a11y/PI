
using Datos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PI
{
    public partial class FrmEntradaDiaria : Form
    {
        public FrmEntradaDiaria()
        {
            InitializeComponent();

            // Configurar las formas de pago
            cmbFormaPago.Items.Add("Efectivo");
            cmbFormaPago.Items.Add("Tarjeta");
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;

            // Mostrar el importe
            lblImporte.Text = "Importe de entrada: $1.000";

            // Asociar eventos
            btnRegistrar.Click += btnRegistrar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre.",
                    "Validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Ingrese el apellido.",
                    "Validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            // Validar DNI
            string dni = txtDNI.Text.Trim();

            if (dni.Length < 7 || dni.Length > 8 ||
                !long.TryParse(dni, out _))
            {
                MessageBox.Show("Ingrese un DNI válido de 7 u 8 dígitos.",
                    "Validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            // Validar forma de pago
            if (cmbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de pago.",
                    "Validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbFormaPago.Focus();
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (MySqlCommand cmd =
                        new MySqlCommand("RegistrarEntradaDiaria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(
                            "@p_Nombre", txtNombre.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@p_Apellido", txtApellido.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@p_DNI", dni);

                        cmd.Parameters.AddWithValue(
                            "@p_FormaPago", cmbFormaPago.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int codEntrada =
                                    Convert.ToInt32(reader["CodEntrada"]);

                                DateTime fechaIngreso =
                                    Convert.ToDateTime(reader["FechaIngreso"]);

                                DateTime fechaVencimiento =
                                    Convert.ToDateTime(reader["FechaVencimiento"]);

                                decimal importe =
                                    Convert.ToDecimal(reader["Importe"]);

                                string nombre =
                                    reader["Nombre"].ToString();

                                string apellido =
                                    reader["Apellido"].ToString();

                                string formaPago =
                                    reader["FormaPago"].ToString();

                                MessageBox.Show(
                                    "¡Entrada diaria registrada correctamente!\n\n" +
                                    "Código de entrada: " + codEntrada + "\n" +
                                    "Nombre: " + nombre + " " + apellido + "\n" +
                                    "DNI: " + dni + "\n" +
                                    "Fecha de ingreso: " +
                                    fechaIngreso.ToString("dd/MM/yyyy HH:mm") + "\n" +
                                    "Vencimiento: " +
                                    fechaVencimiento.ToString("dd/MM/yyyy HH:mm") + "\n" +
                                    "Forma de pago: " + formaPago + "\n" +
                                    "Importe: " + importe.ToString("C2"),
                                    "Entrada registrada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al registrar la entrada en la base de datos:\n" +
                    ex.Message,
                    "Error MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
