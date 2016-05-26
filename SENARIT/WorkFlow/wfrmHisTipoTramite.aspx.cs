using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmHisTipoTramite : System.Web.UI.Page
{
    private clsHisTipoTramite ObjInstanciaTipoTram = new clsHisTipoTramite();
    private int _idConexion;

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
        }

        if (!Page.IsPostBack)
        {
            CargarTipoTramites();
            CargarCboGrupoRestriccion();
            CargarCboModulos();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }



    #region CARGAR_DATOS

    private void CargarCboModulos()
    {
        var oiSeg = new clsSeguridad();

        cboModulo.DataSource = oiSeg.ListaModulos(_idConexion, "Q");
        cboModulo.DataTextField = "DescripcionModulo";
        cboModulo.DataValueField = "IdModulo";
        cboModulo.DataBind();

        cboModulo.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboModulo.SelectedIndex = 0;
    }


    private void CargarTipoTramites()
    {
        ObjInstanciaTipoTram.iIdConexion = _idConexion;
        if (ObjInstanciaTipoTram.ObtieneTiposDeTramite())
        {
            gvTipoTramites.DataSource = ObjInstanciaTipoTram.DSet.Tables[0];
            gvTipoTramites.DataBind();

            cboTramiteSuperior.DataSource = ObjInstanciaTipoTram.DSet.Tables[0];
            cboTramiteSuperior.DataTextField = "Descripcion";
            cboTramiteSuperior.DataValueField = "IdTipoTramite";
            cboTramiteSuperior.DataBind();

            cboTramiteSuperior.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboTramiteSuperior.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de los Tipos de Trámite", ObjInstanciaTipoTram.sMensajeError);
            gvTipoTramites.DataSource = null;
            gvTipoTramites.DataBind();
        }
    }

    private void CargarCboGrupoRestriccion()
    {
        var oiGrupRes = new clsHisGrupoRestriccion();

        oiGrupRes.iIdConexion = _idConexion;
        if (oiGrupRes.ObtieneGruposDeRestricciones())
        {
            cboGrupoRestric.DataSource = oiGrupRes.DSet;
            cboGrupoRestric.DataTextField = "Descripcion";
            cboGrupoRestric.DataValueField = "IdGrupoRestriccion";
            cboGrupoRestric.DataBind();

            cboGrupoRestric.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboGrupoRestric.SelectedIndex = 0;
        }
        else
            Master.MensajeError("Se produjo un error en el cargado de los Grupos de Restricciones", oiGrupRes.sMensajeError);
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
        pnlTipoTram.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        pnlTipoTram.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        pnlTipoTram.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);
        pnlTipoTram.Controls.OfType<LinkButton>().ToList().ForEach(x => x.Enabled = false);

        //btnEliminar.Enabled = false;
        txtIdTipoTramite.Enabled = true;

        HabilitarLinks(false, string.Empty, string.Empty);
    }

    private void AsignarValores()
    {
        ObjInstanciaTipoTram.iIdConexion = _idConexion;
        ObjInstanciaTipoTram.iIdHisInstancia = Convert.ToInt32(hdfHisInstancia.Value);
        ObjInstanciaTipoTram.sIdTipoTramite = txtIdTipoTramite.Text;
        ObjInstanciaTipoTram.sDescripcion = txtDescripcion.Text;
        ObjInstanciaTipoTram.sIdTipoTramiteSup = cboTramiteSuperior.SelectedValue;
        ObjInstanciaTipoTram.bFlagAgrupador = chkEsAgrupador.Checked;
        ObjInstanciaTipoTram.bFlagExcepcion = chkAdmiteExcepciones.Checked;
        ObjInstanciaTipoTram.sFlagReinicio = Convert.ToInt16(chkAdmReinicioTram.Checked).ToString();
        ObjInstanciaTipoTram.iIdModulo = Convert.ToInt32(cboModulo.SelectedValue);
        ObjInstanciaTipoTram.iMaxDiasIniTramite = Convert.ToInt16(txtMaxDiasIniTram.Text);
        ObjInstanciaTipoTram.iMaxDiasTramiteInactivo = Convert.ToInt16(txtMaxDiasInactivo.Text);
        if (!string.IsNullOrEmpty(cboGrupoRestric.SelectedValue))
            ObjInstanciaTipoTram.iIdGrupoRestriccion = Convert.ToInt32(cboGrupoRestric.SelectedValue);
    }

    private void HabilitarLinks(bool pHabil, string pIdTipoTramite, string pTipoTramite)
    {
        _dic.Clear();
        _dic.Add("IdTipTram", pIdTipoTramite);
        _dic.Add("TipTram", pTipoTramite);

        Session["dicNF"] = _dic;


        if (pHabil)
        {
            lnkTipoTramRolUsua.NavigateUrl = "~/WorkFlow/wfrmTipoTramiteRolUsuario.aspx";
            lnkTipoTramConcepto.NavigateUrl = "~/WorkFlow/wfrmTipoTramiteConcepto.aspx";
            lnkTipoTramTipoDoc.NavigateUrl = "~/WorkFlow/wfrmTipoTramiteTipoDoc.aspx";
            lnkTipoTramFlujo.NavigateUrl = "~/WorkFlow/wfrmTipoTramiteFlujo.aspx";
        }

        lnkTipoTramRolUsua.Enabled = pHabil;
        lnkTipoTramConcepto.Enabled = pHabil;
        lnkTipoTramTipoDoc.Enabled = pHabil;
        lnkTipoTramFlujo.Enabled = pHabil;
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void gvTipoTramites_SelectedIndexChanged(object sender, EventArgs e)
    {

        LimpiarMensajesMasterPage();

        int rowSelect = gvTipoTramites.SelectedIndex;
        ObjInstanciaTipoTram.iIdConexion = _idConexion;

        var dataKey = gvTipoTramites.DataKeys[rowSelect];
        if (dataKey != null)
        {
            ObjInstanciaTipoTram.iIdHisInstancia = Convert.ToInt32(gvTipoTramites.DataKeys[rowSelect]["IdHisInstancia"]);
            hdfHisInstancia.Value = ObjInstanciaTipoTram.iIdHisInstancia.ToString();
            ObjInstanciaTipoTram.sIdTipoTramite = gvTipoTramites.DataKeys[rowSelect]["IdTipoTramite"].ToString();
        }
        if (ObjInstanciaTipoTram.ObtieneFila())
        {
            DataRow dr = ObjInstanciaTipoTram.DSet.Tables[0].Rows[0];
            txtIdTipoTramite.Text = dr["IdTipoTramite"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            cboTramiteSuperior.SelectedValue = dr["IdTipoTramiteSup"].ToString();
            chkEsAgrupador.Checked = Convert.ToBoolean(dr["FlagAgrupador"]);
            chkAdmiteExcepciones.Checked = Convert.ToBoolean(dr["FlagExcepcion"]);
            chkAdmReinicioTram.Checked = Convert.ToBoolean(Convert.ToInt16(dr["FlagReinicio"]));
            cboModulo.SelectedValue = dr["IdModulo"].ToString();
            txtMaxDiasIniTram.Text = dr["MaxDiasIniTramite"].ToString();
            txtMaxDiasInactivo.Text = dr["MaxDiasTramiteInactivo"].ToString();
            if (!string.IsNullOrEmpty(dr["IdGrupoRestriccion"].ToString()))
                cboGrupoRestric.SelectedValue = dr["IdGrupoRestriccion"].ToString();
            else
                cboGrupoRestric.SelectedIndex = 0;

            //btnEliminar.Enabled = true;
            txtIdTipoTramite.Enabled = false;
            pnlTipoTram.Controls.OfType<LinkButton>().ToList().ForEach(x => x.Enabled = true);

            HabilitarLinks(true, txtIdTipoTramite.Text, txtDescripcion.Text);

            Master.MensajeOk("Se ha seleccionado correctamente el Registro del Tipo de Trámite");

        }
        else
            Master.MensajeError("Se produjo un error al seleccionar el registro de Tipo de Trámite", ObjInstanciaTipoTram.sMensajeError);
    }

    //protected void btnNuevo_Click(object sender, EventArgs e)
    //{
    //    LimpiarCampos();
    //}

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValores();
            bool resEvento = false;
            string evento = null;

            //if (txtIdTipoTramite.Enabled)
            //{
            //    evento = "adicionó";
            //    resEvento = ObjInstanciaTipoTram.Adicion();
            //}
            //else
            //{
                evento = "modificó";
                resEvento = ObjInstanciaTipoTram.Modificacion();
            //}

            if (resEvento)
            {
                LimpiarCampos();
                CargarTipoTramites();
                Master.MensajeOk("Se " + evento + " correctamente el Registro del Tipo de Trámite");
            }
            else
                Master.MensajeError("Se produjo un error al grabar el Registro del Tipo de Trámite", ObjInstanciaTipoTram.sMensajeError);
        }
    }

    //protected void btnEliminar_Click(object sender, EventArgs e)
    //{
    //    ObjInstanciaTipoTram.iIdConexion = _idConexion;
    //    ObjInstanciaTipoTram.sIdTipoTramite = txtIdTipoTramite.Text;

    //    if (ObjInstanciaTipoTram.Eliminacion())
    //    {
    //        LimpiarCampos();
    //        CargarTipoTramites();
    //        Master.MensajeOk("Se ha eliminado correctamente el Registro del Tipo de Trámite");
    //    }
    //    else
    //        Master.MensajeError("Se produjo un error al eliminar Registro del Tipo de Trámite", ObjInstanciaTipoTram.sMensajeError);
    //}

    #endregion

    #region EVENTOS_SECUNDARIOS

    protected void gvTipoTramites_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipoTramites.PageIndex = e.NewPageIndex;
        CargarTipoTramites();
    }

    #endregion

}