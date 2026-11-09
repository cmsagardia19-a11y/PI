
using System;
using System.Windows.Forms;
//
namespace PI
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }


        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //}

        private void butnListausuarios(object sender, EventArgs e)
        {
            using (FrmSocios formularioSocios = new FrmSocios())
            {
                formularioSocios.ShowDialog(this);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (FrmAgregarUsuario formulario = new FrmAgregarUsuario())
            {
                DialogResult resultado = formulario.ShowDialog(this);

                if (resultado == DialogResult.OK)
                {
                    // Recuperar los datos del socio creado
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

                    // Abrir el formulario de pago
                    using (FormPagoCuota formularioPago =
                           new FormPagoCuota(codUsu, nroSocio))
                    {
                        formularioPago.ShowDialog(this);
                    }
                }
            }
        }
    }
}
