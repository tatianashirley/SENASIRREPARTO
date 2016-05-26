using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfSeguridad.Logica;
using wcfObservados.Logica;
using wcfWorkFlowN.Logica;

public partial class SeguimientoObservados_wfrmReporteTipoObservacion : System.Web.UI.Page
{
    #region Inicio_Clases
    string mensaje = null;
    clsSeguimientoObservados objObservado = new clsSeguimientoObservados();
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
            ListaObservaciones();
            ListaOficinas();
        }
    }
    #endregion
    #region Listados
    public void ListaOficinas() 
    {
        ddlRegional.DataSource = null;
        try
        {
            ddlRegional.DataSource = objObservado.ListaRegionales((int)Session["IdConexion"], "P", ref mensaje);
            ddlRegional.DataValueField = "IdOficina";
            ddlRegional.DataTextField = "Nombre";
            ddlRegional.DataBind();
            //ddlRegional.Items.Insert(0, new ListItem("Todas", "0"));
            //ddlRegional.SelectedValue = "0";
        }
        catch 
        {
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
        }
    }

    public void ListaObservaciones() 
    {
        ddlObservacion.DataSource = null;
        try
        {
            ddlObservacion.DataSource = objObservado.ListaObservaciones((int)Session["IdConexion"], "S", ref mensaje);
            ddlObservacion.DataValueField = "Id";
            ddlObservacion.DataTextField = "Nombre";
            ddlObservacion.DataBind();
        }
        catch {
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
        }
    }
    #endregion
   
    #region Boton_Buscar
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {   
            string IdObservacion = ddlObservacion.SelectedValue.ToString();
            string Regional = ddlRegional.SelectedValue.ToString();
            string FechaIni;
            string FechaFin;
            Session["rbID"] = Convert.ToInt32(rbReporte.SelectedValue);
            if (Convert.ToInt32(rbReporte.SelectedValue) == 2)
            {
                FechaIni = "01/01/1900";
                FechaFin = "01/01/1900";
            }
            else 
            {
                FechaIni = txtFechaDesde.Text;
                FechaFin = txtFechaHasta.Text;
            }
            FechaIni = Convert.ToDateTime(FechaIni).ToString("yyyy-MM-dd");
            FechaFin = Convert.ToDateTime(FechaFin).ToString("yyyy-MM-dd");
            //string contentUrl = "wfrmRptListadoObservacion.aspx";
            //Response.Redirect(contentUrl + "?IdObservacion=" + IdObservacion + "&Regional=" + Regional + "&FechaIni=" + FechaIni + "&FechaFin=" + FechaFin);
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../SeguimientoObservados/wfrmRptListadoObservacion.aspx?IdObservacion=" + IdObservacion + "&Regional=" + Regional + "&FechaIni=" + FechaIni + "&FechaFin=" + FechaFin + "','newWindow', 'height=0, width=0, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    #endregion
    protected void rbReporte_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rbValor = Convert.ToInt32(rbReporte.SelectedValue);
        if (rbValor== 2)
        {
            lblTipoDoc.Visible = true;
            ddlObservacion.Visible = true;
            lblRegional.Visible = true;
            ddlRegional.Visible = true;
            txtFechaDesde.Visible = true;
            txtFechaHasta.Visible = true;
        }
        if (rbValor == 1)
        {
            lblTipoDoc.Visible = true;
            ddlObservacion.Visible = true;
            lblRegional.Visible = true;
            ddlRegional.Visible = true;
            txtFechaDesde.Visible = true;
            txtFechaHasta.Visible = true;
        }
        if (rbValor == 3) 
        {
            lblTipoDoc.Visible = false;
            ddlObservacion.Visible = false;
            lblRegional.Visible = false;
            ddlRegional.Visible = false;
            txtFechaDesde.Visible = true;
            txtFechaHasta.Visible = true;
        }
    }
}
