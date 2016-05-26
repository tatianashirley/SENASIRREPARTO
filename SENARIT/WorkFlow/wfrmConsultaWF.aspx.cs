using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfmConsultaWF : System.Web.UI.Page
{
    clsSolicitudTramite objSolTram = new clsSolicitudTramite();
    clsInstanciaNodo objInstNodo = new clsInstanciaNodo();
    private int _idConexion;

    private static long _idInstancia = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            _idConexion = (int)Session["IdConexion"];
        }

        if (!Page.IsPostBack)
        {
            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS_MAESTRO

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
        Master.lblMasterWarning.Visible = false;
        Master.imgMasterWarning.Visible = false;
    }

    private void LimpiarMaestro()
    {
        LimpiarMensajesMasterPage();

        pnlMaestro.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        gvBusqMaestro.DataSource = null;
        gvBusqMaestro.DataBind();

        gvBusqMaestro.Visible = false;
        pnlDetalle.Visible = false;
        ibtnImprimir.Enabled = false;   
    }

    private void AsignarValoresMaestro()
    {
        objSolTram.iIdConexion = _idConexion;
        objSolTram.sNombres = txtNombres.Text;
        objSolTram.sApellidoPaterno = txtPaterno.Text;
        objSolTram.sApellidoMaterno = txtMaterno.Text;
        objSolTram.sNumeroDocumento = txtDocIdenti.Text;
        if(!string.IsNullOrEmpty(txtTramite.Text))
            objSolTram.iIdTramite = Convert.ToInt64(txtTramite.Text);        
    }

    private void CargarGrillaBusquedaMaestra()
    {
        AsignarValoresMaestro();

        if (objSolTram.Busqueda())
        {
            var dt = objSolTram.DSet.Tables[0];
            Session["dtMaestro"] = dt;
            if ( dt.Rows.Count >= objSolTram.NroFilas)
                ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('La búsqueda devuelve "+ dt.Rows.Count +" registros. Por favor, sea más especifico en los filtros.');", true); 
            
            gvBusqMaestro.DataSource = dt;
            gvBusqMaestro.DataBind();

            gvBusqMaestro.Visible = true;
            pnlDetalle.Visible = true;    
            
        }
        else
        {            
            gvBusqMaestro.DataSource = null;
            gvBusqMaestro.DataBind();
            pnlDetalle.Visible = false;

            if(objSolTram.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla la busqueda", objSolTram.sMensajeError);

            LimpiarDetalle();
        }        
    }

    #endregion

    #region EVENTOS_MAESTRO

    protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarMensajesMasterPage();
        CargarGrillaBusquedaMaestra();
        //LimpiarDetalle();
    }

    private long ObtenerInstancia(int pIdTramite, int pIdGrupoBeneficio, ref string pMensajeError)
    {
        clsInstancia objInst = new clsInstancia();

        objInst.iIdConexion = _idConexion;
        objInst.iIdInstancia = 0;
        objInst.iIdTramite = pIdTramite;
        objInst.iIdGrupoBeneficio = pIdGrupoBeneficio;
        if (objInst.ObtieneFila())
        {
            DataRow dr = objInst.DSet.Tables[0].Rows[0];
            return (long) dr["IdInstancia"];
        }
        else
        {
            pMensajeError = objInst.sMensajeError;
            return 0;
        }
          
    }

    protected void gvBusqMaestro_SelectedIndexChanged(object sender, EventArgs e)
    {
        int vIdGrupoBeneficio;
        string vTramite, vMensajeError="";
        try
        {
            var rowSelect = gvBusqMaestro.SelectedRow.RowIndex;
            var dataKey = gvBusqMaestro.DataKeys[rowSelect];
            if (dataKey.Values != null)
            {
                vIdGrupoBeneficio = (int)dataKey.Values["IdGrupoBeneficio"];
                vTramite = dataKey.Values["NroTramite"].ToString();
                _idInstancia = ObtenerInstancia(Convert.ToInt32(vTramite), vIdGrupoBeneficio, ref vMensajeError);
                Session["IdInstancia"] = _idInstancia;
            }

            if (_idInstancia > 0)
            {
                CargarGrillaDetalle(_idInstancia);
                pnlDetalle.Visible = true;
                ibtnImprimir.Enabled = true;
            }
            else
                Master.MensajeError("Se produjo un error al obtener la instancia", vMensajeError);

        }
        catch (Exception ex)
        {            
            Master.MensajeError("Se produjo un error al seleccionar el registro", ex.Message);
        }
        
    }

    protected void ibtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarMaestro();
    }

    protected void gvBusqMaestro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusqMaestro.PageIndex = e.NewPageIndex;
        CargarGrillaBusquedaMaestra();
    }

    #endregion

    #region LIMPIAR_DETALLE

    private void LimpiarDetalle()
    {
        pnlDetalle.Visible = false;
    }

    #endregion
    
    #region CARGAR_DATOS_DETALLE

    private void CargarGrillaDetalle(long pInstancia)
    {
        objInstNodo.iIdConexion = _idConexion;
        objInstNodo.iIdInstancia = pInstancia;

        if (objInstNodo.ObtieneHistorialEjecucion())
        {
            var dt = objInstNodo.DSet.Tables[0];
            Session["dtDetalle"] = dt;
            gvDetalle.DataSource = dt;
            gvDetalle.DataBind();
        }
        else
        {            
            gvDetalle.DataSource = null;
            gvDetalle.DataBind();

            if(objInstNodo.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de historial", objSolTram.sMensajeError);
        }        
    }

    #endregion   

    protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDetalle.PageIndex = e.NewPageIndex;
            CargarGrillaDetalle(_idInstancia);
        }
        catch (Exception Ex)
        {
            Master.MensajeError("Se produjo un error al recorrer la grilla de Historial", Ex.Message);
        }
    }

    protected void ibtnImprimir_Click(object sender, ImageClickEventArgs e)
    {       
        Response.Redirect("~/WorkFlow/wfrmRptConsultaWF.aspx");
    }
}