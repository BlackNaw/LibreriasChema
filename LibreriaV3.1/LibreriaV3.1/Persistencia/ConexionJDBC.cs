using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LibreriaV3._1.Persistencia
{
    public class ConexionJDBC
    {
        private static MySqlConnection connection = null;

        public static MySqlConnection AbrirConexion()
        {
            if (connection == null)
            {
                try
                {
                    connection = new MySqlConnection();
                    connection.ConnectionString = "Server=" + ConfigurationManager.AppSettings["servidor"].ToString() +
                        ";Database=" + ConfigurationManager.AppSettings["baseDatos"].ToString()
                        + ";Uid=" + ConfigurationManager.AppSettings["usuario"].ToString() +
                        ";Pwd=" + ConfigurationManager.AppSettings["password"].ToString() + ";";
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            return connection;
        }

        public static void CerrarConexion()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
