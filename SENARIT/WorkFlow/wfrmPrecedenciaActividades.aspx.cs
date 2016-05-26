using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmPrecedenciaActividades : System.Web.UI.Page
{
    private clsFlujoNodoPredecesor objFNPred = new clsFlujoNodoPredecesor();

    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private int _idFlujo;
    private string _flujo;

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
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;
            txtFlujo.Text = _flujo;

            CargarCboActividad(cboActividad);
            CargarCboActividad(cboActPredecesora);
            CargarCboGrupoRestriccion();
            CargarGrillaFlujoNodoPred();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void AsignarValoresPivote()
    {
        objFNPred.iIdConexion = _idConexion;
        objFNPred.iIdFlujo = _idFlujo;
        if(cboActividad.SelectedIndex > 0)
            objFNPred.iIdNodo = Convert.ToInt16(cboActividad.SelectedValue);
        if(cboActPredecesora.SelectedIndex > 0)
            objFNPred.iIdNodoPred = Convert.ToInt16(cboActPredecesora.SelectedValue); 
    }


    private void AsignarValores()
    {
        if(cboRestricTransicion.SelectedIndex > 0)
            objFNPred.iIdGrupoRestriccion = Convert.ToInt32(cboRestricTransicion.SelectedValue);
        objFNPred.bFLagGeneraCbteRspldo = chkGeneraCmpte.Checked;
        objFNPred.bFlagImrimeCbteRspldo = chkImpriCmpte.Checked;
        objFNPred.bFlagTransicionMasiva = chkTransMasiva.Checked;
        objFNPred.bFlagManual = chkManual.Checked;
        objFNPred.bFlagAlerta = chkAlerta.Checked;
        objFNPred.bFlagAnonimo = chkAnonimo.Checked;
        if (!string.IsNullOrEmpty(txtActParalelas.Text))
            objFNPred.iNodoParalelo = Convert.ToInt16(txtActParalelas.Text);
        if (!string.IsNullOrEmpty(txtReglaActParalelas.Text))
            objFNPred.sReglaNodoParalelo = txtReglaActParalelas.Text;
        if (!string.IsNullOrEmpty(txtMensajeAlerta.Text))
            objFNPred.sMensajeAlerta = txtMensajeAlerta.Text;
        objFNPred.bFlagRetroceso = chkRetroceso.Checked;
        objFNPred.bFlagUsuarioActual = chkUsuarioActual.Checked;
        if (!string.IsNullOrEmpty(txtDescrip.Text))
            objFNPred.sDescripcion = txtDescrip.Text;
    }

    private void CargarGrillaFlujoNodoPred()
    {
        AsignarValoresPivote();

        if (objFNPred.ObtienePrecedenciasXFlujo())
        {
            gvPrecedAct.DataSource = objFNPred.DSet.Tables[0];
            gvPrecedAct.DataBind();
        }
        else
        {
            gvPrecedAct.DataSource = null;
            gvPrecedAct.DataBind();

            if(objFNPred.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Actividad Predecesora", objFNPred.sMensajeError);
        }
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

    private void CargarCboGrupoRestriccion()
    {
        var objGrupoRest = new clsGrupoRestriccion();

        objGrupoRest.iIdConexion = _idConexion;
        if (objGrupoRest.ObtieneGruposDeRestricciones())
        {
            cboRestricTransicion.DataSource = objGrupoRest.DSet.Tables[0];
            cboRestricTransicion.DataTextField = "IdGrupoRestriccionDesc";
            cboRestricTransicion.DataValueField = "IdGrupoRestriccion";
            cboRestricTransicion.DataBind();

            cboRestricTransicion.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboRestricTransicion.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar el Combo de Grupo de Restricción", objGrupoRest.sMensajeError);
        }
    }


    private void HabilitarLinks(bool pHabil, string pIdNodo, string pNodo, string pIdNodoPred, string pNodoPred)
    {
        if (pHabil)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("IdTipTram", _idTipoTramite);
            dic.Add("TipTram", _tipoTramite);
            dic.Add("IdFluj", _idFlujo.ToString());
            dic.Add("Fluj", _flujo);
            dic.Add("IdNod", pIdNodo);
            dic.Add("Nod", pNodo);
            dic.Add("IdNodPred", pIdNodoPred);
            dic.Add("NodPred", pNodoPred);

            Session["dicNF"] = dic;

            lnkEnlaces.NavigateUrl = "~/WorkFlow/wfrmEnlacesFormaPrevia.aspx";
            lnkDocumentos.NavigateUrl = "~/WorkFlow/wfrmDocumentosFormaPrevia.aspx";
            lnkProcesos.NavigateUrl = "~/WorkFlow/wfrmProcesosTransicion.aspx";
        }

        lnkEnlaces.Enabled = pHabil;
        lnkDocumentos.Enabled = pHabil;
        lnkProcesos.Enabled = pHabil;
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

        pnlDatos.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        pnlDatos.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);   
        txtTipoTramite.Text = _tipoTramite;
        txtFlujo.Text = _flujo;

        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);
        
        cboActividad.Enabled = true;
        btnEliminar.Enabled = false;

        HabilitarLinks(false, string.Empty, string.Empty, string.Empty, string.Empty);
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void gvPrecedAct_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvPrecedAct.SelectedRow.RowIndex;
        var dataKey = gvPrecedAct.DataKeys[rowSelect];
        if (dataKey != null)
            objFNPred.iIdNodo = (short) dataKey.Values["IdNodo"];

        var dataKeyP = gvPrecedAct.DataKeys[rowSelect];
        if (dataKeyP != null)
            objFNPred.iIdNodoPred = (short)dataKeyP.Values["IdNodoPred"];

        if (objFNPred.ObtieneFila())
        {
            var dr = objFNPred.DSet.Tables[0].Rows[0];

            cboActividad.SelectedValue = dr["IdNodo"].ToString();
            cboActPredecesora.SelectedValue = dr["IdNodoPred"].ToString();
            if (!string.IsNullOrEmpty(dr["IdGrupoRestriccion"].ToString()))
                cboRestricTransicion.SelectedValue = dr["IdGrupoRestriccion"].ToString();
            chkGeneraCmpte.Checked = (bool) dr["FLagGeneraCbteRspldo"];
            chkImpriCmpte.Checked = (bool) dr["FlagImrimeCbteRspldo"];
            chkTransMasiva.Checked = (bool) dr["FlagTransicionMasiva"];
            chkManual.Checked = (bool) dr["FlagManual"];
            chkAlerta.Checked = (bool) dr["FlagAlerta"];
            chkAnonimo.Checked = (bool) dr["FlagAnonimo"];
            txtActParalelas.Text = dr["NodoParalelo"].ToString();
            txtReglaActParalelas.Text = dr["ReglaNodoParalelo"].ToString();
            txtMensajeAlerta.Text = dr["MensajeAlerta"].ToString();
            if (!string.IsNullOrEmpty(dr["FlagRetroceso"].ToString()))
                chkRetroceso.Checked = (bool) dr["FlagRetroceso"];
            if (!string.IsNullOrEmpty(dr["FlagUsuarioActual"].ToString()))
                chkUsuarioActual.Checked = (bool) dr["FlagUsuarioActual"];
            if (!string.IsNullOrEmpty(dr["Descripcion"].ToString()))
                txtDescrip.Text = dr["Descripcion"].ToString();

            btnEliminar.Enabled = true;
            cboActividad.Enabled = false;

            HabilitarLinks(true, cboActividad.SelectedValue, cboActividad.SelectedItem.ToString(), cboActPredecesora.SelectedValue,cboActPredecesora.SelectedItem.ToString());
        }
        else
        {
            Master.MensajeError("Se produjo un error al recuperar el registro de Actividad Predecesora", objFNPred.sMensajeError);
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();
        AsignarValores();

        if (Page.IsValid)
        {
            bool resEvento = false;
            string evento;

            if (cboActividad.Enabled)
            {
                resEvento = objFNPred.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objFNPred.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaFlujoNodoPred();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Actividad Predecesora");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Actividad Predecesora", objFNPred.sMensajeError);
            }
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFNPred.Eliminacion())
        {
            CargarGrillaFlujoNodoPred();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el registro de Actividad Predecesora");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación de Actividad Predecesora", objFNPred.sMensajeError);
        }
    }
   

    #endregion

    #region EVENTOS_SECUNDARIOS

    protected void gvPrecedAct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPrecedAct.PageIndex = e.NewPageIndex;
        CargarGrillaFlujoNodoPred();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmTipoTramiteFlujo.aspx");
    }

    #endregion


    
}