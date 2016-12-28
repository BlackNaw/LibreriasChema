using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Persistencia
{
    interface IAcceso<obj>
    {
        bool insertar(obj obj);
        bool borrar(object objeto);
        Object buscar(Type clase, String nombre);
        ArrayList obtener(Type clase);
        bool modificar(string nombre, obj obj);
        bool borradoVirtual(object objeto)
    }
}
