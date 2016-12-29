using LibreriaV3._1.Comun;
using LibreriaV3._1.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Persistencia
{
    class AccesoDAO<T> : IAcceso<T> where T : new()
    {
        public bool BorradoVirtual(object objeto)
        {
            AccesoBD acceso = new AccesoBD();
            acceso.StartTransaction();
            string sql;
            foreach (var item in objeto.GetType().GetProperties())
            {
                if (item.Name.Contains("Borra"))
                {
                    item.SetValue(objeto, 1);
                }
            }
            if ((sql = ExisteSentencia("BorradoVirtual" + objeto.GetType().Name)) == null)
            {
                if (acceso.Insertar(UtilSQL.SqlModificar(objeto), objeto, AccesoBD.ObtenerValorClavePrimaria(objeto)))
                {
                    acceso.Commit();
                    return true;
                }
            }
            else
            {
                if (acceso.Insertar(sql, objeto, AccesoBD.ObtenerValorClavePrimaria(objeto)))
                {
                    acceso.Commit();
                    return true;
                }
            }
            acceso.Rollback();
            return false;
        }

        public bool Borrar(object objeto)
        {
            AccesoBD accesoBD = new AccesoBD();
            accesoBD.StartTransaction();
            String sql;
            if ((sql = ExisteSentencia("DELETE" + objeto.GetType().Name)) == null)
            {
                if (accesoBD.Borrar(GuardarSQL("DELETE" + objeto.GetType().Name, UtilSQL.SqlBorrar(objeto)), objeto))
                {
                    accesoBD.Commit();
                    return true;
                }
            }
            else
            {
                if (accesoBD.Borrar(sql, objeto))
                {
                    accesoBD.Commit();
                    return true;
                }
            }
            accesoBD.Rollback();
            return false;
        }

        public object Buscar(Type clase, string nombre)
        {
            List<object> list = null;
            AccesoBD accesoBD = new AccesoBD();
            String sql;
            if ((sql = ExisteSentencia("SELECTONE" + clase.Name)) == null)
            {
                if ((list = accesoBD.Consultar(GuardarSQL("SELECTONE" + clase.Name, UtilSQL.SqlBuscar(clase)), clase, nombre)).Count == 0)
                {
                    return null;
                }
            }
            else
            {
                if ((list = accesoBD.Consultar(sql, clase, nombre)).Count == 0)
                {
                    return null;
                }
            }
            return list.First();
        }

        public List<object> Buscar(Type clase, string campo, string busqueda)
        {
            AccesoBD acceso = new AccesoBD();
            String sql = "SELECT * FROM " + clase.Name + " WHERE " + campo + " = \"" + busqueda + "\"";
            return acceso.Consultar(sql, clase, "");
        }

        public bool Insertar(T objeto)
        {
            AccesoBD accesoBD = new AccesoBD();
            accesoBD.StartTransaction();
            String sql;
            if ((sql = ExisteSentencia("INSERT" + objeto.GetType().Name)) == null)
            {
                if (accesoBD.Insertar(GuardarSQL("INSERT" + objeto.GetType().Name, UtilSQL.SqlInsertar(objeto)), objeto, ""))
                {
                    accesoBD.Commit();
                    return true;
                }
            }
            else
            {
                if (accesoBD.Insertar(sql, objeto, ""))
                {
                    accesoBD.Commit();
                    return true;
                }
            }
            accesoBD.Rollback();
            return false;
        }

        public bool Modificar(string nombre, T obj)
        {
            AccesoBD accesoBD = new AccesoBD();
            accesoBD.StartTransaction();
            String sql;
            if ((sql = ExisteSentencia("UPDATE" + obj.GetType().Name)) == null)
            {
                if (accesoBD.Insertar(GuardarSQL("UPDATE" + obj.GetType().Name, UtilSQL.SqlModificar(obj)), obj, nombre))
                {
                    accesoBD.Commit();
                    return true;
                }
            }
            else
            {
                if (accesoBD.Insertar(sql, obj, nombre))
                {
                    accesoBD.Commit();
                    return true;

                }
                accesoBD.Rollback();
            }
            return false;
        }

        public List<object> Obtener(Type clase)
        {
            AccesoBD accesoBD = new AccesoBD();
            String sql;
            if ((sql = ExisteSentencia("SELECTALL" + clase.Name)) == null)
            {
                return accesoBD.Consultar(GuardarSQL("SELECTALL" + clase.Name, UtilSQL.SqlObtener(clase)), clase, "");
            }
            else
            {
                return accesoBD.Consultar(sql, clase, "");

            }
        }

        private String ExisteSentencia(String orden)
        {
            foreach (var item in Util.getSENTENCIAS())
            {
                if (item.Key.Equals(orden))
                {
                    return item.Value;
                }
            }
            return null;
        }

        private String GuardarSQL(String orden, String sql)
        {
            Util.getSENTENCIAS().Add(orden, sql);
            return sql;
        }

        public List<string> ObtenerTemas()
        {
            AccesoBD accesoBD = new AccesoBD();
            return accesoBD.ObtenerTemas();
        }
    }
}