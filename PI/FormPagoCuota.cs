
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
        private readonly IPagoCuotaRepositorio _pagoRepositorio;

        public FormPagoCuota(int p_CodUsu, int p_NroSocio)
            : this(
                p_CodUsu,
                p_NroSocio,
                new PagoCuotaRepositorio(new Conexion()))
        {
        }

        public FormPagoCuota(
            int p_CodUsu,
            int p_NroSocio,
            IPagoCuotaRepositorio pagoRepositorio)
        {
            InitializeComponent();

            codUsu = p_CodUsu;
            nroSocio = p_NroSocio;

            _pagoRepositorio = pagoRepositorio ??
                throw new ArgumentNullException(nameof(pagoRepositorio));
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

                var socio = _pagoRepositorio.ObtenerDatosSocio(codUsu);

                if (!socio.Encontrado)
                {
                    MessageBox.Show(
                        "No se encontró el socio.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (socio.NroSocio != nroSocio)
                {
                    MessageBox.Show(
                        "El número de socio recibido no coincide " +
                        "con el registrado en la base de datos.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }

                textBox1.Text = socio.NroSocio.ToString();

                txtNombreSocio.Text =
                    socio.Nombre + " " + socio.Apellido;

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
                var cuota =
                    _pagoRepositorio.ObtenerEstadoCuotaMensual(codUsu);

                if (!cuota.ExisteCuota)
                {
                    MessageBox.Show(
                        "No existe una cuota mensual vigente.",
                        "Cuota no disponible",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                periodoMes = cuota.PeriodoMes;
                periodoAnio = cuota.PeriodoAnio;

                txtCuota.Text = cuota.Importe.ToString("N2");

                txtPeriodo.Text =
                    periodoMes.ToString("00") + "/" + periodoAnio;

                if (cuota.PagoRegistrado)
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
                var pago = _pagoRepositorio.RegistrarPago(
                    codUsu,
                    cmbFormaPago.Text);

                // Abrir el comprobante con los datos devueltos por el SP.
                using (Comprobante comprobante = new Comprobante(
                    pago.CodPago,
                    nroSocio,
                    pago.FechaPago,
                    pago.Nombre,
                    pago.Apellido,
                    pago.FormaPago,
                    pago.Importe,
                    pago.PeriodoMes,
                    pago.PeriodoAnio))
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
