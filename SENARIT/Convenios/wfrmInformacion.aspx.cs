using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using wcfServicioIntercambioPago.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfConvenios.Logica;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using wcfSeguridad.Logica;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using System.Net;
using System.Security.Principal;
using wcfServicioIntercambioPago.Logica;
using wfcDoblePercepcion.Logica;

public partial class Convenios_wfrmInformacion : System.Web.UI.Page
{
    clsInformacionLO Info = new clsInformacionLO();
    clsPagoCC PagosCC = new clsPagoCC();
    string mensaje = null;
    DataTable Encontrados;
    Int64 NUP;
    clsInformacion DP = new clsInformacion();
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
        

        if (!Page.IsPostBack)
        {
            HttpContext.Current.Server.ScriptTimeout = 2400;
            //CargarTipoProceso();
            //CargarEntidad();
            //CargaPeriodos();
            CambiarInterfaz();
        }
    }
    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        lblBusqueda.Visible = true;
        gvBusqueda.Visible = true;
        gvBusqueda.DataSourceID = null;


        if (ValidarBusqueda(txtPrimerApellido.Text, txtSegundoApellido.Text, txtPrimerNombre.Text,
                            txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text))
        { 
        Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona", 
                    txtPrimerApellido.Text, txtSegundoApellido.Text, txtPrimerNombre.Text , 
                    txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, 0, 0, 
                    ref mensaje);

            gvBusqueda.DataSource = Encontrados;
            gvBusqueda.DataBind();
        }
        
    }

    protected bool
    ValidarBusqueda(string txtPrimerApellido, string txtSegundoApellido,string txtPrimerNombre,
                            string txtSegundoNombre, string txtCI, string txtMatricula, string txtCUA)
    {
        int c = 0;
        string script = "";
        if (txtPrimerApellido == "") 
        {
            c = c + 1;
        }
        if (txtSegundoApellido == "")
        {
            c = c + 1;
        }
        if (txtPrimerNombre == "")
        {
            c = c + 1;
        }
        if (txtSegundoNombre == "")
        {
            c = c + 1;
        }
        if (txtCI == "")
        {
            c = c + 1;
        }
        if (txtMatricula == "")
        {
            c = c + 1;
        }
        if (txtCUA == "")
        {
            c = c + 1;
        }
        if (c > 6)
        {
             script = @"<script type='text/javascript'>alert('INGRESE POR LO MENOS UN DATO DE BUSQUEDA')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        return true ;
      
    }

    
    protected void cmdLimpiar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Convenios/wfrmInformacion.aspx");
    }
    protected void gvBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fila2 = gvBusqueda.SelectedRow.RowIndex;

        string h = gvBusqueda.SelectedRow.Cells[10].Text;//TITULAR RENTISTA REPARTO
        if (gvBusqueda.SelectedRow.Cells[10].Text == "Titular PRA" || gvBusqueda.SelectedRow.Cells[10].Text == "TITULAR RENTISTA REPARTO")
        {
            Session["Paterno"] = gvBusqueda.SelectedRow.Cells[6].Text;
            Session["Materno"] = gvBusqueda.SelectedRow.Cells[7].Text;
            Session["PrimerNombre"] = gvBusqueda.SelectedRow.Cells[8].Text;
            Session["NroDocumento"] = gvBusqueda.SelectedRow.Cells[5].Text;
            Session["Matricula"] = gvBusqueda.SelectedRow.Cells[4].Text;
            Response.Redirect("~/Convenios/wfrmCompletaDatos.aspx");
        }
        else
        {
            CargarSeleccionado(fila2);
        }
        lblBusqueda.Visible = false;
        gvBusqueda.Visible = false;
    }
    private void CargarSeleccionado(int fila)
    {
        //cargamos los datos en los textbox
        txtCI.Text = gvBusqueda.SelectedRow.Cells[5].Text;
        txtPrimerApellido.Text = gvBusqueda.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtSegundoApellido.Text = gvBusqueda.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        txtPrimerNombre.Text = gvBusqueda.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        txtSegundoNombre.Text = gvBusqueda.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
        txtNUP.Text = gvBusqueda.SelectedRow.Cells[2].Text;
        txtCUA.Text = gvBusqueda.SelectedRow.Cells[3].Text;
        txtMatricula.Text = gvBusqueda.SelectedRow.Cells[4].Text;
        txtDireccion.Text = gvBusqueda.SelectedDataKey["Direccion"].ToString();
        txtEstadoCivil.Text = gvBusqueda.SelectedDataKey["EstadoCivil"].ToString();
        txtFechaNacimiento.Text = gvBusqueda.SelectedDataKey["FechaNacimiento"].ToString();
        txtFechaFallecimiento.Text = gvBusqueda.SelectedDataKey["FechaFallecimiento"].ToString();
        txtSexo.Text = gvBusqueda.SelectedDataKey["Sexo"].ToString();
        txtCel.Text = gvBusqueda.SelectedDataKey["Celular"].ToString();
        txtCelReferencial.Text = gvBusqueda.SelectedDataKey["CelularReferencia"].ToString();
        txtTelefono.Text = gvBusqueda.SelectedDataKey["Telefono"].ToString();
        NUP = Convert.ToInt64(gvBusqueda.SelectedRow.Cells[2].Text);
        //cargamos los datos de los beneficios
        lblBeneficios.Visible = true;
        gvBeneficios.Visible = true;
        gvBeneficios.DataSourceID = null;
        gvBeneficios.DataSource = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Beneficios", txtPrimerApellido.Text, txtSegundoApellido.Text, txtPrimerNombre.Text
                                                    , txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, NUP, 0, ref mensaje);
        gvBeneficios.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void lnkReposiciones_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void gvBeneficios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        //string CodEntidad = gvBandeja.DataKeys[indice].Values["CodigoEntidad"].ToString();
        //string CodMedio = gvBandeja.DataKeys[indice].Values["CodigoMedio"].ToString();
        //Session["FilaBandeja"] = indice;
        //int IdControl =Convert.ToInt32(gvBandeja.DataKeys[indice].Values["IdControlEnvio"]);
        if (e.CommandName == "cmdInformacion")
        {
            try
            {
                CargarInformacion();
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
        if (e.CommandName == "cmdDeuda")
        {
            Session["NUP"] = txtNUP.Text.Trim();
            Session["CUA"] = txtCUA.Text.Trim();
            Session["Certificado"] = Convert.ToInt32(gvBeneficios.Rows[indice].Cells[0].Text);
            //habrir otro aspx y cargar la info pertienente
            Response.Redirect("~/Convenios/wfrmVerDeuda.aspx");
        }
    }
    protected void gvBeneficios_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvBeneficios.Rows)
        {
           /* if (row.Cells[10].Text != "ACTIVO")
            {
                //12-revisar;13-ver errores;14-vermedio
                row.Cells[11].Enabled = false;
                row.Cells[11].ForeColor = Color.Gray;
                row.Cells[12].Enabled = false;
                row.Cells[12].ForeColor = Color.Gray;
            }*/
            if (row.Cells[10].Text == "SIN BENEFICIO")
            {
                //12-revisar;13-ver errores;14-vermedio

                row.Cells[12].Enabled = true;
                row.Cells[12].ForeColor = Color.Blue;
            }
        }
    }
    private void CargarInformacion()
    {
        lnkPagos.Visible = true;
        lnkConciliaciones.Visible = true;
        lnkGrupoFamiliar.Visible = true;
        lnkReposiciones.Visible = true;
        MultiView1.Visible = true;
        MultiView1.ActiveViewIndex = 0;
        //luego cargamos los datos de pago,conciliacion y grupo familiar
        gvPagos.DataSourceID = null;
        Session["Pagos"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Pago", txtPrimerApellido.Text, txtSegundoApellido.Text
                                    , txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, Convert.ToInt64(txtNUP.Text), "", ref mensaje);
        gvPagos.DataSource = Session["Pagos"] as DataTable;
        gvPagos.DataBind();

        gvConciliaciones.DataSourceID = null;
        Session["Concil"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Conciliacion", txtPrimerApellido.Text
                                                , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text
                                                , txtMatricula.Text, txtCUA.Text, Convert.ToInt64(txtNUP.Text), "", ref mensaje);
        gvConciliaciones.DataSource = Session["Concil"] as DataTable;
        gvConciliaciones.DataBind();

        gvGrupo.DataSourceID = null;
        gvGrupo.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Familia", txtPrimerApellido.Text
                                                , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text
                                                , txtMatricula.Text, txtCUA.Text, Convert.ToInt64(txtNUP.Text), "", ref mensaje);
        gvGrupo.DataBind();

        gvReposiciones.DataSourceID = null;
        Session["Repo"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Reposicion", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, Convert.ToInt64(txtNUP.Text), "", ref mensaje);
        gvReposiciones.DataSource = Session["Repo"] as DataTable;
        gvReposiciones.DataBind();
    }
    protected void gvPagos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPagos.PageIndex = e.NewPageIndex;
        gvPagos.DataSource = Session["Pagos"] as DataTable;
        gvPagos.DataBind();
        int x = gvPagos.PageIndex;
    }
    protected void gvConciliaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConciliaciones.PageIndex = e.NewPageIndex;
        gvConciliaciones.DataSource = Session["Concil"] as DataTable;
        gvConciliaciones.DataBind();
        int x = gvConciliaciones.PageIndex;
    }
    protected void lnkReposiciones_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }
    protected void gvReposiciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReposiciones.PageIndex = e.NewPageIndex;
        gvReposiciones.DataSource = Session["Repo"] as DataTable;
        gvReposiciones.DataBind();
        int x = gvReposiciones.PageIndex;
    }
    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtPrimerApellido, cmdBuscar);
        AgregarJSAtributos(txtPrimerNombre, cmdBuscar);
        AgregarJSAtributos(txtCI, cmdBuscar);
        AgregarJSAtributos(txtCUA, cmdBuscar);
        AgregarJSAtributos(txtSegundoApellido, cmdBuscar);
        AgregarJSAtributos(txtSegundoNombre, cmdBuscar);
        AgregarJSAtributos(txtMatricula, cmdBuscar);
        AgregarJSAtributos(txtFechaNacimiento, cmdBuscar);


    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");
            //controlActual.Attributes.Add("onFocus", "  JavaScript:this.style.backgroundColor='#ffff00'; SelectAll(this)");
            //controlActual.Attributes.Add("onBlur", "  JavaScript:this.style.backgroundColor='#ffffff'; return focusNext('" + ctrlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "', null)  ");

        }
    }
    protected void btnReporte_Click(object sender, EventArgs e)
    {

        clsInformacion info = new clsInformacion();
        clsSeguridad ObjSeguridad = new clsSeguridad();
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "FechaPago", "TITULAR", "", "", "", "", "", "", Convert.ToInt32(txtNUP.Text), 0, ref mensaje);
        DataRow row_q = Encontrados.Rows[0];
 
        string RangoEPC = row_q[0].ToString();
        string RangoSPC = DateTime.Now.ToString("dd/MM/yyyy");
        string fechaini = RangoEPC.Substring(6, 4) + RangoEPC.Substring(3, 2);
        string fechafin = RangoSPC.Substring(6, 4) + RangoSPC.Substring(3, 2);
        string UsrRep;
        string PassUsrRep;
        string DomRep;
        string ServRep;
        string ServApl;
        ReportParameter[] repParams = new ReportParameter[4];
        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
        repParams[0] = new ReportParameter("CUA", txtCUA.Text);
        repParams[1] = new ReportParameter("Fecha1", fechaini);
        repParams[2] = new ReportParameter("Fecha2", fechafin);
        repParams[3] = new ReportParameter("CuentaUsuario", ConexionUsuario());	

        /*panReporte.Visible = true;
        rtpInforme.Visible = true;*/
        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
        rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
        if (Resumido.Checked == true)
        { rtpInforme.ServerReport.ReportPath = "/InformesPagos/rptHistorialPagosResumen"; }
        else
        {
            if (Completo.Checked == true)
            { rtpInforme.ServerReport.ReportPath = "/InformesPagos/rptHistorialPagos"; }
        }
        rtpInforme.ServerReport.SetParameters(repParams);
        rtpInforme.ServerReport.Refresh();
        //panReporte.Visible = true;

        /*rtpInforme.ShowPrintButton = true;
        rtpInforme.PromptAreaCollapsed = true;
        rtpInforme.Height = 500;
        rtpInforme.BackColor = Color.FromArgb(72, 128, 179);
        rtpInforme.ForeColor = Color.WhiteSmoke;
        rtpInforme.ServerReport.Refresh();*/
        GenerarPDF();
    }

    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        // local variable for network credential.
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        private WindowsIdentity _ImpersonationUser;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
            // _ImpersonationUser = ImpersonationUser;
        }
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null; // not use ImpersonationUser
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {

                // use NetworkCredentials
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {

            // not use FormsCredentials unless you have implements a custom autentication.
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }

    protected void GenerarPDF()
    {
        try
        {
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;


            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>21.59cm</PageWidth>" +
            "  <PageHeight>27.94cm</PageHeight>" +
            "  <MarginTop>1cm</MarginTop>" +
            "  <MarginLeft>1cm</MarginLeft>" +
            "  <MarginRight>1cm</MarginRight>" +
            "  <MarginBottom>1cm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report

            renderedBytes = rtpInforme.ServerReport.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);

            Response.Clear();
            Response.ContentType = "application/txt";//mimeType;
            if (Resumido.Checked == true)
            {
                Response.AddHeader("content-disposition", "attachment; filename=rptHistorialPagosResumen." + fileNameExtension);
            }
            else
            {
                if (Completo.Checked == true)
                {
                    Response.AddHeader("content-disposition", "attachment; filename=rptHistorialPagos." + fileNameExtension);
                }
            }
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al intentar crear el archivo PDF", ex.Message);
        }
    }
    protected string ConexionUsuario()
    {
        string UsuarioConexio = "";
        string mensaje = "";
        Encontrados = DP.ObtieneDatos((int)Session["IdConexion"], "Q", "Conexion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        UsuarioConexio = Encontrados.Rows[0][0].ToString();
        return UsuarioConexio;

    }
}
