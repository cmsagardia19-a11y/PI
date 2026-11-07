namespace PI
{
    partial class FormPagoCuota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lnlDatosSocio = new Label();
            lblNroSocio = new Label();
            textBox1 = new TextBox();
            lblNombreSocio = new Label();
            txtNombreSocio = new TextBox();
            lblDetallePago = new Label();
            lblCuota = new Label();
            txtCuota = new TextBox();
            lblPeriodo = new Label();
            txtPeriodo = new TextBox();
            lblFormaPago = new Label();
            cmbFormaPago = new ComboBox();
            btnPagar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(18, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(216, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE PAGO";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lnlDatosSocio
            // 
            lnlDatosSocio.AutoSize = true;
            lnlDatosSocio.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lnlDatosSocio.ForeColor = SystemColors.ButtonHighlight;
            lnlDatosSocio.Location = new Point(22, 79);
            lnlDatosSocio.Name = "lnlDatosSocio";
            lnlDatosSocio.Size = new Size(132, 20);
            lnlDatosSocio.TabIndex = 1;
            lnlDatosSocio.Text = "DATOS DEL SOCIO";
            // 
            // lblNroSocio
            // 
            lblNroSocio.AutoSize = true;
            lblNroSocio.ForeColor = SystemColors.ButtonHighlight;
            lblNroSocio.Location = new Point(25, 120);
            lblNroSocio.Name = "lblNroSocio";
            lblNroSocio.Size = new Size(123, 20);
            lblNroSocio.TabIndex = 2;
            lblNroSocio.Text = "Número de socio";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 156);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            //textBox1.TextChanged += textBox1_TextChanged;
            // 
            // lblNombreSocio
            // 
            lblNombreSocio.AutoSize = true;
            lblNombreSocio.ForeColor = SystemColors.ButtonHighlight;
            lblNombreSocio.Location = new Point(301, 127);
            lblNombreSocio.Name = "lblNombreSocio";
            lblNombreSocio.Size = new Size(46, 20);
            lblNombreSocio.TabIndex = 4;
            lblNombreSocio.Text = "Socio";
            // 
            // txtNombreSocio
            // 
            txtNombreSocio.Location = new Point(299, 156);
            txtNombreSocio.Name = "txtNombreSocio";
            txtNombreSocio.ReadOnly = true;
            txtNombreSocio.Size = new Size(125, 27);
            txtNombreSocio.TabIndex = 5;
            // 
            // lblDetallePago
            // 
            lblDetallePago.AutoSize = true;
            lblDetallePago.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblDetallePago.ForeColor = SystemColors.ButtonHighlight;
            lblDetallePago.Location = new Point(22, 219);
            lblDetallePago.Name = "lblDetallePago";
            lblDetallePago.Size = new Size(139, 20);
            lblDetallePago.TabIndex = 6;
            lblDetallePago.Text = "DETALLE DEL PAGO";
            // 
            // lblCuota
            // 
            lblCuota.AutoSize = true;
            lblCuota.ForeColor = SystemColors.ButtonHighlight;
            lblCuota.Location = new Point(23, 259);
            lblCuota.Name = "lblCuota";
            lblCuota.Size = new Size(183, 20);
            lblCuota.TabIndex = 7;
            lblCuota.Text = "Importe de cuota mensual";
            // 
            // txtCuota
            // 
            txtCuota.Location = new Point(25, 291);
            txtCuota.Name = "txtCuota";
            txtCuota.ReadOnly = true;
            txtCuota.Size = new Size(125, 27);
            txtCuota.TabIndex = 8;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.ForeColor = SystemColors.ButtonHighlight;
            lblPeriodo.Location = new Point(304, 259);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(60, 20);
            lblPeriodo.TabIndex = 9;
            lblPeriodo.Text = "Período";
            // 
            // txtPeriodo
            // 
            txtPeriodo.Location = new Point(297, 291);
            txtPeriodo.Name = "txtPeriodo";
            txtPeriodo.ReadOnly = true;
            txtPeriodo.Size = new Size(125, 27);
            txtPeriodo.TabIndex = 10;
            // 
            // lblFormaPago
            // 
            lblFormaPago.AutoSize = true;
            lblFormaPago.ForeColor = SystemColors.ButtonHighlight;
            lblFormaPago.Location = new Point(577, 259);
            lblFormaPago.Name = "lblFormaPago";
            lblFormaPago.Size = new Size(111, 20);
            lblFormaPago.TabIndex = 11;
            lblFormaPago.Text = "Forma de pago";
            lblFormaPago.Click += lblFormaPago_Click;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(577, 290);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(151, 28);
            cmbFormaPago.TabIndex = 12;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.FromArgb(0, 192, 0);
            btnPagar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPagar.ForeColor = Color.Black;
            btnPagar.Location = new Point(252, 368);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(122, 44);
            btnPagar.TabIndex = 13;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnCancelar.Location = new Point(451, 368);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(115, 44);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //btnCancelar.Click += btnCancelar_Click_1;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormPagoCuota
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnPagar);
            Controls.Add(cmbFormaPago);
            Controls.Add(lblFormaPago);
            Controls.Add(txtPeriodo);
            Controls.Add(lblPeriodo);
            Controls.Add(txtCuota);
            Controls.Add(lblCuota);
            Controls.Add(lblDetallePago);
            Controls.Add(txtNombreSocio);
            Controls.Add(lblNombreSocio);
            Controls.Add(textBox1);
            Controls.Add(lblNroSocio);
            Controls.Add(lnlDatosSocio);
            Controls.Add(lblTitulo);
            Name = "FormPagoCuota";
            Text = "Pago de Cuota";
            Load += FormPagoCuota_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lnlDatosSocio;
        private Label lblNroSocio;
        private TextBox textBox1;
        private Label lblNombreSocio;
        private TextBox txtNombreSocio;
        private Label lblDetallePago;
        private Label lblCuota;
        private TextBox txtCuota;
        private Label lblPeriodo;
        private TextBox txtPeriodo;
        private Label lblFormaPago;
        private ComboBox cmbFormaPago;
        private Button btnPagar;
        private Button btnCancelar;
    }
}