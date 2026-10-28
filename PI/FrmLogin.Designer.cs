namespace PI
{
    partial class Login
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
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblContraseña = new Label();
            txtContrasena = new TextBox();
            lblTitulo = new Label();
            label1 = new Label();
            btnIngresar = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Location = new Point(49, 166);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(668, 27);
            txtUsuario.TabIndex = 0;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = SystemColors.ButtonHighlight;
            lblUsuario.Location = new Point(49, 128);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(100, 35);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            lblUsuario.Click += label1_Click;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.ForeColor = SystemColors.ControlLightLight;
            lblContraseña.Location = new Point(49, 234);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(140, 35);
            lblContraseña.TabIndex = 2;
            lblContraseña.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(49, 272);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(668, 27);
            txtContrasena.TabIndex = 3;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.Desktop;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(262, 31);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(296, 38);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Club - Inicio de sesión";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(219, 69);
            label1.Name = "label1";
            label1.Size = new Size(384, 31);
            label1.TabIndex = 5;
            label1.Text = "Acceso al sistema de administración";
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(295, 351);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(187, 36);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(132, 401);
            label2.Name = "label2";
            label2.Size = new Size(535, 20);
            label2.TabIndex = 7;
            label2.Text = "Solo usuarios activos con rol administrador podrán acceder a la administración.";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnIngresar);
            Controls.Add(label1);
            Controls.Add(lblTitulo);
            Controls.Add(txtContrasena);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Name = "Login";
            Text = "Club";
            Load += FrmLogincs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblContraseña;
        private TextBox txtContrasena;
        private Label lblTitulo;
        private Label label1;
        private Button btnIngresar;
        private Label label2;
    }
}