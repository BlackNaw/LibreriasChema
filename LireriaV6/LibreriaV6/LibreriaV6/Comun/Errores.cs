using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Comun
{
    class Errores : Exception
    {
        Exception _error;

        /**
         * Construye un mensaje de _error a traves del tipo de excepcion
         * 
         * @param e
         */
        public Errores(Exception e)
        {
            _error = e;
        }

        public override string Message { get; }
    }
}
