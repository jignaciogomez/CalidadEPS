using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcfdatos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
   [ServiceContract]
   public interface IService1
    {
       [OperationContract]
       List<Dato> ObtenerDatos(string CodigoEPS);

       [OperationContract]
       List<CargarDatos.CargaDatos> CargarObjetos(string Opcion);

       [OperationContract]
       int CargueEncuesta(int pregunta, int respuesta, string Codigo_EPS);

       [OperationContract]
       List<CargaBarra> Carga_Barra(string EPS);

       [OperationContract]
       List<CargaBarra> Carga_Torta(string EPS);

    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
 
}
