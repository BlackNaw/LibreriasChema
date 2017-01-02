using LibreriaV3._1.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Negocio
{
    class TFactura
    {
        public string CodFactura { get; set; }

        public string Cliente { get; set; }

        public string FechaFactura { get; set; }

        public string Borrado { get; set; }

        public TFactura(string codFactura, string cliente, string fechaFactura, string borrado)
        {
            CodFactura = codFactura;
            Cliente = cliente;
            FechaFactura = fechaFactura;
            Borrado = borrado;
        }

        public TFactura() { }

        public TFactura(string cliente, string fechaFactura)
        {
            CodFactura = Util.GenerarCodigo(this.GetType());
            Cliente = cliente;
            FechaFactura = fechaFactura;
            Borrado = "0";
        }

        public override string ToString()
        {
            return CodFactura + " - " + Cliente;
        }

    }
}
