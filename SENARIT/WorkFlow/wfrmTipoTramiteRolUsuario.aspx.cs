using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmTipoTramiteRolUsuario : System.Web.UI.Page
{
    private clsTipoTramiteRol ObjInstanciaTipTramRol = new clsTipoTramiteRol();
    private clsTipoTramiteRolUsuario ObjInstanciaTipTramRolUsua = new clsTipoTramiteRolUsuario();
    private clsSeguridad ObjInstanciaSeg = new clsSeguridad();
    private clsRolUsuario ObjInstaciaRolUsua = new clsRolUsuario();

    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
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
        }
        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;

            CargarCboRol();
            CargarCboRolSuperior();
            CargarGrillaTipoTramRol();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    #region CARGAR_DATOS_MAESTRO

    private void CargarCboRol()
    {
        cboRol.DataSource = ObjInstanciaSeg.ListaRol();
        cboRol.DataTextField = "DescripcionRol";
        cboRol.DataValueField = "IdRol";
        cboRol.DataBind();

        cboRol.Items.Insert(0, new ListItem("Seleccione valor ...", string.Empty));
        cboRol.SelectedIndex = 0; 
    }

    private void CargarCboRolSuperior()
    {
        cboRolSuperior.DataSource = ObjInstanciaSeg.ListaRol();
        cboRolSuperior.DataTextField = "DescripcionRol";
        cboRolSuperior.DataValueField ="IdRol";
        cboRolSuperior.DataBind();

        cboRolSuperior.Items.Insert(0, new ListItem("Seleccione valor ...", string.Empty));
        cboRolSuperior.SelectedIndex = 0;
    }

    private void CargarGrillaTipoTramRol()
    {
        ObjInstanciaTipTramRol.iIdConexion = _idConexion;
        ObjInstanciaTipTramRol.sIdTipoTramite = _idTipoTramite;

        if (ObjInstanciaTipTramRol.ObtieneRolesRegistrados())
        {
            gvTipoTramRol.DataSource = ObjInstanciaTipTramRol.DSet.Tables[0];
            gvTipoTramRol.DataBind();

            gvTipoTramRol.Columns[1].Visible = false;
            gvTipoTramRol.Columns[3].Visible = false;
            gvTipoTramRol.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        }
        else
        {
            gvTipoTramRol.DataSource = null;
            gvTipoTramRol.DataBind();

            if(ObjInstanciaTipTramRol.iNivel == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Roles asociados al Tipo de Trámite", ObjInstanciaTipTramRol.sMensajeError);
        }
    }


    private void LimpiarCamposMaestro()
    {
        pnlMaestro.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        cboRol.Enabled = true;
        cboRolSuperior.Enabled = true; 
        btnEliminar.Enabled = false;

        LimpiarMensajesMasterPage();

        pnlDetalle.Visible = false;

    }

    private void AsignarValoresMaestro()
    {
        ObjInstanciaTipTramRol.iIdConexion = _idConexion;
        ObjInstanciaTipTramRol.sIdTipoTramite = _idTipoTramite;
        ObjInstanciaTipTramRol.iIdRol = Convert.ToInt32(cboRol.SelectedValue);
        if (!string.IsNullOrEmpty(cboRolSuperior.SelectedValue))
            ObjInstanciaTipTramRol.iIdRolSup = Convert.ToInt32(cboRolSuperior.SelectedValue);
        ObjInstanciaTipTramRol.bFlagUnico = chkUnico.Checked;
    }

    #endregion 


    #region EVENTOS_PRINCIPALES_MAESTRO

    protected void gvTipoTramRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        int rowSelect = gvTipoTramRol.SelectedIndex;

        ObjInstanciaTipTramRol.iIdConexion = _idConexion;
        ObjInstanciaTipTramRol.sIdTipoTramite = _idTipoTramite;
        var dataKey = gvTipoTramRol.DataKeys[rowSelect];
        if (dataKey != null)
            ObjInstanciaTipTramRol.iIdRol = Convert.ToInt32(dataKey.Value);

        if (ObjInstanciaTipTramRol.ObtieneFila())
        {
            DataRow dr = ObjInstanciaTipTramRol.DSet.Tables[0].Rows[0];
            cboRol.SelectedValue = dr["IdRol"].ToString();
            cboRolSuperior.SelectedValue = dr["IdRolSup"].ToString();
            chkUnico.Checked = (bool) dr["FlagUnico"];

            cboRol.Enabled = false;
            cboRolSuperior.Enabled = false;
            btnEliminar.Enabled = true;

            //Detalle
            pnlDetalle.Visible = true;
            CargarCboUsuario();
            CargarCboUsuarioSup();
            CargarGrillaTipoTramiteRolUsua();
        }
        else
            Master.MensajeError("Se produjo un error al cargar la grilla de Roles asociados al Tipo de Trámite", ObjInstanciaTipTramRol.sMensajeError);         

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCamposMaestro();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Page.Validate("maestro");
        if (Page.IsValid)
        {
            AsignarValoresMaestro();

            bool resEvento = false;
            string evento = "";

            if (cboRol.Enabled)
            {
                resEvento = ObjInstanciaTipTramRol.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = ObjInstanciaTipTramRol.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                LimpiarCamposMaestro();
                CargarGrillaTipoTramRol();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Rol asociado al Tipo de Trámite");
            }
            else
                Master.MensajeError("Se produjo un error en el evento para el registro de Rol asociado al Tipo de Trámite", ObjInstanciaTipTramRol.sMensajeError);
        }
    }    

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        var rowSelect = gvTipoTramRol.SelectedIndex;

        ObjInstanciaTipTramRol.iIdConexion = _idConexion;
        ObjInstanciaTipTramRol.sIdTipoTramite = _idTipoTramite;
        var dataKey = gvTipoTramRol.DataKeys[rowSelect];
        if (dataKey != null)
            ObjInstanciaTipTramRol.iIdRol = Convert.ToInt32(dataKey.Value);

        if (ObjInstanciaTipTramRol.Eliminacion())
        {
            LimpiarCamposMaestro();
            CargarGrillaTipoTramRol();
            pnlDetalle.Visible = false;
        }
        else
            Master.MensajeError("Se produjo un error al eliminar el registro de Rol asociado al Tipo de Trámite", ObjInstanciaTipTramRol.sMensajeError);         
    }

    #endregion


    #region EVENTOS_SECUNDARIOS_MAESTRO

    protected void gvTipoTramRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipoTramRol.PageIndex = e.NewPageIndex;
        CargarGrillaTipoTramRol();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmTipoTramite.aspx");
    }

    #endregion
    

    #region CARGAR_DATOS_DETALLE

    private void CargarCboUsuario()
    {
        cboUsuario.Items.Clear();

        ObjInstaciaRolUsua.iIdConexion = _idConexion;
        ObjInstaciaRolUsua.iIdRol = Convert.ToInt32(cboRol.SelectedValue);
        if (ObjInstaciaRolUsua.ObtieneUsuariosXRol())
        {
            cboUsuario.DataSource = ObjInstaciaRolUsua.DSet.Tables[0];

            cboUsuario.DataTextField = "CuentaUsuario";
            cboUsuario.DataValueField = "IdUsuario";
            cboUsuario.DataBind();

            cboUsuario.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboUsuario.SelectedIndex = 0;
        }
        else
        {            
            Master.MensajeError("Se produjo un error al cargar el combo de Usuario según Rol", ObjInstaciaRolUsua.sMensajeError);
        }
    }

    private void CargarCboUsuarioSup()
    {
        cboUsuarioSup.Items.Clear();

        ObjInstaciaRolUsua.iIdConexion = _idConexion;
        ObjInstaciaRolUsua.iIdRol = Convert.ToInt32(cboRolSuperior.SelectedValue);
        if (ObjInstaciaRolUsua.ObtieneUsuariosXRol())
        {
            cboUsuarioSup.DataSource = ObjInstaciaRolUsua.DSet.Tables[0];

            cboUsuarioSup.DataTextField = "CuentaUsuario";
            cboUsuarioSup.DataValueField = "IdUsuario";
            cboUsuarioSup.DataBind();

            cboUsuarioSup.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboUsuarioSup.SelectedIndex = 0;
        }
        else
        {           
            Master.MensajeError("Se produjo un error al cargar el comdo de Usuario según Rol Superior", ObjInstaciaRolUsua.sMensajeError);
        }
    }

    private void LimpiarCamposDetalle()
    {
        pnlDetalle.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        cboUsuario.Enabled = true;
        btnEliminarDet.Enabled = false;

        LimpiarMensajesMasterPage();
    }

    private void AsignarValoresDetalle()
    {
        ObjInstanciaTipTramRolUsua.iIdConexion = _idConexion;
        ObjInstanciaTipTramRolUsua.sIdTipoTramite = _idTipoTramite;
        ObjInstanciaTipTramRolUsua.iIdRol = Convert.ToInt32(cboRol.SelectedValue);                    
    }

    private void CargarGrillaTipoTramiteRolUsua()
    {
        AsignarValoresDetalle();

        if (ObjInstanciaTipTramRolUsua.ObtieneUsuariosRegistradosXRol())
        {
            gvTipoTramUsuaRol.DataSource = ObjInstanciaTipTramRolUsua.DSet.Tables[0];
            gvTipoTramUsuaRol.DataBind();

            gvTipoTramUsuaRol.Columns[1].Visible = false;
            gvTipoTramUsuaRol.Columns[3].Visible = false;
        }
        else
        {
            gvTipoTramUsuaRol.DataSource = null;
            gvTipoTramUsuaRol.DataBind();

            if(ObjInstanciaTipTramRolUsua.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Usuarios con el Rol asociados al Tipo de Trámite", ObjInstanciaTipTramRolUsua.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_PRIMARIOS_DETALLE

    protected void gvTipoTramUsuaRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rowSelect = gvTipoTramUsuaRol.SelectedIndex;

        AsignarValoresDetalle();
        var dataKey = gvTipoTramUsuaRol.DataKeys[rowSelect];
        if (dataKey != null)
            ObjInstanciaTipTramRolUsua.iIdUsuario = Convert.ToInt32(dataKey.Value);

        if (ObjInstanciaTipTramRolUsua.ObtieneFila())
        {
            DataRow dr = ObjInstanciaTipTramRolUsua.DSet.Tables[0].Rows[0];
            cboUsuario.SelectedValue = dr["IdUsuario"].ToString();
            cboUsuarioSup.SelectedValue = dr["IdUsuarioSuperior"].ToString();

            cboUsuario.Enabled = false;
            btnEliminarDet.Enabled = true;
        }
        else
            Master.MensajeError("Se produjo un error al seleccionar el registro de Usuario con el Rol asociado al Tipo de Trámite", ObjInstanciaTipTramRol.sMensajeError);         
    }

    protected void btnNuevoDet_Click(object sender, EventArgs e)
    {
        LimpiarCamposDetalle();
    }

    protected void btnGrabarDet_Click(object sender, EventArgs e)
    {
        Page.Validate("detalle");
        if (Page.IsValid)
        {

            ObjInstanciaTipTramRolUsua.iIdUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
            if (!string.IsNullOrEmpty(cboUsuarioSup.SelectedValue))
                ObjInstanciaTipTramRolUsua.iIdUsuarioSuperior = Convert.ToInt32(cboUsuarioSup.SelectedValue);
            AsignarValoresDetalle();

            bool resEvento = false;
            string evento;
            if (cboUsuario.Enabled)
            {
                resEvento = ObjInstanciaTipTramRolUsua.Adicion();
                evento = "adicionó";
            }
            else
            {
                resEvento = ObjInstanciaTipTramRolUsua.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                LimpiarCamposDetalle();
                CargarGrillaTipoTramiteRolUsua();

                Master.MensajeOk("Se " + evento + " correctament el registro de Usuario con el Rol asociado al Tipo de Trámite");
            }
            else
                Master.MensajeError("Se produjo un error al grabar el registro de Usuario con el Rol asociado al Tipo de Trámite", ObjInstanciaTipTramRolUsua.sMensajeError);
        }
        else
            return;
    }

    protected void btnEliminarDet_Click(object sender, EventArgs e)
    {
        int rowSelect = gvTipoTramUsuaRol.SelectedIndex;

        AsignarValoresDetalle();
        var dataKey = gvTipoTramUsuaRol.DataKeys[rowSelect];
        if (dataKey != null)
            ObjInstanciaTipTramRolUsua.iIdUsuario = Convert.ToInt32(dataKey.Value);

        if (ObjInstanciaTipTramRolUsua.Eliminacion())
        {
            LimpiarCamposDetalle();
            CargarGrillaTipoTramiteRolUsua();
            Master.MensajeOk("Se eliminó correctament el registro de Usuario con el Rol asociado al Tipo de Trámite");
        }
        else
            Master.MensajeError("Se produjo un error al eliminar el registro de Usuario con el Rol asociado al Tipo de Trámite", ObjInstanciaTipTramRolUsua.sMensajeError);         
    }

    #endregion


    #region EVENTOS_SECUNDARIOS_DETALLE

    protected void gvTipoTramUsuaRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipoTramUsuaRol.PageIndex = e.NewPageIndex;
        CargarGrillaTipoTramiteRolUsua();
    }

    #endregion
    
}