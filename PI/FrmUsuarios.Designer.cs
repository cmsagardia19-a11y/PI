namespace PI
{
    partial class FrmUsuarios
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
            btnListaUsuarios = new Button();
            btnAgregarUsuario = new Button();
            lblTitulo = new Label();
            lblMenu = new Label();
            btnEntradaDiaria = new Button();
            SuspendLayout();
            // 
            // btnListaUsuarios
            // 
            btnListaUsuarios.BackColor = SystemColors.ControlLightLight;
            btnListaUsuarios.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListaUsuarios.ForeColor = SystemColors.Desktop;
            btnListaUsuarios.Location = new Point(251, 347);
            btnListaUsuarios.Name = "btnListaUsuarios";
            btnListaUsuarios.Size = new Size(282, 52);
            btnListaUsuarios.TabIndex = 0;
            btnListaUsuarios.Text = "Lista de Usuarios";
            btnListaUsuarios.UseVisualStyleBackColor = false;
            btnListaUsuarios.Click += btnListaUsuarios_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.Location = new Point(77, 237);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(268, 54);
            btnAgregarUsuario.TabIndex = 1;
            btnAgregarUsuario.Text = "Agregar Socio";
            btnAgregarUsuario.UseVisualStyleBackColor = true;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(318, 35);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(159, 46);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Usuarios";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenu.ForeColor = SystemColors.ControlLightLight;
            lblMenu.Location = new Point(252, 120);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(281, 28);
            lblMenu.TabIndex = 3;
            lblMenu.Text = "Menú de Gestión de usuarios";
            // 
            // btnEntradaDiaria
            // 
            btnEntradaDiaria.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntradaDiaria.Location = new Point(447, 237);
            btnEntradaDiaria.Name = "btnEntradaDiaria";
            btnEntradaDiaria.Size = new Size(300, 54);
            btnEntradaDiaria.TabIndex = 4;
            btnEntradaDiaria.Text = "Agregar No Socio";
            btnEntradaDiaria.UseVisualStyleBackColor = true;
            btnEntradaDiaria.Click += btnEntradaDiaria_Click;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEntradaDiaria);
            Controls.Add(lblMenu);
            Controls.Add(lblTitulo);
            Controls.Add(btnAgregarUsuario);
            Controls.Add(btnListaUsuarios);
            Name = "FrmUsuarios";
            Text = "Administración";
            Load += FrmUsuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListaUsuarios;
        private Button btnAgregarUsuario;
        private Label lblTitulo;
        private Label lblMenu;
        //private Button btnEntradaDiaria;
        private Button btnEntradaDiaria;
    }
}