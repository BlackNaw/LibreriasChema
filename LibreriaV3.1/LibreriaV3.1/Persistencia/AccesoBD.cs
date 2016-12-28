using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        protected void StartTrasaction()
        {
            transaccion = connection.BeginTransaction();
        }
        protected void Commit()
        {
            transaccion.Commit();
        }

        protected void Rollback()
        {
            transaccion.Rollback();
        }
        public string ObtenerCodigo(Type clase)
        {
            string sql = "SELECT MAX(cod" + clase.Name.Substring(1) + ") FROM " + clase.Name.ToLower();
            MySqlDataReader sqldataReader = null;
            try
            {
                comando = new MySqlCommand(sql, connection);
                sqldataReader = comando.ExecuteReader();
                return sqldataReader.GetString(1);
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ConexionJDBC.CerrarConexion();
                sqldataReader.Close();
            }
        }
        public List<string> ObtenerTemas()
        {
            List<string> temas = new List<string>();
            MySqlDataReader sqlDataReader = null;
            string sql = "SELECT * FROM tema";
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
                ConexionJDBC.CerrarConexion();
                sqlDataReader.Close();
            }
        }

        protected static Dictionary<string, object> ObtenerDictionaryValorPropiedades(object objeto)
        {
            Dictionary<string, object> mapM = new Dictionary<string, object>();
            foreach (PropertyInfo method in objeto.GetType().GetProperties())
            {
                mapM.Add(method.Name, method.GetValue(objeto, null));
            }

            return mapM;
        }
        public static List<string> ObtenerNombrePropiedades(object objeto)
        {
            List<string> lista = new List<string>();
            //Recorremos las propiedades y almacenamos el nombre
            foreach (PropertyInfo propiedad in objeto.GetType().GetProperties())

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
                    return Convert.ToString(propiedad.GetValue(objeto, null));
            }
            return null;
        }

        public bool Insertar(string sql, object objeto, string antiguo)
        {
            try
            {
                comando = new MySqlCommand(sql, connection);
                Dictionary<string, object> map = ObtenerDictionaryValorPropiedades(objeto);
                int index = 1;
                foreach (string valor in map.Keys)
                {
                    comando.Parameters.Insert(index, valor);
                }
                if (sql.Contains("UPDATE"))
                {
                    comando.Parameters.Insert(index, antiguo);
                }
                return comando.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                ConexionJDBC.CerrarConexion();
            }
        }

        public bool Borrar(string sql, object objeto)
        {
            try
            {
                comando = new MySqlCommand(sql, connection);
                comando.Parameters.AddWithValue("@1", ObtenerValorClavePrimaria(objeto);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ConexionJDBC.CerrarConexion();
            }
            return comando.ExecuteNonQuery() > 0;
        }

        public List<object> Consultar(string sql, Type clase, string nombre)
        {
            List<object> objetos = null;
            object objeto;
            MySqlDataReader sqlDataReader = null;
            List<object> list;
            try
            {
                comando = new MySqlCommand(sql, connection);
                if (!nombre.Equals(""))
                {
                    comando.Parameters.Insert(1,nombre);
                }
                sqlDataReader = comando.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}
