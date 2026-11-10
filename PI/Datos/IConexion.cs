using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public interface IConexion
    {
        MySqlConnection ObtenerConexion();
    }
}
