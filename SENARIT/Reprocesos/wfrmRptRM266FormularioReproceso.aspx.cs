using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using wcfReprocesos.Logica;

public partial class Reprocesos_wfrmRptRM266FormularioReproceso : System.Web.UI.Page
{
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsReprocesoCC objReprocesoCC = new clsReprocesoCC();

    int IdConexion; int IdUsuario; string CuentaUsuario, CodUsuario; int IdRol;
    long NUP; int NroFormularioRepro, IdTramite,IdGrupoBeneficio;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
                CuentaUsuario = Session["CuentaUsuario"].ToString(); //VGALARZA
                CodUsuario = Session["CodUsuario"].ToString(); //45
            }
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState

            NUP = Convert.ToInt64(Session["NUP"]);
            NroFormularioRepro = Convert.ToInt32(Session["NroFormularioRepro"]);
            IdTramite = Convert.ToInt32(Session["IdTramite"]);
            IdGrupoBeneficio= Convert.ToInt32(Session["IdGrupoBeneficio"]);

            DataTable dtDetalle01 = new DataTable();
            objReprocesoCC.iIdConexion = IdConexion;
            objReprocesoCC.iNroFormularioRepro = NroFormularioRepro;
            if (objReprocesoCC.ObtieneFormularioReprocesoEspecifico())
            {
                dtDetalle01 = objReprocesoCC.DSet.Tables[0];
            }
            else
            {
                //Error
                string DetalleError = objReprocesoCC.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);
            }

            //Obtiene Datos del Afiliado
            DataTable dtDatosAfiliadoA = new DataTable();
            DataTable dtDatosAfiliadoB = new DataTable();
            objDatosAfiliado.iIdConexion = IdConexion;
            objDatosAfiliado.iNUP = NUP;
            objDatosAfiliado.iIdTramite = IdTramite;
            objDatosAfiliado.iIdGrupoBeneficio = IdGrupoBeneficio;
            if (objDatosAfiliado.ObtieneDatosEspecificosAfiliado())
            {
                dtDatosAfiliadoA = objDatosAfiliado.DSet.Tables[0];
                dtDatosAfiliadoB = objDatosAfiliado.DSet.Tables[1];
            }
            else
            {
                //Error
                string DetalleError = objDatosAfiliado.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);
            }

            //dtsRepFormulario430TableAdapters.PR_rptF430_Encabezado01TableAdapter taRPTf340Encabezado01 = new dtsRepFormulario430TableAdapters.PR_rptF430_Encabezado01TableAdapter();
            //DataTable dtEncabezado02 = taRPTf340Encabezado01.GetData(40);

            //dtsRepFormulario430TableAdapters.PR_rptF430_Detalle01TableAdapter taRPTf340Detalle01 = new dtsRepFormulario430TableAdapters.PR_rptF430_Detalle01TableAdapter();
            //DataTable dtDetalle02 = taRPTf340Detalle01.GetData(40);

            //ReportViewer1.Visible=true;
            //ReportViewer1.Reset();
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //string exeFolder = Path.GetDirectoryName(Application.StartupPath);
            //string reportPath = Path.Combine(exeFolder, @"WorkFlow\rptFormulario430.rdlc");

            ReportViewer1.LocalReport.ReportPath = @"Reprocesos/RptRM266FormularioReproceso.rdlc";
            ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("CuentaUsuario", Session["CuentaUsuario"].ToString());
            //param[1] = new ReportParameter("s_cOperacion", s_iIdConexion);
            //param[2] = new ReportParameter("s_iSesionTrabajo", s_iIdConexion);
            //param[3] = new ReportParameter("s_sSSN", s_iIdConexion);
            //param[4] = new ReportParameter("o_sMensajeError", s_iIdConexion);
            //param[5] = new ReportParameter("i_iIdComprobante", s_iIdConexion);
            ReportViewer1.LocalReport.SetParameters(param);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource datasource1 = new ReportDataSource("dtsDETALLE01", dtDetalle01);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportDataSource datasource2 = new ReportDataSource("dtsDETALLE02", dtDatosAfiliadoA);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);

            ReportViewer1.LocalReport.Refresh();
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