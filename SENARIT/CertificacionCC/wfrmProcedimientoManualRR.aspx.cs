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


public partial class CertificacionCC_wfrmProcedimientoManualRR : System.Web.UI.Page
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
            if ((int)Session["RolUsuario"] == 9) //Verificador
            {
                lblArchivo.Visible = true;
                pnlBotonesdeAccion.Visible = false;
                pnlComponentes.Visible = false;
                pnlBajaFormulario.Visible = false;
                btnAnularCertificacion.Visible = false;
                
            }
            else
            {
                lblArchivo.Visible = false;
                if (Request.QueryString["vUrl"] != null)
                {
                    ViewState["PreviousPage"] = ObjSeguridad.URLDecode(Request.QueryString["vUrl"]);
                }
                else
                {
                    ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
                }
                int iIdTramite = 0;
                int iIdGrupoBeneficio = 0;
                if (Request.QueryString["iIdTramite"] != null)
                {

                    iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                    iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                    hfIdTramite.Value = Convert.ToString(iIdTramite);
                    hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);
                    ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                    ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                }

            }

        }

    }



    private void ListarDatosAsegurado(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        DataTable tblListaDatosAsegurado = null;
        int Flag;

        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaDatosAsegurado != null && tblListaDatosAsegurado.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in tblListaDatosAsegurado.Rows)
            {
                lblPaterno.Text = Convert.ToString(drDataRow["PrimerApellido"]);
                lblMaterno.Text = Convert.ToString(drDataRow["SegundoApellido"]);
                lblNombres.Text = Convert.ToString(drDataRow["PrimerNombre"]) + ' ' + Convert.ToString(drDataRow["SegundoNombre"]);
                lblDocIdentidad.Text = Convert.ToString(drDataRow["NumeroDocumento"]) + ' ' + Convert.ToString(drDataRow["ComplementoSEGIP"]);
                lblFechaNacimiento.Text = Convert.ToString(drDataRow["FechaNacimiento"]);
                lblFechaFallecimiento.Text = Convert.ToString(drDataRow["FechaFallecimiento"]);
                lblEstadoCivil.Text = Convert.ToString(drDataRow["EstadoCivil"]);
                lblRegional.Text = Convert.ToString(drDataRow["OficinaNotificacion"]); ;
                lblMatricula.Text = Convert.ToString(drDataRow["Matricula"]);
                lblCUA.Text = Convert.ToString(drDataRow["CUA"]);
                lblTramite.Text = Convert.ToString(drDataRow["IdTramite"]);
                lblFechaInicio.Text = Convert.ToString(drDataRow["FechaInicioTramite"]);
                lblTipoReproceso.Text = Convert.ToString(drDataRow["TipoReproceso"]);
                hfEstadoTramite.Value = Convert.ToString(drDataRow["EstadoTramite"]);
            }
            if (hfEstadoTramite.Value == "42")
            {
                lblTipoReproceso.Visible = true;
                lblEstadoTramite.Text = "- Tramite en reproceso verificar componentes";
                lblEstadoTramite.Visible = true;

            }
            if (hfEstadoTramite.Value == "23")
            {

                lblEstadoTramite.Text = "Tramite en recurso de reclamacion";
                lblEstadoTramite.Visible = true;


            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }

    // Lista los componentes que se estan certificando o no
    private void ListarComponentesNew(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        string sMensajeError = null;
        DataTable tblDatosComponentes = ObjProcedimientoManual.DatosProcedimientoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblDatosComponentes != null)
        {
            ViewState["Cantidad"] = tblDatosComponentes.Rows.Count;
            int iVersion = Convert.ToInt32(tblDatosComponentes.Rows[0]["Version"]);


        }
        gvDatosComponentes.DataSource = tblDatosComponentes;
        gvDatosComponentes.DataBind();
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx";
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }







    protected void btnAnularCertificacion_Click(object sender, EventArgs e)
    {

        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "J";

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = 0;
        int iComponente = 0;
        int iAnulaCerti = 0;
        int iContador = 0;

        string sMensajeError = null;

        foreach (GridViewRow row in gvDatosComponentes.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkAnulaCerti = (row.Cells[0].FindControl("chkCertificar") as CheckBox);

                if (chkAnulaCerti.Checked)
                {
                    iContador = iContador + 1;
                }
            }
        }
        if (iContador >= 1)
        {
            foreach (GridViewRow row in gvDatosComponentes.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkAnulaCerti = (row.Cells[0].FindControl("chkCertificar") as CheckBox);

                    if (chkAnulaCerti.Checked)
                    {
                        iComponente = Convert.ToInt32(row.Cells[3].Text);
                        iVersion = Convert.ToInt32(row.Cells[4].Text);
                        iAnulaCerti = 1; //ANULA CERTIFICACION

                    }
                    else
                    {
                        iComponente = Convert.ToInt32(row.Cells[3].Text);
                        iVersion = Convert.ToInt32(row.Cells[4].Text);
                        iAnulaCerti = 2; //MANTIENE LA CERTIFICACION
                    }
                    if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, iAnulaCerti, ref sMensajeError))
                    {
                        string msg = "La aprobacion se realizo con exito";
                        Master.MensajeOk(msg);
                        pnlBajaFormulario.Visible = true;
                        this.pnlBajaFormulario_ModalPopupExtender.Show();
                        // ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                    }
                    else
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                    }
                }
            }
           // Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");

        }
        else
        {
            iAnulaCerti = 3;
            if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, iAnulaCerti, ref sMensajeError))
            {
                string msg = "La aprobacion se realizo con exito";
                Master.MensajeOk(msg);
                // ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
            Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");
        }
    }
    protected void btnAgregarMensual_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "J";

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = 0;
        int iComponente = 0;
        int iAnulaCerti = 4;
      

        string sMensajeError = null;
        foreach (GridViewRow row in gvDatosComponentes.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkAnulaCerti = (row.Cells[0].FindControl("chkCertificar") as CheckBox);

                if (chkAnulaCerti.Checked)
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);
                    

                }
                else
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);
                    
                }
                if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, iAnulaCerti, ref sMensajeError))
                {
                    string msg = "La aprobacion se realizo con exito";
                    Master.MensajeOk(msg);
                 
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
        }
        //Response.Redirect("~/CertificacionCC/wfrmProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
    }
    protected void btnAgregarGlobal_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "J";

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = 0;
        int iComponente = 0;
        int iAnulaCerti = 5;
       

        string sMensajeError = null;
        foreach (GridViewRow row in gvDatosComponentes.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkAnulaCerti = (row.Cells[0].FindControl("chkCertificar") as CheckBox);

                if (chkAnulaCerti.Checked)
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);
                   

                }
                else
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);
                   
                }
                if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, iAnulaCerti, ref sMensajeError))
                {
                    string msg = "La aprobacion se realizo con exito";
                    Master.MensajeOk(msg);
                
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
        }
       // Response.Redirect("~/CertificacionCC/wfrmProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
    }


    protected void btnAgregarMyG_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "J";

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = 0;
        int iComponente = 0;
        int iAnulaCerti = 6;


        string sMensajeError = null;
        foreach (GridViewRow row in gvDatosComponentes.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkAnulaCerti = (row.Cells[0].FindControl("chkCertificar") as CheckBox);

                if (chkAnulaCerti.Checked)
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);


                }
                else
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);

                }
                if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, iAnulaCerti, ref sMensajeError))
                {
                    string msg = "La aprobacion se realizo con exito";
                    Master.MensajeOk(msg);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
        }
        //Response.Redirect("~/CertificacionCC/wfrmProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
    }
    protected void btnSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");
    }
    protected void btnCambioEstado_Click(object sender, EventArgs e)
    {
        pnlBajaFormulario.Visible = false;
        int iAnulaCerti = 4;

        if (rdbFCG.Checked==true)
        {
            iAnulaCerti = 5;
        }
        if (rdbFCM.Checked == true)
        {
            iAnulaCerti = 6;
        }
        if (rdbFCGM.Checked == true)
        {

        }
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "J";

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = 0;
        int iComponente = 0;
        string sMensajeError = null;
        foreach (GridViewRow row in gvDatosComponentes.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkAnulaCerti = (row.Cells[0].FindControl("chkCertificar") as CheckBox);

                if (chkAnulaCerti.Checked)
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);
                }
                else
                {
                    iComponente = Convert.ToInt32(row.Cells[3].Text);
                    iVersion = Convert.ToInt32(row.Cells[4].Text);

                }
                if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, iAnulaCerti, ref sMensajeError))
                {
                    string msg = "La aprobacion se realizo con exito";
                    Master.MensajeOk(msg);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
        }
        Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");

    }
    protected void btnRefresca_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "L";
        string sMensajeError = null;

        string iIdTramite = txtIdTramite.Text;
        int iIdGrupoBeneficio = 3;
        DataTable tblTramiteUrl = null;
        tblTramiteUrl = ObjEmisionFormularioCC.TramiteUrlCertificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblTramiteUrl != null)
        {

            
                iIdTramite = tblTramiteUrl.Rows[0]["IdTramite"].ToString();
                
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = "El tramite no esta disponible para ejecutar la actividad con el rol asignado";
                Master.MensajeError(Error, DetalleError);
            }
        
        hfIdTramite.Value = Convert.ToString(iIdTramite);
        hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);
        ListarDatosAsegurado(Convert.ToInt32(iIdTramite), iIdGrupoBeneficio);
        ListarComponentesNew(Convert.ToInt32(iIdTramite), iIdGrupoBeneficio);
    }
}