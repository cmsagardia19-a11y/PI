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
            dgvUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // btnListaUsuarios
            // 
            btnListaUsuarios.BackColor = SystemColors.ControlLightLight;
            btnListaUsuarios.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnListaUsuarios.ForeColor = SystemColors.Desktop;
            btnListaUsuarios.Location = new Point(65, 142);
            btnListaUsuarios.Name = "btnListaUsuarios";
            btnListaUsuarios.Size = new Size(297, 106);
            btnListaUsuarios.TabIndex = 0;
            btnListaUsuarios.Text = "Lista de Usuarios";
            btnListaUsuarios.UseVisualStyleBackColor = false;
            btnListaUsuarios.Click += button1_Click;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.Location = new Point(427, 142);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(317, 106);
            btnAgregarUsuario.TabIndex = 1;
            btnAgregarUsuario.Text = "Agregar Usuario";
            btnAgregarUsuario.UseVisualStyleBackColor = true;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ControlLightLight;
            lblTitulo.Location = new Point(342, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(102, 31);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Usuarios";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.ForeColor = SystemColors.ControlLightLight;
            lblMenu.Location = new Point(290, 73);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(200, 20);
            lblMenu.TabIndex = 3;
            lblMenu.Text = "Menú de Gestión de usuarios";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(124, 277);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(575, 146);
            dgvUsuarios.TabIndex = 4;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvUsuarios);
            Controls.Add(lblMenu);
            Controls.Add(lblTitulo);
            Controls.Add(btnAgregarUsuario);
            Controls.Add(btnListaUsuarios);
            Name = "FrmUsuarios";
            Text = "Administración";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListaUsuarios;
        private Button btnAgregarUsuario;
        private Label lblTitulo;
        private Label lblMenu;
        private DataGridView dgvUsuarios;
    }
}