using LibreriaV3._1.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Negocio
{
    class ControlAccesoDAO<T> : IAcceso<T> where T : new()
    {
        AccesoDAO<T> obAccesoDAO = new AccesoDAO<T>();

        public bool BorradoVirtual(object objeto)
        {
            return ((IAcceso<T>)obAccesoDAO).BorradoVirtual(objeto);
        }

        public bool Borrar(object objeto)
        {
            return ((IAcceso<T>)obAccesoDAO).Borrar(objeto);
        }

        public object Buscar(Type clase, string nombre)
        {
            return ((IAcceso<T>)obAccesoDAO).Buscar(clase, nombre);
        }

        public List<object> Buscar(Type clase, string campo, string busqueda)
        {
            return ((IAcceso<T>)obAccesoDAO).Buscar(clase, campo, busqueda);
        }

        public bool Insertar(T obj)
        {
            return ((IAcceso<T>)obAccesoDAO).Insertar(obj);
        }

        public bool Modificar(string nombre, T obj)
        {
            return ((IAcceso<T>)obAccesoDAO).Modificar(nombre, obj);
        }

        public List<object> Obtener(Type clase)
        {
            return ((IAcceso<T>)obAccesoDAO).Obtener(clase);
        }
    }
}
