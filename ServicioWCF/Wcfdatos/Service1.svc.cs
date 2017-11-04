using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace Wcfdatos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        public List<Dato> ObtenerDatos(string EPS)
        {

            string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (sql)
                {
                    sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Calidad where codigo_EPS ='" + EPS + "'", sql);
                    da.Fill(ds);
                    var ldatos = new List<Dato>();
                    foreach (DataRow s in ds.Tables[0].Rows)
                    {
                        var dt = new Dato();
                        dt.codigo_categoria = s[0].ToString();
                        dt.nombre_categoria = s[1].ToString();
                        dt.codigo_eps = s[2].ToString();
                        dt.nombre_EPS = s[3].ToString();
                        dt.nomservicio = s[4].ToString();
                        dt.nomespecifique = s[5].ToString();
                        dt.nomidentificador = s[6].ToString();
                        dt.numerador = int.Parse(s[7].ToString());
                        dt.demoninador = int.Parse(s[8].ToString());
                        dt.resultado = int.Parse(s[9].ToString());
                        dt.nomunidad = s[10].ToString();
                        dt.nomfuente = s[10].ToString();
                        dt.linkfuente = s[10].ToString();
                        ldatos.Add(dt);
                    }
                    return ldatos;
                }
                //return ds.Tables[0]. list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<CargaBarra> Carga_Barra(string EPS)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;
           // DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (sql)
                {
                    sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("exec Cargar_Barra '" + EPS + "'", sql);
                    da.Fill(ds);
                    var ldatos = new List<CargaBarra>();
                    foreach (DataRow s in ds.Tables[0].Rows)
                    {
                        var dt = new CargaBarra() ;
                        dt.Nomservicio= s[0].ToString();
                        dt.nombre_categoria = s[1].ToString();
                        dt.resultado = Int32.Parse(s[2].ToString()); 
                        ldatos.Add(dt);
                    }
                    return ldatos;
                }
                //return ds.Tables[0]. list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<CargaBarra> Carga_Torta(string EPS)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;
            // DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (sql)
                {
                    sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("exec Cargar_Torta '" + EPS + "'", sql);
                    da.Fill(ds);
                    var ldatos = new List<CargaBarra>();
                    foreach (DataRow s in ds.Tables[0].Rows)
                    {
                        var dt = new CargaBarra();
                        dt.Nomservicio = s[0].ToString();
                        dt.nombre_categoria = s[1].ToString();
                        dt.resultado = Int32.Parse(s[2].ToString());
                        ldatos.Add(dt);
                    }
                    return ldatos;
                }
                //return ds.Tables[0]. list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public List<CargarDatos.CargaDatos> CargarObjetos(string Opcion)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (sql)
                {
                    sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("exec Cargar_combos " + Opcion, sql);
                    da.Fill(ds);
                    var ldatos = new List<CargarDatos.CargaDatos>();
                    foreach (DataRow s in ds.Tables[0].Rows)
                    {
                        var dt = new CargarDatos.CargaDatos();
                        dt.codigo= s[0].ToString();
                        dt.Descripcion = s[1].ToString();
                        ldatos.Add(dt);
                    }
                    return ldatos;
                }
                //return ds.Tables[0]. list;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public int CargueEncuesta(int pregunta, int respuesta, string Codigo_EPS)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                sql.Open();
                SqlDataAdapter da = new SqlDataAdapter("exec Inserta_Encuesta " + pregunta + " ," + respuesta + ",'" + Codigo_EPS + "'", sql);
                da.Fill(ds);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}