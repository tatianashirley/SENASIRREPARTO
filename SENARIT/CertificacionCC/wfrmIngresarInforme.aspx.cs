using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AjaxControlToolkit;
using wcfSeguridad.Logica;
using wcfCertificacionCC.Logica;
using wcfGeo.Logica;
using wcfWorkFlowN.Logica;


using System.Drawing;

public partial class CertificacionCC_wfrmIngresarInforme : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsParametrizacion ObjParametrizacion = new clsParametrizacion();
    clsTramiteAsignado ObjTramite = new clsTramiteAsignado();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hfIdTramite.Value = Request.QueryString["iIdTramite"];
            hfIdGrupoBeneficio.Value = Request.QueryString["iIdGrupoBeneficio"];
            int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
            int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
            DatosAsegurado(iIdTramite, iIdGrupoBeneficio);
            ListaInformes(iIdTramite, iIdGrupoBeneficio);
        }

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        ckeInforme.Text = "";
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        string sInforme = ckeInforme.Text;

        //WF
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);

        //CODIGO PARA WF

        string Par1 = null;
        string Par2 = null;
        string Par3 = null;
        string Par4 = null;
        string Par5 = null;
        if ((int)Session["RolUsuario"] == 9) // Verificador
        {
            Par1 = "VERIFICACION";
            Par2 = "VERIFICACION_OK";
            DataTable tblVerificador = null;
            //tblVerificador = ObjTramite.ListaParametrosWF(iIdConexion, "S", iIdTramite, iIdGrupoBeneficio, ref sMensajeError);

            //foreach (DataRow drDataRow in tblVerificador.Rows)
            //{
            //    Par3 = Convert.ToString(drDataRow["IdUsuarioSuperior"]);

            //}
        }
        if ((int)Session["RolUsuario"] == 8) // Revisor
        {
            Par1 = "REVISION";
            Par2 = "REVISION_OK";
        }
        if ((int)Session["RolUsuario"] == 7) // Control
        {
            Par1 = "QCTRL";
            Par2 = "QCTRL_OK";
        }

        cOperacion = "A";

        if (ObjProcedimientoManual.Apruebaconinforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, 0, sInforme, ref sMensajeError))
        {

            //CODIGO DE INTEGRACION CON WF


            //clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
            //ObjINodo.iIdConexion = iIdConexion;
            //ObjINodo.iIdTramite = iIdTramite;
            //ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
            //ObjINodo.sNemoNodoOrig = Par1;
            //ObjINodo.sEstado = "I";
            //if (ObjINodo.ObtieneActividadActiva())
            //{
            //    clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
            //    ObjINodoCpto.iIdConexion = iIdConexion;
            //    ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
            //    ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
            //    ObjINodoCpto.sIdConcepto = Par2;
            //    ObjINodoCpto.bValorBoolean = true;
            //    if (ObjINodoCpto.Grabar())
            //    {
            //        ObjINodoCpto.iIdConexion = iIdConexion;
            //        ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
            //        ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
            //        ObjINodoCpto.sIdConcepto = "ID_USUARIO";
            //        ObjINodoCpto.iValorInt = Convert.ToInt32(Par3);
            //        if (ObjINodoCpto.Grabar())
            //        {

            string msg = "La aprobacion se realizo con exito";
            Master.MensajeOk(msg);
            //}

            //}
            //else
            //{
            //    string Error = "Error al realizar la operación";
            //    string DetalleError = ObjINodo.sMensajeError;
            //    Master.MensajeError(Error, DetalleError);
            //}

            //}
            //else
            //{
            //    string Error = "Error al realizar la operación";
            //    string DetalleError = ObjINodo.sMensajeError;
            //    Master.MensajeError(Error, DetalleError);
            //}



            //if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
            //{

            //    Response.Redirect(ViewState["PreviousPage"].ToString());
            //}

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void DatosAsegurado(int iIdTramite, int iIdGrupoBeneficio)
    {

        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        DataTable tblListaDatosAsegurado = null;
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaDatosAsegurado != null)
        {
            foreach (DataRow drDataRow in tblListaDatosAsegurado.Rows)
            {
                lblPaterno.Text = Convert.ToString(drDataRow["PrimerApellido"]);
                lblMaterno.Text = Convert.ToString(drDataRow["SegundoApellido"]);
                lblNombres.Text = Convert.ToString(drDataRow["PrimerNombre"]) + ' ' + Convert.ToString(drDataRow["SegundoNombre"]);
                lblMatricula.Text = Convert.ToString(drDataRow["Matricula"]);
                lblFechaInicio.Text = Convert.ToString(drDataRow["FechaInicioTramite"]);
                lblFechaAsignacion.Text = Convert.ToString(drDataRow["FechaAsignacion"]);


            }
     
        }
    }
    private void ListaInformes(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "K";
        string sMensajeError = null;
        DataTable tblListaInformes = null;
        tblListaInformes = ObjEmisionFormularioCC.ListaInformes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaInformes != null && tblListaInformes.Rows.Count > 0)
        {
            gvDatosInformes.Visible = true;
            lblTituloInformes.Visible = true;
            gvDatosInformes.DataSource = tblListaInformes;
            gvDatosInformes.DataBind();
        }
        else
        {
            gvDatosInformes.Visible = false;
            lblTituloInformes.Visible = false;
        }

    }
    protected void gvDatosInformes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int iIdTramite = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            string NroControl = Convert.ToString(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["NroControl"]);
            string sRevisor = Convert.ToString(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["Revisor"]);
            int iRegistroActivo = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["RegistroActivo"]);
            if (iRegistroActivo == 0)
            {
                e.Row.BackColor = Color.FromName("#FFCC00");
            }
            e.Row.FindControl("imgVer").Visible = true;
            
        }
    }
    protected void gvDatosInformes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sMensajeError = null;
        
        if (e.CommandName == "cmdVer")
        {
            try
            {
                //pnlEditarInforme.Visible = true;
                //btnActualizar.Visible = false;
                //btnInsertarInforme.Visible = false;
                int Index = Convert.ToInt32(e.CommandArgument);
                string NroControl = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);
                string iIdTramite = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteInformeCertificacion.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&NroControl=" + Server.UrlEncode(NroControl) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }

    }
}