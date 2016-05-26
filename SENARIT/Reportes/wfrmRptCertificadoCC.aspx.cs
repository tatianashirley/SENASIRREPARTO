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


public partial class Reportes_wfrmRptCertificadoCC : System.Web.UI.Page
{
    clsRenumera objRenumera = new clsRenumera();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;
    string mensaje = null;
    int NroCertificado, IdTipoTramite;

    protected void Page_Load(object sender, EventArgs e)
    {
        NroCertificado = (int)Session["NroCertificado"];
        IdTipoTramite = (int)Session["IdTipoTramite"];

        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
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

            DataTable dtDetalle01 = new DataTable();
            objRenumera.iIdConexion = IdConexion;
            objRenumera.iNroCertificado = NroCertificado;
            objRenumera.iIdTipoTramite = IdTipoTramite;
            if (objRenumera.ObtieneDatosCertificado())
            {
                dtDetalle01 = objRenumera.DSet.Tables[0];
            }
            else
            {
                //Error
                string DetalleError = objRenumera.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }

            ReportViewer1.LocalReport.ReportPath = @"Reportes/ReporteCertificadoCC.rdlc";
            ReportViewer1.LocalReport.EnableExternalImages = true;

            //ReportViewer1.ShowExportControls = false;
            //ReportViewer1.ShowPrintButton = false;
            //ReportViewer1.ShowRefreshButton = false;
            //ReportViewer1.ShowToolBar = false;
            //ReportViewer1.ShowZoomControl = false;

            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("usuario", "vgo01");
            //param[1] = new ReportParameter("s_cOperacion", s_iIdConexion);
            //param[2] = new ReportParameter("s_iSesionTrabajo", s_iIdConexion);
            //param[3] = new ReportParameter("s_sSSN", s_iIdConexion);
            //param[4] = new ReportParameter("o_sMensajeError", s_iIdConexion);
            //param[5] = new ReportParameter("i_iIdComprobante", s_iIdConexion);

            //ReportViewer1.LocalReport.SetParameters(param);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource datasource1 = new ReportDataSource("DsCertificadoCC", dtDetalle01);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            //ReportDataSource datasource2 = new ReportDataSource("dtsCertificadoCC", dtDetalle01);
            //ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.Refresh();
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        if (Session["PreviusPage"] != null)
        {
            Session["PreviusPage"] = null;
            Response.Redirect(Session["PreviusPage"].ToString());
        }
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }        
    }
}