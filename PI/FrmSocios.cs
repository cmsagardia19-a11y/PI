using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Datos;
using System.IO;
using System.Text;
using System.Linq;

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
                    END AS 'Apto Médico',
                    DATE_ADD(
                        DATE(p.FechaPago),
                        INTERVAL 1 MONTH
                    ) AS 'Fecha de Vencimiento'

                FROM socio s

                INNER JOIN usuario u
                    ON u.CodUsu = s.CodUsu

                INNER JOIN pago_cuota p
                    ON p.CodPago = (
                        SELECT p2.CodPago
                        FROM pago_cuota p2
                        WHERE p2.CodUsu = s.CodUsu
                        ORDER BY p2.FechaPago DESC, p2.CodPago DESC
                        LIMIT 1
                    )

                WHERE u.RolUsu = 3
                    AND DATE_ADD(
                        DATE(p.FechaPago),
                        INTERVAL 1 MONTH
                        ) = CURDATE()

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvSocios.DataSource == null || dgvSocios.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay socios para exportar.",
                    "Descargar CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Title = "Guardar listado de socios";
                guardar.Filter = "Archivo CSV (*.csv)|*.csv";
                guardar.FileName = "Socios.csv";
                guardar.DefaultExt = "csv";
                guardar.AddExtension = true;

                if (guardar.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter escritor = new StreamWriter(
                        guardar.FileName, false, new UTF8Encoding(true)))
                    {
                        // Exportar encabezados de las columnas visibles.
                        var columnas = dgvSocios.Columns
                            .Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .OrderBy(c => c.DisplayIndex)
                            .ToList();

                        escritor.WriteLine(
                            string.Join(";",
                                columnas.Select(c => EscaparCsv(c.HeaderText))));

                        // Exportar todos los socios del DataGridView.
                        foreach (DataGridViewRow fila in dgvSocios.Rows)
                        {
                            if (fila.IsNewRow || !fila.Visible)
                                continue;

                            var valores = columnas.Select(c =>
                                EscaparCsv(
                                    Convert.ToString(fila.Cells[c.Index].Value) ?? ""));

                            escritor.WriteLine(string.Join(";", valores));
                        }
                    }

                    MessageBox.Show(
                        "El archivo CSV se descargó correctamente.",
                        "Exportación completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al exportar el archivo CSV:\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }


        }

        private string EscaparCsv(string valor)
        {
            if (valor == null)
                return "";

            return "\"" + valor.Replace("\"", "\"\"") + "\"";
        }

    }
}