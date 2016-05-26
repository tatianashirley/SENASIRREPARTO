using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfNovedades.Logica;
using wcfSeguridad.Logica;

using System.Drawing;

//using WcfServicioClasificador.Logica;

public partial class Novedades_wfrmBusquedaNovedades : System.Web.UI.Page
{



    
    protected void Page_Load(object sender, EventArgs e)
    {
 
        if (!Page.IsPostBack)
        {
            if (Session["IdConexion"] == null) return;
            String IdConexion = Convert.ToString((int)Session["IdConexion"]);
            const String Operacion = "A";
            String iSesionTrabajo = null;
            String sSSN = null;
            String iIdRol = null;
            const int Transac = 1100000;

            //clsSeguridad habilita = new clsSeguridad();
            //int resultado = Master.HabilitaTransaccion(Transac);
            imgbtnBuscar.Enabled = true;
            /*
            Int32 resultado = Master.HabilitaTransaccion(Transac);
            if (resultado == 1) { imgbtnBuscar.Enabled = true; }
            else { imgbtnBuscar.Enabled = false; imgbtnBuscar.ImageUrl = "~/Imagenes/32Buscar_disable.png"; }
             * */
            Cargar_Grid();
        }
    }
    //-------------------------------------------------------------------------------------------------

    protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
    {

        Cargar_Grid();
    }

    protected void imgbtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {

        LimpiarBusqueda();
    }

    private void Cargar_Grid()
    {

        string ci = this.TextCI.Text;
        string cua = this.TextCua.Text; 
        string app = this.TextPaterno.Text;
        string apm = this.TextMaterno.Text;
        string nom1 = this.TextNom1.Text;
        string nom2 = this.TextNom2.Text;
        string tipo = this.ddlTipoCertificado.SelectedValue;
        if (ci != "" |  cua != "" | app != "" | apm != "" | nom1 != "" | nom2 != "")
        {
            int IdConexion = (int)Session["IdConexion"];
            string sMensajeError = "";
            clsNovedades busca = new clsNovedades();
            gvNovedades.DataSource = busca.ListarTitDH1(IdConexion, ref sMensajeError,ci, cua, app, apm, nom1, nom2, tipo);
            gvNovedades.DataBind();
            if (sMensajeError.Length!=0)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
        }
        else LimpiarBusqueda();
    
    }



    protected void gvNovedades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNovedades.PageIndex = e.NewPageIndex;
        Cargar_Grid();
    }

    protected void LimpiarBusqueda()
    {
        this.TextCua.Text = "";
        this.TextPaterno.Text = "";
        this.TextMaterno.Text = "";
        gvNovedades.DataSource = null;
        gvNovedades.DataBind();
        const int Transac = 1100000;
        //Int32 resultado = Master.HabilitaTransaccion(Transac);
        //if (resultado == 1) { imgbtnBuscar.Enabled = true; }
        //else { imgbtnBuscar.Enabled = false; imgbtnBuscar.ImageUrl = "~/Imagenes/32Buscar_disable.png"; }
    }
    protected void gvNovedades_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvNovedades.SelectedRow;
        string Tipo = Convert.ToString(gvNovedades.DataKeys[row.RowIndex].Values["Tipo"]).ToUpper();
        string Certificado = Convert.ToString(gvNovedades.DataKeys[row.RowIndex].Values["Certificado"]).ToUpper();
        string IdTipoCertificado = Convert.ToString(gvNovedades.DataKeys[row.RowIndex].Values["IdTipoCertificado"]).ToUpper();
        string NUP = Convert.ToString(gvNovedades.DataKeys[row.RowIndex].Values["NUP"]).ToUpper();
        Session["Tipo"] = Tipo;
        Session["Certificado"] = Certificado;
        Session["TipoCertificado"] = IdTipoCertificado;
        Session["NUP"] = NUP;
        if (Tipo=="TITULAR") Response.Redirect("wfrmRegistraF03.aspx");
        else Response.Redirect("wfrmRegistraF04.aspx");


    }
    protected void ddlTipoCertificado_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Grid();
    }
}

