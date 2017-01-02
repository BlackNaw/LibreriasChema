using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;


namespace LibreriaV3._1.Persistencia
{
    public class ConexionJDBC
    {
        private static MySqlConnection connection;

        /*  
         *  Abre la conexion con la base de datos
         */
        public static MySqlConnection AbrirConexion()
        {
            if (connection == null)
            {
                try
                {
                    connection = new MySqlConnection();
                    connection.ConnectionString = 
                        "Server=" + ConfigurationManager.AppSettings["servidor"].ToString()
                        + ";Database=" + ConfigurationManager.AppSettings["baseDatos"].ToString()
                        + ";Uid=" + ConfigurationManager.AppSettings["usuario"].ToString() 
                        + ";Pwd=" + ConfigurationManager.AppSettings["password"].ToString() + ";";
                    connection.Open();
                }

                catch (Exception ex)
                {
                    string Success = ex.Message;
                    throw new Exception(ex.Message, ex);
                }
            }
            return connection;
        }

        public static void CerrarConexion()
        {
          connection.Close();
        }
    }
}
