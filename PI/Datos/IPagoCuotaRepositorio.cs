
using System;

namespace Datos
{
    public interface IPagoCuotaRepositorio
    {
        (bool Encontrado, int NroSocio, string Nombre, string Apellido,
            string DNI, string Estado, DateTime FechaInscripcion)
            ObtenerDatosSocio(int codUsu);

        (bool ExisteCuota, decimal Importe, int PeriodoMes,
            int PeriodoAnio, bool PagoRegistrado)
            ObtenerEstadoCuotaMensual(int codUsu);

        (int CodPago, DateTime FechaPago, string Nombre,
            string Apellido, string FormaPago, decimal Importe,
            int PeriodoMes, int PeriodoAnio)
            RegistrarPago(int codUsu, string formaPago);
    }
}
