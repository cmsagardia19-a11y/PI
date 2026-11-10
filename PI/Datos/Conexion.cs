using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Datos
{
    //Abstracción	
    //IConexion define qué operaciones debe ofrecer una conexión,
    //sin exponer su implementación.
    public class Conexion : IConexion
    {
        //Encapsulamiento	
        //connectionString es privada y de solo lectura (readonly).
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

