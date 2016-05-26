using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmActividadesFlujo : System.Web.UI.Page
{
    private clsFlujoNodo objIFlujoNodo = new clsFlujoNodo();
    private clsSeguridad objInstanciaSeg = new clsSeguridad();
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
            _idConexion = (int) Session["IdConexion"];

            _dic = (Dictionary<string, string>) Session["dicNF"];
            _idTipoTramite = _dic["IdTipTram"];
            _tipoTramite = _dic["TipTram"];
            _idFlujo = Convert.ToInt32(_dic["IdFluj"]);
            _flujo = _dic["Fluj"];
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;
            txtFlujo.Text = _flujo;

            CargarCboNivelOficina();
            CargarCboRol();
            CargarCboOficina();
            CargarGrillaFlujoNodo();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }


    #region CARGAR_DATOS

    private void CargarCboNivelOficina()
    {
        cboNivelOficina.Items.Clear();

        var objInstOficina = new clsOficinas();
        string sMensajeError = "";

        if (objInstOficina.ObtieneNivelesDeOficina(_idConexion, ref sMensajeError))
        {
            cboNivelOficina.DataSource = objInstOficina.DTNiveles;
            cboNivelOficina.DataTextField = "Nivel";
            cboNivelOficina.DataValueField = "Nivel";
            cboNivelOficina.DataBind();

            cboNivelOficina.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboNivelOficina.SelectedIndex = 0;
        }
        else
            Master.MensajeError("Se produjo un error en el cargado de Nivel de Oficina", sMensajeError);
    }

    private void CargarCboRol()
    {
        cboRol.Items.Clear();

        cboRol.DataSource = objInstanciaSeg.ListaRol();
        cboRol.DataTextField = "DescripcionRol";
        cboRol.DataValueField = "IdRol";
        cboRol.DataBind();

        cboRol.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboRol.SelectedIndex = 0;
    }

    private void CargarCboOficina()
    {
        cboOficina.Items.Clear();

        cboOficina.DataSource = objInstanciaSeg.ListaOficinas();
        cboOficina.DataTextField = "Nombre";
        cboOficina.DataValueField = "IdOficina";
        cboOficina.DataBind();

        cboOficina.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboOficina.SelectedIndex = 0;
    }

    private void CargarCboArea(int pIdOficina)
    {
        cboArea.Items.Clear();

        cboArea.DataSource = objInstanciaSeg.ListaArea(pIdOficina);
        cboArea.DataTextField = "Descripcion";
        cboArea.DataValueField = "IdArea";
        cboArea.DataBind();

        cboArea.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboArea.SelectedIndex = 0;
    }

    private void CargarCboUsuario(int pRol)
    {
        cboUsuario.Items.Clear();

        var objInstRolUsua = new clsRolUsuario();

        objInstRolUsua.iIdConexion = _idConexion;
        objInstRolUsua.iIdRol = pRol;
        if (objInstRolUsua.ObtieneUsuariosXRol())
        {
            cboUsuario.DataSource = objInstRolUsua.DSet.Tables[0];

            cboUsuario.DataTextField = "CuentaUsuario";
            cboUsuario.DataValueField = "IdUsuario";
            cboUsuario.DataBind();

            cboUsuario.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboUsuario.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar el Usuario según Rol", objInstRolUsua.sMensajeError);
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

        pnlDatos.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        cboArea.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboUsuario.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        pnlDatos.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        txtActividad.Enabled = true;
        btnEliminar.Enabled = false;

        txtTipoTramite.Text = _tipoTramite;
        txtFlujo.Text = _flujo;

        HabilitarLinks(false, "","");
    }

    private void AsignarValoresPivote()
    {
        objIFlujoNodo.iIdConexion = _idConexion;
        objIFlujoNodo.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        objIFlujoNodo.iIdFlujo = _idFlujo;
        if (!string.IsNullOrEmpty(txtActividad.Text))
            objIFlujoNodo.iIdNodo = Convert.ToInt16(txtActividad.Text);

    }

    private void AsignarValores()
    {
        objIFlujoNodo.sDescripcion = txtDescripcion.Text;
        if (!string.IsNullOrEmpty(txtDescripcion.Text))
            objIFlujoNodo.sComentarios = txtComentarios.Text;
        objIFlujoNodo.iDuracionMaxDias = Convert.ToInt16(txtMaxDias.Text);
        objIFlujoNodo.iDuracionMaxHoras = Convert.ToInt16(txtMaxHoras.Text);
        if (cboNivelOficina.SelectedIndex!=0)
            objIFlujoNodo.iNivelOficina = Convert.ToByte(cboNivelOficina.SelectedValue);
        if (cboOficina.SelectedIndex!=0)
            objIFlujoNodo.iIdOficina = Convert.ToInt32(cboOficina.SelectedValue);
        if (cboArea.SelectedIndex > 0)
            objIFlujoNodo.iIdArea = Convert.ToInt32(cboArea.SelectedValue);
        if (cboRol.SelectedIndex!=0)
            objIFlujoNodo.iIdRol = Convert.ToInt32(cboRol.SelectedValue);
        if (cboUsuario.SelectedIndex > 0)
            objIFlujoNodo.iIdUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
        objIFlujoNodo.bFlagRechazo = chkRechazarTram.Checked;
        objIFlujoNodo.bFlagFicticio = chkActividadFicticia.Checked;
        objIFlujoNodo.bFlagSincronizador = chkSincronizador.Checked;
        objIFlujoNodo.bFlagTerminal = chkActividadTerminal.Checked;

        //******************************
        //Pendiente de definición
        //objIFlujoNodo.iIdEstadoTramite 
        //******************************
        if (!string.IsNullOrEmpty(txtNemonico.Text))
            objIFlujoNodo.sNemonico = txtNemonico.Text;
        if (chkActivo.Checked)
            objIFlujoNodo.sEstado = "A";
        else
            objIFlujoNodo.sEstado = "I";
    }

    private void CargarGrillaFlujoNodo()
    {
        AsignarValoresPivote();

        if (objIFlujoNodo.ObtieneNodosXFlujo())
        {
            gvActiFlujo.DataSource = objIFlujoNodo.DSet.Tables[0];
            gvActiFlujo.DataBind();            
        }
        else
        {
            gvActiFlujo.DataSource = null;
            gvActiFlujo.DataBind();    
   
            if(objIFlujoNodo.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Flujo Nodo", objIFlujoNodo.sMensajeError);
        }
    }
    

    private void HabilitarLinks(bool pHabil, string pIdNodo, string pNodo)
    {
        if (pHabil)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("IdTipTram",_idTipoTramite);
            dic.Add("TipTram", _tipoTramite);
            dic.Add("IdFluj", _idFlujo.ToString());
            dic.Add("Fluj", _flujo);
            dic.Add("IdNod", pIdNodo);
            dic.Add("Nod", pNodo);

            Session["dicNF"] = dic;

            lnkEnlaces.NavigateUrl = "~/WorkFlow/wfrmActividadEnlacesAccesibles.aspx";
            lnkConcepto.NavigateUrl = "~/WorkFlow/wfrmConceptosDisponiblesActividad.aspx";
            lnkTipDoc.NavigateUrl = "~/WorkFlow/wfrmDocDisponiblesActividad.aspx";
        }

        lnkEnlaces.Enabled = pHabil;
        lnkConcepto.Enabled = pHabil;
        lnkTipDoc.Enabled = pHabil;
    }

    #endregion


    #region EVENTOS_PRINCIPALES

    protected void gvActiFlujo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarCampos();
        AsignarValoresPivote();

        var rowSelect = gvActiFlujo.SelectedRow.RowIndex;
        var dataKey = gvActiFlujo.DataKeys[rowSelect];
        if (dataKey != null)
            objIFlujoNodo.iIdNodo = Convert.ToInt16(dataKey.Value);
        
        if (objIFlujoNodo.ObtieneFila())
        {
            var dr = objIFlujoNodo.DSet.Tables[0].Rows[0];

            txtActividad.Text = dr["IdNodo"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            txtComentarios.Text = dr["Comentarios"].ToString();
            txtMaxDias.Text = dr["DuracionMaxDias"].ToString();
            txtMaxHoras.Text = dr["DuracionMaxHoras"].ToString();
            txtNemonico.Text = dr["Nemonico"].ToString();
            if (!string.IsNullOrEmpty(dr["NivelOficina"].ToString()))
                cboNivelOficina.SelectedValue = dr["NivelOficina"].ToString();
            if (!string.IsNullOrEmpty(dr["IdOficina"].ToString()))
            {
                cboOficina.SelectedValue = dr["IdOficina"].ToString();
                CargarCboArea(Convert.ToInt32(dr["IdOficina"]));
                cboOficina_SelectedIndexChanged(sender,e);
            }
            if (!string.IsNullOrEmpty(dr["IdArea"].ToString()))
                cboArea.SelectedValue = dr["IdArea"].ToString();
            if (!string.IsNullOrEmpty(dr["IdRol"].ToString()))
            {
                cboRol.SelectedValue = dr["IdRol"].ToString();
                CargarCboUsuario((int) dr["IdRol"]);
                cboRol_SelectedIndexChanged(sender,e);
            }
            if (!string.IsNullOrEmpty(dr["IdUsuario"].ToString()))
                cboUsuario.SelectedValue = dr["IdUsuario"].ToString();
            chkActividadFicticia.Checked = Convert.ToBoolean(dr["FlagFicticio"].ToString());
            chkActividadTerminal.Checked = Convert.ToBoolean(dr["FlagTerminal"].ToString());
            chkRechazarTram.Checked = Convert.ToBoolean(dr["FlagRechazo"].ToString());
            chkSincronizador.Checked = Convert.ToBoolean(dr["FlagSincronizador"].ToString());
            if (dr["Estado"].ToString()=="A")
                chkActivo.Checked = true;
            else
                chkActivo.Checked = false;

            btnEliminar.Enabled = true;
            txtActividad.Enabled = false;

            HabilitarLinks(true, dr["IdNodo"].ToString(), dr["Descripcion"].ToString());

        }
        else
        {
            Master.MensajeError("Se produjo un error al seleccionar el registro de Flujo Nodo",objIFlujoNodo.sMensajeError);
        }
    }
    
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValoresPivote();
            AsignarValores();

            string evento;
            bool resEvento = false;

            if (txtActividad.Enabled)
            {
                resEvento = objIFlujoNodo.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objIFlujoNodo.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaFlujoNodo();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Flujo Nodo");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Flujo Nodo", objIFlujoNodo.sMensajeError);
            }
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objIFlujoNodo.Eliminacion())
        {
            LimpiarCampos();
            CargarGrillaFlujoNodo();
            Master.MensajeOk("Se eliminó correctamente el registro de Flujo Nodo");
        }
        else
        {
            Master.MensajeError("Se produjo un error al eliminar el registro de Flujo Nodo", objIFlujoNodo.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS

    protected void gvActiFlujo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvActiFlujo.PageIndex = e.NewPageIndex;
        CargarGrillaFlujoNodo();
    }

    protected void cboOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();
        if (cboOficina.SelectedIndex > 0)
        {
            CargarCboArea(Convert.ToInt32(cboOficina.SelectedValue));
            
        }
    }

    protected void cboRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();
        if (cboRol.SelectedIndex > 0)
        {
            CargarCboUsuario(Convert.ToInt32(cboRol.SelectedValue));
        }
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmTipoTramiteFlujo.aspx");
    }

    #endregion
   
}