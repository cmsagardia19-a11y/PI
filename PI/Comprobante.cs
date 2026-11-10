
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using PI.Interfaces;

namespace PI
{
    public partial class Comprobante : Form, IImprimible
    {
        private const string nombreClub = "IFTS N° 29 - DSOO G4";
        private int codPago;
        private int nroSocio;
        private DateTime fechaPago;
        private string nombre;
        private string apellido;
        private string formaPago;
        private decimal importe;
        private int periodoMes;
        private int periodoAnio;
        private string dni;
        private string estadoSocio;
        private DateTime fechaInscripcion;
        private string estadoPago;
        private PrintDocument documento = new PrintDocument();
        private PrintDocument documentoPago = new PrintDocument();

        public Comprobante(
            int p_CodPago,
            int p_NroSocio,
            DateTime p_FechaPago,
            string p_Nombre,
            string p_Apellido,
            string p_FormaPago,
            decimal p_Importe,
            int p_PeriodoMes,
            int p_PeriodoAnio,
            string p_DNI,
            string p_EstadoSocio,
            string p_EstadoPago,
            DateTime p_FechaInscripcion)
        {
            InitializeComponent();

            codPago = p_CodPago;
            nroSocio = p_NroSocio;
            fechaPago = p_FechaPago;
            nombre = p_Nombre;
            apellido = p_Apellido;
            formaPago = p_FormaPago;
            importe = p_Importe;
            periodoMes = p_PeriodoMes;
            periodoAnio = p_PeriodoAnio;
            dni = p_DNI;
            estadoSocio = p_EstadoSocio;
            estadoPago = p_EstadoPago;
            fechaInscripcion = p_FechaInscripcion;

            CargarComprobante();

            // Configuración de impresión del carnet
            documento.DefaultPageSettings.Landscape = true;
            // Configuración de impresión del comprobante de pago
            documentoPago.DefaultPageSettings.Landscape = false;
            documentoPago.PrintPage += DocumentoPago_PrintPage;
            documento.PrintPage += Documento_PrintPage;

        }

        public void Imprimir(PrintDocument documento)
        {
            if (documento == null)
                throw new ArgumentNullException(nameof(documento));

            using (PrintDialog dialogo = new PrintDialog())
            {
                dialogo.Document = documento;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    documento.Print();
                }
            }
        }

        private void CargarComprobante()
        {
            lblCodPago.Text = codPago.ToString();
            lblNroSocio.Text = nroSocio.ToString();
            lblNombre.Text = nombre + " " + apellido;
            lblFecha.Text = fechaPago.ToString("dd/MM/yyyy HH:mm");
            lblPeriodo.Text = periodoMes.ToString("00") + "/" + periodoAnio;
            lblFormaPago.Text = formaPago;
            lblImporte.Text = importe.ToString("C2");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir(documento);
        }

        private void DocumentoPago_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            float x = 70;
            float y = 70;

            using (Font titulo = new Font("Arial", 20, FontStyle.Bold))
            using (Font subtitulo = new Font("Arial", 13, FontStyle.Bold))
            using (Font normal = new Font("Arial", 11))
            using (Font negrita = new Font("Arial", 11, FontStyle.Bold))
            using (Font importeFuente = new Font("Arial", 17, FontStyle.Bold))
            {
                g.DrawString(
                    "COMPROBANTE DE PAGO",
                    titulo,
                    Brushes.Black,
                    x,
                    y);

                y += 50;

                g.DrawString(
                    "CUOTA MENSUAL",
                    subtitulo,
                    Brushes.Black,
                    x,
                    y);

                y += 50;

                g.DrawLine(Pens.Black, x, y, 520, y);

                y += 30;

                g.DrawString("Comprobante N°: " + codPago,
                    normal, Brushes.Black, x, y);

                y += 30;

                g.DrawString("Número de socio: " + nroSocio,
                    normal, Brushes.Black, x, y);

                y += 30;

                g.DrawString("Nombre: " + nombre + " " + apellido,
                    normal, Brushes.Black, x, y);

                y += 30;

                g.DrawString("Fecha de pago: " + fechaPago.ToString("dd/MM/yyyy HH:mm"),
                    normal, Brushes.Black, x, y);

                y += 30;

                g.DrawString("Período abonado: " +
                    periodoMes.ToString("00") + "/" + periodoAnio,
                    normal, Brushes.Black, x, y);

                y += 30;

                g.DrawString("Forma de pago: " + formaPago,
                    normal, Brushes.Black, x, y);

                y += 40;

                g.DrawLine(Pens.Black, x, y, 520, y);

                y += 30;

                g.DrawString("TOTAL PAGADO:",
                    negrita, Brushes.Black, x, y);

                g.DrawString(importe.ToString("C2"),
                    importeFuente, Brushes.Black, x + 180, y - 5);

                y += 60;

                g.DrawString("Gracias por su pago.",
                    normal, Brushes.Black, x, y);
            }

            e.HasMorePages = false;
        }


        private void Documento_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle area = e.MarginBounds;

            float ancho = 520;
            float alto = 310;

            float x = area.Left + (area.Width - ancho) / 2;
            float y = area.Top + (area.Height - alto) / 2;

            RectangleF carnet = new RectangleF(x, y, ancho, alto);

            using (Font titulo = new Font("Arial", 16, FontStyle.Bold))
            using (Font clubFuente = new Font("Arial", 9, FontStyle.Bold))
            using (Font nombreFuente = new Font("Arial", 17, FontStyle.Bold))
            using (Font normal = new Font("Arial", 10))
            using (Font negrita = new Font("Arial", 10, FontStyle.Bold))
            using (Pen borde = new Pen(Color.FromArgb(0, 120, 180), 3))
            using (Brush fondo = new SolidBrush(Color.White))
            using (Brush azul = new SolidBrush(Color.FromArgb(0, 120, 180)))
            using (Brush verde = new SolidBrush(Color.Green))
            {
                // Fondo y borde del carnet.
                g.FillRectangle(fondo, carnet);
                g.DrawRectangle(borde, x, y, ancho, alto);

                // Encabezado único.
                g.FillRectangle(azul, x, y, ancho, 55);

                g.DrawString(
                    nombreClub,
                    clubFuente,
                    Brushes.White,
                    x + 20,
                    y + 5);

                g.DrawString(
                    "CARNET DE SOCIO",
                    titulo,
                    Brushes.White,
                    x + 155,
                    y + 22);

                // Fotografía.
                string rutaFoto = System.IO.Path.Combine(
                    Application.StartupPath,
                    "Imagenes",
                    "perfil.jpg");

                Rectangle foto = new Rectangle(
                    (int)x + 20,
                    (int)y + 75,
                    125,
                    165);

                if (System.IO.File.Exists(rutaFoto))
                {
                    using (Image imagen = Image.FromFile(rutaFoto))
                    {
                        g.DrawImage(imagen, foto);
                    }
                }
                else
                {
                    g.DrawRectangle(Pens.Gray, foto);

                    g.DrawString(
                        "Sin foto",
                        normal,
                        Brushes.Gray,
                        foto.X + 30,
                        foto.Y + 70);
                }

                // Datos del socio.
                float datosX = x + 165;
                float datosY = y + 75;

                g.DrawString(
                    nombre + " " + apellido,
                    nombreFuente,
                    Brushes.Black,
                    datosX,
                    datosY);

                datosY += 40;

                g.DrawString(
                    "Número de socio: " + nroSocio,
                    normal,
                    Brushes.Black,
                    datosX,
                    datosY);

                datosY += 27;

                g.DrawString(
                    "DNI: " + dni,
                    normal,
                    Brushes.Black,
                    datosX,
                    datosY);

                datosY += 27;

                g.DrawString(
                    "Estado del socio: " + estadoSocio.ToUpper(),
                    negrita,
                    Brushes.Black,
                    datosX,
                    datosY);

                datosY += 27;

                g.DrawString(
                    "Fecha de inscripción: " +
                    fechaInscripcion.ToString("dd/MM/yyyy"),
                    normal,
                    Brushes.Black,
                    datosX,
                    datosY);

                datosY += 27;

                // Pie del carnet.
                g.DrawLine(
                    Pens.LightGray,
                    x + 160,
                    y + alto - 35,
                    x + ancho - 20,
                    y + alto - 35);
            }

            e.HasMorePages = false;
        }

        private void btnImprimirPagoAux_Click(object sender, EventArgs e)
        {
            Imprimir(documentoPago);
        }

    }
}
