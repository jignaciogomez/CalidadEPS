using System;
using System.Collections.Generic;
using System.Linq;
using Datos_Calidad.ServicioCalidad;

namespace DatosCalidad
{
    public class DatosWCF
    {
        /// <summary>
        ///    Carga informacion general de las estadisticas una EPS
        /// </summary>
        /// <param name="EPS">Codigo de la EPS a consultar</param>
        /// <returns>Lista de estadisticas</returns>
        public List<Dato> DatosGenerales(string EPS)
        {
            var servicio = new Service1Client();
            var datos = servicio.ObtenerDatos(EPS).ToList() ;
            return datos;
        }

        /// <summary>
        ///    Carga informacion general de los dropdownlist
        /// </summary>
        /// <param name="Opcion">Consulta el id de la opcion de la informacion a reportar</param>
        /// <returns>Lista de datos</returns>
        public List<CargarDatosCargaDatos> CargaCombos(string Opcion)
        {
            var servicio = new Service1Client();
            var datosCombo = servicio.CargarObjetos(Opcion).ToList();
            return datosCombo;
        }

        /// <summary>
        ///    Envia informacion general la encuesta realizada
        /// </summary>
        /// <param name="Respuesta">lista de las respuestas generadas</param>
        /// <returns>Entero 1 correcto y o incorrecto</returns>
        public int CargarEncuesta(int pregunta, int respuesta, string EPS)
        {
            var servicio = new Service1Client();
            int respuestaEncuesta = servicio.CargueEncuesta(pregunta, respuesta,EPS);
            return respuestaEncuesta;
        }

        public List<CargaBarra> carga_Barra(string EPS)
        {
            var servicio = new Service1Client();
            var datos = servicio.Carga_Barra(EPS).ToList();
            return datos;
        }

        public List<CargaBarra> carga_torta(string EPS)
        {
            var servicio = new Service1Client();
            var datos = servicio.Carga_Torta(EPS).ToList();
            return datos;
        }

    }
     
}

