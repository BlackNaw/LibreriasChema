using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Persistencia
{
    interface IAcceso<obj>
    {
        bool Insertar(obj obj);
        bool Borrar(object objeto);
        Object Buscar(Type clase, String nombre);
        List<object> Obtener(Type clase);
        bool Modificar(string nombre, obj obj);
        bool BorradoVirtual(object objeto);
        List<object> Buscar(Type clase, string campo, string busqueda);
    }
}
