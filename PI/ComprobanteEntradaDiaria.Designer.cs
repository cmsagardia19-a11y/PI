namespace PI
{
    partial class ComprobanteEntradaDiaria
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
            lblVigencia = new Label();
            btnImprimir = new Button();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(206, 28);
            label1.Name = "label1";
            label1.Size = new Size(383, 41);
            label1.TabIndex = 0;
            label1.Text = "COMPROBANTE DE PAGO";
            // 
            // lblVigencia
            // 
            lblVigencia.AutoSize = true;
            lblVigencia.ForeColor = SystemColors.ControlLightLight;
            lblVigencia.Location = new Point(311, 298);
            lblVigencia.Name = "lblVigencia";
            lblVigencia.Size = new Size(66, 20);
            lblVigencia.TabIndex = 2;
            lblVigencia.Text = "Vigencia";
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.Location = new Point(234, 353);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(143, 49);
            btnImprimir.TabIndex = 3;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.Location = new Point(450, 353);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(130, 49);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // ComprobanteEntradaDiaria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnImprimir);
            Controls.Add(lblVigencia);
            Controls.Add(label1);
            Name = "ComprobanteEntradaDiaria";
            Text = "Comprobante de Pago No Socio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblVigencia;
        private Button btnImprimir;
        private Button btnCerrar;
    }
}