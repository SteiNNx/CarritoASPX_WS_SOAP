using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class CL_Conexion
    {
        private MySqlConnection cone;
        private MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
        public CL_Conexion()
        {
            csb.Port = 3306;
            csb.Password = "";
            csb.UserID = "root";
            csb.Database = "sanguchote";
            csb.Server = "localhost";
            cone = new MySqlConnection(csb.ToString());
        }

        public MySqlConnection obtenerConexion()
        {
            return cone;
        }

    }
}
