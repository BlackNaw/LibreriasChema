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
        private String server;
        protected String bdName;
        private String user;
        private String password;
        private static MySqlConnection connection;

       public ConexionJDBC()
        {
            server = ConfigurationManager.AppSettings["servidor"].ToString();
            user = ConfigurationManager.AppSettings["usuario"].ToString();
            password = ConfigurationManager.AppSettings["password"].ToString();
            bdName = ConfigurationManager.AppSettings["baseDatos"].ToString();
        }

        private MySqlConnection AbrirConexion()
        {
            if (connection == null)
            {
                try
                {
                    connection = new MySqlConnection();
                    connection.ConnectionString = "Server=" + server + ";Database=" + bdName + ";Uid=" + user + ";Pwd=" + password + ";";
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            return connection;
        }


    }
}
