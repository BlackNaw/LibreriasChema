using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Negocio
{
    class TLineaFactura
    {
        public string CodFactura { get; set; }

        public string Libro{ get; set; }

        public string Cantidad { get; set; }

        public string Total{ get; set; }

        public TLineaFactura(string codFactura, string libro, string cantidad, string total)
        {
            CodFactura = codFactura;
            Libro = libro;
            Cantidad = cantidad;
            Total = total;
        }

        public TLineaFactura() { }

        public override string ToString()
        {
            return Libro+" - "+Cantidad+" - "+Total;
        }
    }
}
