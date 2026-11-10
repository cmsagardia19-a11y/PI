using System;
using System.Windows.Forms;

namespace PI
{
    // Herencia: FrmUsuarios hereda de Form
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
        }

        //Encapsulamiento: Evento privado
        private void btnListaUsuarios_Click(object sender, EventArgs e)
        {
            using (FrmSocios formularioSocios = new FrmSocios())
            {
                formularioSocios.ShowDialog(this);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        //Encapsulamiento: Evento privado
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (FrmAgregarUsuario formulario = new FrmAgregarUsuario())
            {
                DialogResult resultado = formulario.ShowDialog(this);

                if (resultado == DialogResult.OK)
                {
                    int codUsu = formulario.CodUsu;
                    int nroSocio = formulario.NroSocio;

                    if (codUsu <= 0 || nroSocio <= 0)
                    {
                        MessageBox.Show(
                            "No se recibieron correctamente los datos del socio.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    using (FormPagoCuota formularioPago =
                           new FormPagoCuota(codUsu, nroSocio))
                    {
                        formularioPago.ShowDialog(this);
                    }
                }
            }
        }

        //Encapsulamiento: Evento privado
        private void btnEntradaDiaria_Click(object sender, EventArgs e)
        {
            using (FrmEntradaDiaria formulario = new FrmEntradaDiaria())
            {
                formulario.ShowDialog(this);
            }
        }
    }
}
