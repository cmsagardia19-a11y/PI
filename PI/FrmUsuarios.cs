
using Datos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace PI
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.Visible = false;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                        SELECT
                        s.NroSocio AS 'Nro. Socio',
                        u.DNI AS 'DNI',
                        u.Nombre AS 'Nombre',
                        u.Apellido AS 'Apellido',
                        s.FechaInscripcion AS 'Fecha de Inscripción',
                        s.Estado AS 'Estado',
                        CASE
                            WHEN s.AptoMedico = 1 THEN 'Sí'
                            ELSE 'No'
                        END AS 'Apto Médico'
                    FROM socio s
                    INNER JOIN usuario u
                        ON u.CodUsu = s.CodUsu
                    WHERE u.RolUsu = 3
                    ORDER BY s.NroSocio; ";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(sql, cn))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        dgvUsuarios.DataSource = tabla;
                    }
                }

                dgvUsuarios.Visible = true;
                dgvUsuarios.BringToFront();

                if (dgvUsuarios.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron usuarios con rol 3.",
                        "Lista de usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar los usuarios:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (FrmAgregarUsuario formulario =
                   new FrmAgregarUsuario())
            {
                formulario.ShowDialog(this);
            }
        }
    }
}
