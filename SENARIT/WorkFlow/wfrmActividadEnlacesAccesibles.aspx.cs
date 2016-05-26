using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmActividadEnlacesAccesibles : System.Web.UI.Page
{
    private clsFlujoNodoLink objFlujNodLink= new clsFlujoNodoLink();
    private clsFlujoNodoLinkParametro objInstNodoLinkParam = new clsFlujoNodoLinkParametro();
    
    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private int _idFlujo;
    private string _flujo;
    private short _idNodo;
    private string _nodo;
    private Dictionary<string,string> _dic = new Dictionary<string, string>();

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
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;
            txtFlujo.Text = _flujo;
            txtActividad.Text = _nodo;

            CargarGrillaNodoLinks();
            CargarCboGrupoRestriccion();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS_MAESTRO

    private void AsignarValoresPivote()
    {
        objFlujNodLink.iIdConexion = _idConexion;
        objFlujNodLink.iIdFlujo = _idFlujo;
        objFlujNodLink.iIdNodo = _idNodo;
        if (!String.IsNullOrEmpty(txtSecuencia.Text))
            objFlujNodLink.iSecuencia = Convert.ToInt16(txtSecuencia.Text);
    }

    private void AsignarValores()
    {        
        objFlujNodLink.sDescripcion = txtDescripcion.Text;
        objFlujNodLink.sLink = txtLinks.Text;
        objFlujNodLink.bFlagObligatorio = chkObli.Checked;
        if (chkActivo.Checked) 
            objFlujNodLink.sEstado = "A";
        else
            objFlujNodLink.sEstado = "I";
    }

    private void CargarGrillaNodoLinks()
    {
        AsignarValoresPivote();

        if (objFlujNodLink.ObtieneLinksXNodo())
        {
            gvActEnl.DataSource = objFlujNodLink.DSet.Tables[0];
            gvActEnl.DataBind();
        }
        else
        {
            gvActEnl.DataSource = null;
            gvActEnl.DataBind();   
            
            if(objFlujNodLink.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Actividad Enlaces", objFlujNodLink.sMensajeError);
        }
    }

    private void CargarCboGrupoRestriccion()
    {
        clsGrupoRestriccion objGRestric = new clsGrupoRestriccion();

        objGRestric.iIdConexion = _idConexion;

        if (objGRestric.ObtieneGruposDeRestricciones())
        {
            ddlGrupoRestriccion.DataSource = objGRestric.DSet.Tables[0];
            ddlGrupoRestriccion.DataTextField = "IdGrupoRestriccion";
            ddlGrupoRestriccion.DataValueField = "IdGrupoRestriccion";
            ddlGrupoRestriccion.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar el combo de Grupo Restricción", objGRestric.sMensajeError);
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

        pnlMaestro.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        txtTipoTramite.Text = _tipoTramite;
        txtFlujo.Text = _flujo;
        txtActividad.Text = _nodo;
        pnlMaestro.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        txtSecuencia.Enabled = true;
        btnEliminar.Enabled = false;

        pnlDetalle.Visible = false;
    }

    #endregion


    #region EVENTOS_PRINCIPALES_MAESTRO

    protected void gvActEnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsignarValoresPivote();
        
        var rowSelect = gvActEnl.SelectedRow.RowIndex;
        var dataKey = gvActEnl.DataKeys[rowSelect];
        if (dataKey != null)
            objFlujNodLink.iSecuencia = Convert.ToInt16(dataKey.Value);

        if (objFlujNodLink.ObtieneFila())
        {
            var dr = objFlujNodLink.DSet.Tables[0].Rows[0];

            txtSecuencia.Text = dr["Secuencia"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            txtLinks.Text = dr["Link"].ToString();
            chkObli.Checked = Convert.ToBoolean(dr["FlagObligatorio"]);
            if (dr["Estado"].ToString() == "A")
                chkActivo.Checked = true;
            else
                chkActivo.Checked = false;

            btnEliminar.Enabled = true;
            txtSecuencia.Enabled = false;
            
            pnlDetalle.Visible = true;
            CargarCboConceptos();
            CargarGrillaParametros();

        }
        else
        {
            btnEliminar.Enabled = false;
            txtSecuencia.Enabled = true;
            pnlDetalle.Visible = false;

            Master.MensajeError("Se produjo un error en la obtención del registro Actividad Enlaces", objFlujNodLink.sMensajeError);
        }

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValores();
            AsignarValoresPivote();
            bool resEvento = false;
            string evento;

            if (txtSecuencia.Enabled)
            {
                resEvento = objFlujNodLink.Adicion();
                evento = "adicionó";
            }
            else
            {
                resEvento = objFlujNodLink.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                LimpiarCampos();
                CargarGrillaNodoLinks();
                Master.MensajeOk("Se " + evento + " correctamente el Registro de Actividad Enlace");
            }
            else
                Master.MensajeError("Se produjo un error al grabar el Registro de Actividad Enlace", objFlujNodLink.sMensajeError);
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFlujNodLink.Eliminacion())
        {
            LimpiarCampos();
            CargarGrillaNodoLinks();
            Master.MensajeOk("Se eliminó correctamente el registro de Actividad Enlace");
        }
        else
        {
            Master.MensajeError("Se produjo un error al eliminar el registro de de Actividad Enlace", objFlujNodLink.sMensajeError);
        }
    }
   
    #endregion


    #region EVENTOS_SECUNDARIOS_MAESTRO

    protected void gvActEnl_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvActEnl.PageIndex = e.NewPageIndex;
        CargarGrillaNodoLinks();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmActividadesFlujo.aspx");
    }

    #endregion


    #region CARGAR_DATOS_DETALLE

    private void CargarGrillaParametros()
    {
        AsignarValoresPivoteDet();

        if (objInstNodoLinkParam.ObtieneParametrosXLinkNodo())
        {
            gvParam.DataSource = objInstNodoLinkParam.DSet.Tables[0];
            gvParam.DataBind();
        }
        else
        {
            gvParam.DataSource = null;
            gvParam.DataBind();

            if(objInstNodoLinkParam.iNivelError==1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Flujo Link Parámetro", objInstNodoLinkParam.sMensajeError);
        }
    }

    private void CargarCboConceptos()
    {
        clsConcepto objConcepto = new clsConcepto();
        objConcepto.iIdConexion = _idConexion;

        if (objConcepto.ObtieneConceptos())
        {
            cboConcepto.DataSource = objConcepto.DSet.Tables[0];
            cboConcepto.DataTextField = "Descripcion";
            cboConcepto.DataValueField = "IdConcepto";
            cboConcepto.DataBind();

            cboConcepto.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboConcepto.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de conceptos", objConcepto.sMensajeError);
        }
    }

    private void LimpiarCamposDetalle()
    {
        cboConcepto.SelectedIndex = 0;
        chkSolicitud.Checked = false;
        txtComentarios.Text = string.Empty;

        cboConcepto.Enabled = true;
        btnEliminarDet.Enabled = false;
    }

    private void AsignarValoresPivoteDet()
    {
        objInstNodoLinkParam.iIdConexion = _idConexion;
        objInstNodoLinkParam.iIdFlujo = _idFlujo;
        objInstNodoLinkParam.iIdNodo = _idNodo;
        objInstNodoLinkParam.iSecuencia = Convert.ToInt16(txtSecuencia.Text);
        if (cboConcepto.SelectedIndex > 0)
            objInstNodoLinkParam.sIdConcepto = cboConcepto.SelectedValue;
    }

    private void AsignarValoresDet()
    {
        objInstNodoLinkParam.bFlagSolicitud = chkSolicitud.Checked;
        objInstNodoLinkParam.sComentarios = txtComentarios.Text;
    }

    #endregion


    #region EVENTOS_PRINCIPALES_DETALLE

    protected void gvParam_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivoteDet();
        var rowSelect = gvParam.SelectedRow.RowIndex;
        var dataKey = gvParam.DataKeys[rowSelect];
        if (dataKey != null)
            objInstNodoLinkParam.sIdConcepto = dataKey.Value.ToString();

        if (objInstNodoLinkParam.ObtieneFila())
        {
            var dr = objInstNodoLinkParam.DSet.Tables[0].Rows[0];

            cboConcepto.SelectedValue = dr["IdConcepto"].ToString();
            chkSolicitud.Checked = (bool) dr["FlagSolicitud"];
            txtComentarios.Text = dr["Comentarios"].ToString();

            btnEliminarDet.Enabled = true;
            cboConcepto.Enabled = false;

            CargarGrillaParametros();
        }
        else
        {
            btnEliminarDet.Enabled = false;
            cboConcepto.Enabled = true;

            Master.MensajeError("Se produjo un error en la obtención de la fila de Flujo Link Parámetro", objInstNodoLinkParam.sMensajeError);
        }

    }

    protected void btnNuevoDet_Click(object sender, EventArgs e)
    {
        LimpiarCamposDetalle();
    }

    protected void btnGuardarDet_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValoresPivoteDet();
            AsignarValoresDet();
            
            bool resEvento = false;
            string evento;

            if (cboConcepto.Enabled)
            {
                resEvento = objInstNodoLinkParam.Adicion();
                evento = "adicionó";
            }
            else
            {
                resEvento = objInstNodoLinkParam.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                LimpiarCamposDetalle();
                CargarGrillaParametros();
                Master.MensajeOk("Se " + evento + " correctamente el Registro del Flujo Link Parámetro");
            }
            else
                Master.MensajeError("Se produjo un error al grabar el registro Flujo Link Parámetro", objInstNodoLinkParam.sMensajeError);
        }
    }

    protected void btnEliminarDet_Click(object sender, EventArgs e)
    {
        AsignarValoresPivoteDet();

        if (objInstNodoLinkParam.Eliminacion())
        {
            LimpiarCamposDetalle();
            CargarGrillaParametros();
            Master.MensajeOk("Se eliminó correctamente el registro de Flujo Link Parámetro");
        }
        else
        {
            Master.MensajeError("Se produjo un error al eliminar el registro de Flujo Link Parámetro", objInstNodoLinkParam.sMensajeError);
        }
    }
   
    #endregion


    #region EVENTOS_SECUNDARIOS_DETALLE

    protected void gvParam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvParam.PageIndex = e.NewPageIndex;
        CargarGrillaParametros();
    }
    #endregion







    
}