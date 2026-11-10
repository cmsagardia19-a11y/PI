using MySql.Data.MySqlClient;
using System;

namespace Datos
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly IConexion _conexion;

        public LoginRepositorio(IConexion conexion)
        {
            _conexion = conexion ??
                throw new ArgumentNullException(nameof(conexion));
        }

        public bool ValidarCredenciales(
            string usuario,
            string contrasena,
            out int codUsu,
            out string nombre,
            out string apellido,
            out int rol)
        {
            codUsu = 0;
            nombre = "";
            apellido = "";
            rol = 0;

            using (MySqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT CodUsu, Nombre, Apellido, RolUsu
                    FROM usuario
                    WHERE Nombre = @usuario
                      AND PassUsu = @contrasena
                      AND Activo = 1
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return false;
                        }

                        codUsu = Convert.ToInt32(reader["CodUsu"]);
                        nombre = reader["Nombre"].ToString() ?? "";
                        apellido = reader["Apellido"].ToString() ?? "";
                        rol = Convert.ToInt32(reader["RolUsu"]);

                        return true;
                    }
                }
            }
        }
    }
}