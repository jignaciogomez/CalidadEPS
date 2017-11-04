using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatosCalidad
{
    public class DatosEL
    {
        public string codigo_categoria { get; set; }
        public string nombre_categoria { get; set; }
        public string codigo_eps { get; set; }
        public string nombre_EPS { get; set; }
        public string nomservicio { get; set; }
        public string nomespecifique { get; set; }
        public string nomidentificador { get; set; }
        public int numerador { get; set; }
        public int demoninador { get; set; }
        public int resultado { get; set; }
        public string nomunidad { get; set; }
        public string nomfuente { get; set; }
        public string linkfuente { get; set; }
    }
}