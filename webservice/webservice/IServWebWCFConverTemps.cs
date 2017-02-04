using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace webservice
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract(Namespace = "miServicio")]
    public interface IServWebWCFConverTemps
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        double ConvCentAFahr(double gCent);

        [OperationContract]
        double ConvFahrACent(double gFahr);

        [OperationContract]
        Detalles ResultadoDetallado(Detalles detalle);
    }

    [DataContract(Namespace = "miServicio")]
    public class Detalles
    {
        private bool _sonCentigrados;
        private string _literal;
        private double _grados;


        [DataMember]
        public bool SonCentigrados
        {
            get { return _sonCentigrados; }
            set { _sonCentigrados = value; }
        }

        [DataMember]
        public string Literal
        {
            get { return _literal; }
            set { _literal = value; }
        }

        [DataMember]
        public double Grados
        {
            get { return _grados; }
            set { _grados = value; }
        }
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
 