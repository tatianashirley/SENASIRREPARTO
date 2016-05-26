using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

using wcfReprocesos.Logica;
using wcfSeguridad.Logica;

public partial class Reprocesos_wfrmRM266Certificado : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsRM266 objRM266 = new clsRM266();

    int IdConexion, NuevoNumeroCertificado;
    private Int32 vIdUsuario
    {
        get { return Int32.Parse(ViewState["IdUsuario"].ToString()); }
        set { ViewState["IdUsuario"] = value; }
    }
    //private Int32 IdGrupoBeneficioV
    //{
    //    get { return Int32.Parse(ViewState["IdGrupoBeneficio"].ToString()); }
    //    set { ViewState["IdGrupoBeneficio"] = value; }
    //}
    private Int32 vNroFormularioRepro
    {
        get { return Int32.Parse(ViewState["NroFormularioRepro"].ToString()); }
        set { ViewState["NroFormularioRepro"] = value; }
    }
    private Boolean vRegistroAPS
    {
        get { return Boolean.Parse(ViewState["RegistroAPS"].ToString()); }
        set { ViewState["RegistroAPS"] = value; }
    }
    private Int64 vIdTramite
    {
        get { return Int64.Parse(ViewState["IdTramite"].ToString()); }
        set { ViewState["IdTramite"] = value; }
    }
    private Int32 vNroCertificado
    {
        get { return Int32.Parse(ViewState["NroCertificado"].ToString()); }
        set { ViewState["NroCertificado"] = value; }
    }
    private Int32 vIdTipoTramite
    {
        get { return Int32.Parse(ViewState["IdTipoTramite"].ToString()); }
        set { ViewState["IdTipoTramite"] = value; }
    }
    private Int32 vIdOficina
    {
        get { return Int32.Parse(ViewState["IdOficina"].ToString()); }
        set { ViewState["IdOficina"] = value; }
    }
    private Int32 vIdOficinaArea
    {
        get { return Int32.Parse(ViewState["IdOficinaArea"].ToString()); }
        set { ViewState["IdOficinaArea"] = value; }
    }
    private String vArea
    {
        get { object obj = ViewState["Area"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["Area"] = value; }
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
            //IdConexion = 4039;
            //IdConexion = 5679;
            string s01 = Session["CuentaUsuario"].ToString();
            string s02 = Session["CodUsuario"].ToString();
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
                vIdOficina = Int32.Parse(s14);
                vIdOficinaArea = Int32.Parse(s16);
                vArea = s17;
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

            vNroFormularioRepro = Convert.ToInt32(Session["NroFormularioRepro"]);
            vRegistroAPS = Convert.ToBoolean(Session["RegistroAPS"]);
            vIdTramite = Convert.ToInt64(Session["IdTramite"]);
            int IdGrupoBeneficio = Convert.ToInt32(Session["IdGrupoBeneficio"]);
            vNroCertificado = Convert.ToInt32(Session["NroCertificado"]);
            CargaDatosCertificado(vIdTramite, IdGrupoBeneficio, vNroCertificado);
            vIdTipoTramite = Convert.ToInt32(Session["IdTipoTramite"]);
            CargaAsignacionCertificados(vIdOficina, vIdOficinaArea, vIdTipoTramite);
        }
    }

    protected void CargaDatosCertificado(Int64 IdTramite, Int32 IdGrupoBeneficio, Int32 NroCertificado)
    {
        //Datos Certificado
        objRM266.iIdConexion = IdConexion;
        objRM266.iIdTramite = IdTramite;
        objRM266.iIdGrupoBeneficio = IdGrupoBeneficio;
        objRM266.iNroCertificado = NroCertificado;
        if (objRM266.ObtieneCertificadosTramite())
        {
            gvCertificados.DataSource = objRM266.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvCertificados.DataBind();
    }

    protected void chkCertificado_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbCertificadoS = (CheckBox)sender;
        if (cbCertificadoS.Checked)
        {
            foreach (GridViewRow row01 in this.gvCertificados.Rows)
            {
                CheckBox row01cb = (CheckBox)row01.FindControl("chkCertificado");
                if (row01cb != cbCertificadoS)
                    row01cb.Checked = false;
            }
        }

        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        gvCertificados.SelectedIndex = index;

        string sNroCertificado = gvCertificados.DataKeys[index]["NroCertificado"].ToString();
        vNroCertificado = Int32.Parse(sNroCertificado);
        string sIdTipoTramite = gvCertificados.DataKeys[index]["IdTipoTramite"].ToString();
        vIdTipoTramite = Int32.Parse(sIdTipoTramite);

        CargaAsignacionCertificados(vIdOficina, vIdOficinaArea, vIdTipoTramite);
    }
    protected void CargaAsignacionCertificados(Int32 iIdOficina, Int32 iIdOficinaArea, Int32 iIdTipoTramite)
    {
        //Datos Certificado
        objRM266.iIdConexion = IdConexion;
        objRM266.iIdOficina = iIdOficina;
        objRM266.iIdOficinaArea = iIdOficinaArea;
        objRM266.iIdTipoTramite = iIdTipoTramite;
        if (objRM266.ObtieneBandejaCertificadosAsignadosOficina())
        {
            gvAsignacionCertificados.DataSource = objRM266.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objRM266.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        gvAsignacionCertificados.DataBind();
    }
    protected void imgProcesaCertificado_Click(object sender, ImageClickEventArgs e)
    {
        if (HFchkNumeroAsignacionChecked.Value != "0")
        {
            //Datos Certificado
            objRM266.iIdConexion = IdConexion;
            objRM266.iNroFormularioRepro = vNroFormularioRepro;
            objRM266.bRegistroAPS = vRegistroAPS;
            objRM266.iNroCertificado = vNroCertificado;
            objRM266.iIdTipoTramite = vIdTipoTramite;
            objRM266.iIdOficina = vIdOficina;
            objRM266.iIdOficinaArea = vIdOficinaArea;
            objRM266.iNroAsignacion = Int32.Parse(HFchkNumeroAsignacionChecked.Value); //debe seleccionarse desde el grid
            objRM266.iIdUsuario = vIdUsuario;
            if (objRM266.ProcesaNuevoCertificado())
            {
                NuevoNumeroCertificado = objRM266.iNuevoNumeroCertificado;
                Session["NroCertificado"] = NuevoNumeroCertificado;
                Session["IdTipoTramite"] = vIdTipoTramite;
                Session["PreviusPage"] = ViewState["PreviousPage"];
                Response.Redirect("../Reportes/wfrmRptCertificadoCC.aspx");
            }
            else
            {
                //Error
                string DetalleError = objRM266.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Debe elegir un lote de Asignación de Certificados!');", true);
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/Reprocesos/wfrmReprocesos.aspx");
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }        
    }
}