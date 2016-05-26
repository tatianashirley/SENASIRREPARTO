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
using wcfNotificacion.Logica;
using wcfWorkFlowN.Logica;

public partial class Notificaciones_wfrmReportesNotificacion : System.Web.UI.Page
{
    #region Inicio_Clases
    clsEnvio Envio = new clsEnvio();
    clsReportes Reportes = new clsReportes();
    string mensaje = null;
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
            ListaDocumentos();
            ListaOficinas();
        }
    }
    #endregion
    #region Listados
    public void ListaOficinas() 
    {
        ddlRegional.DataSource = null;
        ddlRegional.DataSource = Envio.ListaOficinas((int)Session["IdConexion"], "B", 1,ref mensaje);
        ddlRegional.DataValueField = "IdOficina";
        ddlRegional.DataTextField = "Nombre";
        ddlRegional.DataBind();
        if (ddlRegional.DataSource != null && ddlRegional.Items.Count>0)
        {
            ddlRegional.Items.Insert(0, new ListItem("Todas", "0"));
            ddlRegional.SelectedValue = "0";
        }
        else
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
    }

    public void ListaDocumentos() 
    {
        ddlTipoDocumento.DataSource = null;
        ddlTipoDocumento.DataSource = Reportes.ListadoDocumentos((int)Session["IdConexion"], "A", ref mensaje);
        ddlTipoDocumento.DataValueField = "IdDocumento";
        ddlTipoDocumento.DataTextField = "Detalle";
        ddlTipoDocumento.DataBind();
        if (ddlTipoDocumento.DataSource != null && ddlTipoDocumento.Items.Count > 0)
        {
            ddlTipoDocumento.Items.Insert(0, new ListItem("Todas", "0"));
            ddlTipoDocumento.SelectedValue = "0";
        }
        else 
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
        
    }
    #endregion
    #region Grillas de Reportes

    public void GrillaEnvioDevolucion()
    {   
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        Int32 IdTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
        string IdDocumento = ddlTipoDocumento.SelectedValue.ToString();
        string Regional = ddlRegional.SelectedValue.ToString();
        string FechaIni = txtFechaDesde.Text;
        string FechaFin= txtFechaHasta.Text;
        try
        {
            gvEnvioDevolucion.Visible = true;
            gvEnvioDevolucion.DataSource = Reportes.DocumentosEnv_Dev(iIdConexion, cOperacion, IdTipoReporte, IdDocumento, Regional,FechaIni,FechaFin, ref mensaje);
            gvEnvioDevolucion.DataBind();
            lblTotal.Text = "Total de Registros encontrados: "+Convert.ToString(gvEnvioDevolucion.Rows.Count);
            lblTotal.Visible = true;
            Master.MensajeCancel();
            gvListaNotificaciones.Visible = false;
            gvListaRecursos.Visible = false;
            gvPendientesMesDocs.Visible = false;
            gvPlazosDocs.Visible = false;
        }
        catch 
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }
    public void GrillaPendientes()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        Int32 IdTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
        string IdDocumento = ddlTipoDocumento.SelectedValue.ToString();
        string Regional = ddlRegional.SelectedValue.ToString();
        string FechaIni = txtFechaDesde.Text;
        string FechaFin = txtFechaHasta.Text;
        try
        {
            gvPendientesMesDocs.Visible = true;
            gvPendientesMesDocs.DataSource = Reportes.DocumentosEnv_Dev(iIdConexion, cOperacion, IdTipoReporte, IdDocumento, Regional, FechaIni, FechaFin, ref mensaje);
            gvPendientesMesDocs.DataBind();
            lblTotal.Text = "Total de Registros encontrados: " + Convert.ToString(gvPendientesMesDocs.Rows.Count);
            lblTotal.Visible = true;
            Master.MensajeCancel();
            gvEnvioDevolucion.Visible = false;
            gvListaRecursos.Visible = false;
            gvListaNotificaciones.Visible = false;
            gvPlazosDocs.Visible = false;
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }
    public void GrillaDocs_conPlazo()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        Int32 IdTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
        string IdDocumento = ddlTipoDocumento.SelectedValue.ToString();
        string Regional = ddlRegional.SelectedValue.ToString();
        string FechaIni = txtFechaDesde.Text;
        string FechaFin = txtFechaHasta.Text;
        try
        {
            gvPlazosDocs.Visible = true;
            gvPlazosDocs.DataSource = Reportes.DocumentosEnv_Dev(iIdConexion, cOperacion, IdTipoReporte, IdDocumento, Regional, FechaIni, FechaFin, ref mensaje);
            gvPlazosDocs.DataBind();
            lblTotal.Text = "Total de Registros encontrados: " + Convert.ToString(gvPlazosDocs.Rows.Count);
            lblTotal.Visible = true;
            Master.MensajeCancel();
            gvListaRecursos.Visible = false;
            gvListaNotificaciones.Visible = false;
            gvPendientesMesDocs.Visible = false;
            gvEnvioDevolucion.Visible = false;
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }

    public void Grilla_Notificados()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        Int32 IdTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
        string IdDocumento = ddlTipoDocumento.SelectedValue.ToString();
        string Regional = ddlRegional.SelectedValue.ToString();
        string FechaIni = txtFechaDesde.Text;
        string FechaFin = txtFechaHasta.Text;
        try
        {
            gvListaNotificaciones.Visible = true;
            gvListaNotificaciones.DataSource = Reportes.DocumentosEnv_Dev(iIdConexion, cOperacion, IdTipoReporte, IdDocumento, Regional, FechaIni, FechaFin, ref mensaje);
            gvListaNotificaciones.DataBind();
            lblTotal.Text = "Total de Registros encontrados: " + Convert.ToString(gvListaNotificaciones.Rows.Count);
            lblTotal.Visible = true;
            Master.MensajeCancel();
            gvListaRecursos.Visible = false;
            gvPendientesMesDocs.Visible = false;
            gvEnvioDevolucion.Visible = false;
            gvPlazosDocs.Visible = false;
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }

    public void Grilla_Recursos()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        Int32 IdTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
        string IdDocumento = ddlTipoDocumento.SelectedValue.ToString();
        string Regional = ddlRegional.SelectedValue.ToString();
        string FechaIni = txtFechaDesde.Text;
        string FechaFin = txtFechaHasta.Text;
        try
        {
            gvListaRecursos.Visible= true;
            gvListaRecursos.DataSource = Reportes.DocumentosEnv_Dev(iIdConexion, cOperacion, IdTipoReporte, IdDocumento, Regional, FechaIni, FechaFin, ref mensaje);
            gvListaRecursos.DataBind();
            lblTotal.Text = "Total de Registros encontrados: " + Convert.ToString(gvListaRecursos.Rows.Count);
            lblTotal.Visible = true;
            Master.MensajeCancel();
            gvListaNotificaciones.Visible = false;
            gvEnvioDevolucion.Visible = false;
            gvPlazosDocs.Visible = false;
            gvPendientesMesDocs.Visible = false;
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }

    #endregion
    #region Boton_Buscar
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {   
        Int32 TipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
        Int32 rdbImprimir = Convert.ToInt32(rbReporte.SelectedValue);
        if (rdbImprimir == 1)
        {
            if (TipoReporte == 1 || TipoReporte == 2)
            {
                GrillaEnvioDevolucion();
            }
            if (TipoReporte == 3 || TipoReporte == 4 || TipoReporte == 5)
            {
                GrillaPendientes();
            }
            if (TipoReporte == 6 || TipoReporte == 7)
            {
                GrillaDocs_conPlazo();
            }
            if (TipoReporte == 8)
            {
                Grilla_Notificados();
            }
            if (TipoReporte == 9)
            {
                Grilla_Recursos();
            }
        }
        if (rdbImprimir == 2) 
        {
            Int32 IdTipoReporte = Convert.ToInt32(ddlTipoReporte.SelectedValue);
            string IdDocumento = ddlTipoDocumento.SelectedValue.ToString();
            string Regional = ddlRegional.SelectedValue.ToString();
            string FechaIni = txtFechaDesde.Text;
            string FechaFin = txtFechaHasta.Text;
            string contentUrl = "wfrmListadoReportes.aspx";
            Response.Redirect(contentUrl + "?IdTipoReporte=" + IdTipoReporte + "&IdDocumento=" + IdDocumento + "&Regional=" + Regional + "&FechaIni=" + FechaIni + "&FechaFin=" + FechaFin);
        }
    }
    #endregion
}
