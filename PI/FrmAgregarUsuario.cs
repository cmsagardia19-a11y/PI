
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    //Herencia	FrmAgregarUsuario hereda de Form.
    public partial class FrmAgregarUsuario : Form
    {
        public int CodUsu { get; private set; }
        public int NroSocio { get; private set; }
        //Polimorfismo: El formulario trabaja con IUsuarioRepositorio
        //Encapsulamiento: El repositorio oculta los detalles de conexión
        //y ejecución SQL.
        //Abstracción: IUsuarioRepositorio define la operación de registrar un socio.
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public FrmAgregarUsuario() : this(
            new UsuarioRepositorio(new Conexion()))
        {
        }

        public FrmAgregarUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            InitializeComponent();

            _usuarioRepositorio = usuarioRepositorio ??
                throw new ArgumentNullException(nameof(usuarioRepositorio));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();

            // Validar campos obligatorios.
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show(
                    "Complete nombre, apellido y DNI.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud.
            if (nombre.Length > 20 || apellido.Length > 30)
            {
                MessageBox.Show(
                    "El nombre admite hasta 20 caracteres y el apellido hasta 30.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validar DNI.
            if (dni.Length < 7 || dni.Length > 8 ||
                !System.Text.RegularExpressions.Regex.IsMatch(
                    dni, @"^\d+$"))
            {
                MessageBox.Show(
                    "Ingrese un DNI válido de 7 u 8 dígitos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDni.Focus();
                return;
            }

            // Validar apto médico.
            if (!chkAptoMedico.Checked)
            {
                MessageBox.Show(
                    "Debe confirmar que el socio presentó el apto médico.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var resultado = _usuarioRepositorio.RegistrarSocio(
                    nombre,
                    apellido,
                    dni,
                    true);

                CodUsu = resultado.CodUsu;
                NroSocio = resultado.NroSocio;

                MessageBox.Show(
                    "Socio registrado correctamente.\n\n" +
                    "Número de socio: " + NroSocio,
                    "Alta de socio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1644)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Validación de datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo registrar el socio.\n\n" + ex.Message,
                        "Error al guardar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error inesperado:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
