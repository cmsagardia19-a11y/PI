
using System.Data;

namespace Datos
{
    public interface ISocioRepositorio
    {
        DataTable ObtenerSociosConCuotasPendientes();
    }
}
