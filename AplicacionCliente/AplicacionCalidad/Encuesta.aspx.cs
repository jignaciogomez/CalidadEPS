using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatosCalidad;

namespace AplicacionCalidad
{
    public partial class Encuesta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                try
                {
                    Cargar_Combo(DDLDatoEPS, "1");
                }
                catch (Exception ex)
                {
                }
        }

        /// <summary>
        ///     Carga cualquier combo que se quiera cargar
        /// </summary>
        private void Cargar_Combo(DropDownList Combo, string Carga)
        {
            try
            {
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
        ///     Almacena los datos seleccionados en la encuesta
        /// </summary>
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var datos = new DatosWCF();
                var a = datos.CargarEncuesta(1, int.Parse(RbPreg1.SelectedValue), DDLDatoEPS.SelectedValue);
                a = datos.CargarEncuesta(2, int.Parse(Rbpreg2.SelectedValue), DDLDatoEPS.SelectedValue);
                a = datos.CargarEncuesta(3, int.Parse(Rbpreg3.SelectedValue), DDLDatoEPS.SelectedValue);
                ScriptManager.RegisterStartupScript(this, GetType(), "alertIns",
                    "alert('El registro se guardó correctamente');", true);
                //string str_java;
                //str_java = "<script language='javascript'>";
                //str_java += " window.close();";
                //str_java += "</script>";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(),"" ,str_java,true);
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
        }
    }
}