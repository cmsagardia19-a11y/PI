using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        private readonly string connectionString;
    public Conexion()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            connectionString =
                configuration.GetConnectionString("ClubConnection")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena ClubConnection.");
        }

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }
    }

}
