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

using wcfSeguridad.Logica;
using wcfWFArticulador.Logica;

public partial class EnvioAPS_wfrmListadoPreliminarAltas : System.Web.UI.Page
{
    clsGeneraBandejas objGeneraBandejas = new clsGeneraBandejas();
    clsSeguridad objSeguridad = new clsSeguridad();
    clsBandejaUsuario objBandejaUsuario = new clsBandejaUsuario();

    int IdConexion; int IdUsuario, IdOficina, IdArea; string CuentaUsuario; int IdRol;
    long IdTramite;

    string Sort_Direction = "NroRegistro ASC";

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

            string s01 = Session["CuentaUsuario"].ToString();
            string s02 = Session["CodUsuario"].ToString();
            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion(IdConexion);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
                string s11 = dtUsuarioDatos.Rows[0]["CuentaUsuario"].ToString();  //TECENVIOS2
                string s12 = dtUsuarioDatos.Rows[0]["IdRol"].ToString();    //107
                string s13 = dtUsuarioDatos.Rows[0]["Rol"].ToString();    //Técnico de Procesamiento CC y Envío APS
                string s14 = dtUsuarioDatos.Rows[0]["IdOficina"].ToString();    //2
                string s15 = dtUsuarioDatos.Rows[0]["Oficina"].ToString();  //LA PAZ
                string s16 = dtUsuarioDatos.Rows[0]["IdArea"].ToString();  //240
                string s17 = dtUsuarioDatos.Rows[0]["Area"].ToString(); //Envíos APS
                string s18 = dtUsuarioDatos.Rows[0]["FecHoraString"].ToString();    //29/05/2015  9:15AM
                string s19 = dtUsuarioDatos.Rows[0]["IdTipoUsuario"].ToString();    //677

                IdUsuario = Int32.Parse(s10);
                IdOficina = Int32.Parse(s14);
                IdArea = Int32.Parse(s16);
            }
            else
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
        }
        
        if (!Page.IsPostBack)
        {
            ViewState["SortExpr"] = Sort_Direction;

            txtFechaCorte.Text = String.Format("{0:dd/MM/yyyy}",  DateTime.Now);    //formato español      
            LlenaListadoPreliminarAltas(txtFechaCorte.Text, 1);
            //CargaPosiblesDestinos();
        }
    }

    #region ListadoPreliminarAltas
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        LlenaListadoPreliminarAltas(txtFechaCorte.Text, 1);
    }
    private void LlenaListadoPreliminarAltas(string FechaCorte, int pageIndex)
    {
        int RecordCount = 0, RecordCountA = 0, RecordCountM = 0;
        int pageSize = int.Parse(ddlPageSize.SelectedValue);
        
        DataTable listado1 = new DataTable();
        objGeneraBandejas.iIdConexion = IdConexion;
        objGeneraBandejas.fFechaCorte = Convert.ToDateTime(FechaCorte);
        objGeneraBandejas.iPageIndex = pageIndex;
        objGeneraBandejas.iPageSize = pageSize;
        objGeneraBandejas.sOrderBy = ViewState["SortExpr"].ToString();
        if (objGeneraBandejas.ListadoPreliminarEnvioAPSPag())
        {
            listado1 = objGeneraBandejas.DSet.Tables[0];
            RecordCountA = objGeneraBandejas.iRecordCountA;
            RecordCount = objGeneraBandejas.iRecordCount;
        }
        else
        {
            //Error
            string DetalleError = objGeneraBandejas.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        //DataView dvlistado1 = listado1.DefaultView;
        //dvlistado1.Sort = ViewState["SortExpr"].ToString();
        //gvListadoPreliminarAltas.DataSource = dvlistado1;

        gvListadoPreliminarAltas.DataSource = listado1;
        gvListadoPreliminarAltas.DataBind();

        RecordCountM =  Math.Abs(RecordCount - RecordCountA);
        lblRecordCount.Text = RecordCount.ToString();
        lblRecordCountA.Text = RecordCountA.ToString();
        lblRecordCountM.Text = RecordCountM.ToString();

        this.PopulatePager(RecordCount, pageIndex);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.LlenaListadoPreliminarAltas(txtFechaCorte.Text, pageIndex);
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("|<", "1", currentPage > 1));
            //for (int i = 1; i <= pageCount; i++)
            //{
            //    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //}
            int startPage = currentPage - 5;
            int endPage = currentPage + 5;
            if (startPage < 5) startPage = 1;
            if (endPage > pageCount) endPage = pageCount;
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == startPage & i!=1) pages.Add(new ListItem("...", startPage.ToString(), startPage != currentPage));
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                if (i == endPage & i != pageCount) pages.Add(new ListItem("...", endPage.ToString(), currentPage < pageCount));
            }            
            pages.Add(new ListItem(">|", pageCount.ToString(), currentPage < pageCount));
        }
        if (pageCount > 1)
        {
            rptPager.Visible = true;
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
        else
        {
            rptPager.Visible = false;
        }
    }
    protected void gvListadoPreliminarAltas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Boolean ErrValidacion = false;
            LinkButton lnkObservado = (LinkButton)e.Row.FindControl("lnkObservado");
            LinkButton lnkGeneraEM = (LinkButton)e.Row.FindControl("lnkGeneraEM");
            lnkObservado.Visible = false;
            lnkGeneraEM.Visible = false;

            string ErrorFechaNac = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "ErrorFechaNac"));
            if (!string.IsNullOrEmpty(ErrorFechaNac))
            {
                e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                e.Row.ForeColor = System.Drawing.Color.Black;
                ErrValidacion = true;
            }
            string MontoAlto = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "MontosAltos"));
            if (!string.IsNullOrEmpty(MontoAlto))
            {
                e.Row.BackColor = System.Drawing.Color.GreenYellow;
                e.Row.ForeColor = System.Drawing.Color.DarkSlateGray;
                ErrValidacion = true;
            }
            string DifAPSfechaNac = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "Diferencias_APS_FECHA_NAC"));
            if (!string.IsNullOrEmpty(DifAPSfechaNac))
            {
                e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                e.Row.ForeColor = System.Drawing.Color.Black;
                ErrValidacion = true;
            }
            string DifAPSci = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "Diferencias_APS_CI"));
            if (!string.IsNullOrEmpty(DifAPSci))
            {
                e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                e.Row.ForeColor = System.Drawing.Color.Black;
                ErrValidacion = true;
            }
            string DifNombreApellido = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "Dif_APS_NOMBRES_APELLIDOS"));
            if (!string.IsNullOrEmpty(DifNombreApellido))
            {
                e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                e.Row.ForeColor = System.Drawing.Color.Black;
                ErrValidacion = true;
            }
            string DifAfiliadoAPS = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "Afiliado_APS"));
            if (DifAfiliadoAPS == "NO TIENE REGISTRO AFILIADOS APS")
            {
                e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                e.Row.ForeColor = System.Drawing.Color.Black;
                ErrValidacion = true;
            }
            string DifCambioAFP = Convert.ToString
                (DataBinder.Eval(e.Row.DataItem, "Cambio_APS_AFP"));
            if (!string.IsNullOrEmpty(DifCambioAFP))
            {
                e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                e.Row.ForeColor = System.Drawing.Color.Black;
                ErrValidacion = true;
            }
            if (ErrValidacion)
            {
                lnkObservado.Visible = true;
                lnkGeneraEM.Visible = false;
            }
            else
            {
                lnkObservado.Visible = false;
                lnkGeneraEM.Visible = true;
            }
        }
    }
    protected void gvListadoPreliminarAltas_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
        }
        this.LlenaListadoPreliminarAltas(txtFechaCorte.Text, 1);
    }
    #endregion
    
    #region Observados
    private DataTable ListaPosiblesDestinos()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.ListaPosiblesDestinos())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    protected void CargaPosiblesDestinos()
    {
        ddlPosiblesDestinos.DataSource = ListaPosiblesDestinos();
        ddlPosiblesDestinos.DataTextField = "AreaDestino";
        ddlPosiblesDestinos.DataValueField = "IdAreaDestino";
        ddlPosiblesDestinos.DataBind();

        ddlPosiblesDestinos.Items.Insert(0, new ListItem("--Elegir--", "0"));
        ddlRolUsuario.Items.Insert(0, new ListItem("--Elegir--", "0"));
    }
    protected void ddlPosiblesDestinos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        string Codigo = ddlPosiblesDestinos.SelectedValue;

        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.iIdAreaDestino = IdArea;
        objBandejaUsuario.iIdAreaDestinoNew = Int32.Parse(Codigo);
        if (objBandejaUsuario.ListaUsuarioDestinoPosible())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        ddlRolUsuario.DataSource = dt;
        ddlRolUsuario.DataTextField = "Descripcion";
        ddlRolUsuario.DataValueField = "IdRolDestino";
        ddlRolUsuario.DataBind();

        ddlRolUsuario.Items.Insert(0, new ListItem("--Elegir--", "0"));
        this.ModalPopupExtender1.Show();
    }
    protected void ddlRolUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        this.ModalPopupExtender1.Show();
    }
    protected void lnkObservado_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/WFArticulador/wfrmBandejaUsuario.aspx");

        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        //lblNroRegistro.Text = gvListadoPreliminarAltas.DataKeys[gRow.RowIndex].Value.ToString();
        //lblNroRegistro2.Text = gRow.Cells[1].Text;
        //lblIdTramite.Text = gRow.Cells[2].Text;
        //lblNUP.Text = gRow.Cells[3].Text;
        //lblNroCertificado.Text = gRow.Cells[4].Text;
        //lblClaseCC.Text = gRow.Cells[6].Text;

        vIdTramite = Int64.Parse(gvListadoPreliminarAltas.DataKeys[gRow.RowIndex]["IdTramite"].ToString());
        vIdGrupoBeneficio = Int32.Parse(gvListadoPreliminarAltas.DataKeys[gRow.RowIndex]["IdGrupoBeneficio"].ToString());
        //..::workflow::..
        //ListaWF(vIdTramite, vIdGrupoBeneficio);
        lblIdTramite.Text = "IdTramite: " + gvListadoPreliminarAltas.DataKeys[gRow.RowIndex]["IdTramite"].ToString();

        CargaPosiblesDestinos();
        this.ModalPopupExtender1.Show();
    }
    protected void lnkGeneraEM_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmGeneracionDeMedios.aspx");
    }
    protected void btnDerivarObservado_Click(object sender, EventArgs e)
    {
        DateTime fFechaAsignacion = DateTime.Now;

        //Valida el tramite y la derivación
        string sIdRol = ddlRolUsuario.SelectedValue;
        string sIdRuta = "";

        DataTable dtConsulta = new DataTable();
        int numFilas = 0;
        int numColumnas = 0;

        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.sIdTramite = vIdTramite.ToString();
        objBandejaUsuario.iIdAreaDestino = IdArea;
        objBandejaUsuario.iIdAreaDestinoNew = Int32.Parse(ddlPosiblesDestinos.SelectedValue);
        objBandejaUsuario.iIdRolNew = Int32.Parse(sIdRol);
        if (objBandejaUsuario.BuscaTramitePreAsignaBandejaTrabajo())
        {
            dtConsulta = objBandejaUsuario.DSet.Tables[0];
            numFilas = dtConsulta.Rows.Count;
            numColumnas = dtConsulta.Columns.Count;
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        if (numFilas != 1 || numColumnas != 1)
        {
            sIdRuta = dtConsulta.Rows[0]["IdRuta"].ToString();
            
            //Genera 430 de derivación a Observados
            objBandejaUsuario.iIdConexion = IdConexion;
            objBandejaUsuario.sIdTramite = vIdTramite.ToString();
            objBandejaUsuario.iIdRuta = Int32.Parse(sIdRuta);
            objBandejaUsuario.iIdAreaDestinoNew = Int32.Parse(ddlPosiblesDestinos.SelectedValue);
            objBandejaUsuario.fFechaAsignacion = fFechaAsignacion;
            objBandejaUsuario.sObsSalidaArea = txtProveido.Text;
            objBandejaUsuario.sProvehido = "Remite Envios APS, tramite observado: " + vIdTramite.ToString();
            if (objBandejaUsuario.AsignaTramite())
            {
                Master.MensajeOk("Exito!! Se derivó el tramite correctamente.");
                txtProveido.Text = "";
            }
            else
            {
                //Error
                string DetalleError = objBandejaUsuario.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            //Error
            string DetalleError = dtConsulta.Rows[0][0].ToString();
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        LlenaListadoPreliminarAltas(txtFechaCorte.Text, 1);
    }
    #endregion
    protected void btnListadoExportaExcel_Click(object sender, EventArgs e)
    {
        Session["txtFechaCorte"] = txtFechaCorte.Text;
        //Response.Redirect("wfrmGeneraListadoPreliminar.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmGeneraListadoPreliminar.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    protected void btnListadoExportaExcel_Click2(object sender, EventArgs e)
    {
        //Export o excel
        int RecordCount = 0, RecordCountA = 0;

        DataTable sourceTable = new DataTable();
        objGeneraBandejas.iIdConexion = IdConexion;
        objGeneraBandejas.fFechaCorte = Convert.ToDateTime(txtFechaCorte.Text);
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
            Master.MensajeError(Error, DetalleError);
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

            ws.Cells[2, 1].Value = "(Fecha de Corte: " + txtFechaCorte.Text.ToString() + ")";
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
                    border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;
                    if (colIndex == 6)
                    {
                        string Clase_CC = cell.Value.ToString();
                        if (Clase_CC=="A")
                        {
                            CertificadosAutomaticos = CertificadosAutomaticos + 1;
                        }
                        if (Clase_CC=="M")
                        {
                            CertificadosManuales = CertificadosManuales + 1;
                        }
                    }
                    if (colIndex == 21 || colIndex == 22 || colIndex == 24 || colIndex == 25 || colIndex == 26 || colIndex == 28)
                    {
                        string ColumnaError = cell.Value.ToString();
                        if (!string.IsNullOrEmpty(ColumnaError))
                        {
                            CertificadoObservado = CertificadoObservado + 1;
                        }
                    }
                    if (colIndex == 27)
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
    protected void btnProcesaListadoPreliminarAltas_Click(object sender, EventArgs e)
    {
        this.LlenaListadoPreliminarAltas(txtFechaCorte.Text, 1);
    }
}