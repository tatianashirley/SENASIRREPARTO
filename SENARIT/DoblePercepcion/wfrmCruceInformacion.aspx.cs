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
using System.Security.Principal;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Globalization;
using System.Drawing;
using wfcDoblePercepcion.Logica;
using System.Web.UI.HtmlControls;  // esta clase es la que se tiene q aumentar



public partial class DoblePercepcion_wfrmCruceInformacion : System.Web.UI.Page
{

    string prefijo = "", ruta;
    bool ban = false;
    int IDTM;
    Regex FormatoCampos;
    DataTable DTExpresiones;
    DataRow DRFormato;
    DataTable tabla = new DataTable("tabla");
    DataTable TablaErrores = new DataTable("TablaErrores");
    clsDetalleClasificador ides = new clsDetalleClasificador();
    clsManejoArchivo ManejoArchivo = new clsManejoArchivo();
    clsServicioIntercambio Automata = new clsServicioIntercambio();
    clsInformacion eli = new clsInformacion();
    string mensaje = null;
    clsInformacion info = new clsInformacion(); DataTable Encontrados = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEjecutar_Click(object sender, EventArgs e)
    {
        //-----------------------------------------------INICIO--------------------------------------------------------------------//
        ObtenerExpresiones("PE");
        Boolean fileOK = true;
        String CarpetaMedio = Server.MapPath("~/Medios/CruceDoblePercepcion/");
        Session["ARCH"] = fulArchivo.FileName.ToUpper();
        //  lblMuestra.Text = fulArchivo.FileName.ToUpper();

        if (fulArchivo.HasFile)
        {
            fileOK = RevisarFormato(fulArchivo.FileName.ToUpper());
        }

        else
        {
            Master.MensajeError("Archivo vacío", "No es necesario cargar el archivo vacío");
        }


        if (fileOK && fulArchivo.HasFile)
        {
            try
            {
                //CarpetaMedio += ddlTipoMedio.SelectedValue.ToString() + ddlEntidad.SelectedValue.ToString() + "//";
                Directory.CreateDirectory(CarpetaMedio);
                Session["CARPETA"] = CarpetaMedio;

                ruta = CarpetaMedio + fulArchivo.FileName;

                fulArchivo.PostedFile.SaveAs(ruta);

                ControlEnvio("Registro", "P");

                GeneraTablaDinamica(Convert.ToInt32(DRFormato.ItemArray[0]));

                //label.Text = Convert.ToString(Session["IdConexion"])+" " + Convert.ToString(DRFormato.ItemArray[0]) + " hasta aqui llego(1) " + Convert.ToString(TablaErrores.Rows.Count);

                
                CargarEstructuraDinamica();

                // label.Text = Convert.ToString(DRFormato.ItemArray[0]) + " hasta aqui llego2 " + Convert.ToString(tabla.Rows.Count);
                //RevisaColumnas(ddlTipoMedio.SelectedValue.ToString());

                if (tabla.Rows.Count > 0 && TablaErrores.Rows.Count <= 0)
                {
                    //label.Text = "hasta aqui llego3";
                    EliminaTemporal();

                    if (inserta_temporal("PE"))
                    {

                        ControlEnvio("Aceptado", "A");

                        //Master.MensajeOk("El archivo se cargo de Forma Exitosa");

                        //Prevalida(ddlEntidad.SelectedValue, ddlPeriodo.SelectedValue, ddlTipoMedio.SelectedValue, Convert.ToInt32(lblNumEnvio.Text));

                        gvCruce.Visible = true;
                        gvCruce.DataSourceID = null;

                        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Cruce", "", "", ""
                        , "", "", "", "", 0, 0, ref mensaje);
                        gvCruce.DataSource = Encontrados;
                        gvCruce.DataBind();

                        if (Encontrados != null )
                        CrearArchivo(Encontrados, "Casos_DoblePercepcion" + fulArchivo.FileName, true);

                        if (Encontrados != null)
                        {
                         if(Encontrados.Rows.Count!=0)
                            CrearArchivo(Encontrados, "Casos_DoblePercepcion" + fulArchivo.FileName, true);
                        }

                        //exportar("Resultado_Cruce_DoblePercepcion" + fulArchivo.FileName + ".xls", gvCruce); // aqui llamo al metodo

                        gvCruce.Visible = true;
                        gvCruce.DataSourceID = null;
                        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Cruce", "", "", ""
                       , "", "", "", "", 0, 0, ref mensaje);
                        gvCruce.DataSource = Encontrados;
                        gvCruce.DataBind();
                        

                        if (gvCruce.Rows.Count > 0)
                        {
                            //btnImprimir.Visible = true;
                            btnExportarExcel.Visible = true;
                            lblMuestra.Text = lblMuestra.Text + " y "+gvCruce.Rows.Count +" casos resultantes";
                        }
                        gvErrores.Visible = false;
                    }
                }
                if (tabla.Rows.Count == 0)
                {
                    Response.Write("<script>window.alert('El archivo que intenta cargar esta vacio\nNo se realizó la carga');</script>");
                }
            }
            catch (Exception ex)
            {
                lblMuestra.Text = "El archivo no pudo ser cargado por " + ex.Message;
                Master.MensajeError("El archivo no pudo ser cargado...", ex.Message);
            }
        }
        else
        {
            lbltexto.Visible = false;
            gvErrores.Visible = false;
            lblMuestra.Visible = false;
            label.Visible = false;
            lblrsultado.Visible = false;
            Master.MensajeError("El archivo que intenta cargar no es el correcto o esta vacio", "Intente cargando otro archivo o Corrija el Archivo");
        }


        //---------------------------------------------FIN----------------------------------------------------------------------//
    }
    
    private bool RevisarFormato(string NombreArchivo)
    {
        //System.Text.RegularExpressions.Regex automata = new Regex(@DRFormato.ItemArray[7].ToString());
        string mensaje = null;
        bool resultado = Automata.RevisaNombre((int)Session["IdConexion"], NombreArchivo, "PE", ref mensaje);
      

        return resultado;
    }


    private void ControlEnvio(string TipoControl, string Estado)
    {
        try
        {
            string NombreArchivo = null;
            NombreArchivo = fulArchivo.FileName.ToUpper();

            string mensaje = null;
            ManejoArchivo.ControlEnvio((int)Session["IdConexion"], TipoControl, "PE"
                        , "701 -" + NombreArchivo, Estado, ref mensaje);

            if (mensaje != null)
            {
                Master.MensajeError("Error al registrar el Envio", mensaje);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al registrar el Envio", ex.Message);
        }
    }



    private bool EliminaTemporal()
    {
        try
        {
            eli.EliminarTemporal();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool inserta_temporal(string TipoMedio)
    {
        clsCargarMedios cargar = new clsCargarMedios();
        string resp =null;
        resp = cargar.InsertaBulk(tabla, DRFormato.ItemArray[8].ToString().Trim());
        if (resp == null)
        {
            //Response.Write("<script>window.alert('El archivo no tiene errores de estructura.\nSe procede a la revisión general');</script>");
            lblMuestra.Text = tabla.Rows.Count.ToString() + " registros cargados exitosamente.";
            Master.MensajeOk("El archivo no tiene errores de estructura.\nSe procede a la revisión general");
            return true;
        }
        else
        {
            Master.MensajeError("Error al insertar en la temporal", resp);
            return false;
        }
    }


    private void ObtenerExpresiones(string TipoMedio)
    {
        clsServicioIntercambio inter = new clsServicioIntercambio();
        //DRFormato = inter.ListarArchivoTodo(0, TipoMedio).Rows[0];
        string mensaje = null;
        DRFormato = inter.ListarTipoMedio((int)Session["IdConexion"], "Q", 0, TipoMedio, ref mensaje).Rows[0];
        IDTM = Convert.ToInt16(DRFormato.ItemArray[0]);
        lblMuestra.Text = Convert.ToString(IDTM);

        //DTExpresiones = inter.ListarCampoTodo(IDTM, "MEDIO");
        DTExpresiones = inter.ListarCampoMedio((int)Session["IdConexion"], "Q", IDTM, "MEDIO", ref mensaje);
    }

    private void GeneraTablaDinamica(int IdArchivo)
    {
        try
        {

            //generamos automaticamente la tabla segun tipo medio
            string mensaje = null;
            DataSet tablas = Automata.GenerarTablaDinamica((int)Session["IdConexion"], "PE", ref mensaje);
            tabla = tablas.Tables[0];
            TablaErrores = tablas.Tables[1];
        }
        catch (Exception er)
        {
            Master.MensajeError("Error al generar la tabla dinamicamente", er.Message);
        }
    }


    private void CargarEstructuraDinamica()
    {
        DataSet Dinamico = Automata.CargaTablaDinamica(tabla, TablaErrores, DTExpresiones, ruta);
        tabla = Dinamico.Tables[0];
        TablaErrores = Dinamico.Tables[1];
        TablaErrores = Automata.ValidarCampos(tabla, DTExpresiones, TablaErrores);
        // ValidacionPropia();
        if (TablaErrores.Rows.Count > 0)
        {
            lblMuestra.Text = "El medio contiene errores\nPor favor revisar";

              MostrarErrores();
        }
        else
        {
            ban = true;
            // lblCantidad.Text = (tabla.Rows.Count).ToString();
        }

    }

    private void MostrarErrores()
    {
        Session["ERRORES"] = TablaErrores;
        gvErrores.Visible = true;
        gvErrores.DataSource = TablaErrores;
        gvErrores.DataBind();
        lbltexto.Visible = true;
      
    }

    private void CrearArchivo(DataTable TablaArchivo, string NomArchivo, bool Solapar)
    {
        try
        {
            string RutaCrear = Session["CARPETA"].ToString();
            ManejoArchivo.CrearArchivo(TablaArchivo, RutaCrear + NomArchivo + ".XLS");
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al crear el Archivo.", ex.Message);
        }
    }
    protected void btnExportarExcel_Click1(object sender, EventArgs e)
    {
       // Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Cruce", "", "", ""
        //, "", "", "", "", 0, 0, ref mensaje);
        //gvCruce.DataSource = Encontrados;
        //gvCruce.DataBind();
        //   CrearArchivo(Encontrados, "Resultado_Cruce_DoblePercepcion" + fulArchivo.FileName, true);
        if (gvCruce.Rows.Count == 0 || gvCruce == null)
            Master.MensajeError("Error al crear el archivo", "Archivo vacio");
        else
            exportar("Resultado_Cruce_DoblePercepcion" + fulArchivo.FileName + ".xls", gvCruce);  // aqui llamo al metodo

    }


    private void exportar(string nameReport, GridView wControl) // este es el metodo que crea el excel
    {
        HttpResponse response = Response;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pageToRender = new Page();
        HtmlForm form = new HtmlForm();
        form.Controls.Add(wControl);
        pageToRender.Controls.Add(form);
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
        response.Charset = "UTF-8";
        response.ContentEncoding = Encoding.Default;
        pageToRender.RenderControl(htw);
        response.Write(sw.ToString());
        response.End();
    }



    protected void gvErrores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvErrores.PageIndex = e.NewPageIndex;
        gvErrores.DataSource = Session["ERRORES"] as DataTable; ;
        gvErrores.DataBind();
        gvErrores.Visible = true;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DoblePercepcion/wfrmCruceInformacion.aspx");
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            panReporte.Visible = true;
            rtpInforme.Visible = true;
            rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
            rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials("SFERNANDEZ", "Darkrai799", "SENASIR");
            rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
            rtpInforme.ServerReport.ReportPath = "/ReportesDp/rtpCruceInformacion";
           // rtpInforme.ServerReport.SetParameters(repParams);
            rtpInforme.ServerReport.Refresh();
            panReporte.Visible = true;

        }
        catch (Exception ex)
        {
            Master.MensajeError("No se genero el reporte de revise los datos porfavor", ex.Message);
        }
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
    protected void gvCruce_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "DATOS";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 4;
            
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "DATOS INSTITUCION EXTERNA";
            HeaderCell.BackColor = Color.SkyBlue;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 5;
            
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "DATOS SENASIR";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 7;
            
            HeaderGridRow.Cells.Add(HeaderCell);


            gvCruce.Controls[0].Controls.AddAt(0, HeaderGridRow);

        } 
    }
}