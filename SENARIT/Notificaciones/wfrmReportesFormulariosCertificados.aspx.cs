using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfNotificacion.Logica;

public partial class Notificaciones_wfrmReportesFormulariosCertificados : System.Web.UI.Page
{
    #region Variables
    
    clsReportes reporte = new clsReportes();
    string mensaje,cUsuario;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["IdConexion"] == null)
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
            HttpContext.Current.Server.ScriptTimeout = 2400;
            ddlProcedimiento();
            ddlRegionales();
        }
    }
    #region Metodos
    
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        string IdTipoReporte,IdProcedimiento,Regional,contentUrl,IdReporte;

        if (Convert.ToInt32(ddlTipoReporte.SelectedValue) != 0)
        {
            //cUsuario = reporte.CuentaUsuario((int)Session["IdConexion"], "C", ref mensaje).Rows[0]["CuentaUsuario"].ToString();
            IdTipoReporte = ddlTipoReporte.SelectedValue.ToString();
            IdProcedimiento = ddlProcedimientos.SelectedValue.ToString();
            Regional = ddlRegional.SelectedValue.ToString();
            DateTime Ini, Fin;
            Ini = Convert.ToDateTime(txtFechaDesde.Text);
            Fin = Convert.ToDateTime(txtFechaHasta.Text);
            string IniA, FinA;
            IniA = Ini.ToString("yyyy-MM-dd");
            FinA = Fin.ToString("yyyy-MM-dd");
            IdReporte = rbReporte.SelectedValue;
            contentUrl = "../Reportes/wfrmListadoFormularioCertificado.aspx";
            Response.Redirect(contentUrl + "?IdTipoReporte=" + IdTipoReporte + "&IdProcedimiento=" + IdProcedimiento + "&Regional=" + Regional + "&IniA=" + IniA + "&FinA=" + FinA + "&IdReporte=" + IdReporte);
        }
        
    }
    #endregion

    #region Eventos Datos

    protected void ddlProcedimiento ()
    {
        //ddlProcedimiento.DataSource = null;
        ddlProcedimientos.DataSource = reporte.Procedimiento((int)Session["IdConexion"], "H", ref mensaje);
        ddlProcedimientos.DataValueField = "Id";
        ddlProcedimientos.DataTextField = "Descripcion";
        ddlProcedimientos.DataBind();
        if (ddlProcedimientos.DataSource != null && ddlProcedimientos.Items.Count > 0)
        {
            ddlProcedimientos.Items.Insert(0, new ListItem("SELECCIONE..", "0"));
            ddlProcedimientos.SelectedValue = "0";
        }
        else 
        {
            ddlProcedimientos.Items.Insert(0, new ListItem("No existen datos", "0"));
            ddlProcedimientos.SelectedValue = "0";
        }
    }
    protected void ddlRegionales()
    {
        //ddlProcedimiento.DataSource = null;
        ddlRegional.DataSource = reporte.Regional((int)Session["IdConexion"], "G", ref mensaje);
        ddlRegional.DataValueField = "IdOficina";
        ddlRegional.DataTextField = "Regional";
        ddlRegional.DataBind();
        if (ddlRegional.DataSource != null && ddlRegional.Items.Count > 0)
        {
            ddlRegional.Items.Insert(0, new ListItem("TODAS", "0"));
            ddlRegional.SelectedValue = "0";
        }
        else
        {
            ddlRegional.Items.Insert(0, new ListItem("No existen datos", "0"));
            ddlRegional.SelectedValue = "0";
        }
    }
    #endregion
}