using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using DatosCalidad;
using Telerik.Web.UI;

namespace AplicacionCalidad
{
    public partial class Calidad : System.Web.UI.Page
    {
        //string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
        //SqlConnection sql = new SqlConnection();
        private List<Datos_Calidad.ServicioCalidad.Dato> DatosGeneralesgrilla
        {
            get { return (List<Datos_Calidad.ServicioCalidad.Dato>)HttpContext.Current.Session["GrillaDatosGenerales"]; }
            set { HttpContext.Current.Session["GrillaDatosGenerales"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //sql.ConnectionString = conexion;
                try
                {
                    Cargar_Combo(DDLDatoEPS, "1");
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void GridDatosCalidad_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            GridDatosCalidad.DataSource = DatosGeneralesgrilla;
        }
        //DataTable Cargar(string query)
        //{
        //    //DataTable tabla = new DataTable();
        //    SqlDataAdapter table = new SqlDataAdapter(query, sql);
        //    table.Fill(tabla);
        //    return tabla;
        //}
        /// <summary>
        ///    Carga cualquier combo que se quiera cargar
        /// </summary>
        /// <param name="Combo">Nombre de combo a cargar</param>
        /// <param name="Carga">opcion de datos a consultar</param>
        /// <returns>Lista de datos</returns>
        void Cargar_Combo(DropDownList Combo, string Carga)
        {
                try
                {
                //sql.Open();
                //string query = "exec Cargar_combos " + Carga;
                //sql.Close();
                var datos = new DatosWCF();
                var lista = datos.CargaCombos(Carga);
                Combo.DataTextField = "Descripcion";
                Combo.DataValueField = "Codigo";
                Combo.DataSource = lista;
                Combo.DataBind();
                }
                catch (Exception ex)
                {
                }
        }

        /// <summary>
        ///   Selecciona una EPS y carga los demas objetos
        /// </summary>
        protected void DDLDatoEPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var datos = new DatosWCF();
                //= conexion;
                string EPS = DDLDatoEPS.SelectedValue;
                LblGraficas.Visible = true;
                LblGrilla.Visible = true;
                // string query = "select Nomservicio + ' '+ CONVERT(VARCHAR, sum(resultado)/count(0)) as Nomservicio, sum(resultado)/count(0) as resultado from [dbo].[CalidadSaludEPS] where codigo_eps = '" + EPS + "' group by  Nomservicio ";
                var listaBarra = datos.carga_torta(EPS);
                Chart1.DataSource = listaBarra;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart1.Series["Series1"].LegendToolTip = "nombre_categoria";
                Chart1.Series["Series1"].XValueMember = "Nomservicio";
                Chart1.Series["Series1"].YValueMembers = "resultado";

                Series series1 = Chart1.Series[0];
                
                series1["CollectedThreshold"] = "5";
  
                // Set the label of the collected pie slice
               series1["CollectedLabel"] = "Otros";

                // Set the legend text of the collected pie slice
               series1["CollectedLegendText"] = "Other";

                //sql.ConnectionString = conexion;
                var listaTorta = datos.carga_Barra(EPS);
                Chart2.DataSource = listaTorta;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart2.Series["Series1"].XValueMember = "Nombre_categoria";
                Chart2.Series["Series1"].YValueMembers = "resultado";
                Chart2.Series["Series1"].AxisLabel = "resultado";

                DatosGeneralesgrilla = datos.DatosGenerales(EPS);
                GridDatosCalidad.DataSource = DatosGeneralesgrilla;
                GridDatosCalidad.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        ///    hace llamado a la encuesta de la EPS del usuario
        /// </summary>
        protected void LnkEncuesta_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('encuesta.aspx' ,'Encuesta','height=300', 'width=300')</script>");
        }
    }
}