
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class SocioRepositorio : ISocioRepositorio
    {
        private readonly IConexion _conexion;

        public SocioRepositorio(IConexion conexion)
        {
            _conexion = conexion ??
                throw new ArgumentNullException(nameof(conexion));
        }

        public DataTable ObtenerSociosConCuotasPendientes()
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

            DataTable tabla = new DataTable();

            using (MySqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(consulta, cn))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}
