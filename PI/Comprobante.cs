
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PI
{
    public partial class Comprobante : Form
    {
        private int codPago;
        private int nroSocio;
        private DateTime fechaPago;
        private string nombre;
        private string apellido;
        private string formaPago;
        private decimal importe;
        private int periodoMes;
        private int periodoAnio;

        private PrintDocument documento = new PrintDocument();

        public Comprobante(
            int p_CodPago,
            int p_NroSocio,
            DateTime p_FechaPago,
            string p_Nombre,
            string p_Apellido,
            string p_FormaPago,
            decimal p_Importe,
            int p_PeriodoMes,
            int p_PeriodoAnio)
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

            CargarComprobante();

            documento.PrintPage += Documento_PrintPage;
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
            using (PrintDialog dialogo = new PrintDialog())
            {
                dialogo.Document = documento;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    documento.Print();
                }
            }
        }

        private void Documento_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Font titulo = new Font("Arial", 18, FontStyle.Bold))
            using (Font normal = new Font("Arial", 11))
            using (Font negrita = new Font("Arial", 11, FontStyle.Bold))
            using (Font importeFuente = new Font("Arial", 16, FontStyle.Bold))
            {
                float x = 70;
                float y = 80;

                g.DrawString("COMPROBANTE DE PAGO",
                    titulo, Brushes.Black, x, y);

                y += 45;

                g.DrawString("CUOTA MENSUAL",
                    normal, Brushes.Black, x, y);

                y += 45;
                g.DrawString("Comprobante N°: " + codPago, normal, Brushes.Black, x, y);

                y += 30;
                g.DrawString("Número de socio: " + nroSocio, normal, Brushes.Black, x, y);

                y += 30;
                g.DrawString("Nombre: " + nombre + " " + apellido, normal, Brushes.Black, x, y);

                y += 30;
                g.DrawString("Fecha de pago: " + fechaPago.ToString("dd/MM/yyyy HH:mm"),
                    normal, Brushes.Black, x, y);

                y += 30;
                g.DrawString("Período: " + periodoMes.ToString("00") + "/" + periodoAnio,
                    normal, Brushes.Black, x, y);

                y += 30;
                g.DrawString("Forma de pago: " + formaPago, normal, Brushes.Black, x, y);

                y += 50;
                g.DrawLine(Pens.Black, x, y, 480, y);

                y += 25;
                g.DrawString("TOTAL PAGADO:", negrita, Brushes.Black, x, y);
                g.DrawString(importe.ToString("C2"), importeFuente,
                    Brushes.Black, 300, y - 5);

                y += 60;
                g.DrawString("Gracias por su pago.", normal, Brushes.Black, x, y);
            }
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblCodPago = new Label();
            lblNroSocio = new Label();
            lblNombre = new Label();
            lblFecha = new Label();
            lblPeriodo = new Label();
            lblFormaPago = new Label();
            lblImporte = new Label();
            btnImprimir = new Button();
            lblCodigo = new Label();
            lblNumsocio = new Label();
            lblNom = new Label();
            lblFech = new Label();
            lblPeriod = new Label();
            this.lblFormDePago = new Label();
            this.lblImp = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(12, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(256, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "COMPROBANTE DE PAGO";
            // 
            // lblCodPago
            // 
            lblCodPago.AutoSize = true;
            lblCodPago.ForeColor = SystemColors.ControlLightLight;
            lblCodPago.Location = new Point(26, 88);
            lblCodPago.Name = "lblCodPago";
            lblCodPago.Size = new Size(118, 20);
            lblCodPago.TabIndex = 1;
            lblCodPago.Text = "Código de pago";
            // 
            // lblNroSocio
            // 
            lblNroSocio.AutoSize = true;
            lblNroSocio.ForeColor = SystemColors.ControlLightLight;
            lblNroSocio.Location = new Point(287, 88);
            lblNroSocio.Name = "lblNroSocio";
            lblNroSocio.Size = new Size(75, 20);
            lblNroSocio.TabIndex = 2;
            lblNroSocio.Text = "Nro Socio";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = SystemColors.ControlLightLight;
            lblNombre.Location = new Point(26, 142);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = SystemColors.ControlLightLight;
            lblFecha.Location = new Point(287, 142);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(47, 20);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha";
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.ForeColor = SystemColors.ControlLightLight;
            lblPeriodo.Location = new Point(26, 198);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(60, 20);
            lblPeriodo.TabIndex = 5;
            lblPeriodo.Text = "Periodo";
            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.ForeColor = SystemColors.ControlLightLight;
            lblFormaPago.Location = new Point(287, 198);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(109, 20);
            lblFormaPago.TabIndex = 6;
            lblFormaPago.Text = "Forma de Pago";
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.ForeColor = SystemColors.ControlLightLight;
            lblImporte.Location = new Point(26, 253);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(62, 20);
            lblImporte.TabIndex = 7;
            lblImporte.Text = "Importe";
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.Location = new Point(235, 327);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(104, 39);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.ForeColor = SystemColors.ControlLightLight;
            lblCodigo.Location = new Point(26, 68);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(58, 20);
            lblCodigo.TabIndex = 9;
            lblCodigo.Text = "Código";
            // 
            // lblNumsocio
            // 
            lblNumsocio.AutoSize = true;
            lblNumsocio.ForeColor = SystemColors.ControlLightLight;
            lblNumsocio.Location = new Point(287, 68);
            lblNumsocio.Name = "lblNumsocio";
            lblNumsocio.Size = new Size(123, 20);
            lblNumsocio.TabIndex = 10;
            lblNumsocio.Text = "Número de socio";
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.ForeColor = SystemColors.ControlLightLight;
            lblNom.Location = new Point(26, 122);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(64, 20);
            lblNom.TabIndex = 11;
            lblNom.Text = "Nombre";
            lblNom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFech
            // 
            lblFech.AutoSize = true;
            lblFech.ForeColor = SystemColors.ControlLightLight;
            lblFech.Location = new Point(287, 122);
            lblFech.Name = "lblFech";
            lblFech.Size = new Size(47, 20);
            lblFech.TabIndex = 12;
            lblFech.Text = "Fecha";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.ForeColor = SystemColors.ControlLightLight;
            lblPeriod.Location = new Point(26, 178);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(60, 20);
            lblPeriod.TabIndex = 13;
            lblPeriod.Text = "Periodo";
            // 
            // lblFormDePago
            // 
            this.lblFormDePago.AutoSize = true;
            this.lblFormDePago.ForeColor = SystemColors.ControlLightLight;
            this.lblFormDePago.Location = new Point(288, 176);
            this.lblFormDePago.Name = "lblFormDePago";
            this.lblFormDePago.Size = new Size(109, 20);
            this.lblFormDePago.TabIndex = 14;
            this.lblFormDePago.Text = "Forma de Pago";
            // 
            // lblImp
            // 
            this.lblImp.AutoSize = true;
            this.lblImp.ForeColor = SystemColors.ControlLightLight;
            this.lblImp.Location = new Point(28, 232);
            this.lblImp.Name = "lblImp";
            this.lblImp.Size = new Size(62, 20);
            this.lblImp.TabIndex = 15;
            this.lblImp.Text = "Importe";
            // 
            // Comprobante
            // 
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(605, 392);
            Controls.Add(this.lblImp);
            Controls.Add(this.lblFormDePago);
            Controls.Add(lblPeriod);
            Controls.Add(lblFech);
            Controls.Add(lblNom);
            Controls.Add(lblNumsocio);
            Controls.Add(lblCodigo);
            Controls.Add(btnImprimir);
            Controls.Add(lblImporte);
            Controls.Add(lblFormaPago);
            Controls.Add(lblPeriodo);
            Controls.Add(lblFecha);
            Controls.Add(lblNombre);
            Controls.Add(lblNroSocio);
            Controls.Add(lblCodPago);
            Controls.Add(lblTitulo);
            Name = "Comprobante";
            Text = "Comprobante ";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
