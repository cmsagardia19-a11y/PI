
using Datos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Net;
using System.Windows.Forms;

namespace PI
{
    //Herencia
    //FrmEntradaDiaria hereda de Form.
    public partial class FrmEntradaDiaria : Form
    {
        //Encapsulamiento:
        //_conexion es privado y readonly.
        //Polimorfismo:
        //El formulario recibe una referencia IConexion, que puede
        //representar distintas implementaciones.
        private readonly IConexion _conexion;

        public FrmEntradaDiaria() : this(new Conexion())
        {
        }

        public FrmEntradaDiaria(IConexion conexion)
        {
            InitializeComponent();

            _conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));

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
                int codEntrada = 0;
                DateTime fechaIngreso = DateTime.MinValue;
                DateTime fechaVencimiento = DateTime.MinValue;
                decimal importe = 0;

                string nombre = "";
                string apellido = "";
                string formaPago = cmbFormaPago.Text;

                using (MySqlConnection cn = _conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (MySqlCommand cmd =
                        new MySqlCommand("RegistrarEntradaDiaria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(
                            "@p_Nombre", txtNombre.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@p_Apellido", txtApellido.Text.Trim());

                        // IMPORTANTE: enviar el DNI ingresado
                        cmd.Parameters.AddWithValue(
                            "@p_DNI", dni);

                        cmd.Parameters.AddWithValue(
                            "@p_FormaPago", formaPago);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                codEntrada = Convert.ToInt32(reader["CodEntrada"]);

                                fechaIngreso =
                                    Convert.ToDateTime(reader["FechaIngreso"]);

                                fechaVencimiento =
                                    Convert.ToDateTime(reader["FechaVencimiento"]);

                                importe =
                                    Convert.ToDecimal(reader["Importe"]);

                                nombre = reader["Nombre"].ToString();
                                apellido = reader["Apellido"].ToString();
                                formaPago = reader["FormaPago"].ToString();
                            }
                        }
                    }
                }

                // Abrir comprobante una vez registrado el ingreso
                if (codEntrada > 0)
                {
                    using (ComprobanteEntradaDiaria comprobante =
                        new ComprobanteEntradaDiaria(
                            codEntrada,
                            nombre,
                            apellido,
                            dni,
                            fechaIngreso,
                            fechaVencimiento,
                            formaPago,
                            importe))
                    {
                        comprobante.ShowDialog();
                    }

                    // Limpiar los campos después de cerrar el comprobante
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDNI.Clear();
                    cmbFormaPago.SelectedIndex = -1;

                    txtNombre.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo obtener el comprobante de la entrada registrada.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al registrar la entrada en la base de datos:\n" + ex.Message,
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
