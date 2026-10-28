
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void FrmLogincs_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show(
                    "Ingrese el usuario y la contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                        SELECT CodUsu, Nombre, Apellido, RolUsu
                        FROM usuario
                        WHERE Nombre = @usuario
                          AND PassUsu = @contrasena
                          AND Activo = 1
                        LIMIT 1;";

                    using (MySqlCommand cmd =
                           new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@usuario", usuario);

                        cmd.Parameters.AddWithValue(
                            "@contrasena", contraseña);

                        using (MySqlDataReader reader =
                               cmd.ExecuteReader())
                        {
                            // Verificar si existe el usuario.
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Usuario o contraseña incorrectos, " +
                                    "o usuario inactivo.",
                                    "Acceso denegado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            // Obtener los datos antes de cerrar el lector.
                            int rol = Convert.ToInt32(
                                reader["RolUsu"]);

                            string nombre =
                                reader["Nombre"].ToString() ?? "";

                            string apellido =
                                reader["Apellido"].ToString() ?? "";

                            // Validar que sea administrador.
                            if (rol != 1)
                            {
                                MessageBox.Show(
                                    "El usuario no tiene permisos " +
                                    "de administrador.",
                                    "Acceso denegado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            MessageBox.Show(
                                $"Bienvenido, {nombre} {apellido}.",
                                "Acceso correcto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                this.Hide();

                FrmUsuarios formulario = new FrmUsuarios();

                formulario.FormClosed += (s, args) =>
                {
                    this.Close();
                };

                formulario.Show();
                formulario.Activate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo validar el acceso.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
