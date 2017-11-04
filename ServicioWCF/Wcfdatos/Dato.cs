using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Wcfdatos
{
        [DataContract]
        public class Dato
        {
            [DataMember]
            public string codigo_categoria { get; set; }
            [DataMember]
            public string nombre_categoria { get; set; }
            [DataMember]
            public string codigo_eps { get; set; }
            [DataMember]
            public string nombre_EPS { get; set; }
            [DataMember]
            public string nomservicio { get; set; }
            [DataMember]
            public string nomespecifique { get; set; }
            [DataMember]
            public string nomidentificador { get; set; }
            [DataMember]
            public int numerador { get; set; }
            [DataMember]
            public int demoninador { get; set; }
            [DataMember]
            public int resultado { get; set; }
            [DataMember]
            public string nomunidad { get; set; }
            [DataMember]
            public string nomfuente { get; set; }
            [DataMember]
            public string linkfuente { get; set; }
        }

}
