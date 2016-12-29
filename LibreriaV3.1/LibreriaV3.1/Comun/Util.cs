using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using LibreriaV3._1.Persistencia;

namespace LibreriaV3._1.Comun
{
    class Util
    {
        //private static string ruta = Path.Combine(Application.StartupPath, "files\\sql.txt");
        private static string ruta = "sql.txt";
        private static Dictionary<string, string> SENTENCIAS;
        static BinaryFormatter serializer = new BinaryFormatter();

        public static Dictionary<string, string> getSENTENCIAS()
        {
            return SENTENCIAS;
        }



        public static void RellenarDictionarySentencias()
        {
            if (ComprobarArchivo() && File.ReadAllLines(ruta).Count() > 0)
            {
                using (var stream = File.OpenRead(ruta))
                {
                    SENTENCIAS = (Dictionary<string, string>)serializer.Deserialize(stream);
                }

            }
            else
            {
                SENTENCIAS = new Dictionary<string, string>();
            }
        }

        public static void EscribirDictionarySentenciasFichero()
        {
            if (ComprobarArchivo())
            {
                using (var stream = File.OpenWrite(ruta))
                {
                    serializer.Serialize(stream, SENTENCIAS);
                }
            }
        }

        private static bool ComprobarArchivo()
        {
            if (!File.Exists(ruta))
            {
                try
                {
                    File.Create(ruta);
                }
                catch
                {
                    //Errores.controlError(new Errores(Errores.ERROR_FICHERO));
                    return false;
                }
            }
            return true;
        }
        public static String GenerarCodigo(Type clase)
        {
            string codigo = new AccesoBD().ObtenerCodigo(clase);
            if (codigo == null)
            {
                return "cod001";
            }
            int indice = int.Parse(codigo.Substring(3)) + 1;
            if (indice >= 10)
                return "cod0" + indice;
            else if (indice >= 100)
                return "cod" + indice;
            else
                return "cod00" + indice;
        }
    }
}