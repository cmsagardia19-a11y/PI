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
            lblDatosPersonales = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtApellido = new TextBox();
            label5 = new Label();
            txtDni = new TextBox();
            lblRequisitos = new Label();
            chkAptoMedico = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            SuspendLayout();
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
            txtNombre.Size = new Size(190, 27);
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
            // txtApellido
            // 
            txtApellido.Location = new Point(16, 185);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(188, 27);
            txtApellido.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(22, 229);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 6;
            label5.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(17, 269);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(187, 27);
            txtDni.TabIndex = 7;
            // 
            // lblRequisitos
            // 
            lblRequisitos.AutoSize = true;
            lblRequisitos.BackColor = SystemColors.Desktop;
            lblRequisitos.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequisitos.ForeColor = SystemColors.ControlLightLight;
            lblRequisitos.Location = new Point(16, 325);
            lblRequisitos.Name = "lblRequisitos";
            lblRequisitos.Size = new Size(292, 31);
            lblRequisitos.TabIndex = 8;
            lblRequisitos.Text = "Requisitos de la inscripción";
            // 
            // chkAptoMedico
            // 
            chkAptoMedico.AutoSize = true;
            chkAptoMedico.ForeColor = SystemColors.ControlLightLight;
            chkAptoMedico.Location = new Point(25, 377);
            chkAptoMedico.Name = "chkAptoMedico";
            chkAptoMedico.Size = new Size(118, 24);
            chkAptoMedico.TabIndex = 9;
            chkAptoMedico.Text = "Apto Médico";
            chkAptoMedico.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 192, 0);
            btnGuardar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ControlText;
            btnGuardar.Location = new Point(205, 441);
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
            btnCancelar.Location = new Point(438, 441);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 48);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(18, 147);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 18;
            label1.Text = "Apellido";
            // 
            // FrmAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 514);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkAptoMedico);
            Controls.Add(lblRequisitos);
            Controls.Add(txtDni);
            Controls.Add(label5);
            Controls.Add(txtApellido);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(lblDatosPersonales);
            Name = "FrmAgregarUsuario";
            Text = "Agregar Socio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //private Label label1;
        private Label lblDatosPersonales;
        private TextBox txtNombre;
        private Label label3;
        //private Label label4;
        private TextBox txtApellido;
        private Label label5;
        private TextBox txtDni;
        private Label lblRequisitos;
        private CheckBox chkAptoMedico;
        //private CheckBox chkPagoRecibido;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label1;
    }
}