using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wcfEnvioAPS.Logica;
using System.Data;

public partial class EnvioAPS_wfrmRegistroDeBajas : System.Web.UI.Page
{
    clsGeneraMedios ObjGeneraMedios = new clsGeneraMedios();
    clsRegistroBajas objRegistroBajas = new clsRegistroBajas();

    int IdConexion;

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
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState

            //CargaActividadesParaGeneracionCbte();
            PanelResultadoBusqueda.Visible = false;
            PanelDatosBaja.Visible = false;
        }
    }
    protected void CargarHistorialEnviosAPS()
    {
        objRegistroBajas.iIdConexion = IdConexion;
        objRegistroBajas.iNroCertificado = Int32.Parse(txtNumeroCertificado.Text);
        int idTipoTramite = (ddlClaseCC.SelectedValue == "A") ? 357 : 356;
        objRegistroBajas.iIdTipoTramite = idTipoTramite;
        DataTable DetalleEnvioAPS = new DataTable();
        if (objRegistroBajas.SeleccionaHistorialEnviosAPS())
        {
            gvHistorialEnvioAPS.DataSource = objRegistroBajas.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objRegistroBajas.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('El Certificado indica que fue registrado en la APS, pero NO Existen datos del Envío!!');", true);
            btnBajaSPVS.Enabled = false;
        }
        gvHistorialEnvioAPS.DataBind();
    }
    protected void CargaDatosPagosCertificado()
    {
        objRegistroBajas.iIdConexion = IdConexion;
        objRegistroBajas.iNroCertificado = Int32.Parse(txtNumeroCertificado.Text);
        objRegistroBajas.iNUP = Int64.Parse(lblNUP.Text);
        if (objRegistroBajas.SeleccionaDatosPagosCertificado())
        {
            gvDatosPagosCertificado.DataSource = objRegistroBajas.DSet.Tables[0];            
        }
        else
        {
            //Error
            string DetalleError = objRegistroBajas.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvDatosPagosCertificado.DataBind();
    }

    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        int idTipoTramite = (ddlClaseCC.SelectedValue == "A") ? 357 : 356;

        DataTable dtDatosCertificado = new DataTable();

        //dtDatosCertificado = ObjGeneracionDeMedios.BuscaDatosCertificado(txtNumeroCertificado.Text, idTipoTramite.ToString());
        ObjGeneraMedios.iIdConexion = IdConexion;
        ObjGeneraMedios.iNroCertificado = Int32.Parse(txtNumeroCertificado.Text);
        ObjGeneraMedios.iIdTipoTramite = idTipoTramite;
        if (ObjGeneraMedios.BuscaDatosCertificado())
        {
            PanelResultadoBusqueda.Visible = true;
            PanelDatosBaja.Visible = true;
            dtDatosCertificado = ObjGeneraMedios.DSet.Tables[1];

            lblCI.Text = dtDatosCertificado.Rows[0]["NumeroDocumento"].ToString();
            lblNUA.Text = dtDatosCertificado.Rows[0]["CUA"].ToString();
            lblNUP.Text = dtDatosCertificado.Rows[0]["NUP"].ToString();
            lblPaterno.Text = dtDatosCertificado.Rows[0]["PrimerApellido"].ToString();
            lblMaterno.Text = dtDatosCertificado.Rows[0]["SegundoApellido"].ToString();
            lblNombres.Text = dtDatosCertificado.Rows[0]["PrimerNombre"].ToString() + " " + dtDatosCertificado.Rows[0]["SegundoNombre"].ToString();

            lblAFP.Text = dtDatosCertificado.Rows[0]["AFP"].ToString();
            lblTipoCC.Text = dtDatosCertificado.Rows[0]["Tipo_CC"].ToString();
            lblMontoCC.Text = String.Format("{0:f2}", dtDatosCertificado.Rows[0]["MontoCC"]); //206.00

            lblFechaCC.Text = dtDatosCertificado.Rows[0]["Fecha_Aprobacion"].ToString();

            Master.MensajeOk("Certificado Encontrado!");
            CargarHistorialEnviosAPS();
            CargaDatosPagosCertificado();
        }
        else
        {
            PanelResultadoBusqueda.Visible = false;
            PanelDatosBaja.Visible = false;
            //Error
            string DetalleError = ObjGeneraMedios.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + @DetalleError + "');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('CERTI NO ENCON');", true);
            int Caso01 = DetalleError.IndexOf("Certificado no encontrado!");
            int Caso02 = DetalleError.IndexOf("El Certificado pertenece a un tramite que no se encuentra en Bandeja de Trabajo!");
            if (Caso01 == 33) ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Certificado no encontrado!');", true);
            if (Caso02 == 33) ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('El Certificado pertenece a un tramite que no se encuentra en Bandeja de Trabajo!');", true);
        }
    }
    protected void btnBajaSPVS_Click(object sender, EventArgs e)
    {
        //Dar de Baja Novedades
        int idTipoTramite = (ddlClaseCC.SelectedValue == "A") ? 357 : 356;

        objRegistroBajas.iIdConexion = IdConexion;
        objRegistroBajas.iNroCertificado = Int32.Parse(txtNumeroCertificado.Text);
        objRegistroBajas.iIdTipoTramite = idTipoTramite;
        objRegistroBajas.sNumeroResolucionA = txtNumeroRA.Text;
        objRegistroBajas.fFechaResolucionA = txtFechaRA.Text;
        objRegistroBajas.bAprueba = false; //Se dá de baja un Certificado sin aprobación=true
        if (objRegistroBajas.RegistraBajaCertificado())
        {
            Master.MensajeOk(objRegistroBajas.mensaje);
            btnBajaSPVS.Enabled = false;
        }
        else
        {
            //Error
            string DetalleError = objRegistroBajas.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
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