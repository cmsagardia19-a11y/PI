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
        //Encapsulamiento: _conexion y _socioRepositorio son privados y
        //readonly.
        private readonly IConexion _conexion;
        //Polimorfismo: SocioRepositorio implementa ISocioRepositorio;
        //el formulario trabaja con la interfaz.
        private readonly ISocioRepositorio _socioRepositorio;
        public FrmSocios() : this(
            new SocioRepositorio(new Conexion()))
        {
        }

        public FrmSocios(ISocioRepositorio socioRepositorio)
        {
            InitializeComponent();

            _socioRepositorio = socioRepositorio ??
                throw new ArgumentNullException(nameof(socioRepositorio));
        }

        private void FrmSocios_Load(object sender, EventArgs e)
        {
            CargarSocios();
        }


        private void CargarSocios()
        {
            try
            {
                DataTable tabla =
                    _socioRepositorio.ObtenerSociosConCuotasPendientes();

                dgvSocios.DataSource = tabla;

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
                        "No hay socios con cuotas de pago pendientes.",
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