using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;
using TextBox = System.Web.UI.WebControls.TextBox;

public partial class WorkFlow_wfrmTipoTramiteFlujo : System.Web.UI.Page
{
    private clsFlujo objInstFlujo = new clsFlujo();
    private clsSeguridad objInstanciaSeg = new clsSeguridad();
    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private static bool _filaSeleccionada = false;
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

            CargarCboNivelOficina();
            CargarCboRol();
            CargarCboOficina();
            CargarGrillaTipTramFlujo();
            CargarCboGrupoRestricciones();

            Master.btnCerrarSesion.CausesValidation = false;
        }

    }

    #region CARGAR_DATOS

    private void CargarCboGrupoRestricciones()
    {
        var objInstGrupRestric = new clsGrupoRestriccion();

        objInstGrupRestric.iIdConexion = _idConexion;

        if (objInstGrupRestric.ObtieneGruposDeRestricciones())
        {
            cboGrupoRestriccion.DataSource = objInstGrupRestric.DSet.Tables[0];
            cboGrupoRestriccion.DataTextField = "IdGrupoRestriccionDesc";
            cboGrupoRestriccion.DataValueField = "IdGrupoRestriccion";
            cboGrupoRestriccion.DataBind();

            cboGrupoRestriccion.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboGrupoRestriccion.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar el Combo de Grupo de Restricciones", objInstGrupRestric.sMensajeError);
        }
    }

    private void CargarCboNivelOficina()
    {
        cboNivOficina.Items.Clear();

        var objInstOficina = new clsOficinas();
        string sMensajeError = "";

        if (objInstOficina.ObtieneNivelesDeOficina(_idConexion, ref sMensajeError))
        {
            cboNivOficina.DataSource = objInstOficina.DTNiveles;
            cboNivOficina.DataTextField = "Nivel";
            cboNivOficina.DataValueField = "Nivel";
            cboNivOficina.DataBind();

            cboNivOficina.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboNivOficina.SelectedIndex = 0;
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

    private void CargarGrillaTipTramFlujo()
    {
        AsignarValoresPivote();

        if (objInstFlujo.ObtieneFlujosXTipoTramite())
        {
            gvFlujo.DataSource = objInstFlujo.DSet.Tables[0];
            gvFlujo.DataBind();
        }
        else
        {
            gvFlujo.DataSource = null;
            gvFlujo.DataBind();

            if(objInstFlujo.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Flujo", objInstFlujo.sMensajeError);
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
        txtTipoTramite.Text = _tipoTramite;
        pnlDatos.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0 );
        chkRechazo.Checked = false;

        txtIdFlujo.Enabled = true;
        btnEliminar.Enabled = false;
        _filaSeleccionada = false;
        lnkActividadFlujo.Enabled = false;
        lnkPrecedencia.Enabled = false;

        HabilitarLinks(false, string.Empty, string.Empty);
    }

    private void AsignarValoresPivote()
    {
        objInstFlujo.iIdConexion = _idConexion;
        objInstFlujo.sIdTipoTramite = _idTipoTramite;
        if (!string.IsNullOrEmpty(txtIdFlujo.Text))
            objInstFlujo.iIdFlujo = Convert.ToInt32(txtIdFlujo.Text);
    }

    private void AsignarValores()
    {
        objInstFlujo.sDescripcion = txtDescripcion.Text;
        objInstFlujo.sComentarios = txtComentarios.Text;
        objInstFlujo.iDuracionMaxDias = Convert.ToInt16(txtMaxDias.Text);
        objInstFlujo.iDuracionMaxHoras = Convert.ToInt16(txtMaxHoras.Text);
        objInstFlujo.iIdGrupoRestriccion = Convert.ToInt32(cboGrupoRestriccion.SelectedValue);
        objInstFlujo.bFlagUnRechazo = chkRechazo.Checked;
        if (cboNivOficina.SelectedIndex > 0)
            objInstFlujo.iNivelOficina = Convert.ToByte(cboNivOficina.SelectedValue);
        if(cboOficina.SelectedIndex > 0)
            objInstFlujo.iIdOficina = Convert.ToInt32(cboOficina.SelectedValue);
        if(cboArea.SelectedIndex > 0)
            objInstFlujo.iIdArea = Convert.ToInt32(cboArea.SelectedValue);
        if(cboRol.SelectedIndex > 0)
            objInstFlujo.iIdRol = Convert.ToInt32(cboRol.SelectedValue);
        if (cboUsuario.SelectedIndex > 0)
            objInstFlujo.iIdUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
        objInstFlujo.iPrioridad = Convert.ToByte(txtPrioridad.Text);

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

    private void HabilitarLinks(bool pHabil, string pIdFlujo, string pFlujo)
    {
        _dic.Clear();

        _dic.Add("IdTipTram", _idTipoTramite);
        _dic.Add("TipTram", _tipoTramite);
        _dic.Add("IdFluj", pIdFlujo);
        _dic.Add("Fluj", pFlujo);

        Session["dicNF"] = _dic;

        if (pHabil)
        {
            lnkActividadFlujo.NavigateUrl = "~/WorkFlow/wfrmActividadesFlujo.aspx";
            lnkPrecedencia.NavigateUrl = "~/WorkFlow/wfrmPrecedenciaActividades.aspx";
        }

        lnkActividadFlujo.Enabled = pHabil;
        lnkPrecedencia.Enabled = pHabil;
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void gvFlujo_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsignarValoresPivote();
        var rowSelect = gvFlujo.SelectedRow.RowIndex;
        var dataKey = gvFlujo.DataKeys[rowSelect];
        if (dataKey != null)
            objInstFlujo.iIdFlujo = Convert.ToInt32(dataKey.Value);

        if (objInstFlujo.ObtieneFila())
        {
            var dr = objInstFlujo.DSet.Tables[0].Rows[0];

            txtIdFlujo.Text = dr["IdFlujo"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            txtComentarios.Text = dr["Comentarios"].ToString();
            txtMaxDias.Text = dr["DuracionMaxDias"].ToString();
            txtMaxHoras.Text = dr["DuracionMaxHoras"].ToString();
            cboGrupoRestriccion.SelectedValue = dr["IdGrupoRestriccion"].ToString();
            chkRechazo.Checked = Convert.ToBoolean(dr["FlagUnRechazo"].ToString());
            txtPrioridad.Text = dr["Prioridad"].ToString();
            if (!string.IsNullOrEmpty(dr["NivelOficina"].ToString()))
                cboNivOficina.SelectedValue = dr["NivelOficina"].ToString();
            else
                cboNivOficina.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(dr["IdOficina"].ToString()))
                cboOficina.SelectedValue = dr["IdOficina"].ToString();
            else
                cboOficina.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(dr["IdArea"].ToString()))
            {
                CargarCboArea(Convert.ToInt32(dr["IdOficina"]));
                cboArea.SelectedValue = dr["IdArea"].ToString();
            }
            else
            {
                cboArea.SelectedIndex = 0;
            }
            cboRol.SelectedValue = dr["IdRol"].ToString();
            CargarCboUsuario((int) dr["IdRol"]);
            cboUsuario.SelectedValue = dr["IdUsuario"].ToString();

            _filaSeleccionada = true;
            txtIdFlujo.Enabled = false;
            btnEliminar.Enabled = true;
          
            HabilitarLinks(true, dr["IdFlujo"].ToString(), dr["Descripcion"].ToString());

            lnkActividadFlujo.Enabled = true;
            lnkPrecedencia.Enabled = true;
        }
        else
        {
            _filaSeleccionada = false;
            btnEliminar.Enabled = false;
            Master.MensajeError("Se produjo un error al recuperar el registro de Flujo", objInstFlujo.sMensajeError);
        }
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmTipoTramite.aspx");
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

            if (!_filaSeleccionada)
            {
                resEvento = objInstFlujo.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objInstFlujo.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaTipTramFlujo();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Flujo");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Flujo", objInstFlujo.sMensajeError);
            }
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objInstFlujo.Eliminacion())
        {
            LimpiarCampos();
            CargarGrillaTipTramFlujo();
            Master.MensajeOk("Se eliminó correctamente el registro de Flujo");
        }
        else
        {
            Master.MensajeError("Se produjo un error al eliminar el registro de Flujo", objInstFlujo.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS

    protected void gvFlujo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFlujo.PageIndex = e.NewPageIndex;
        CargarGrillaTipTramFlujo();
    }

    protected void cboOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboOficina.SelectedIndex > 0)
        {
            LimpiarMensajesMasterPage();
            CargarCboArea(Convert.ToInt32(cboOficina.SelectedValue));
        }
    }

    protected void cboRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboRol.SelectedIndex > 0)
        {
            LimpiarMensajesMasterPage();
            CargarCboUsuario(Convert.ToInt32(cboRol.SelectedValue));
        }
    }

    #endregion





   
}