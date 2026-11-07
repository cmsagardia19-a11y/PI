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

        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(520, 570);
        //    this.Text = "Comprobante";
        //    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        //}

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
    }
}