
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConexion _conexion;

        public UsuarioRepositorio(IConexion conexion)
        {
            _conexion = conexion ??
                throw new ArgumentNullException(nameof(conexion));
        }

        public (int CodUsu, int NroSocio) RegistrarSocio(
            string nombre,
            string apellido,
            string dni,
            bool aptoMedico)
        {
            using (MySqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (MySqlCommand cmd =
                    new MySqlCommand("AltaSocio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_Nombre", nombre);
                    cmd.Parameters.AddWithValue("@p_Apellido", apellido);
                    cmd.Parameters.AddWithValue("@p_DNI", dni);
                    cmd.Parameters.AddWithValue("@p_AptoMedico", aptoMedico);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int codUsu =
                                Convert.ToInt32(reader["CodUsu"]);

                            int nroSocio =
                                Convert.ToInt32(reader["NroSocio"]);

                            return (codUsu, nroSocio);
                        }

                        throw new Exception(
                            "El procedimiento no devolvió los datos del socio.");
                    }
                }
            }
        }
    }
}
