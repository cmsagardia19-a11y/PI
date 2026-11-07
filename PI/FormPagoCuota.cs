
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    public partial class FormPagoCuota : Form
    {
        private int codUsu;
        private int periodoMes;
        private int periodoAnio;
        private int nroSocio;

        public FormPagoCuota(int p_CodUsu, int p_NroSocio)
        {
            InitializeComponent();

            codUsu = p_CodUsu;
            nroSocio = p_NroSocio;
        }

        private void FormPagoCuota_Load(object sender, EventArgs e)
        {
            btnPagar.Enabled = false;

            cmbFormaPago.Items.Clear();
            cmbFormaPago.Items.Add("Efectivo");
            cmbFormaPago.Items.Add("Tarjeta");
            cmbFormaPago.SelectedIndex = -1;

            bool socioValido = CargarDatosSocio();
            bool cuotaValida = CargarCuotaMensual();

            btnPagar.Enabled = socioValido && cuotaValida;
        }

        // Consultar datos del socio.

        private bool CargarDatosSocio()
        {
            try
            {
                if (codUsu <= 0 || nroSocio <= 0)
                {
                    MessageBox.Show(
                        "Los datos recibidos del socio no son válidos.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                SELECT
                    s.NroSocio,
                    u.Nombre,
                    u.Apellido
                FROM socio s
                INNER JOIN usuario u
                    ON u.CodUsu = s.CodUsu
                WHERE s.CodUsu = @CodUsu;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@CodUsu", codUsu);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "No se encontró el socio.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return false;
                            }

                            int nroSocioBD =
                                Convert.ToInt32(reader["NroSocio"]);

                            // Verificar que el número recibido coincida
                            // con el que realmente tiene la base de datos.
                            if (nroSocioBD != nroSocio)
                            {
                                MessageBox.Show(
                                    "El número de socio recibido no coincide " +
                                    "con el registrado en la base de datos.",
                                    "Error de validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                return false;
                            }

                            // En el diseñador el control todavía se llama textBox1.
                            textBox1.Text = nroSocioBD.ToString();

                            txtNombreSocio.Text =
                                reader["Nombre"].ToString() + " " +
                                reader["Apellido"].ToString();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar el socio:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        // Consultar cuota mensual y verificar pagos anteriores.

        private bool CargarCuotaMensual()
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                SELECT
                    Importe,
                    MONTH(CURDATE()) AS PeriodoMes,
                    YEAR(CURDATE()) AS PeriodoAnio
                FROM cuota
                WHERE TipoCuota = 'Mensual'
                  AND Vigente = TRUE
                ORDER BY CodCuota DESC
                LIMIT 1;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "No existe una cuota mensual vigente.",
                                "Cuota no disponible",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return false;
                        }

                        decimal importe =
                            Convert.ToDecimal(reader["Importe"]);

                        periodoMes =
                            Convert.ToInt32(reader["PeriodoMes"]);

                        periodoAnio =
                            Convert.ToInt32(reader["PeriodoAnio"]);

                        txtCuota.Text = importe.ToString("N2");

                        txtPeriodo.Text =
                            periodoMes.ToString("00") + "/" + periodoAnio;
                    }

                    string sqlPago = @"
                SELECT COUNT(*)
                FROM pago_cuota
                WHERE CodUsu = @CodUsu
                  AND PeriodoMes = @PeriodoMes
                  AND PeriodoAnio = @PeriodoAnio;";

                    using (MySqlCommand cmd = new MySqlCommand(sqlPago, cn))
                    {
                        cmd.Parameters.AddWithValue("@CodUsu", codUsu);
                        cmd.Parameters.AddWithValue("@PeriodoMes", periodoMes);
                        cmd.Parameters.AddWithValue("@PeriodoAnio", periodoAnio);

                        int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cantidad > 0)
                        {
                            MessageBox.Show(
                                "El socio ya tiene registrado el pago " +
                                "correspondiente al período " +
                                txtPeriodo.Text + ".",
                                "Pago duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar la cuota mensual:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        // Registrar el pago.
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (codUsu <= 0 || nroSocio <= 0 ||
                !int.TryParse(textBox1.Text, out int nroIngresado) ||
                nroIngresado != nroSocio)
            {
                MessageBox.Show(
                    "El número de socio no es válido. No se puede registrar el pago.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione una forma de pago.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbFormaPago.Focus();
                return;
            }

            DialogResult confirmar = MessageBox.Show(
                "¿Confirma el registro del pago?\n\n" +
                "Número de socio: " + nroSocio + "\n" +
                "Socio: " + txtNombreSocio.Text + "\n" +
                "Importe: $" + txtCuota.Text + "\n" +
                "Período: " + txtPeriodo.Text + "\n" +
                "Forma de pago: " + cmbFormaPago.Text,
                "Confirmar pago",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            RegistrarPago();
        }


        private void RegistrarPago()
        {
            try
            {
                Conexion conexion = new Conexion();

                int codPago = 0;
                DateTime fechaPago = DateTime.MinValue;
                string nombre = "";
                string apellido = "";
                string formaPago = "";
                decimal importe = 0;
                int mes = 0;
                int anio = 0;

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (MySqlCommand cmd =
                           new MySqlCommand("RegistrarPagoCuota", cn))
                    {
                        cmd.CommandType =
                            System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_CodUsu", codUsu);
                        cmd.Parameters.AddWithValue(
                            "@p_FormaPago", cmbFormaPago.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "El procedimiento no devolvió los datos del pago.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            codPago = Convert.ToInt32(reader["CodPago"]);
                            fechaPago = Convert.ToDateTime(reader["FechaPago"]);
                            nombre = reader["Nombre"].ToString();
                            apellido = reader["Apellido"].ToString();
                            formaPago = reader["FormaPago"].ToString();
                            importe = Convert.ToDecimal(reader["ImportePagado"]);
                            mes = Convert.ToInt32(reader["PeriodoMes"]);
                            anio = Convert.ToInt32(reader["PeriodoAnio"]);
                        }
                    }
                }

                // El lector y la conexión ya están cerrados.
                // Abrimos el comprobante con los datos devueltos por el SP.

                using (Comprobante comprobante = new Comprobante(
                    codPago,
                    nroSocio,
                    fechaPago,
                    nombre,
                    apellido,
                    formaPago,
                    importe,
                    mes,
                    anio))
                {
                    comprobante.ShowDialog(this);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "No se pudo registrar el pago.\n\n" + ex.Message,
                    "Error al registrar",
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }

        private void lblFormaPago_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
