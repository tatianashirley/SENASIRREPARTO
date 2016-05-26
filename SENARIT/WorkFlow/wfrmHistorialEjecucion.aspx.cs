using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;
using System.Data;

public partial class WorkFlow_wfrmHistorialEjecucion : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;
    string instancia, secuencia;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];
            //IdConexion = 4039;
            //IdConexion = 5638;
        }

        if (!Page.IsPostBack)
        {
            instancia = Request.QueryString["inst"];
            secuencia = Request.QueryString["sec"];
            CargaDatosTramite();
            CargaHistorialEjecucion();
        }
    }
    protected void CargaDatosTramite()
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdInstancia = Convert.ToInt64(instancia); //Request.QueryString("rf")
        ObjInstanciaNodo.iSecuencia = Convert.ToInt32(secuencia);
        DataTable dtDatosTramite = new DataTable();

        if (ObjInstanciaNodo.ObtieneFila())
        {
            dtDatosTramite = ObjInstanciaNodo.DSet.Tables[0];
            txtNroTramite.Text = dtDatosTramite.Rows[0]["IdTramite"].ToString();
            txtTipoTramite.Text = dtDatosTramite.Rows[0]["IdTipoTramite"].ToString();
            txtBeneficiario.Text = dtDatosTramite.Rows[0]["NombreBeneficiario"].ToString();
            txtCI.Text = dtDatosTramite.Rows[0]["DocIdBeneficiario"].ToString();
            txtGrupoBeneficio.Text = dtDatosTramite.Rows[0]["DescripcionGrupoBeneficio"].ToString();
            txtFlujo.Text = dtDatosTramite.Rows[0]["DescFlujo"].ToString();
            txtActividad.Text = dtDatosTramite.Rows[0]["DescNodo"].ToString();
            txtComentarios.Text = dtDatosTramite.Rows[0]["Comentarios"].ToString();
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void CargaHistorialEjecucion()
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdInstancia = Convert.ToInt64(instancia);
        ObjInstanciaNodo.iSecuencia = Convert.ToInt32(secuencia);
        if (ObjInstanciaNodo.ObtieneHistorialEjecucion())
        {
            pnlGrilla.Visible = true;
            gvHistorialEjecucion.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            gvHistorialEjecucion.DataBind();
        }
        else
        {
            //Error
            pnlGrilla.Visible = false;
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        instancia = Request.QueryString["inst"];
        secuencia = Request.QueryString["sec"];

        Response.Redirect(@"~/Workflow/wfrmEjecucionActividades.aspx?inst=" + instancia + "&sec=" + secuencia);
    }
}