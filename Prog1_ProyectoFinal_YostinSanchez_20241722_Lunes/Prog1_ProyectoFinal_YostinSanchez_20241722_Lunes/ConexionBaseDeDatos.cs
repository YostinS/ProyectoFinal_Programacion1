using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Prog1_ProyectoFinal_YostinSanchez_20241722_Lunes
{
    internal class ConexionDB
    {
        public static SqlConnection ObtenerConexion()
        {
            string cadena = "Server=LAPTOP-EL4CJHNR\\SQLEXPRESS01;Database=Proyecto_Final_Prog1; Integrated Security=True;TrustServerCertificate=True;";
            //string cadena = "data source = LAPTOP-EL4CJHNR\\SQLEXPRESS01; initial catalog = Proyecto_Final_Prog1; Integrated Security=True";
            return new SqlConnection(cadena);
        }
    }
}

