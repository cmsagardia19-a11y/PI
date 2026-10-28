using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    MessageBox.Show(
                        "Conexión exitosa a la base de datos club.",
                        "MySQL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}