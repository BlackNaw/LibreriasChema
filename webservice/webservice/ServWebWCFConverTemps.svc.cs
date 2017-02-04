using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace webservice
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServWebWCFConverTemps" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServWebWCFConverTemps.svc o ServWebWCFConverTemps.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServWebWCFConverTemps : IServWebWCFConverTemps
    {
        public double ConvCentAFahr(double gCent)
        {
            double grados = Math.Round(9.0 / 5.0 * gCent + 32.0, 2);
            return grados;
        }

        public double ConvFahrACent(double gFahr)
        {
            double grados = Math.Round(((gFahr - 32.0) * 5.0) / 9.0, 2);
            return grados;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Detalles ResultadoDetallado(Detalles detalle)
        {
            if (detalle == null)
            {
                throw new ArgumentNullException("detalle");
            }
            if (detalle.SonCentigrados)
                detalle.Literal = ConvCentAFahr(detalle.Grados) +
                                  " grados fahrenheit.";
            else
                detalle.Literal = ConvFahrACent(detalle.Grados) +
                                  " grados centígrados.";
            return detalle;
        }
    }
}
