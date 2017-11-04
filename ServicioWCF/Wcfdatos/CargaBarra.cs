using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Wcfdatos
{
    [DataContract]
    public class CargaBarra
    {
        [DataMember]
        public string Nomservicio { get; set; }
        [DataMember]
        public string nombre_categoria { get; set; }
        [DataMember]
        public int resultado { get; set; }
    }
}