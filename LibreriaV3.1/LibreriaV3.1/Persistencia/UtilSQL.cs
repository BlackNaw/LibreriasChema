using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Persistencia
{
    class UtilSQL
    {
        private static StringBuilder sql = new StringBuilder();

        public static string SqlInsertar(object objeto)
        {
            sql.Clear();
            sql.Append("INSERT INTO " + objeto.GetType().Name.ToLower() + " ( ");
            RellenarSql(AccesoBD.ObtenerNombrePropiedades(objeto.GetType()));
            return sql.ToString();
        }

        public static string SqlBuscar(Type clase)
        {
            sql.Clear();
            sql.Append("SELECT * FROM " + clase + " WHERE " + obtenerClave(clase) + " = @1 ");
            return sql.ToString();
        }

        public static string SqlBorrar(object objeto)
        {
            sql.Clear();
            sql.Append("DELETE FROM " + objeto.GetType().Name.ToLower() + " WHERE " + obtenerClave(objeto.GetType()) + " = @1 ");
            return sql.ToString();
        }

        public static String SqlObtener(Type clase)
        {
            sql.Clear();
            sql.Append("SELECT * FROM " + clase.Name.ToLower());
            return sql.ToString();
        }
        public static String SqlModificar(object objeto)
        {
            sql.Clear();
            sql.Append("UPDATE " + objeto.GetType().Name.ToLower() + " SET ");
            int index = 1;
            foreach (string item in AccesoBD.ObtenerNombrePropiedades(objeto.GetType()))
            {
                sql.Append(item + " = @" + index++ + " , ");
            }
            sql.Remove(sql.Length - 2, sql.Length);
            sql.Append(" WHERE " + obtenerClave(objeto.GetType()) + " = @" + index);
            return sql.ToString();
        }
        private static string obtenerClave(Type clase)
        {
            foreach (string item in AccesoBD.ObtenerNombrePropiedades(clase))
            {
                if (item.StartsWith("Cod"))
                    return item;
            }
            return null;
        }
        private static void RellenarSql(List<string> list)
        {
            StringBuilder cadena = new StringBuilder(" ) VALUES ( ");
            int index = 1;
            foreach (string item in list)
            {
                sql.Append(item + ", ");
                cadena.Append("@" + (index++) + " , ");
            }
            sql.Remove(sql.Length - 2, sql.Length);
            sql.Append(cadena.Remove(sql.Length - 2, sql.Length) + ")");
        }
    }
}
