using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Web;
using wcfInicioTramite.Tramite.Logica;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;

public partial class InicioTramite_wfrmReportForm03 : System.Web.UI.Page
{
    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string tramite = Request.QueryString["tramite"];
        Reporte_form_03(tramite);
    }

    #endregion

    #region datos reporte

    DataTable datosPersonales(long idtramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtReporte = new DataTable();
        dtReporte = ObjTramite.ObtenerDatosReporte(iIdConexion, cOperacion, idtramite, "DatosPersonales", ref sMensajeError);
        return dtReporte;
    }

    DataTable docIndispensable(long idtramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtReporte = new DataTable();
        dtReporte = ObjTramite.ObtenerDatosReporte(iIdConexion, cOperacion, idtramite, "DatosDocumentos1", ref sMensajeError);
        return dtReporte;
    }

    DataTable docSector(long idtramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtReporte = new DataTable();
        dtReporte = ObjTramite.ObtenerDatosReporte(iIdConexion, cOperacion, idtramite, "DatosDocumentos2", ref sMensajeError);
        return dtReporte;
    }

    #endregion

    #region generacion

    void Reporte_form_03(string tramite)
    {
        byte[] bytes;
        DateTime Hoy = DateTime.Now;
        DataTable dt_persona = datosPersonales(Convert.ToInt64(tramite));
        if (dt_persona != null && dt_persona.Rows.Count > 0)
        {
            string NROTRAMITE = "", Matricula = "", NumeroDocumento = "", ComplementoSEGIP = "", PrimerNombre = "", SegundoNombre = "", PrimerApellido = "", SegundoApellido = "", FechaNacimiento = "", FechaFallecimiento = "", OficinaNotificacion = "";
            string EntidadGestora = "", CUA = "", EstadoCivil = "", Direccion = "", Telefono = "", TipoTramite = "", sector = "", FechaInicioTramite = "";
            string DocExpedicion, EntidadGestoraall, Sexoall, ApellidoCasada, NombreProvincia, NombreDepartamento, CuentaUsuario, Celular;
            string NUP, IdTipoTramite, NoFormularioCalculo, FechaNotificacion;
            NUP = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NUP"].ToString());
            NROTRAMITE = HttpUtility.HtmlDecode(dt_persona.Rows[0]["IdTramite"].ToString());
            Matricula = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Matricula"].ToString());
            NumeroDocumento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NumeroDocumento"].ToString());
            ComplementoSEGIP = HttpUtility.HtmlDecode(dt_persona.Rows[0]["ComplementoSEGIP"].ToString());
            PrimerNombre = HttpUtility.HtmlDecode(dt_persona.Rows[0]["PrimerNombre"].ToString());
            SegundoNombre = HttpUtility.HtmlDecode(dt_persona.Rows[0]["SegundoNombre"].ToString());
            PrimerApellido = HttpUtility.HtmlDecode(dt_persona.Rows[0]["PrimerApellido"].ToString());
            SegundoApellido = HttpUtility.HtmlDecode(dt_persona.Rows[0]["SegundoApellido"].ToString());
            FechaNacimiento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaNacimiento"].ToString());
            FechaFallecimiento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaFallecimiento"].ToString());

            OficinaNotificacion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["OficinaNotificacion"].ToString());
            EntidadGestora = HttpUtility.HtmlDecode(dt_persona.Rows[0]["EntidadGestora"].ToString());
            CUA = HttpUtility.HtmlDecode(dt_persona.Rows[0]["CUA"].ToString());
            EstadoCivil = HttpUtility.HtmlDecode(dt_persona.Rows[0]["EstadoCivil"].ToString());
            Direccion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Direccion"].ToString());
            Telefono = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Telefono"].ToString());
            Celular = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Celular"].ToString());
            TipoTramite = HttpUtility.HtmlDecode(dt_persona.Rows[0]["TipoTramite"].ToString());
            IdTipoTramite = HttpUtility.HtmlDecode(dt_persona.Rows[0]["IdTipoTramite"].ToString());
            sector = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Sector"].ToString());
            FechaInicioTramite = Convert.ToDateTime(HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaInicioTramite"].ToString())).ToString("dd MMMM, yyyy");
            DocExpedicion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["DocExpedicion"].ToString());
            EntidadGestoraall = HttpUtility.HtmlDecode(dt_persona.Rows[0]["EntidadGestoraall"].ToString());
            Sexoall = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Sexoall"].ToString());
            ApellidoCasada = HttpUtility.HtmlDecode(dt_persona.Rows[0]["ApellidoCasada"].ToString());

            NombreProvincia = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NombreProvincia"].ToString());
            NombreDepartamento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NombreDepartamento"].ToString());
            CuentaUsuario = HttpUtility.HtmlDecode(dt_persona.Rows[0]["CuentaUsuario"].ToString());

            NoFormularioCalculo = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NoFormularioCalculo"].ToString());
            FechaNotificacion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaNotificacion"].ToString());

            //------------------------
            DataTable dt_docIndis = docIndispensable(Convert.ToInt64(tramite));
            string documento;
            //---------------------------------------------------------
            DataTable dt_docSector = docSector(Convert.ToInt64(tramite));
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
                       new Phrase(CuentaUsuario, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_RIGHT);
                table.AddCell(cell);
                //-----------------
                cell = ImageCell("~/Imagenes/InicioTramite/icono_senasir.JPG", 30f, Element.ALIGN_CENTER);
                table.AddCell(cell);

                var phrase = new Phrase
                {
                    new Chunk("FORMULARIO DE RENUNCIA AL PROCEDIMIENTO AUTOMATICO UCC-IADR-03",
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
                //----------------------------
                var tableAFP = new PdfPTable(7) { TotalWidth = 570f, LockedWidth = true };
                tableAFP.WidthPercentage = 100;
                tableAFP.HorizontalAlignment = 0;
                PdfPCell cellAFP;
                cellAFP =
                    PhraseCell(
                        new Phrase(EntidadGestoraall, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_LEFT);
                cellAFP.Colspan = 4;
                cellAFP.BorderColor = Color.BLACK;
                tableAFP.AddCell(cellAFP);
                cellAFP =
                    PhraseCell(
                        new Phrase("CUA[ ] RFCC[ ]" + "No CUA: " + CUA + "     NUB:" + NUP, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellAFP.Colspan = 3;
                cellAFP.BorderColor = Color.BLACK;
                tableAFP.AddCell(cellAFP);
                document.Add(tableAFP);
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
                        new Phrase(ApellidoCasada, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
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
                        new Phrase("APELLIDO DE CASADA", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //---------------------------
                cellDP =
                   PhraseCell(
                       new Phrase("FECHA DE NACIMIENTO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);

                cellDP =
                   PhraseCell(
                       new Phrase("FECHA DE FALLECIMIENTO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
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
                       new Phrase("DOCUMENTO DE IDENTIDAD", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
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
                      new Phrase(NumeroDocumento + "" + ComplementoSEGIP + " " + DocExpedicion, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
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
                    new Phrase("SECCION 2 RENUNCIA AL PROCEDIMIENTO AUTOMATICO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                cellseccion2.Colspan = 5;
                cellseccion2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellseccion2.BorderColor = Color.BLACK;
                tableseccion2.AddCell(cellseccion2);
                document.Add(tableseccion2);

                //----------------------------
                var tablefecha = new PdfPTable(7) { TotalWidth = 570f, LockedWidth = true };
                tablefecha.WidthPercentage = 100;
                tablefecha.HorizontalAlignment = 0;
                PdfPCell cellNroFormCalculo;
                cellNroFormCalculo =
                    PhraseCell(
                        new Phrase("Nro. Formulario Calculo:"+NoFormularioCalculo, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_LEFT);
                cellNroFormCalculo.Colspan = 4;
                cellNroFormCalculo.BorderColor = Color.BLACK;
                tablefecha.AddCell(cellNroFormCalculo);
                cellNroFormCalculo =
                    PhraseCell(
                        new Phrase("Fecha Notificación:" + FechaNotificacion, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellNroFormCalculo.Colspan = 3;
                cellNroFormCalculo.BorderColor = Color.BLACK;
                tablefecha.AddCell(cellNroFormCalculo);
                document.Add(tablefecha);
                //----------------------------

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
                if (dt_docIndis!=null && dt_docIndis.Rows.Count > 0)
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