namespace PI
{
    partial class FrmAgregarUsuario
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
            label1 = new Label();
            lblDatosPersonales = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtApellido = new TextBox();
            label5 = new Label();
            txtDni = new TextBox();
            lblRequisitos = new Label();
            chkAptoMedico = new CheckBox();
            chkPagoRecibido = new CheckBox();
            lblCuotaInicial = new Label();
            txtCuota = new TextBox();
            lblCuotaMensualVigente = new Label();
            lblPeriodo = new Label();
            txtPeriodo = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // lblDatosPersonales
            // 
            lblDatosPersonales.AutoSize = true;
            lblDatosPersonales.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDatosPersonales.ForeColor = SystemColors.ControlLightLight;
            lblDatosPersonales.Location = new Point(10, 12);
            lblDatosPersonales.Name = "lblDatosPersonales";
            lblDatosPersonales.Size = new Size(187, 31);
            lblDatosPersonales.TabIndex = 1;
            lblDatosPersonales.Text = "Datos Personales";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 98);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(183, 27);
            txtNombre.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(16, 62);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(266, 62);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 4;
            label4.Text = "Apellido";
            label4.Click += label4_Click;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(266, 98);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(188, 27);
            txtApellido.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(530, 58);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 6;
            label5.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(525, 98);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(126, 27);
            txtDni.TabIndex = 7;
            // 
            // lblRequisitos
            // 
            lblRequisitos.AutoSize = true;
            lblRequisitos.BackColor = SystemColors.Desktop;
            lblRequisitos.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequisitos.ForeColor = SystemColors.ControlLightLight;
            lblRequisitos.Location = new Point(10, 181);
            lblRequisitos.Name = "lblRequisitos";
            lblRequisitos.Size = new Size(292, 31);
            lblRequisitos.TabIndex = 8;
            lblRequisitos.Text = "Requisitos de la inscripción";
            // 
            // chkAptoMedico
            // 
            chkAptoMedico.AutoSize = true;
            chkAptoMedico.ForeColor = SystemColors.ControlLightLight;
            chkAptoMedico.Location = new Point(19, 233);
            chkAptoMedico.Name = "chkAptoMedico";
            chkAptoMedico.Size = new Size(118, 24);
            chkAptoMedico.TabIndex = 9;
            chkAptoMedico.Text = "Apto Médico";
            chkAptoMedico.UseVisualStyleBackColor = true;
            chkAptoMedico.CheckedChanged += checkAptoMedico_CheckedChanged;
            // 
            // chkPagoRecibido
            // 
            chkPagoRecibido.AutoSize = true;
            chkPagoRecibido.ForeColor = SystemColors.ControlLight;
            chkPagoRecibido.Location = new Point(199, 235);
            chkPagoRecibido.Name = "chkPagoRecibido";
            chkPagoRecibido.Size = new Size(107, 24);
            chkPagoRecibido.TabIndex = 10;
            chkPagoRecibido.Text = "Pago Cuota";
            chkPagoRecibido.UseVisualStyleBackColor = true;
            // 
            // lblCuotaInicial
            // 
            lblCuotaInicial.AutoSize = true;
            lblCuotaInicial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCuotaInicial.ForeColor = SystemColors.ControlLightLight;
            lblCuotaInicial.Location = new Point(13, 299);
            lblCuotaInicial.Name = "lblCuotaInicial";
            lblCuotaInicial.Size = new Size(140, 31);
            lblCuotaInicial.TabIndex = 11;
            lblCuotaInicial.Text = "Cuota inicial";
            // 
            // txtCuota
            // 
            txtCuota.Location = new Point(16, 387);
            txtCuota.Name = "txtCuota";
            txtCuota.Size = new Size(157, 27);
            txtCuota.TabIndex = 12;
            // 
            // lblCuotaMensualVigente
            // 
            lblCuotaMensualVigente.AutoSize = true;
            lblCuotaMensualVigente.ForeColor = SystemColors.ControlLightLight;
            lblCuotaMensualVigente.Location = new Point(16, 346);
            lblCuotaMensualVigente.Name = "lblCuotaMensualVigente";
            lblCuotaMensualVigente.Size = new Size(162, 20);
            lblCuotaMensualVigente.TabIndex = 13;
            lblCuotaMensualVigente.Text = "Cuota Mensual Vigente";
            lblCuotaMensualVigente.Click += lblCuotaMensualVigente_Click;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.BackColor = SystemColors.Desktop;
            lblPeriodo.ForeColor = SystemColors.ControlLightLight;
            lblPeriodo.Location = new Point(282, 351);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(126, 20);
            lblPeriodo.TabIndex = 14;
            lblPeriodo.Text = "Periodo Abonado";
            // 
            // txtPeriodo
            // 
            txtPeriodo.Location = new Point(283, 387);
            txtPeriodo.Name = "txtPeriodo";
            txtPeriodo.Size = new Size(216, 27);
            txtPeriodo.TabIndex = 15;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 192, 0);
            btnGuardar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlText;
            btnGuardar.Location = new Point(233, 460);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(154, 48);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(451, 460);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 48);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 539);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtPeriodo);
            Controls.Add(lblPeriodo);
            Controls.Add(lblCuotaMensualVigente);
            Controls.Add(txtCuota);
            Controls.Add(lblCuotaInicial);
            Controls.Add(chkPagoRecibido);
            Controls.Add(chkAptoMedico);
            Controls.Add(lblRequisitos);
            Controls.Add(txtDni);
            Controls.Add(label5);
            Controls.Add(txtApellido);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(lblDatosPersonales);
            Controls.Add(label1);
            Name = "FrmAgregarUsuario";
            Text = "Agregar Socio";
            Load += FrmAgregarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblDatosPersonales;
        private TextBox txtNombre;
        private Label label3;
        private Label label4;
        private TextBox txtApellido;
        private Label label5;
        private TextBox txtDni;
        private Label lblRequisitos;
        private CheckBox chkAptoMedico;
        private CheckBox chkPagoRecibido;
        private Label lblCuotaInicial;
        private TextBox txtCuota;
        private Label lblCuotaMensualVigente;
        private Label lblPeriodo;
        private TextBox txtPeriodo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}