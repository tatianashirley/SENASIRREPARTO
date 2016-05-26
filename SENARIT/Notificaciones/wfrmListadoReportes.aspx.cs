using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Web;
using wcfNotificacion.Logica;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;
//PARTE PARA EXPORTAR EN EXCEL
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
public partial class Notificaciones_wfrmListadoReportes : System.Web.UI.Page
{
    #region Inicio_Reportes
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        Int32 IdTipoReporte = Convert.ToInt32(Request.QueryString["IdTipoReporte"]);
        string IdDocumento = Request.QueryString["IdDocumento"];
        string Regional = Request.QueryString["Regional"];
        string FechaIni = Request.QueryString["FechaIni"];
        string FechaFin = Request.QueryString["FechaFin"];
        Reporte_Listados(IdTipoReporte,IdDocumento,Regional,FechaIni,FechaFin);
    }
    #endregion

    #region generacion

    void Reporte_Listados(Int32 IdTipoReporte,string IdDocumento,string Regional,string FechaIni,string FechaFin)
    {
        int hojas = 1;
        byte[] bytes;
        DataTable dts_Reporte = DatosReporte(Regional, IdTipoReporte, IdDocumento, FechaIni, FechaFin);
        int cabecera = 0;

        if (dts_Reporte != null && dts_Reporte.Rows.Count > 0)
        {
            string Matricula, Tramite, Beneficio, FecSis, Nombres, EstadNot, FecDoc, NroDoc, Documento, CiteEnv, FecEnv, FecDev, Obs, EstEnv, Region, NroDias;
            string Cuenta;
            if (IdTipoReporte == 1 || IdTipoReporte == 2)
            {
                //Datos para Reporte
                DataTable Usuario = UsuarioCuenta();
                Cuenta = Usuario.Rows[0]["CuentaUsuario"].ToString();

                //Inicio de Documento
                var document = new Document(PageSize.LETTER, 10, 10, 10, 10);
                document.SetMargins(10, 10, 30, 10);
                document.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
                FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
                int Alto = Convert.ToInt32(document.PageSize.Height) - 50;
                using (var memoryStream = new System.IO.MemoryStream())
                {

                    var writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    //Cabecera Principal
                    var table = Cabecera_Principal(IdTipoReporte, FechaIni, FechaFin);
                    document.Add(table);

                    cabecera += Convert.ToInt32(table.TotalHeight);

                    table.CompleteRow();
                    document.Add(new Paragraph(" "));//--salto de linea


                    //Inicio de ForEach
                    table = CabeceraEnvioDevolucion(IdTipoReporte);
                    document.Add(table);

                    cabecera += Convert.ToInt32(table.TotalHeight);

                    //Alto -= cabecera;
                    Alto = 320;

                    var table1 = new PdfPTable(16) { TotalWidth = 750f, LockedWidth = true };
                    table1.WidthPercentage = 100;
                    //table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f, 8f, 8f });
                    table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f, 10f });
                    PdfPCell cell;

                    foreach (DataRow rowF in dts_Reporte.Rows)
                    {
                        Matricula = rowF["Matricula"].ToString(); Tramite = rowF["IdTramite"].ToString(); Beneficio = rowF["Beneficio"].ToString(); FecSis = rowF["FechaSistema"].ToString();
                        Nombres = rowF["Nombres"].ToString(); EstadNot = rowF["EstadoNot"].ToString(); FecDoc = rowF["FechaDocumento"].ToString(); NroDoc = rowF["NroDocumento"].ToString();
                        Documento = rowF["Documento"].ToString(); CiteEnv = rowF["CiteEnv"].ToString(); FecDev = rowF["FechaDevolucion"].ToString(); FecEnv = rowF["FechaEnvio"].ToString();
                        Obs = rowF["Obs"].ToString(); EstEnv = rowF["EstadoEnv"].ToString(); Region = rowF["Regional"].ToString();
                        //1
                        cell = PhraseCell(new Phrase(Matricula, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //2
                        cell = PhraseCell(new Phrase(Tramite, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //3
                        cell = PhraseCell(new Phrase(Beneficio, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //4
                        cell = PhraseCell(new Phrase(FecSis, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_CENTER);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //5,6
                        cell = PhraseCell(new Phrase(Nombres, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        cell.Colspan = 2;
                        table1.AddCell(cell);
                        //7
                        cell = PhraseCell(new Phrase(EstadNot, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //8
                        cell = PhraseCell(new Phrase(FecDoc, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //9
                        cell = PhraseCell(new Phrase(NroDoc, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_CENTER);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //10
                        cell = PhraseCell(new Phrase(Documento, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        cell.Colspan = 2;
                        table1.AddCell(cell);
                        //11
                        cell = PhraseCell(new Phrase(CiteEnv, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        if (IdTipoReporte == 1)
                        {   //12
                            cell = PhraseCell(new Phrase(FecEnv, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                            cell.BorderColor = Color.BLACK;
                            table1.AddCell(cell);
                        }
                        if (IdTipoReporte == 2)
                        {   //12
                            cell = PhraseCell(new Phrase(FecDev, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                            cell.BorderColor = Color.BLACK;
                            table1.AddCell(cell);
                        }
                        //13
                        cell = PhraseCell(new Phrase(Obs, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //14
                        cell = PhraseCell(new Phrase(EstEnv, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);
                        //15
                        cell = PhraseCell(new Phrase(Region, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        cell.BorderColor = Color.BLACK;
                        table1.AddCell(cell);

                        //cell = PhraseCell(new Phrase(NroDias, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
                        //cell.BorderColor = Color.BLACK;
                        //table1.AddCell(cell);

                        //document.Add(table1);
                        //WriteWaterMark(document, "~/Imagenes/InicioTramite/ESCUDO_BOLIVIA.JPG");
                        //document.NewPage();
                        //document.SetMargins(10, 10, 30, 10);
                        if (Alto <= Convert.ToInt32(table1.TotalHeight))
                        {
                            document.Add(table1);
                            table1 = new PdfPTable(1) { TotalWidth = 750f, LockedWidth = true };
                            table1.WidthPercentage = 100;
                            document.NewPage();
                            //Cabecera Principal
                            var tableP = Cabecera_Principal(IdTipoReporte, FechaIni, FechaFin);
                            document.Add(tableP);

                            document.Add(new Paragraph(" "));//--salto de linea

                            //Inicio de ForEach
                            tableP = CabeceraEnvioDevolucion(IdTipoReporte);
                            document.Add(tableP);
                            Alto = 320;
                            hojas++;
                        }
                    }
                    document.Add(table1);
                    //Fin Foreach
                    //Inicio de marca de Agua

                    //WriteWaterMark(document, "~/Imagenes/InicioTramite/icono_senasir.JPG");

                    //Fin de Marca de Agua

                    document.Close();
                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Env_Dev_Documentos.pdf");
                Response.ContentType = "application/pdf";
                //Response.ContentType = "application/vnd.ms-excel";                
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
            if (IdTipoReporte >= 3 && IdTipoReporte <= 9)
            {
                GridView Prueba = new GridView();
                Prueba.DataSource = dts_Reporte;
                Prueba.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Notificaciones.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    Prueba.AllowPaging = false;

                    //Prueba.HeaderRow.BackColor =Color.WHITE;
                    foreach (TableCell cell in Prueba.HeaderRow.Cells)
                    {
                        cell.BackColor = Prueba.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in Prueba.Rows)
                    {
                        //row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = Prueba.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = Prueba.RowStyle.BackColor;
                            }
                            //cell.CssClass = "textmode";
                        }
                    }

                    Prueba.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }
        else 
        {
            Response.Redirect("wfrmReportesNotificacion.aspx");
        }
    }

    #endregion

    #region Datos_Reportes
    DataTable DatosReporte(string Regional, Int32 IdTipoReporte, string IdDocumento, string FechaIni, string FechaFin)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsReportes objNotificacion = new clsReportes();
        DataTable dtReporte = new DataTable();
        dtReporte = objNotificacion.DocumentosEnv_Dev(iIdConexion, cOperacion,IdTipoReporte,IdDocumento,Regional,FechaIni,FechaFin,ref sMensajeError);
        return dtReporte;
    }

    DataTable UsuarioCuenta()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";

        clsReportes objNotificacion = new clsReportes();
        DataTable dtReporte = new DataTable();
        dtReporte = objNotificacion.CuentaUsuario(iIdConexion, cOperacion, ref sMensajeError);
        return dtReporte;
    }
    #endregion

    #region partes

    // Dibuja linea
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }
    // Celdas para Reporte
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        var cell = new PdfPCell(phrase)
        {
            BorderColor = Color.WHITE,
            VerticalAlignment = Element.ALIGN_TOP,
            HorizontalAlignment = align,
            PaddingBottom = 2f,
            PaddingTop = 0f//,
        };
        return cell;
    }

    //Imagen en Celda para Reporte
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        var image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        var cell = new PdfPCell(image)
        {
            BorderColor = Color.WHITE,
            VerticalAlignment = Element.ALIGN_TOP,
            HorizontalAlignment = align,
            PaddingBottom = 0f,
            PaddingTop = 0f
        };
        return cell;
    }

    //Imagen de Fondo
    //private void WriteWaterMark(Document objPdfDocument, string strFileImage)
    //{
    //    Image objImagePdf;

    //    // Crea la imagen
    //    objImagePdf = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strFileImage));
    //    //objImagePdf = Image.GetInstance(strFileImage);
    //    // Cambia el tamaño de la imagen
    //    objImagePdf.ScaleToFit(200, 200);

    //    // Se indica que la imagen debe almacenarse como fondo
    //    objImagePdf.Alignment = iTextSharp.text.Image.UNDERLYING;

    //    // Coloca la imagen en una posición absoluta
    //    objImagePdf.SetAbsolutePosition(350, 300);
    //    // Imprime la imagen como fondo de página
    //    objPdfDocument.Add(objImagePdf);
    //}

    //Cabecera Propia
    private PdfPTable Cabecera_Principal(Int32 TipoReporte, string FechaIni, string FechaFin)
    {
        DateTime Hoy = DateTime.Now;
        string Cuenta, titulo="";
        //OBtencion de Usuario
        DataTable Usuario = UsuarioCuenta();
        Cuenta = Usuario.Rows[0]["CuentaUsuario"].ToString();
        var table = new PdfPTable(4) { TotalWidth = 720f, LockedWidth = true };
        table.WidthPercentage = 100;
        //--> Cabecera
        PdfPCell cellCabecera;
        //-----------------
        //1ra Línea
        cellCabecera = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER); //celda con contenido
        cellCabecera.Colspan = 4; //tamaño de la celda
        table.AddCell(cellCabecera); //adicion a la tabla

        //2da Línea
        cellCabecera = ImageCell("~/Imagenes/InicioTramite/icono_senasir.JPG", 30f, Element.ALIGN_LEFT);
        table.AddCell(cellCabecera);

        switch (TipoReporte)
        {
            case 1:
                titulo = "ENVIO DE DOCUMENTOS";
                break;
            case 2:
                titulo = "DEVOLUCION DE DOCUMENTOS";
                break;
            case 3:
                titulo = "NOTIFICACIONES PENDIENTES";
                break;
            case 4:
                titulo = "PENDIENTES MAYOR A 6 MESES";
                break;
            case 5:
                titulo = "PENDIENTES MAYOR A 1 MES";
                break;
            case 6:
                titulo = "NOTIFICACION CON PLAZO VENCIDO";
                break;
            case 7:
                titulo = "NOTIFICACION EN PLAZO";
                break;
            case 8:
                titulo = "NOTIFICACIONES";
                break;
            case 9:
                titulo = "RECURSOS";
                break;
        }

        //Crea Frase para ponerla en una celda
        var phrase = new Phrase { new Chunk("LISTADO DE " + titulo, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)) };

        cellCabecera = PhraseCell(phrase, Element.ALIGN_CENTER);
        cellCabecera.Colspan = 2;
        table.AddCell(cellCabecera);

        cellCabecera = PhraseCell(new Phrase((Hoy.ToString("dd/MM/yyyy") + "\n" + Hoy.ToString("hh:mm:ss") + "\n" + Cuenta), FontFactory.GetFont("Times New Roman", 5.5f, Font.ITALIC, Color.BLACK)),
                Element.ALIGN_RIGHT);
        table.AddCell(cellCabecera);

        //3ra linea de Encabezado
        cellCabecera = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), Element.ALIGN_RIGHT);
        table.AddCell(cellCabecera);


        cellCabecera = PhraseCell(new Phrase(("DEL " + FechaIni + " AL " + FechaFin), FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK)), Element.ALIGN_CENTER);
        cellCabecera.Colspan = 2;
        table.AddCell(cellCabecera);

        cellCabecera = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        table.AddCell(cellCabecera);

        return table;
    }

    //Cabecera Secundaria
    private PdfPTable CabeceraEnvioDevolucion(Int32 IdTipoReporte)
    {   
        string titulo= "";
        switch (IdTipoReporte)
        {
            case 1:
                titulo = "FechaEnv";
                break;
            case 2:
                titulo = "FechaDev";
                break;
        }
        var table1 = new PdfPTable(16) { TotalWidth = 750f, LockedWidth = true };
        table1.WidthPercentage = 100;
        PdfPCell cell;

        //table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f, 8f, 8f });
        table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f,10f,10f });
        //1
        cell = PhraseCell(new Phrase("Matrícula", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)), Element.TITLE);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //2
        cell = PhraseCell(new Phrase("Trámite", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //3
        cell = PhraseCell(new Phrase("Beneficio", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //4
        cell = PhraseCell(new Phrase("Fecha_Sis", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //5,6
        cell = PhraseCell(new Phrase("Nombres", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        cell.Colspan = 2;
        table1.AddCell(cell);
        //7
        cell = PhraseCell(new Phrase("Estado_Not", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //8
        cell = PhraseCell(new Phrase("FechaDoc", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //9
        cell = PhraseCell(new Phrase("NroDoc", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //10
        cell = PhraseCell(new Phrase("Documento", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        cell.Colspan = 2;
        table1.AddCell(cell);

        //cell = PhraseCell(new Phrase("FechaNot", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        //cell.BorderColor = Color.BLACK;
        //cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        //table1.AddCell(cell);

        //cell = PhraseCell(new Phrase("FechaRec", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        //cell.BorderColor = Color.BLACK;
        //cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        //table1.AddCell(cell);

        //11
        cell = PhraseCell(new Phrase("Cite", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //12
        cell = PhraseCell(new Phrase(titulo, FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //13
        cell = PhraseCell(new Phrase("Obs",FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //14
        cell = PhraseCell(new Phrase("Est. \n Envio", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);
        //15
        cell = PhraseCell(new Phrase("Regional", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
        cell.BorderColor = Color.BLACK;
        cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        table1.AddCell(cell);

        return table1;
    }

    private PdfPTable CabeceraPendientes(Int32 IdTipoReporte)
    {
        Int32 campo = 0;
        switch (IdTipoReporte)
        {
            case 3:
                campo = 15;
                break;
            case 4:
                campo = 16;
                break;
            case 5:
                campo = 16;
                break;
        }
        if (IdTipoReporte == 3)
        {
            var table1 = new PdfPTable(campo) { TotalWidth = 750f, LockedWidth = true };
            table1.WidthPercentage = 100;
            PdfPCell cell;

            //table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f, 8f, 8f });
            table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f});
            //1
            cell = PhraseCell(new Phrase("Matrícula", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)), Element.TITLE);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //2
            cell = PhraseCell(new Phrase("Trámite", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //3
            cell = PhraseCell(new Phrase("Beneficio", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //4
            cell = PhraseCell(new Phrase("Fecha_Sis", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //5,6
            cell = PhraseCell(new Phrase("Nombres", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell.Colspan = 2;
            table1.AddCell(cell);
            //7
            cell = PhraseCell(new Phrase("Estado_Not", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //8
            cell = PhraseCell(new Phrase("FechaDoc", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //9
            cell = PhraseCell(new Phrase("NroDoc", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //10,11
            cell = PhraseCell(new Phrase("Documento", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell.Colspan = 2;
            table1.AddCell(cell);

            //12
            cell = PhraseCell(new Phrase("Cite", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //13
            cell = PhraseCell(new Phrase("Fecha", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //14
            cell = PhraseCell(new Phrase("Obs", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //15
            cell = PhraseCell(new Phrase("Est. \n Envio", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //16
            //cell = PhraseCell(new Phrase("NroDias", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            //cell.BorderColor = Color.BLACK;
            //cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            //table1.AddCell(cell);
            return table1;
        }
        else 
        {
            var table1 = new PdfPTable(campo) { TotalWidth = 750f, LockedWidth = true };
            table1.WidthPercentage = 100;
            PdfPCell cell;

            //table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f, 8f, 8f });
            table1.SetWidths(new float[] { 16f, 11f, 9f, 12f, 11f, 8f, 9f, 12f, 10f, 12f, 10f, 10f, 10f, 10f, 10f, 10f });
            //1
            cell = PhraseCell(new Phrase("Matrícula", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)), Element.TITLE);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //2
            cell = PhraseCell(new Phrase("Trámite", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //3
            cell = PhraseCell(new Phrase("Beneficio", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //4
            cell = PhraseCell(new Phrase("Fecha_Sis", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //5,6
            cell = PhraseCell(new Phrase("Nombres", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell.Colspan = 2;
            table1.AddCell(cell);
            //7
            cell = PhraseCell(new Phrase("Estado_Not", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //8
            cell = PhraseCell(new Phrase("FechaDoc", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //9
            cell = PhraseCell(new Phrase("NroDoc", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //10,11
            cell = PhraseCell(new Phrase("Documento", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            cell.Colspan = 2;
            table1.AddCell(cell);

            //12
            cell = PhraseCell(new Phrase("Cite", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //13
            cell = PhraseCell(new Phrase("Fecha", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //14
            cell = PhraseCell(new Phrase("Obs", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //15
            cell = PhraseCell(new Phrase("Est. \n Envio", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            //16
            cell = PhraseCell(new Phrase("NroDias", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)), Element.ALIGN_CENTER);
            cell.BorderColor = Color.BLACK;
            cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
            table1.AddCell(cell);
            return table1;
        }

    }
    #endregion

}