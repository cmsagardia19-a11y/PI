
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class PagoCuotaRepositorio : IPagoCuotaRepositorio
    {
        private readonly IConexion _conexion;

        public PagoCuotaRepositorio(IConexion conexion)
        {
            _conexion = conexion ??
                throw new ArgumentNullException(nameof(conexion));
        }

        // Consultar los datos del socio.
        public (bool Encontrado, int NroSocio, string Nombre, string Apellido)
            ObtenerDatosSocio(int codUsu)
        {
            string sql = @"
                SELECT
                    s.NroSocio,
                    u.Nombre,
                    u.Apellido
                FROM socio s
                INNER JOIN usuario u
                    ON u.CodUsu = s.CodUsu
                WHERE s.CodUsu = @CodUsu;";

            using (MySqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@CodUsu", codUsu);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return (false, 0, "", "");

                        return (
                            true,
                            Convert.ToInt32(reader["NroSocio"]),
                            Convert.ToString(reader["Nombre"]),
                            Convert.ToString(reader["Apellido"])
                        );
                    }
                }
            }
        }

        // Consultar la cuota vigente y verificar pagos anteriores.
        public (bool ExisteCuota, decimal Importe, int PeriodoMes,
            int PeriodoAnio, bool PagoRegistrado)
            ObtenerEstadoCuotaMensual(int codUsu)
        {
            using (MySqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT
                        Importe,
                        MONTH(CURDATE()) AS PeriodoMes,
                        YEAR(CURDATE()) AS PeriodoAnio
                    FROM cuota
                    WHERE TipoCuota = 'Mensual'
                      AND Vigente = TRUE
                    ORDER BY CodCuota DESC
                    LIMIT 1;";

                decimal importe;
                int periodoMes;
                int periodoAnio;

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return (false, 0, 0, 0, false);

                    importe = Convert.ToDecimal(reader["Importe"]);
                    periodoMes = Convert.ToInt32(reader["PeriodoMes"]);
                    periodoAnio = Convert.ToInt32(reader["PeriodoAnio"]);
                }

                string sqlPago = @"
                    SELECT COUNT(*)
                    FROM pago_cuota
                    WHERE CodUsu = @CodUsu
                      AND PeriodoMes = @PeriodoMes
                      AND PeriodoAnio = @PeriodoAnio;";

                int cantidad;

                using (MySqlCommand cmd = new MySqlCommand(sqlPago, cn))
                {
                    cmd.Parameters.AddWithValue("@CodUsu", codUsu);
                    cmd.Parameters.AddWithValue("@PeriodoMes", periodoMes);
                    cmd.Parameters.AddWithValue("@PeriodoAnio", periodoAnio);

                    cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                }

                return (
                    true,
                    importe,
                    periodoMes,
                    periodoAnio,
                    cantidad > 0
                );
            }
        }

        // Registrar el pago mediante el procedimiento almacenado.
        public (int CodPago, DateTime FechaPago, string Nombre,
            string Apellido, string FormaPago, decimal Importe,
            int PeriodoMes, int PeriodoAnio)
            RegistrarPago(int codUsu, string formaPago)
        {
            using (MySqlConnection cn = _conexion.ObtenerConexion())
            {
                cn.Open();

                using (MySqlCommand cmd =
                    new MySqlCommand("RegistrarPagoCuota", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_CodUsu", codUsu);
                    cmd.Parameters.AddWithValue("@p_FormaPago", formaPago);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new Exception(
                                "El procedimiento no devolvió los datos del pago.");
                        }

                        return (
                            Convert.ToInt32(reader["CodPago"]),
                            Convert.ToDateTime(reader["FechaPago"]),
                            Convert.ToString(reader["Nombre"]),
                            Convert.ToString(reader["Apellido"]),
                            Convert.ToString(reader["FormaPago"]),
                            Convert.ToDecimal(reader["ImportePagado"]),
                            Convert.ToInt32(reader["PeriodoMes"]),
                            Convert.ToInt32(reader["PeriodoAnio"])
                        );
                    }
                }
            }
        }
    }
}
