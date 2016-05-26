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
using wcfInicioTramite.Logica;
using wcfWorkFlowN.Logica;

public partial class Reprocesos_wfrmRM266CambiaFechaNacimiento : System.Web.UI.Page
{
    int IdConexion; int IdUsuario;
    private Int64 vIdTramite
    {
        get { return Int64.Parse(ViewState["IdTramite"].ToString()); }
        set { ViewState["IdTramite"] = value; }
    }
    private Int32 vIdGrupoBeneficio
    {
        get { return Int32.Parse(ViewState["IdGrupoBeneficio"].ToString()); }
        set { ViewState["IdGrupoBeneficio"] = value; }
    }

    clsSeguridad objSeguridad = new clsSeguridad();
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    //clsReprocesoCC objReprocesoCC = new clsReprocesoCC();
    clsRM266 objRM266 = new clsRM266();

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
                IdUsuario = Int32.Parse(s10);
            }
            else
            {
                //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
                Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
                return;
            }
        }

        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState

            //Reprocesos/wfrmRM266CambiaFechaNacimiento.aspx?iIdTramite=218318&iIdGrupoBeneficio=3
            if (Request.QueryString["iIdTramite"] != null)
            {
                txtNumeroTramite.Text = Request.QueryString["iIdTramite"];
                vIdTramite = Int64.Parse(Request.QueryString["iIdTramite"]);
                vIdGrupoBeneficio = Int32.Parse(Request.QueryString["iIdGrupoBeneficio"]);
                CargaDatosAfiliado();
            }
        }
    }
    protected void CargaDatosAfiliado()
    {
        //Obtiene Datos del Afiliado
        DataTable dtDatosAfiliadoA = new DataTable();
        DataTable dtDatosAfiliadoB = new DataTable();
        objDatosAfiliado.iIdConexion = IdConexion;
        objDatosAfiliado.iIdTramite = vIdTramite;
        objDatosAfiliado.iIdGrupoBeneficio = vIdGrupoBeneficio;
        if (objDatosAfiliado.ObtieneDatosEspecificosAfiliado())
        {
            dtDatosAfiliadoA = objDatosAfiliado.DSet.Tables[0];
            dtDatosAfiliadoB = objDatosAfiliado.DSet.Tables[1];
            if (dtDatosAfiliadoA.Rows.Count > 0)
            {
                lblPrimerApellido.Text = dtDatosAfiliadoA.Rows[0]["PrimerApellido"].ToString();
                lblSegundoApellido.Text = dtDatosAfiliadoA.Rows[0]["SegundoApellido"].ToString();
                lblPrimerNombre.Text = dtDatosAfiliadoA.Rows[0]["PrimerNombre"].ToString();
                lblSegundoNombre.Text = dtDatosAfiliadoA.Rows[0]["SegundoNombre"].ToString();
                lblSexo.Text = dtDatosAfiliadoA.Rows[0]["Sexo"].ToString();
                lblCUA.Text = dtDatosAfiliadoA.Rows[0]["CUA"].ToString();
                lblFechaNacimiento.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoA.Rows[0]["FechaNacimiento"]);
                txtFechaNacimientoNueva.Text = lblFechaNacimiento.Text;
                lblFechaFallecimiento.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoA.Rows[0]["FechaFallecimiento"]);
                lblEstadoCivil.Text = dtDatosAfiliadoA.Rows[0]["EstadoCivil"].ToString();
                lblEntidadGestora.Text = dtDatosAfiliadoA.Rows[0]["EntidadGestora"].ToString();
                lblNombreSubBeneficio.Text = dtDatosAfiliadoA.Rows[0]["NombreSubBeneficio"].ToString();
                lblSector.Text = dtDatosAfiliadoA.Rows[0]["Sector"].ToString();
                lblOficinaNotificacion.Text = dtDatosAfiliadoA.Rows[0]["OficinaNotificacion"].ToString();
                lblFechaInicioTramite.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoA.Rows[0]["FechaInicioTramite"]);
                lblDescripcionEstadoObjeto.Text = dtDatosAfiliadoA.Rows[0]["DescripcionEstadoObjeto"].ToString();
            }
            if (dtDatosAfiliadoB.Rows.Count > 0)
            {
                //lblMontoCC.Text = String.Format("{0:f2}", dtDatosAfiliadoB.Rows[0]["MontoCC"]); //206.00
                //lblMontoCCA.Text = String.Format("{0:f2}", dtDatosAfiliadoB.Rows[0]["MontoCCAceptado"]); //206.00
                ////lblFechaGeneracion.Text = dtDatosAfiliadoB.Rows[0]["FechaGeneracion"].ToString();
                //lblFechaCalculo.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaCalculo"]);
                //lblFechaGeneracion.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaGeneracion"]);
                //lblFechaAceptacion.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaAceptacion"]);
                //lblFechaImpresion.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaImpresion"]);
                //lblPeriodoSalario.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["PeriodoSalario"]);
                //lblSIPimp.Text = dtDatosAfiliadoB.Rows[0]["SIP_impresion"].ToString();
                //lblDensidadTotal.Text = String.Format("{0:f2}", dtDatosAfiliadoB.Rows[0]["DensidadTotal"]); //206.00 
            }
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnCambiaFechaNacimientoRM266_Click(object sender, EventArgs e)
    {
        Page.Validate("ValRepro2");
        if (Page.IsValid && !String.IsNullOrEmpty(txtMatriculaNueva.Text))
        {
            DateTime FechaNacimientoNueva = DateTime.Parse(txtFechaNacimientoNueva.Text);

            objRM266.iIdConexion = IdConexion;

            objRM266.iNumeroResolucion = txtNumeroResolucion2.Text;
            objRM266.fFechaResolucion = (String.IsNullOrEmpty(txtFechaResolucion2.Text) ? (DateTime?)null : DateTime.Parse(txtFechaResolucion2.Text));
            objRM266.fFechaNacimientoNueva = FechaNacimientoNueva;
            objRM266.sMatriculaNueva = txtMatriculaNueva.Text;
            objRM266.iIdTramite = vIdTramite;
            objRM266.iIdGrupoBeneficio = vIdGrupoBeneficio;
            if (objRM266.ModFechaNacimiento())
            {
                Master.MensajeOk("EXITO! Nueva Fecha de Nacimiento actualizada.");
            }
            else
            {
                //Error
                string DetalleError = objRM266.sMensajeError;
                string Error = "Error al realizar la operación";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Error + ": " + DetalleError + "');", true);
                Master.MensajeError(Error, DetalleError);
                return;
            }

            string Mensaje = "Se cambió exitosamente la Fecha de Nacimiento!<br/>";
            Mensaje += "<ul>";
            Mensaje += "<li>El cambio registró en el módulo de Novedades Formulario 05.</li>";
            Mensaje += "<li>Se actualizó la tabla Persona.Persona y Referencial.PERSONACC.</li>";
            Mensaje += "</ul><br/>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + Mensaje + "');", true);
            
            //btnVolver_Click(null, null);
            btnGenerarMatricula.Enabled = false;
            btnCambiaFechaNacimiento.Enabled = false;
        }
    }
    #region Genera Matricula
    protected void btnGenerarMatricula_Click(object sender, EventArgs e)
    {
        txtMatriculaNueva.Text = GenerarMatricula(lblPrimerApellido.Text, lblSegundoApellido.Text, lblPrimerNombre.Text, (new clsFormatoFecha()).GeneraFechaDMY(txtFechaNacimientoNueva.Text), lblSexo.Text);
        btnCambiaFechaNacimiento.Focus();
    }
    public string GenerarMatricula(string pat, string mat, string nombre, DateTime fnac, string sex)
    {
        string result = "";
        string mat_new;
        try
        {
            string ip = "";
            string im = "";
            string ino = "";
            int tsexo;
            int a, d, m;
            string a1, d1, m1;

            if (pat == "NULL" || pat.Trim() == "")
            {
                pat = "";
            }
            else
            {
                pat = pat.Trim();
                ip = pat.Substring(0, 1);
            }

            if (mat == "NULL" || mat.Trim() == "")
            {
                mat = "";
            }
            else
            {
                mat = mat.Trim();
                im = mat.Substring(0, 1);
            }

            if (nombre == "NULL" || nombre.Trim() == "")
            {
                nombre = "";
            }
            else
            {
                nombre = nombre.Trim();
                ino = nombre.Substring(0, 1);
            }

            if (ip == "" && im != "")
            {
                if (mat.Length > 1)
                {
                    im = mat.Substring(0, 2);
                }
            }
            if (im == "" && ip != "")
            {
                if (pat.Length > 1)
                {
                    ip = pat.Substring(0, 2);
                }
            }

            tsexo = 0;

            if (sex == "1" || sex == "F")
            {
                tsexo = 50;
            }

            a = fnac.Year;
            m = fnac.Month;
            d = fnac.Day;
            m = m + tsexo;

            a1 = a.ToString().Substring(2, 2);
            if (m < 10)
            {
                m1 = "0" + m;
            }
            else
            {
                m1 = m.ToString();
            }

            if (d < 10)
            {
                d1 = "0" + d;
            }
            else
            {
                d1 = d.ToString();
            }

            mat_new = a1 + m1 + d1 + ip + im + ino;
            result = mat_new.ToUpper();
        }
        catch (Exception ex)
        {
            result = "";
            System.Console.Write(ex.Message);
        }
        return result;
    }
    #endregion
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