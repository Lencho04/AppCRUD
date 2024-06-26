using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Librerias para usar SQL
using System.Data.SqlClient;

namespace CRUD_EJEMPLO
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-3DM810J; " +
                                                 "DATABASE=CRUD_con_C#;" +
                                                 "integrated security=true;");
            cn.Open();
            return cn;
        }
    }
}
