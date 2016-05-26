using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

using wcfSeguridad.Logica;
using wcfReprocesos.Logica;

public partial class Reprocesos_wfrmDS288HabilitaReproceso : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsDS28888 objDS8888 = new clsDS28888();
    //clsReprocesoCC objReprocesoCC = new clsReprocesoCC();

    int IdConexion;
    private Int32 vIdUsuario
    {
        get { return Int32.Parse(ViewState["IdUsuario"].ToString()); }
        set { ViewState["IdUsuario"] = value; }
    }
    private Int64 vIdTramite
    {
        get { return Int64.Parse(ViewState["IdTramite"].ToString()); }
        set { ViewState["IdTramite"] = value; }
    }
    private Int64 vNUP
    {
        get { return Int64.Parse(ViewState["NUP"].ToString()); }
        set { ViewState["NUP"] = value; }
    }
    private Int32 vIdGrupoBeneficio
    {
        get { return Int32.Parse(ViewState["IdGrupoBeneficio"].ToString()); }
        set { ViewState["IdGrupoBeneficio"] = value; }
    }
    private Int32 vIdTipoTramite
    {
        get { return Int32.Parse(ViewState["IdTipoTramite"].ToString()); }
        set { ViewState["IdTipoTramite"] = value; }
    }
    private Int32 vNroCertificado
    {
        get { return Int32.Parse(ViewState["NroCertificado"].ToString()); }
        set { ViewState["NroCertificado"] = value; }
    }
    private Int32 vIdTipoCC
    {
        get { return Int32.Parse(ViewState["IdTipoCC"].ToString()); }
        set { ViewState["IdTipoCC"] = value; }
    }
    private Boolean vRegistroAPS
    {
        get { return Boolean.Parse(ViewState["RegistroAPS"].ToString()); }
        set { ViewState["RegistroAPS"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];
            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion(IdConexion);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
                string s11 = dtUsuarioDatos.Rows[0]["CuentaUsuario"].ToString();  //TECENVIOS2
                string s12 = dtUsuarioDatos.Rows[0]["IdRol"].ToString();    //107
                string s13 = dtUsuarioDatos.Rows[0]["Rol"].ToString();    //Técnico de Procesamiento CC y Envío APS
                string s14 = dtUsuarioDatos.Rows[0]["IdOficina"].ToString();    //2
                string s15 = dtUsuarioDatos.Rows[0]["Oficina"].ToString();  //LA PAZ
                string s16 = dtUsuarioDatos.Rows[0]["IdArea"].ToString();  //240
                string s17 = dtUsuarioDatos.Rows[0]["Area"].ToString(); //Envíos APS
                string s18 = dtUsuarioDatos.Rows[0]["FecHoraString"].ToString();    //29/05/2015  9:15AM
                string s19 = dtUsuarioDatos.Rows[0]["IdTipoUsuario"].ToString();    //677

                vIdUsuario = Int32.Parse(s10);
            }
            else
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
        }

        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState

            //Session["NroFormularioRepro"] = vNroFormularioRepro;
            //Session["RegistroAPS"] = vRegistroAPS;
            //Session["IdTramite"] = vIdTramite;
            //Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
            //Session["NroCertificado"] = vNroCertificado;
            //Session["IdTipoTramite"] = vIdTipoTramite;

            //vNroFormularioRepro = Convert.ToInt32(Session["NroFormularioRepro"]);
            //vRegistroAPS = Convert.ToBoolean(Session["RegistroAPS"]);
            vIdTramite = Convert.ToInt64(Session["IdTramite"]);
            vIdGrupoBeneficio = Convert.ToInt32(Session["IdGrupoBeneficio"]);
            //vNroCertificado = Convert.ToInt32(Session["NroCertificado"]);
            vIdTipoTramite = Convert.ToInt32(Session["IdTipoTramite"]);

            CargaSalarioCotizable(vIdTramite, vIdGrupoBeneficio);
        }
    }

    protected void CargaSalarioCotizable(Int64 IdTramite, Int32 IdGrupoBeneficio)
    {
        //Datos Certificado
        DataTable dtSalarioCotizable = new DataTable();
        objDS8888.iIdConexion = IdConexion;
        objDS8888.iIdTramite = IdTramite;
        objDS8888.iIdGrupoBeneficio = IdGrupoBeneficio;
        if (objDS8888.ObtieneSalarioCotizable())
        {
            dtSalarioCotizable = objDS8888.DSet.Tables[0];
            gvSalarioCotizable.DataSource = dtSalarioCotizable;
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvSalarioCotizable.DataBind();
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx");
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }        
    }
}