using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using wcfEnvioAPS.Logica;
using wcfWorkFlowN.Logica;

using AjaxControlToolkit;
using System.Configuration;

using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
//using System.Text;

public partial class EnvioAPS_wfrmGeneraListadoPreliminar : System.Web.UI.Page
{
    int IdConexion; string txtFechaCorte;
    clsGeneraBandejas objGeneraBandejas = new clsGeneraBandejas();

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
            //IdConexion = 5679;
        }

        if (!Page.IsPostBack)
        {
            txtFechaCorte = (string)Session["txtFechaCorte"];
            ListadoExportaExcel();
        }
    }

    protected void ListadoExportaExcel()
    {
        //Export o excel
        int RecordCount = 0, RecordCountA = 0;

        DataTable sourceTable = new DataTable();
        objGeneraBandejas.iIdConexion = IdConexion;
        objGeneraBandejas.fFechaCorte = Convert.ToDateTime(txtFechaCorte);
        if (objGeneraBandejas.ListadoPreliminarEnvioAPS())
        {
            sourceTable = objGeneraBandejas.DSet.Tables[0];
            RecordCountA = objGeneraBandejas.iRecordCountA;
            RecordCount = objGeneraBandejas.iRecordCount;
        }
        else
        {
            //Error
            string DetalleError = objGeneraBandejas.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }

        using (ExcelPackage p = new ExcelPackage())
        {
            //Here setting some document properties
            p.Workbook.Properties.Author = "SENASIR";
            p.Workbook.Properties.Title = "Listado Preliminar de Altas";
            //Create a sheet
            p.Workbook.Worksheets.Add("Listado Preliminar de Altas");
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = "Listado1"; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet
            DataTable dt = sourceTable; //My Function which generates DataTable
            //Merging cells and create a center heading for out table
            ws.Cells[1, 1].Value = "LISTADO PRELIMINAR DE ALTAS";
            ws.Cells[1, 1, 1, dt.Columns.Count].Merge = true;
            ws.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1].Value = "(Fecha de Corte: " + txtFechaCorte + ")";
            ws.Cells[2, 1, 2, dt.Columns.Count].Merge = true;
            ws.Cells[2, 1, 2, dt.Columns.Count].Style.Font.Italic = true;
            ws.Cells[2, 1, 2, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            int colIndex = 1;
            int rowIndex = 3;
            foreach (DataColumn dc in dt.Columns) //Creating Headings
            {
                var cell = ws.Cells[rowIndex, colIndex];
                //Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Gray);
                //Setting Top/left,right/bottom borders.
                var border = cell.Style.Border;
                border.Bottom.Style =
                    border.Top.Style =
                    border.Left.Style =
                    border.Right.Style = ExcelBorderStyle.Thin;
                //Setting Value in cell
                cell.Value = dc.ColumnName;
                colIndex++;
            }
            int CertificadoObservado = 0;
            int CertificadosAutomaticos = 0;
            int CertificadosManuales = 0;
            foreach (DataRow dr in dt.Rows) // Adding Data into rows
            {
                colIndex = 1;
                rowIndex++;
                CertificadoObservado = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    var cell = ws.Cells[rowIndex, colIndex];
                    //Setting Value in cell
                    cell.Value = Convert.ToString(dr[dc.ColumnName]);
                    //Setting borders of cell
                    var border = cell.Style.Border;
                    border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                    if (colIndex == 8)
                    {
                        string Clase_CC = cell.Value.ToString();
                        if (Clase_CC == "A")
                        {
                            CertificadosAutomaticos = CertificadosAutomaticos + 1;
                        }
                        if (Clase_CC == "M")
                        {
                            CertificadosManuales = CertificadosManuales + 1;
                        }
                    }
                    if (colIndex == 23 || colIndex == 24 || colIndex == 26 || colIndex == 27 || colIndex == 28 || colIndex == 30)
                    {
                        string ColumnaError = cell.Value.ToString();
                        if (!string.IsNullOrEmpty(ColumnaError))
                        {
                            CertificadoObservado = CertificadoObservado + 1;
                        }
                    }
                    if (colIndex == 29)
                    {
                        string DifAfiliadoAPS = cell.Value.ToString();
                        if (DifAfiliadoAPS == "NO TIENE REGISTRO AFILIADOS APS")
                        {
                            CertificadoObservado = CertificadoObservado + 1;
                        }
                    }
                    colIndex++;
                }
                if (CertificadoObservado >= 1)
                {
                    ws.Cells[rowIndex, 1, rowIndex, dt.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[rowIndex, 1, rowIndex, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(Color.Goldenrod);
                }
            }
            rowIndex++;
            ws.Cells[rowIndex, 1].Value = "TOTAL CERTIFICADOS AUTOMATICOS [" + CertificadosAutomaticos.ToString() + "] -- CERTIFICADOS MANUALES [" + CertificadosManuales.ToString() + "]";
            ws.Cells[rowIndex, 1, rowIndex, dt.Columns.Count].Merge = true;
            ws.Cells[rowIndex, 1, rowIndex, dt.Columns.Count].Style.Font.Bold = true;
            ws.Cells[rowIndex, 1, rowIndex, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            colIndex = 0;

            Byte[] bin = p.GetAsByteArray();

            // Send the file to the browser
            string name = "ListadoAltasPreliminar.xlsx";
            //string contentType = "application/vnd.ms-excel"; //MSOFFICE 2003
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
            Response.BinaryWrite(bin);
            Response.Flush();
            Response.End();

            //-------------------------------------------------------------
            ////Generate A File with Random name
            ////string file = @"d:\\" + Guid.NewGuid().ToString() + ".xlsx";
            //string file = @"D:\\ListadoAltasPreliminar.xlsx";
            ////E:\\PublicadoPruebas\SENASIR\EnvioAPS
            //File.WriteAllBytes(file, bin);

            //Response.Redirect("wfrmEnvioFile.aspx?filePath=" + Server.UrlEncode(file));
        }
    }
}