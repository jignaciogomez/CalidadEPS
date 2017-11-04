using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Wcfdatos
{
    public class CargarDatos
    {
        [DataContract]
        public class CargaDatos
        {
            [DataMember]
            public string codigo { get; set; }
            [DataMember]
            public string Descripcion { get; set; }
        }

    }
}