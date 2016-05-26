using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Web;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;

public partial class InicioTramite_wfrmReportForm03ACC : System.Web.UI.Page
{
    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string tramite = Request.QueryString["tramite"];
        string matricula = Request.QueryString["matricula"];
        Reporte_form_03(tramite, matricula);
    }

    #endregion

    #region datos reporte

    DataTable datosReporte(string idtramite, string matricula,string tipoReporte)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        DataTable dtReporte = new DataTable();
        clsAccesoDirecto ObjTramite = new clsAccesoDirecto();
        ObjTramite.iIdConexion = iIdConexion;
        ObjTramite.cOperacion = cOperacion;
        ObjTramite.IdTramite = idtramite;
        ObjTramite.Matricula = matricula;
        ObjTramite.TipoInformacion = tipoReporte;
        if (ObjTramite.ObtenerDatosReporte())
        {
            dtReporte = ObjTramite.DSetTmp.Tables[0];
        }
        return dtReporte;
    }
    
    #endregion

    #region generacion

    void Reporte_form_03(string tramite, string matricula)
    {
        byte[] bytes;
        DateTime Hoy = DateTime.Now;
        DataTable dt_persona = datosReporte(tramite, matricula, "DatosPersonales");
        if (dt_persona != null && dt_persona.Rows.Count > 0)
        {
            string NROTRAMITE = "", Matricula = "", NumeroDocumento = "", ComplementoSEGIP = "", PrimerNombre = "", SegundoNombre = "", PrimerApellido = "", SegundoApellido = "", FechaNacimiento = "", FechaFallecimiento = "", OficinaNotificacion = "";
            string EntidadGestora = "", CUA = "", EstadoCivil = "", Direccion = "", Telefono = "", TipoTramite = "", sector = "", FechaInicioTramite = "";
            string DocExpedicion, EntidadGestoraall, Sexoall, ApellidoCasada, NombreProvincia, NombreDepartamento, CuentaUsuario, Celular;
            string correlativoabc, NUP, IdTipoTramite;
            NROTRAMITE = HttpUtility.HtmlDecode(dt_persona.Rows[0]["IdTramite"].ToString());
            Matricula = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Matricula"].ToString());
            NumeroDocumento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NumeroDocumento"].ToString());
            //ComplementoSEGIP = HttpUtility.HtmlDecode(dt_persona.Rows[0]["ComplementoSEGIP"].ToString());
            PrimerNombre = HttpUtility.HtmlDecode(dt_persona.Rows[0]["PrimerNombre"].ToString());
            //SegundoNombre = HttpUtility.HtmlDecode(dt_persona.Rows[0]["SegundoNombre"].ToString());
            PrimerApellido = HttpUtility.HtmlDecode(dt_persona.Rows[0]["PrimerApellido"].ToString());
            SegundoApellido = HttpUtility.HtmlDecode(dt_persona.Rows[0]["SegundoApellido"].ToString());
            //ApellidoCasada = HttpUtility.HtmlDecode(dt_persona.Rows[0]["ApellidoCasada"].ToString());
            FechaNacimiento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaNacimiento"].ToString());
            //FechaFallecimiento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaFallecimiento"].ToString());            
            EstadoCivil = HttpUtility.HtmlDecode(dt_persona.Rows[0]["EstadoCivil"].ToString());            
            Sexoall = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Sexo"].ToString());            
            //CuentaUsuario = HttpUtility.HtmlDecode(dt_persona.Rows[0]["CuentaUsuario"].ToString());
            string documento;
            //------------------------            
            DataTable dt_docIndis = datosReporte(tramite, matricula, "DatosDocumentos1");
            DataTable dt_docSector = datosReporte(tramite, matricula, "DatosDocumentos2");
            DataTable dt_docCausa = datosReporte(tramite, matricula, "DatosDocumentos3");
            //-------------------------
            var document = new Document(PageSize.LEGAL, 20, 20, 20, 20);
            FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
            using (var memoryStream = new System.IO.MemoryStream())
            {
                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                var table = new PdfPTable(4) { TotalWidth = 550f, LockedWidth = true };
                table.WidthPercentage = 100;
                PdfPCell cell;
                //-----------------
                cell =
                   PhraseCell(
                       new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_RIGHT);
                table.AddCell(cell);
                cell =
                   PhraseCell(
                       new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_RIGHT);
                table.AddCell(cell);
                cell =
                   PhraseCell(
                       new Phrase("Fecha y Hora de Impresion: " + (Convert.ToString(Hoy)), FontFactory.GetFont("Arial", 5, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_RIGHT);
                table.AddCell(cell);
                cell =
                   PhraseCell(
                       new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_RIGHT);
                table.AddCell(cell);
                //-----------------
                cell = ImageCell("~/Imagenes/InicioTramite/icono_senasir.JPG", 30f, Element.ALIGN_CENTER);
                table.AddCell(cell);

                var phrase = new Phrase
                {
                    new Chunk("FORMULARIO DE RENUNCIA AL SISTEMA DE REPARTO Y ACCESO DIRECTO A LA CC MANUAL",
                        FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))
                };
                cell = PhraseCell(phrase, Element.ALIGN_CENTER);
                cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                table.AddCell(cell);

                //-----------------
                cell =
                    PhraseCell(
                        new Phrase(("MATRICULA: " + Matricula + "\n Nro Tramite: " + NROTRAMITE), FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_RIGHT);
                //cell.Colspan = 2;
                table.AddCell(cell);
                cell = ImageCell("~/Imagenes/InicioTramite/CC.JPG", 10f, Element.ALIGN_RIGHT);
                table.AddCell(cell);
                document.Add(table);
                document.Add(new Paragraph(" "));//--salto de linea

                //--------------------------------------tabla2
                var table2 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                table2.WidthPercentage = 100;
                table2.HorizontalAlignment = 0;


                PdfPCell cellnotaInicio;
                cellnotaInicio =
                PhraseCell(
                    new Phrase("IMPORTANTE: El presente formulario deberá ser llenado por el oficial de registro o técnico información y prestación datos de asegurado titular o derecho habiente con tramite del sistema de reparto, que por diferentes razones debe o desea realizar el acceso directo a la compensación de cotizaciones, en aplicación de la R.M. 1230 de fecha 17.12.01 y R.M. 780 de fecha 04.11.04 una vez firmado se constituye una declaración jurada, de libre voluntad e irrevocable. A la presentación del presente formulario debe adicionarse los requisitos para el procedimiento manual por acceso directo.", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                cellnotaInicio.BackgroundColor = iTextSharp.text.Color.WHITE;
                table2.AddCell(cellnotaInicio);

                PdfPCell cell2;
                //SECCION :1 DATOS DE INICIO DE TRAMITE
                cell2 =
                    PhraseCell(
                        new Phrase("SECCION 1 DATOS PERSONALES DEL (A) ASEGURADO (A)", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_LEFT);
                //cell2.Colspan = 5;
                cell2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cell2.BorderColor = Color.BLACK;
                table2.AddCell(cell2);
                document.Add(table2);
                document.Add(new Paragraph(" "));
                //---------------------------------TABLA DATOS PERSONALES
                var tableDP = new PdfPTable(6) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableDP.WidthPercentage = 100;
                tableDP.HorizontalAlignment = 0;
                PdfPCell cellDP;
                cellDP =
                    PhraseCell(
                        new Phrase(PrimerApellido, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 3;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase(SegundoApellido, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);

                cellDP.Colspan = 3;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //------------
                cellDP =
                    PhraseCell(
                        new Phrase("APELLIDO PATERNO", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 3;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase("APELLIDO MATERNO", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 3;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //----------            
                cellDP =
                    PhraseCell(
                        new Phrase(PrimerNombre, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase(SegundoNombre, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase("PRIMER NOMBRE", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase("SEGUNDO NOMBRE", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase("APELLIDO CASADA", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //---------------------------
                cellDP =
                   PhraseCell(
                       new Phrase("FECHA NACIMIENTO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);

                cellDP =
                   PhraseCell(
                       new Phrase("FECHA DEFUNCION", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                   PhraseCell(
                       new Phrase("SEXO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                   PhraseCell(
                       new Phrase("DOCUMENTO IDENTIDAD", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                 PhraseCell(
                     new Phrase("ESTADO CIVIL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                     Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //----------------------
                cellDP =
                   PhraseCell(
                       new Phrase(FechaNacimiento, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);

                cellDP =
                   PhraseCell(
                       new Phrase(FechaFallecimiento, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                   PhraseCell(
                       new Phrase(Sexoall, FontFactory.GetFont("Arial", 5, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                //cellDP.Colspan = 2;
                tableDP.AddCell(cellDP);
                if (ComplementoSEGIP != "")
                {
                    ComplementoSEGIP = "-" + ComplementoSEGIP;
                }
                cellDP =
                  PhraseCell(
                      new Phrase(NumeroDocumento + "" + ComplementoSEGIP, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                      Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                 PhraseCell(
                     new Phrase(EstadoCivil, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                     Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //------------------------------------------------------------------------------------------               
                document.Add(tableDP);
                //--------------------
                document.Add(new Paragraph(" "));//--salto de linea
                //-----------------------------------------------
                var tableseccion2 = new PdfPTable(5) { TotalWidth = 570f, LockedWidth = true };
                tableseccion2.WidthPercentage = 100;
                tableseccion2.HorizontalAlignment = 0;
                PdfPCell cellseccion2;
                cellseccion2 =
                PhraseCell(
                    new Phrase("SECCION 2 RENUNCIA AL SISTEMA DE REPARTO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                cellseccion2.Colspan = 5;
                cellseccion2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellseccion2.BorderColor = Color.BLACK;
                tableseccion2.AddCell(cellseccion2);
                document.Add(tableseccion2);
                document.Add(new Paragraph(" "));
                var tableautomatico = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                tableautomatico.WidthPercentage = 100;
                tableautomatico.HorizontalAlignment = 0;
                PdfPCell cellautomatico;
                cellautomatico =
                PhraseCell(
                    new Phrase("REQUISITOS INDISPENSABLES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 2;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                //------------------------
                if (dt_docIndis != null && dt_docIndis.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt_docIndis.Rows)
                    {
                        documento = HttpUtility.HtmlDecode(dr["Descripcion"].ToString());
                        cellautomatico =
                        PhraseCell(
                            new Phrase(documento, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                    }
                }
                else
                {
                    cellautomatico =
                        PhraseCell(
                            new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                    cellautomatico.Colspan = 3;
                    cellautomatico.BorderColor = Color.BLACK;
                    tableautomatico.AddCell(cellautomatico);

                }
                document.Add(tableautomatico);
                document.Add(new Paragraph(" "));//--salto de linea
                /////////////------------------------
                var tableautomatico2 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                tableautomatico2.WidthPercentage = 100;
                tableautomatico2.HorizontalAlignment = 0;
                PdfPCell cellautomatico2;
                cellautomatico2 =
                PhraseCell(
                    new Phrase("REQUISITOS POR SECTOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico2.BorderColor = Color.BLACK;
                tableautomatico2.AddCell(cellautomatico2);
                cellautomatico2 =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico2.Colspan = 2;
                cellautomatico2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico2.BorderColor = Color.BLACK;
                tableautomatico2.AddCell(cellautomatico2);
                //------------------------
                if (dt_docSector != null && dt_docSector.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_docSector.Rows)
                    {
                        documento = HttpUtility.HtmlDecode(dr["Descripcion"].ToString());
                        cellautomatico2 =
                        PhraseCell(
                            new Phrase(documento, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        cellautomatico2.BorderColor = Color.BLACK;
                        tableautomatico2.AddCell(cellautomatico2);
                    }
                }
                else
                {
                    cellautomatico2 =
                        PhraseCell(
                            new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                    cellautomatico2.Colspan = 3;
                    cellautomatico2.BorderColor = Color.BLACK;
                    tableautomatico2.AddCell(cellautomatico2);

                }
                document.Add(tableautomatico2);
                document.Add(new Paragraph(" "));//--salto de linea



                /////////////------------------------
                var tableautomatico3 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                tableautomatico3.WidthPercentage = 100;
                tableautomatico3.HorizontalAlignment = 0;
                PdfPCell cellautomatico3;
                cellautomatico3 =
                PhraseCell(
                    new Phrase("REQUISITOS POR MODALIDAD", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico3.BorderColor = Color.BLACK;
                tableautomatico3.AddCell(cellautomatico3);
                cellautomatico3 =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico3.Colspan = 2;
                cellautomatico3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico3.BorderColor = Color.BLACK;
                tableautomatico3.AddCell(cellautomatico3);
                //------------------------
                if (dt_docCausa != null && dt_docCausa.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_docCausa.Rows)
                    {
                        documento = HttpUtility.HtmlDecode(dr["Descripcion"].ToString());
                        cellautomatico3 =
                        PhraseCell(
                            new Phrase(documento, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        cellautomatico3.BorderColor = Color.BLACK;
                        tableautomatico3.AddCell(cellautomatico3);
                    }
                }
                else
                {
                    cellautomatico3 =
                        PhraseCell(
                            new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                    cellautomatico3.Colspan = 3;
                    cellautomatico3.BorderColor = Color.BLACK;
                    tableautomatico3.AddCell(cellautomatico3);

                }
                document.Add(tableautomatico3);
                document.Add(new Paragraph(" "));//--salto de linea

                /////////////------------------------
                var tablenota1 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tablenota1.WidthPercentage = 100;
                tablenota1.HorizontalAlignment = 50;
                PdfPCell cellnota1;
                cellnota1 =
                PhraseCell(
                    new Phrase("El suscrito, de forma libre y voluntaria, renuncia al Procedimiento Automático y solicito al SENASIR que pase el trámite al Procedimiento Manual de la Compensación de Cotizaciones, conforme a normas y requisitos establecidos para el efecto.", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                //cellseccion3.Colspan = 5;
                cellnota1.BackgroundColor = iTextSharp.text.Color.WHITE;
                tablenota1.AddCell(cellnota1);
                document.Add(tablenota1);
                document.Add(new Paragraph(" "));//--salto de linea
                //--------------------------------------


                //----------------------------------------------seccion 5
                var tableSEC5 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableSEC5.WidthPercentage = 100;
                tableSEC5.HorizontalAlignment = 0;

                PdfPCell cellSEC5;
                cellSEC5 =
                PhraseCell(
                    new Phrase("SECCION 3 CONSTANCIA DE VERASIDAD DE LA DOCUMENTACION PRESENTADA Y RECIBIDA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                //cellseccion3.Colspan = 5;
                cellSEC5.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellSEC5.BorderColor = Color.BLACK;
                tableSEC5.AddCell(cellSEC5);
                document.Add(tableSEC5);
                document.Add(new Paragraph(" "));//--salto de linea
                //document.Add(new Paragraph(" "));//--salto de linea
                //-------------------------------------------------

                var tableSEC5descrip = new PdfPTable(9) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableSEC5descrip.WidthPercentage = 100;
                tableSEC5descrip.HorizontalAlignment = 0;
                PdfPCell cellSEC5descr;
                cellSEC5descr =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //---

                cellSEC5descr =
                PhraseCell(
                    new Phrase("\n \n \n--------------------------------------------------------", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);

                //----------------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-----------------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("(Oficina Central o Administracion y/o Agencia)", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //---
                cellSEC5descr =
                PhraseCell(
                    new Phrase("FIRMA DEL ASEGURADO (A) O  BENEFICIARIO (A)", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);


                //----------------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //------------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("DIA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //ellSEC5descr.Colspan = 3;
                cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-----------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("MES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //ellSEC5descr.Colspan = 3;
                cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //------------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //ellSEC5descr.Colspan = 3;
                cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-----------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //------------------------

                //------------------

                string dia, mes, anio;
                dia = Hoy.Day.ToString();
                mes = Hoy.Month.ToString();
                anio = Hoy.Year.ToString();
                cellSEC5descr =
                PhraseCell(
                    new Phrase(dia, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //ellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-----------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase(mes, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //ellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //------------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase(anio, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //ellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("\n------------------------------------\nACLARACION DE FIRMA", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                //cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //-----------------
                cellSEC5descr =
                PhraseCell(
                    new Phrase("Sello y Pie de Firma de Recepción", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellSEC5descr.Colspan = 3;
                cellSEC5descr.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC5descr.BorderColor = Color.BLACK;
                tableSEC5descrip.AddCell(cellSEC5descr);
                //------------------------
                document.Add(tableSEC5descrip);
                document.Add(new Paragraph(" "));//--salto de linea
                /////////////------------------------
                var tablenota = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tablenota.WidthPercentage = 100;
                tablenota.HorizontalAlignment = 50;

                PdfPCell cellnota;
                cellnota =
                PhraseCell(
                    new Phrase("NOTA: La declaración de cifras o datos falsos que influyan en la determinación del valor de la Compensación de Cotizaciones, constituye delito de falsedad ideológica y uso de instrumento falsificado, sancionado penalmente.", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                //cellseccion3.Colspan = 5;
                cellnota.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellnota.BorderColor = Color.BLACK;
                tablenota.AddCell(cellnota);
                document.Add(tablenota);
                document.Add(new Paragraph(" "));//--salto de linea
                //////////////-------------------
                var tablenofojas = new PdfPTable(1) { TotalWidth = 180f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tablenofojas.WidthPercentage = 100;
                tablenofojas.HorizontalAlignment = 300;

                PdfPCell cellnofojas;
                //cellnofojas =
                //PhraseCell(
                //    new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                //    Element.ALIGN_CENTER);
                ////cellseccion3.Colspan = 5;
                ////cellnofojas.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                ////cellnofojas.BorderColor = Color.BLACK;
                //tablenofojas.AddCell(cellnofojas);

                cellnofojas =
                    //--------------
                PhraseCell(
                    new Phrase("No de Fojas: ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellseccion3.Colspan = 5;
                //cellnofojas.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellnofojas.BorderColor = Color.BLACK;
                tablenofojas.AddCell(cellnofojas);
                //-------------
                //cellnofojas =
                //PhraseCell(
                //    new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                //    Element.ALIGN_CENTER);
                ////cellseccion3.Colspan = 5;
                ////cellnofojas.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                ////cellnofojas.BorderColor = Color.BLACK;
                //tablenofojas.AddCell(cellnofojas);
                ////----------------------
                document.Add(tablenofojas);
                //------------------------------------------linea
                DrawLine(writer, 10, 990, 600, 990, Color.BLACK);
                //-----------------------------
                DrawLine(writer, 14, 14, 14, 930, Color.BLACK);
                DrawLine(writer, 600, 14, 600, 930, Color.BLACK);

                DrawLine(writer, 14, 930, 600, 930, Color.BLACK);
                DrawLine(writer, 14, 14, 600, 14, Color.BLACK);
                //--------
                document.Close();
                bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=InicioTramiteCC_Form03.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }

    #endregion

    #region partes

    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }

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

    #endregion
}