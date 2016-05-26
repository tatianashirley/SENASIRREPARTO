using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmEnlacesFormaPrevia : System.Web.UI.Page
{
    private clsFlujoNodoPredecesorLink objFNPredLink = new clsFlujoNodoPredecesorLink();

    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private int _idFlujo;
    private string _flujo, _nodoPred, _nodo;
    private short _idNodoPred, _idNodo;

    private Dictionary<string, string> _dic = new Dictionary<string, string>();

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

            _dic = (Dictionary<string, string>)Session["dicNF"];
            _idTipoTramite = _dic["IdTipTram"];
            _tipoTramite = _dic["TipTram"];
            _idFlujo = Convert.ToInt32(_dic["IdFluj"]);
            _flujo = _dic["Fluj"];
            _idNodo = Convert.ToInt16(_dic["IdNod"]);
            _nodo = _dic["Nod"];
            _idNodoPred = Convert.ToInt16(_dic["IdNodPred"]);
            _nodoPred = _dic["NodPred"];
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;
            txtFlujo.Text = _flujo;
            CargarCboActividad(cboActPredecesora);
            CargarCboActividad(cboActividad);
            cboActividad.SelectedValue = _idNodo.ToString();
            cboActPredecesora.SelectedValue = _idNodoPred.ToString();
            CargarCboEnlaces();
            CargarGrillaEnlaces();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void AsignarValoresPivote()
    {
        objFNPredLink.iIdConexion = _idConexion;
        objFNPredLink.iIdFlujo = _idFlujo;
        objFNPredLink.iIdNodoPred = _idNodoPred;
        objFNPredLink.iIdNodo = _idNodo;

        if (cboEnlace.SelectedIndex > 0)
            objFNPredLink.iSecuencia = Convert.ToInt16(cboEnlace.SelectedValue);
    }

    private void CargarCboActividad(DropDownList pCbo)
    {
        var objIFlujoNodo = new clsFlujoNodo();

        objIFlujoNodo.iIdConexion = _idConexion;
        objIFlujoNodo.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        objIFlujoNodo.iIdFlujo = _idFlujo;

        if (objIFlujoNodo.ObtieneNodosXFlujo())
        {
            pCbo.DataSource = objIFlujoNodo.DSet.Tables[0];
            pCbo.DataTextField = "IdNodoDesc";
            pCbo.DataValueField = "IdNodo";
            pCbo.DataBind();

            pCbo.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            pCbo.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado del combo de Actividades", objIFlujoNodo.sMensajeError);
        }
    }

    private void CargarGrillaEnlaces()
    {
        AsignarValoresPivote();

        if (objFNPredLink.ObtieneEnlacesXTransicion())
        {
            gvEnlacesVP.DataSource = objFNPredLink.DSet.Tables[0];
            gvEnlacesVP.DataBind();
        }
        else
        {
            gvEnlacesVP.DataSource = null;
            gvEnlacesVP.DataBind();

            if(objFNPredLink.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Enlaces Visitados de Forma Previa", objFNPredLink.sMensajeError);
        }
    }

    private void CargarCboEnlaces()
    {
        var objFNL = new clsFlujoNodoLink();

        objFNL.iIdConexion = _idConexion;
        objFNL.iIdFlujo = _idFlujo;
        objFNL.iIdNodo = _idNodoPred;
        
        if (objFNL.ObtieneLinksXNodo())
        {
            var dsFNL = objFNL.DSet.Tables[0];
            cboEnlace.DataSource = objFNL.DSet.Tables[0];
            cboEnlace.DataTextField = "Descripcion";
            cboEnlace.DataValueField = "Secuencia";
            cboEnlace.DataBind();

            cboEnlace.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboEnlace.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado del combo de Enlaces", objFNL.sMensajeError);
        }
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    private void LimpiarCampos()
    {
        LimpiarMensajesMasterPage();

        cboEnlace.SelectedIndex = 0;

        cboEnlace.Enabled = true;
        btnEliminar.Enabled = false;
    }


    #endregion


    #region EVENTOS_PRINCIPALES

    protected void gvEnlacesVP_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvEnlacesVP.SelectedRow.RowIndex;
        var dataKey = gvEnlacesVP.DataKeys[rowSelect];
        if (dataKey != null)
            objFNPredLink.iSecuencia = (short) dataKey.Value;


        if (objFNPredLink.ObtieneFila())
        {
            var dr = objFNPredLink.DSet.Tables[0].Rows[0];

            cboEnlace.SelectedValue = dr["Secuencia"].ToString();

            btnEliminar.Enabled = true;
            cboEnlace.Enabled = false;            
        }
        else
        {
            Master.MensajeError("Se produjo un error al recuperar el registro de Enlace Visitado de Forma Previa", objFNPredLink.sMensajeError);
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();        

        if (Page.IsValid)
        {
            if (objFNPredLink.Adicion())
            {
                CargarGrillaEnlaces();
                LimpiarCampos();
                Master.MensajeOk("Se adicionó correctamente el registro de Enlace Visitado de Forma Previa");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Enlace Visitado de Forma Previa", objFNPredLink.sMensajeError);
            }
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFNPredLink.Eliminacion())
        {
            CargarGrillaEnlaces();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el registro de Enlace Visitado de Forma Previa");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación de Enlace Visitado de Forma Previa", objFNPredLink.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmPrecedenciaActividades.aspx");
    }
    
    protected void gvEnlacesVP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEnlacesVP.PageIndex = e.NewPageIndex;
        CargarGrillaEnlaces();
    }

    #endregion
    
}