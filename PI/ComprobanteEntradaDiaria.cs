
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PI
{
    public partial class ComprobanteEntradaDiaria : Form
    {
        private int codEntrada;
        private string nombre;
        private string apellido;
        private string dni;
        private DateTime fechaIngreso;
        private DateTime fechaVencimiento;
        private string formaPago;
        private decimal importe;

        private PrintDocument documento = new PrintDocument();

        public ComprobanteEntradaDiaria(
            int p_CodEntrada,
            string p_Nombre,
            string p_Apellido,
            string p_DNI,
            DateTime p_FechaIngreso,
            DateTime p_FechaVencimiento,
            string p_FormaPago,
            decimal p_Importe)
        {
            InitializeComponent();

            codEntrada = p_CodEntrada;
            nombre = p_Nombre;
            apellido = p_Apellido;
            dni = p_DNI;
            fechaIngreso = p_FechaIngreso;
            fechaVencimiento = p_FechaVencimiento;
            formaPago = p_FormaPago;
            importe = p_Importe;

            ConfigurarFormulario();

            documento.DefaultPageSettings.Landscape = false;
            documento.PrintPage += Documento_PrintPage;

            // Asociar eventos
            btnImprimir.Click += btnImprimir_Click;
            btnCerrar.Click += btnCerrar_Click;
        }

        private void ConfigurarFormulario()
        {
            //lblImporte.Text = "Total pagado: " + importe.ToString("C2");

            lblVigencia.Text =
                "Válido hasta: " +
                fechaVencimiento.ToString("dd/MM/yyyy HH:mm");

            AgregarDato("Código de entrada: " + codEntrada, 100);
            AgregarDato("Nombre: " + nombre + " " + apellido, 130);
            AgregarDato("DNI: " + dni, 160);

            AgregarDato(
                "Fecha de ingreso: " +
                fechaIngreso.ToString("dd/MM/yyyy HH:mm"), 190);

            AgregarDato(
                "Forma de pago: " + formaPago, 220);
        }

        private void AgregarDato(string texto, int posicionY)
        {
            Label etiqueta = new Label();

            etiqueta.Text = texto;
            etiqueta.Font = new Font("Arial", 10);
            etiqueta.ForeColor = SystemColors.ControlLightLight;
            etiqueta.Location = new Point(220, posicionY);
            etiqueta.Size = new Size(400, 25);

            Controls.Add(etiqueta);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialogo = new PrintDialog())
            {
                dialogo.Document = documento;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    documento.Print();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Documento_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float x = 70;
            float y = 80;

            using (Font titulo = new Font("Arial", 19, FontStyle.Bold))
            using (Font subtitulo = new Font("Arial", 12, FontStyle.Bold))
            using (Font normal = new Font("Arial", 11))
            using (Font negrita = new Font("Arial", 14, FontStyle.Bold))
            {
                g.DrawString("COMPROBANTE DE PAGO",
                    titulo, Brushes.Black, x, y);

                y += 45;

                g.DrawString("ENTRADA DIARIA - NO SOCIO",
                    subtitulo, Brushes.Black, x, y);

                y += 45;
                g.DrawLine(Pens.Black, x, y, 520, y);
                y += 30;

                g.DrawString("Código de entrada: " + codEntrada,
                    normal, Brushes.Black, x, y);
                y += 30;

                g.DrawString("Nombre: " + nombre + " " + apellido,
                    normal, Brushes.Black, x, y);
                y += 30;

                g.DrawString("DNI: " + dni,
                    normal, Brushes.Black, x, y);
                y += 30;

                g.DrawString("Fecha de ingreso: " +
                    fechaIngreso.ToString("dd/MM/yyyy HH:mm"),
                    normal, Brushes.Black, x, y);
                y += 30;

                g.DrawString("Vencimiento: " +
                    fechaVencimiento.ToString("dd/MM/yyyy HH:mm"),
                    normal, Brushes.Black, x, y);
                y += 30;

                g.DrawString("Forma de pago: " + formaPago,
                    normal, Brushes.Black, x, y);

                y += 45;
                g.DrawLine(Pens.Black, x, y, 520, y);
                y += 30;

                g.DrawString("TOTAL PAGADO: " + importe.ToString("C2"),
                    negrita, Brushes.Black, x, y);

                y += 50;

                g.DrawString("Válido durante 24 horas desde el ingreso.",
                    normal, Brushes.Black, x, y);

                y += 35;

                g.DrawString("Gracias por su visita.",
                    normal, Brushes.Black, x, y);
            }

            e.HasMorePages = false;
        }
    }
}
