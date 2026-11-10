namespace PI
{
    partial class FrmEntradaDiaria
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
            lblNoSocio = new Label();
            lblResgistroEntrada = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblFormaDePago = new Label();
            lblImporte = new Label();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDNI = new TextBox();
            cmbFormaPago = new ComboBox();
            SuspendLayout();
            // 
            // lblNoSocio
            // 
            lblNoSocio.AutoSize = true;
            lblNoSocio.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblNoSocio.ForeColor = SystemColors.ControlLightLight;
            lblNoSocio.Location = new Point(340, 23);
            lblNoSocio.Name = "lblNoSocio";
            lblNoSocio.Size = new Size(111, 31);
            lblNoSocio.TabIndex = 0;
            lblNoSocio.Text = "No Socio";
            // 
            // lblResgistroEntrada
            // 
            lblResgistroEntrada.AutoSize = true;
            lblResgistroEntrada.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResgistroEntrada.ForeColor = SystemColors.ControlLightLight;
            lblResgistroEntrada.Location = new Point(273, 75);
            lblResgistroEntrada.Name = "lblResgistroEntrada";
            lblResgistroEntrada.Size = new Size(259, 28);
            lblResgistroEntrada.TabIndex = 1;
            lblResgistroEntrada.Text = "Registro de entrada diaria";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = SystemColors.ControlLightLight;
            lblNombre.Location = new Point(40, 142);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.ForeColor = SystemColors.ControlLightLight;
            lblApellido.Location = new Point(275, 144);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.ForeColor = SystemColors.ControlLightLight;
            lblDni.Location = new Point(540, 142);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(35, 20);
            lblDni.TabIndex = 4;
            lblDni.Text = "DNI";
            // 
            // lblFormaDePago
            // 
            lblFormaDePago.AutoSize = true;
            lblFormaDePago.ForeColor = SystemColors.ControlLightLight;
            lblFormaDePago.Location = new Point(40, 222);
            lblFormaDePago.Name = "lblFormaDePago";
            lblFormaDePago.Size = new Size(111, 20);
            lblFormaDePago.TabIndex = 5;
            lblFormaDePago.Text = "Forma de pago";
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.ForeColor = SystemColors.ControlLightLight;
            lblImporte.Location = new Point(277, 261);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(138, 20);
            lblImporte.TabIndex = 6;
            lblImporte.Text = "Importe de entrada";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.Location = new Point(155, 370);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(204, 46);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar Entrada";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(442, 370);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(133, 46);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(44, 179);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(277, 177);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(125, 27);
            txtApellido.TabIndex = 10;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(544, 177);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(125, 27);
            txtDNI.TabIndex = 11;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(43, 253);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(151, 28);
            cmbFormaPago.TabIndex = 12;
            // 
            // FrmEntradaDiaria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbFormaPago);
            Controls.Add(txtDNI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrar);
            Controls.Add(lblImporte);
            Controls.Add(lblFormaDePago);
            Controls.Add(lblDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblResgistroEntrada);
            Controls.Add(lblNoSocio);
            Name = "FrmEntradaDiaria";
            Text = "No Socio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNoSocio;
        private Label lblResgistroEntrada;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblFormaDePago;
        private Label lblImporte;
        private Button btnRegistrar;
        private Button btnCancelar;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDNI;
        private ComboBox cmbFormaPago;
    }
}