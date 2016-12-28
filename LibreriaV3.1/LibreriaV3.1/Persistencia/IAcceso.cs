using System;
using System.Collections.Generic;
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
        List<string> obtener(Type clase);
        bool modificar(string nombre, obj obj);
        bool borradoVirtual(object objeto)
    }
}
