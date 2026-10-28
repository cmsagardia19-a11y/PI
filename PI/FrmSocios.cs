using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;

namespace PI
{
    public partial class FrmSocios : Form
    {
        public FrmSocios()
        {
            InitializeComponent();
        }

        private void FrmSocios_Load(object sender, EventArgs e)
        {
            CargarSocios();
        }

        private void CargarSocios()
        {
            string consulta = @"
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
                ORDER BY s.NroSocio;";

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection cn =
                    conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (MySqlDataAdapter adaptador =
                        new MySqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        adaptador.Fill(tabla);

                        dgvSocios.DataSource = tabla;
                    }
                }

                dgvSocios.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSocios.ReadOnly = true;
                dgvSocios.AllowUserToAddRows = false;
                dgvSocios.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvSocios.MultiSelect = false;

                if (dgvSocios.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay socios registrados.",
                        "Listado de socios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al consultar los socios:\n" + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los socios:\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}