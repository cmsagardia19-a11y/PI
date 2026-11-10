using System;
using System.Windows.Forms;
using Datos;

namespace PI
{
    public partial class Login : Form
    {
        private readonly ILoginRepositorio _loginRepositorio;

        public Login() : this(new LoginRepositorio(new Conexion()))
        {
        }

        public Login(ILoginRepositorio loginRepositorio)
        {
            InitializeComponent();

            _loginRepositorio = loginRepositorio ??
                throw new ArgumentNullException(nameof(loginRepositorio));
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
                int codUsu;
                int rol;
                string nombre;
                string apellido;

                bool usuarioEncontrado =
                    _loginRepositorio.ValidarCredenciales(
                        usuario,
                        contraseña,
                        out codUsu,
                        out nombre,
                        out apellido,
                        out rol);

                if (!usuarioEncontrado)
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos, " +
                        "o usuario inactivo.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

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