using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wfcInventario.Logica;
using System.Net;
using System.Security.Principal;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public partial class ControlInventario_wfrmCargarArchivo : System.Web.UI.Page
{
    DataTable Encontrados = null;
    string mensaje = null;
    clsLogicaI info = new clsLogicaI();
    Regex FormatoCampos;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void BindGridView()
    {    
        string FilePath = ResolveUrl("~/Medios/CruceDoblePercepcion/"); // Give Upload File Path
        string filename = string.Empty;

        if (FileUploadToServer.HasFile) // Check FileControl has any file or not
        {
            try
            {
                string[] allowdFile = { ".xls", ".xlsx" };
                string FileExt = System.IO.Path.GetExtension(FileUploadToServer.PostedFile.FileName).ToLower();// get extensions
                bool isValidFile = allowdFile.Contains(FileExt);

                // check if file is valid or not
                if (!isValidFile)
                {
                    lblMsg.Visible = true;
                    lblMsg.Style.Add("color", "red");
                    lblMsg.Text = "Please upload only Excel";
                }
                else
                {
                    int FileSize = FileUploadToServer.PostedFile.ContentLength; // get filesize
                    if (FileSize <= 1048576) //1048576 byte = 1MB
                    {
                        filename = Path.GetFileName(Server.MapPath(FileUploadToServer.FileName));// get file name
                        FileUploadToServer.SaveAs(Server.MapPath(FilePath) + filename); // save file to uploads folder
                        string filePath = Server.MapPath(FilePath) + filename;
                        string conStr = "";
                        if (FileExt == ".xls") // check for excel file type
                        {
                            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        }
                        else if (FileExt == ".xlsx")
                        {
                            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                      }
                        OleDbConnection con = new OleDbConnection(conStr);
                        OleDbCommand ExcelCommand = new OleDbCommand();
                        ExcelCommand.Connection = con;
                        con.Open();
                        DataTable ExcelDataSet = new DataTable();
                        ExcelDataSet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        DataTable dt = new DataTable();
                        if (ExcelDataSet != null && ExcelDataSet.Rows.Count > 0)
                        {
                            string SheetName = ExcelDataSet.Rows[0]["TABLE_NAME"].ToString(); // get sheetname
                            ExcelCommand.CommandText = "SELECT * From [" + SheetName + "]";
                            OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                            ExcelAdapter.SelectCommand = ExcelCommand;
                            ExcelAdapter.Fill(dt);
                        }
                        con.Close();
                        if (dt != null && dt.Rows.Count > 0) // Check if File is Blank or not
                        {
                            grvBatchUpload.DataSource = dt;
                            grvBatchUpload.DataBind();
                            lblMsg.Visible = false;
                        }
                        else
                        {

                            lblMsg.Visible = true;
                            lblMsg.Style.Add("color", "red");
                            lblMsg.Text = "There are No Rows in this File!!!";
                        }
                        FilePath = ResolveUrl("~/Uploads/");
                        string fileName = Server.MapPath(FilePath) + filename;
                        FileInfo f = new FileInfo(fileName);
                        if (f.Exists)
                        {
                            f.IsReadOnly = false;
                            f.Delete();
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Style.Add("color", "red");
                        lblMsg.Text = "Attachment file size should not be greater then 1 MB!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Style.Add("color", "red");
                lblMsg.Text = "Error occurred while uploading a file: " + ex.Message;
            }
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Style.Add("color", "red");
            lblMsg.Text = "Please select a file to upload.";
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
//***************************************************************************************************************************
        gvUbicacion.Visible = true;
        gvUbicacion.DataSourceID = null;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "UbicacionExcel", "", "",
        "", "", "", "", "", 0, 0, 0, 0, ref mensaje);

        gvUbicacion.DataSource = Encontrados;
        gvUbicacion.DataBind();
        lbl1.Text =  "Cantidad de Registros encontrados: "+Encontrados.Rows.Count.ToString();
        btnExportarExcelUbicados.Visible = true;
        //gvUbicacion1.Visible = true;
        gvUbicacion1.DataSourceID = null;
        gvUbicacion1.DataSource = Encontrados;
        gvUbicacion1.DataBind();

//***************************************************************************************************************************
        gv430.Visible = true;
        gv430.DataSourceID = null;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "430Excel", "", "",
         "", "", "", "", "", 0, 0, 0, 0, ref mensaje);
        gv430.DataSource = Encontrados;
        gv430.DataBind();
        lbl2.Text = "Cantidad de Registros encontrados: " + Encontrados.Rows.Count.ToString();
        btnExportarExcel430.Visible = true;

        gv4301.DataSourceID = null;
        gv4301.DataSource = Encontrados;
        gv4301.DataBind();
//***************************************************************************************************************************

        gvOtros.Visible = true;
        gvOtros.DataSourceID = null;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "OtraArea", "", "",
        "", "", "", "", "", 0, 0, 0, 0, ref mensaje);
        gvOtros.DataSource = Encontrados;
        gvOtros.DataBind();
        lbl3.Text = "Cantidad de Registros encontrados: " + Encontrados.Rows.Count.ToString();
        btnExpotarAreas.Visible = true;

        gvOtros1.DataSourceID = null;
        gvOtros1.DataSource = Encontrados;
        gvOtros1.DataBind();
    }
    protected void gvUbicacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        gvUbicacion.PageIndex = e.NewPageIndex;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "UbicacionExcel", "", "",
        "", "", "", "", "", 0, 0, 0, 0, ref mensaje);
        gvUbicacion.DataSource = Encontrados;
        gvUbicacion.DataBind();
    }
    protected void gv430_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv430.PageIndex = e.NewPageIndex;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "430Excel", "", "",
         "", "", "", "", "", 0, 0, 0, 0, ref mensaje);
        gv430.DataSource = Encontrados;
        gv430.DataBind();
    }
    protected void gvOtros_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOtros.PageIndex = e.NewPageIndex;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "OtraArea", "", "",
       "", "", "", "", "", 0, 0, 0, 0, ref mensaje);
        gvOtros.DataSource = Encontrados;
        gvOtros.DataBind();
    }
    protected void btnExportarExcelUbicados_Click(object sender, EventArgs e)
    {
        gvUbicacion1.Visible = true;
        if (gvUbicacion1.Rows.Count == 0 || gvUbicacion1 == null)
            Master.MensajeError("Error al crear el archivo", "Archivo vacio");
        else
            exportar("Resultado_Tramite_Con_Ubicacion.xls", gvUbicacion1);
        gvUbicacion1.Visible = false;
    }
    protected void btnExportarExcel430_Click(object sender, EventArgs e)
    {

        gv4301.Visible = true;
        if (gv4301.Rows.Count == 0 || gv4301 == null)
            Master.MensajeError("Error al crear el archivo", "Archivo vacio");
        else
            exportar("Resultado_Tramites_En_430.xls", gv4301);
        gv4301.Visible = false;
    }
    protected void btnExpotarAreas_Click(object sender, EventArgs e)
    {
        gvOtros1.Visible = true;
        if (gvOtros1.Rows.Count == 0 || gvOtros1 == null)
            Master.MensajeError("Error al crear el archivo", "Archivo vacio");
        else
            exportar("Resultado_Tramites en_Otras_Areas.xls", gvOtros1);
        gvOtros1.Visible = true;

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
}