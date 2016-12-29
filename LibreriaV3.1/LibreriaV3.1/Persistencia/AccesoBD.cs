using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace LibreriaV3._1.Persistencia
{
    class AccesoBD
    {
        private static MySqlConnection connection = null;
        private MySqlTransaction transaccion;
        private MySqlCommand comando;

        public AccesoBD()
        {
            connection = ConexionJDBC.AbrirConexion();
        }

        public bool Insertar(string sql, object objeto, string antiguo)
        {
            Dictionary<string, object> map = ObtenerDictionaryValorPropiedades(objeto);
            try
            {
                comando = new MySqlCommand(sql, connection);
                int index = 1;
                foreach (object valor in map.Values)
                {
                    comando.Parameters.AddWithValue("@index", valor);
                }
                if (sql.Contains("UPDATE"))
                {
                    comando.Parameters.AddWithValue("@index", antiguo);
                }

            }
            catch (Exception e)
            {
                return false;
            }
            return comando.ExecuteNonQuery() > 0;
        }

        public bool Borrar(string sql, object objeto)
        {
            try
            {
                comando = new MySqlCommand(sql, connection);
                comando.Parameters.AddWithValue("@1", ObtenerValorClavePrimaria(objeto));
            }
            catch (Exception e)
            {
                throw;
            }
            return comando.ExecuteNonQuery() > 0;
        }

        public List<object> Consultar(string sql, Type clase, string nombre)
        {
            MySqlDataReader sqlDataReader = null;
            List<object> objetos = null;
            try
            {
                comando = new MySqlCommand(sql, connection);
                if (!nombre.Equals(""))
                {
                    comando.Parameters.AddWithValue("@1", nombre);
                }
                sqlDataReader = comando.ExecuteReader();
                if (sqlDataReader != null)
                    objetos = new List<object>();
                List<string> list = ObtenerNombrePropiedades(clase);
                while (sqlDataReader.Read())
                {
                    object obj = Activator.CreateInstance(clase);
                    foreach (string nombrename in list)
                    {
                        string valor = sqlDataReader[nombre].ToString();
                        PropertyInfo propiedad = obj.GetType().GetProperty(nombre);
                        propiedad.SetValue(obj, Convert.ChangeType(valor, propiedad.PropertyType), null);

                    }
                    objetos.Add(obj);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlDataReader.Close();
                connection.Close();
            }

            return objetos;
        }


        /*
        * Obtiene un diccionario con el nombre de la propiedad y su valor
        */
        protected static Dictionary<string, object> ObtenerDictionaryValorPropiedades(object objeto)
        {
            Dictionary<string, object> mapM = new Dictionary<string, object>();
            foreach (PropertyInfo method in objeto.GetType().GetProperties())
            {
                mapM.Add(method.Name, method.GetValue(objeto, null));
            }
            return mapM;
        }
        /*
        * Se obtiene una lista con el nombre de las propiedades para, posteriormente, hacer el set
        */
        public static List<string> ObtenerNombrePropiedades(Type clase)
        {
            List<string> lista = new List<string>();
            //Recorremos las propiedades y almacenamos el nombre
            foreach (PropertyInfo propiedad in clase.GetProperties())
            {
                lista.Add(propiedad.Name);
            }

            return lista;
        }
        public static string ObtenerValorClavePrimaria(object objeto)
        {
            foreach (PropertyInfo propiedad in objeto.GetType().GetProperties())
            {
                if (propiedad.Name.StartsWith("Cod"))
                {
                    return Convert.ToString(propiedad.GetValue(objeto, null));
                }
            }
            return null;
        }
        public string ObtenerCodigo(Type clase)
        {
            string sql = "SELECT MAX(cod" + clase.Name.Substring(1) + ") FROM " + clase.Name.ToLower();
            MySqlDataReader sqlDataReader = null;
            try
            {
                comando = new MySqlCommand(sql, connection);
                //Introduce los datos en la tabla
                sqlDataReader = comando.ExecuteReader();
                return sqlDataReader.GetString(1);
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                sqlDataReader.Close();
            }
        }

        public List<string> ObtenerTemas()
        {
            List<string> temas = new List<string>();
            string sql = "SELECT * FROM tema";
            MySqlDataReader sqlDataReader = null;
            try
            {
                comando = new MySqlCommand(sql, connection);
                sqlDataReader = comando.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    temas.Add(sqlDataReader.GetString(1));
                }
                return temas;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                sqlDataReader.Close();
            }
        }

        public void StartTransaction()
        {
            transaccion = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaccion.Commit();
        }

        public void Rollback()
        {
            transaccion.Rollback();
        }
    }
}
