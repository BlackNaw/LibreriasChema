using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Persistencia
{
        interface IAcceso<ClaseGenerica>
    {
        /**
	 * Da de alta el objeto, lo introduce si no existe aún
	 * 
	 * @param obj
	 *            Nuevo objeto a dar de alta
	 * @return booleano -Indica si el alta ha sido satisfactoria(true) o
	 *         no(false)
	 */
        bool Insertar(ClaseGenerica obj);

        /**
        * Realiza un Update del campo borrado del objeto con el nombre indicado
        * 
        * @param nombre
        *            - Nombre del objeto a Borrar
        * @return booleano -Indica si la baja ha sido satisfactoria(true) o
        *         no(false)
        */
        bool BorradoVirtual(String nombre);

        /**
         * Elimina el objeto con el nombre indicado
         * 
         * @param nombre
         *            - Nombre del objeto a Borrar
         * @return booleano -Indica si la baja ha sido satisfactoria(true) o
         *         no(false)
         */
        bool Borrar(String nombre);

        /**
         * Busca el objeto con el nombre proporcionado
         * 
         * @param nombre
         *            - Nombre del objeto a Buscar
         * @return ClaseGenerica - Devuelve el objeto si ha sido encontrado si no
         *         retorna null
         */
        ClaseGenerica Buscar(String nombre);

        /**
         * Devuelve el conjunto de objetos en una colección.
         * 
         * @return colección
         */
        List<ClaseGenerica> Obtener();

        /**
         * Modifica el objeto anterior por el nuevo
         * 
         * @param nombre
         *            Nombre del objeto sin Modificar
         * @param obj
         *            Modificado
         * @return true si se modificó y false en caso contrario
         */
        bool Modificar(String nombre, ClaseGenerica obj);

    }
}
