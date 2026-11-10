
namespace PI
{
    partial class Comprobante
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            lblFormDePago = new Label();
            lblImp = new Label();
            btnImprimirPagoAux = new Button();

            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F,
                FontStyle.Bold | FontStyle.Underline);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(12, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(256, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "COMPROBANTE DE PAGO";

            // lblCodPago
            lblCodPago.AutoSize = true;
            lblCodPago.ForeColor = SystemColors.ControlLightLight;
            lblCodPago.Location = new Point(26, 88);
            lblCodPago.Name = "lblCodPago";
            lblCodPago.Size = new Size(118, 20);
            lblCodPago.TabIndex = 1;
            lblCodPago.Text = "Código de pago";

            // lblNroSocio
            lblNroSocio.AutoSize = true;
            lblNroSocio.ForeColor = SystemColors.ControlLightLight;
            lblNroSocio.Location = new Point(287, 88);
            lblNroSocio.Name = "lblNroSocio";
            lblNroSocio.Size = new Size(75, 20);
            lblNroSocio.TabIndex = 2;
            lblNroSocio.Text = "Nro Socio";

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = SystemColors.ControlLightLight;
            lblNombre.Location = new Point(26, 142);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";

            // lblFecha
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = SystemColors.ControlLightLight;
            lblFecha.Location = new Point(287, 142);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(47, 20);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha";

            // lblPeriodo
            lblPeriodo.AutoSize = true;
            lblPeriodo.ForeColor = SystemColors.ControlLightLight;
            lblPeriodo.Location = new Point(26, 198);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(60, 20);
            lblPeriodo.TabIndex = 5;
            lblPeriodo.Text = "Periodo";

            // lblFormaPago
            lblFormaPago.AutoSize = true;
            lblFormaPago.ForeColor = SystemColors.ControlLightLight;
            lblFormaPago.Location = new Point(287, 198);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(109, 20);
            lblFormaPago.TabIndex = 6;
            lblFormaPago.Text = "Forma de Pago";

            // lblImporte
            lblImporte.AutoSize = true;
            lblImporte.ForeColor = SystemColors.ControlLightLight;
            lblImporte.Location = new Point(26, 253);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(62, 20);
            lblImporte.TabIndex = 7;
            lblImporte.Text = "Importe";

            // btnImprimir
            btnImprimir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnImprimir.Location = new Point(69, 337);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(199, 39);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir Carnet";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;

            // lblCodigo
            lblCodigo.AutoSize = true;
            lblCodigo.ForeColor = SystemColors.ControlLightLight;
            lblCodigo.Location = new Point(26, 68);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(118, 20);
            lblCodigo.TabIndex = 9;
            lblCodigo.Text = "Código de pago";

            // lblNumsocio
            lblNumsocio.AutoSize = true;
            lblNumsocio.ForeColor = SystemColors.ControlLightLight;
            lblNumsocio.Location = new Point(287, 68);
            lblNumsocio.Name = "lblNumsocio";
            lblNumsocio.Size = new Size(123, 20);
            lblNumsocio.TabIndex = 10;
            lblNumsocio.Text = "Número de socio";

            // lblNom
            lblNom.AutoSize = true;
            lblNom.ForeColor = SystemColors.ControlLightLight;
            lblNom.Location = new Point(26, 122);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(64, 20);
            lblNom.TabIndex = 11;
            lblNom.Text = "Nombre";
            lblNom.TextAlign = ContentAlignment.MiddleLeft;

            // lblFech
            lblFech.AutoSize = true;
            lblFech.ForeColor = SystemColors.ControlLightLight;
            lblFech.Location = new Point(287, 122);
            lblFech.Name = "lblFech";
            lblFech.Size = new Size(47, 20);
            lblFech.TabIndex = 12;
            lblFech.Text = "Fecha";

            // lblPeriod
            lblPeriod.AutoSize = true;
            lblPeriod.ForeColor = SystemColors.ControlLightLight;
            lblPeriod.Location = new Point(26, 178);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(60, 20);
            lblPeriod.TabIndex = 13;
            lblPeriod.Text = "Periodo";

            // lblFormDePago
            lblFormDePago.AutoSize = true;
            lblFormDePago.ForeColor = SystemColors.ControlLightLight;
            lblFormDePago.Location = new Point(288, 176);
            lblFormDePago.Name = "lblFormDePago";
            lblFormDePago.Size = new Size(109, 20);
            lblFormDePago.TabIndex = 14;
            lblFormDePago.Text = "Forma de Pago";

            // lblImp
            lblImp.AutoSize = true;
            lblImp.ForeColor = SystemColors.ControlLightLight;
            lblImp.Location = new Point(28, 232);
            lblImp.Name = "lblImp";
            lblImp.Size = new Size(62, 20);
            lblImp.TabIndex = 15;
            lblImp.Text = "Importe";

            // btnImprimirPagoAux
            btnImprimirPagoAux.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnImprimirPagoAux.Location = new Point(309, 337);
            btnImprimirPagoAux.Name = "btnImprimirPagoAux";
            btnImprimirPagoAux.Size = new Size(241, 39);
            btnImprimirPagoAux.TabIndex = 16;
            btnImprimirPagoAux.Text = "Imprimir Comprobante";
            btnImprimirPagoAux.UseVisualStyleBackColor = true;
            btnImprimirPagoAux.Click += btnImprimirPagoAux_Click;

            // Comprobante
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(605, 430);

            Controls.Add(btnImprimirPagoAux);
            Controls.Add(lblImp);
            Controls.Add(lblFormDePago);
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
            Text = "Comprobante";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblCodPago;
        private Label lblNroSocio;
        private Label lblNombre;
        private Label lblFecha;
        private Label lblPeriodo;
        private Label lblFormaPago;
        private Label lblImporte;
        private Button btnImprimir;
        private Label lblCodigo;
        private Label lblNumsocio;
        private Label lblNom;
        private Label lblFech;
        private Label lblPeriod;
        private Label lblFormDePago;
        private Label lblImp;
        private Button btnImprimirPagoAux;
    }
}




//namespace PI
//{
//    partial class Comprobante
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }

//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        #endregion

//        private Label lblTitulo;
//        private Label lblCodPago;
//        private Label lblNroSocio;
//        private Label lblNombre;
//        private Label lblFecha;
//        private Label lblPeriodo;
//        private Label lblFormaPago;
//        private Label lblImporte;
//        private Button btnImprimir;
//        private Label lblCodigo;
//        private Label lblNumsocio;
//        private Label lblNom;
//        private Label lblFech;
//        private Label lblPeriod;
//        private Label lblFormDePago;
//        private Label lblImp;
//    }
//}