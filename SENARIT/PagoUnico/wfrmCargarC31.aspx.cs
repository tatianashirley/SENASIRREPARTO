using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using wcfPagoUnico.Entidades;
using wcfPagoUnico.Logica;

public partial class PagoUnico_wfrmCargarC31 : System.Web.UI.Page
{
    private clsPUProcesos objProc = new clsPUProcesos();
    private int _idConexion;
    private string _mensajeError;

    private static int _anioProc, _mesProc, _C31;

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

            CargarGrillaC31();    
        } 
    }

    #region CARGAR_DATOS

    private void Limpiar()
    {
        CargarGrillaC31();

        btnRegistrar.Enabled = true;
        btnAnular.Enabled = false;

        HabilitarControles(true);
    }

    private void CargarGrillaC31()
    {
        var dt = objProc.ObtieneGeneralC31(_idConexion, ref _mensajeError);

        if (dt != null)
        {

            if (dt.Rows.Count > 0)
            {
                gvRegC31.DataSource = dt;
                gvRegC31.DataBind();
            }
            else
            {
                gvRegC31.DataSource = null;
                gvRegC31.DataBind();
                Master.MensajeWarning("No se encontró ningun registro de C31 almacenado!");
            }
        }
        else
        {
            gvRegC31.DataSource = null;
            gvRegC31.DataBind();
            Master.MensajeError("Se produjo un error a la cargar la grilla de Registros C31", _mensajeError);
        }
    }
    
    #endregion

    #region EVENTOS_INTERMEDIOS
    
    private clsPUC31 RegistrarDatosC31()
    {
        var objC31 = new clsPUC31();
        objC31.AnioProceso = DateTime.Today.Year;
        objC31.MesProceso = DateTime.Today.Month;
        objC31.Anio = Convert.ToInt32(txtAnio.Text);
        objC31.Mes = Convert.ToInt32(ddlMes.SelectedValue);
        objC31.Cpl = ddlBeneficio.SelectedValue;
        objC31.Seguros = ddlSeguros.SelectedValue;
        objC31.Glosa = txtGlosa.Text;
        objC31.C31 = Convert.ToInt32(txtC31.Text);
        if (!string.IsNullOrEmpty(txtC31Rev.Text))
            objC31.C31_Rev = Convert.ToInt32(txtC31Rev.Text);
        objC31.Aniop = Convert.ToInt32(txtGestionAfectar.Text);
        objC31.Fte = txtFuenteFmto.Text;
        objC31.Total = Convert.ToSingle(txtTot.Text);
        objC31.Retension = Convert.ToSingle(txtTotAutoriz.Text); //*****************PENDIETE
        objC31.Ent = txtCodEntidad.Text;
        objC31.Org = txtOrganismo.Text;
        objC31.Dad = Convert.ToInt32(txtDirAdmin.Text);
        objC31.Ues = Convert.ToInt32(txtUnidEjec.Text);
        objC31.Cpd = txtCentroProcDat.Text;   
        objC31.Ins = txtInstancia.Text;
        objC31.Tco = ddlTipoCmpte.SelectedValue;
        objC31.Tip = ddlTipoPlanilla.SelectedValue;
        objC31.Seg = "";//*****************PENDIETE
        objC31.Codigo = "A";//*****************PENDIETE

        return objC31;

    }

    private void CargarCamposC31(int pAnioProc, int pMesProc)
    {
        var dt = objProc.ObtieneC31(_idConexion, ref _mensajeError, pAnioProc, pMesProc);

        if (dt != null && dt.Rows.Count == 1)
        {
            var dr = dt.Rows[0];

            txtAnio.Text = dr["Anio"].ToString();
            ddlMes.SelectedValue = dr["Mes"].ToString();
            ddlBeneficio.SelectedValue = dr["Cpl"].ToString();
            if (!string.IsNullOrEmpty(dr["Seguros"].ToString()))
                ddlSeguros.SelectedValue = dr["Seguros"].ToString();
            txtGlosa.Text = dr["Glosa"].ToString();
            txtC31.Text = dr["C31"].ToString();
            if (!string.IsNullOrEmpty(dr["C31_Rev"].ToString()))
                txtC31Rev.Text = dr["C31_Rev"].ToString();
            txtGestionAfectar.Text = dr["Aniop"].ToString();
            txtFuenteFmto.Text = dr["Fte"].ToString();
            txtTotAutoriz.Text = Convert.ToDecimal(dr["Retension"]).ToString();
            txtTot.Text = Convert.ToDecimal(dr["Total"]).ToString();
            txtCodEntidad.Text = dr["Ent"].ToString();
            txtOrganismo.Text = dr["Org"].ToString();
            txtDirAdmin.Text = dr["Dad"].ToString();
            txtUnidEjec.Text = dr["Ues"].ToString();
            txtCentroProcDat.Text = dr["Cpd"].ToString();
            txtInstancia.Text = dr["Ins"].ToString();
            ddlTipoPlanilla.SelectedValue = dr["Tip"].ToString();
            ddlTipoCmpte.SelectedValue = dr["Tco"].ToString();            
        }
    }

    private void HabilitarControles(bool pHabil)
    {
        txtAnio.Text = "0";
        ddlMes.SelectedIndex = 0;
        txtC31.Text = "";
        txtC31Rev.Text = "";
        btnAnular.Enabled = !pHabil;
        btnRegistrar.Enabled = pHabil;
    }

    #endregion
    
    #region EVENTOS_PRINCIPALES

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {        
        var vC31 = objProc.RegistraC31(_idConexion, ref _mensajeError, RegistrarDatosC31());

        if (vC31 != 0 && _mensajeError == null)
        {
            CargarGrillaC31();
            Limpiar();
            Master.MensajeOk("Se ha registrado el C31 corectamente");            
        }
        else
        {
            Master.MensajeError("Se ha producido un error al registrar el C31.", _mensajeError);
        }
    }
  

    /*****************************************************************************
     * Se establecio el valor de Mes Proceso y Año Proceso, según análisis
     * ***************************************************************************/
    protected void gvRegC31_SelectedIndexChanged(object sender, EventArgs e)
    {        
        var filaSel = gvRegC31.SelectedIndex;
        var dataKey = gvRegC31.DataKeys[filaSel];

        if (dataKey != null)
        {
            _anioProc = (int) dataKey["AnioProceso"];
            _mesProc = (int) dataKey["MesProceso"];
            _C31 = (int) dataKey["C31"];

            CargarCamposC31(_anioProc, _mesProc);

            btnRegistrar.Enabled = false;
            btnAnular.Enabled = true;
        }        
    }

    protected void gvRegC31_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRegC31.PageIndex = e.NewPageIndex;
        CargarGrillaC31();
    }

    protected void btnAnular_Click(object sender, EventArgs e)
    {
        var chequesAnulados = objProc.AnulaC31(_idConexion, ref _mensajeError, _anioProc, _mesProc);

        if (chequesAnulados==1 && _mensajeError == null)
        {
            Master.MensajeOk("Se anuló correctamente el registro de C31 " +  _C31);
            CargarGrillaC31();
            HabilitarControles(true);
        }
        else
        {
            Master.MensajeError("Se produjo un error al anular el C31", _mensajeError);
        }
    }

    #endregion

    
}