using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Web;
using wcfInicioTramite.Tramite.Logica;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;

public partial class InicioTramite_wfrmReportForm02 : System.Web.UI.Page
{
    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string tramite = Request.QueryString["tramite"];
        Reporte_form_02(tramite);
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

    DataTable datossalarioautomatico(long idtramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtReporte = new DataTable();
        dtReporte = ObjTramite.ObtenerDatosReporte(iIdConexion, cOperacion, idtramite, "DatoSalarioAutomatico", ref sMensajeError);
        return dtReporte;
    }

    DataTable datosempresa(long idtramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtReporte = new DataTable();
        dtReporte = ObjTramite.ObtenerDatosReporte(iIdConexion, cOperacion, idtramite, "DatoEmpresaRegistro", ref sMensajeError);
        return dtReporte;
    }

    #endregion

    #region generacion

    void Reporte_form_02(string tramite)
    {
        byte[] bytes;
        DateTime Hoy = DateTime.Now;
        DataTable dt_persona = datosPersonales(Convert.ToInt64(tramite));
        if (dt_persona!=null && dt_persona.Rows.Count > 0)
        {
            string NROTRAMITE = "", Matricula = "", NumeroDocumento = "", ComplementoSEGIP = "", PrimerNombre = "", SegundoNombre = "", PrimerApellido = "", SegundoApellido = "", FechaNacimiento = "", FechaFallecimiento = "", OficinaNotificacion = "";
            string EntidadGestora = "", CUA = "", EstadoCivil = "", Direccion = "", Telefono = "", TipoTramite = "", sector = "", FechaInicioTramite = "";
            string DocExpedicion, EntidadGestoraall, Sexoall, ApellidoCasada, NombreProvincia, NombreDepartamento, CuentaUsuario, Celular;
            string correlativoabc, NUP, IdTipoTramite;
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


            //------------------------
            DataTable dt_salarios = datossalarioautomatico(Convert.ToInt64(tramite));
            string
            IdTramite, IdGrupoBeneficio, NombreEmpresa, RUC, doc, MonedaDescripcion, PeriodoSalario,
            MesPeriodo, anioPeriodo, SalarioCotizable, IdSector, descripcionSector;

            //---------------------------------------------------------
            DataTable dt_Empresas = datosempresa(Convert.ToInt64(tramite));
            string NombreEmpresaE, RUCE, docE, monedaEmpE, PeriodoInicioE, DiaPeriodoInicialE, MesPeriodoInicialE, AnioPeriodoInicialE, MontoE, DiaPeriodoFinE, MesPeriodoFinE, AnioPeriodoFinE, descripcionSectorE, NroPatronalRucAltE, NombreEmpresaDeclaradaE;
            //-------------------------
            var document = new Document(PageSize.LEGAL, 20, 20, 20, 20);
            FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
            using (var memoryStream = new System.IO.MemoryStream())
            {
                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                var table = new PdfPTable(4) { TotalWidth = 550f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                table.WidthPercentage = 100;
                //table.HorizontalAlignment = 0;

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
                    new Chunk("FORMULARIO DE INICIO DE TRAMITE PROCEDIMIENTO AUTOMATICO Y MANUAL UCC-IAM-02",
                        FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))
                };
                //cell.Colspan = 2;
                //cell.BorderWidthLeft = 1f;
                //cell.BorderWidthRight = 1f;
                //cell.BorderWidthTop = 1f;
                //cell.BorderWidthBottom = 1f;
                //cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;

                cell = PhraseCell(phrase, Element.ALIGN_CENTER);
                cell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cell.BorderColor = Color.BLACK;
                //cell.VerticalAlignment = Element.ALIGN_TOP;
                table.AddCell(cell);

                //-----------------
                cell =
                    PhraseCell(
                        new Phrase(("MATRICULA: " + Matricula + "\n Nro Tramite: " + NROTRAMITE + "\n Procedimiento: " + TipoTramite), FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
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
                        new Phrase("SECCION 1 DATOS PERSONALES DEL (A) ASEGURADO (A)", FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_LEFT);
                //cell2.Colspan = 5;
                cell2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cell2.BorderColor = Color.BLACK;
                table2.AddCell(cell2);
                document.Add(table2);
                document.Add(new Paragraph(" "));
                //----------------------------
                var tableAFP = new PdfPTable(7) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableAFP.WidthPercentage = 100;
                tableAFP.HorizontalAlignment = 0;
                PdfPCell cellAFP;
                //SECCION :1 DATOS DE INICIO DE TRAMITE
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
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
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
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase(SegundoNombre, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                    PhraseCell(
                        new Phrase(ApellidoCasada, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
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
                //cellDP =
                // PhraseCell(
                //     new Phrase("DIA MES AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //     Element.ALIGN_CENTER);
                ////cellDP.Colspan = 2;
                //tableDP.AddCell(cellDP);
                //cellDP =
                // PhraseCell(
                //     new Phrase("DIA MES AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //     Element.ALIGN_CENTER);
                ////cellDP.Colspan = 2;
                //tableDP.AddCell(cellDP);
                //cellDP =
                // PhraseCell(
                //     new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //     Element.ALIGN_CENTER);
                ////cellDP.Colspan = 2;
                //tableDP.AddCell(cellDP);
                //cellDP =
                // PhraseCell(
                //     new Phrase("NUMERO EXP", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //     Element.ALIGN_CENTER);
                //cellDP.Colspan = 2;
                //tableDP.AddCell(cellDP);
                //cellDP =
                // PhraseCell(
                //     new Phrase("ESTADO CIVIL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //     Element.ALIGN_CENTER);
                ////cellDP.Colspan = 2;
                //tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                    new Phrase("DOMICILIO ACTUAL DEL AFILIADO", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellDP.Colspan = 6;
                cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //-------------------------------------
                cellDP =
                PhraseCell(
                    new Phrase(NombreDepartamento, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                    new Phrase(NombreProvincia, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                    new Phrase(Direccion, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //cellDP =
                //PhraseCell(
                //    new Phrase(Direccion, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                //    Element.ALIGN_CENTER);
                ////cellDP.Colspan = 6;
                ////cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellDP.BorderColor = Color.BLACK;
                //tableDP.AddCell(cellDP);
                //cellDP =
                //PhraseCell(
                //    new Phrase(Direccion, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                //    Element.ALIGN_CENTER);
                //cellDP.Colspan = 3;
                ////cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellDP.BorderColor = Color.BLACK;
                //tableDP.AddCell(cellDP);
                if (Celular != "")
                {
                    if (Telefono != "")
                    {
                        Celular = "-" + Celular;
                    }

                }
                cellDP =
                PhraseCell(
                    new Phrase(Telefono + "" + Celular, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                   new Phrase(OficinaNotificacion, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //--------------------------
                cellDP =
                PhraseCell(
                    new Phrase("DEPARTAMENTO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                    new Phrase("PROVINCIA/REGIONAL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //cellDP =
                //PhraseCell(
                //    new Phrase("ZONA/BARRIO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //    Element.ALIGN_CENTER);
                ////cellDP.Colspan = 6;
                ////cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellDP.BorderColor = Color.BLACK;
                //tableDP.AddCell(cellDP);
                //cellDP =
                //PhraseCell(
                //    new Phrase("AV./CALLE", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                //    Element.ALIGN_CENTER);
                ////cellDP.Colspan = 6;
                ////cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellDP.BorderColor = Color.BLACK;
                //tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                    new Phrase("DOMICILIO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellDP.Colspan = 2;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                cellDP =
                PhraseCell(
                    new Phrase("TELF./CEL.", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //-------------

                cellDP =
                PhraseCell(
                    new Phrase("OFICINA NOTIFICACION", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellDP.Colspan = 6;
                //cellDP.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellDP.BorderColor = Color.BLACK;
                tableDP.AddCell(cellDP);
                //-------------
                document.Add(tableDP);
                //--------------------
                document.Add(new Paragraph(" "));//--salto de linea
                //-----------------------------------------------
                var tableseccion2 = new PdfPTable(5) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableseccion2.WidthPercentage = 100;
                tableseccion2.HorizontalAlignment = 0;
                PdfPCell cellseccion2;
                cellseccion2 =
                PhraseCell(
                    new Phrase("SECCION 2 INFORMACION DEL ULTIMO SALARIO COTIZABLE AL SISTEMA DE REPARTO-PROCEDIMIENTO AUTOMATICO", FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                cellseccion2.Colspan = 5;
                cellseccion2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellseccion2.BorderColor = Color.BLACK;
                tableseccion2.AddCell(cellseccion2);
                document.Add(tableseccion2);
                document.Add(new Paragraph(" "));
                var tableautomatico = new PdfPTable(8) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableautomatico.WidthPercentage = 100;
                tableautomatico.HorizontalAlignment = 0;
                PdfPCell cellautomatico;
                cellautomatico =
                PhraseCell(
                    new Phrase("NOMBRE O RAZON SOCIAL DEL EMPLEADOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 3;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("ULTIMO SALARIOCOTIZABLE AL SISTEMA DE REPARTO O SISTEMA ANTIGUO DE PENSIONES(OCTUBRE 1996, SI NO TRABAJO A LA INMEDIATA ANTERIOR) EN CASO DE HABER PERCIBIDO OTROS SALARIOS EN EL MISMO PERIODO REGISTRAR EN LOS MISMOS B) Y C)", FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 3;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("DOCUMENTO DE RESPALDO DEL EMPLEADOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 2;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                //--------------------------------------------
                cellautomatico =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 3;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);

                cellautomatico =
                PhraseCell(
                    new Phrase("MES", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellautomatico.Colspan = 3;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("AÑO", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellautomatico.Colspan = 3;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("total salario Cotizable", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                //cellautomatico.Colspan = 3;
                tableautomatico.AddCell(cellautomatico);

                cellautomatico =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 2;
                cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                //--------------------------------------------
                //IdTramite, IdGrupoBeneficio, NombreEmpresa, RUC, doc, MonedaDescripcion, PeriodoSalario,
                //MesPeriodo, anioPeriodo, SalarioCotizable, IdSector, descripcionSector;
                //----------------------------------------parametros salario automatico
                double sumasalario = 0;
                //------------------------
                if (dt_salarios.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt_salarios.Rows)
                    {
                        IdTramite = dr["IdTramite"].ToString();
                        IdGrupoBeneficio = dr["IdGrupoBeneficio"].ToString();
                        NombreEmpresa = HttpUtility.HtmlDecode(dr["NombreEmpresa"].ToString());
                        RUC = HttpUtility.HtmlDecode(dr["RUC"].ToString());
                        doc = HttpUtility.HtmlDecode(dr["doc"].ToString());
                        MonedaDescripcion = HttpUtility.HtmlDecode(dr["MonedaDescripcion"].ToString());
                        PeriodoSalario = HttpUtility.HtmlDecode(dr["PeriodoSalario"].ToString());
                        MesPeriodo = HttpUtility.HtmlDecode(dr["MesPeriodo"].ToString());
                        anioPeriodo = HttpUtility.HtmlDecode(dr["anioPeriodo"].ToString());
                        SalarioCotizable = HttpUtility.HtmlDecode(dr["SalarioCotizable"].ToString());
                        IdSector = HttpUtility.HtmlDecode(dr["IdSector"].ToString());
                        descripcionSector = HttpUtility.HtmlDecode(dr["descripcionSector"].ToString());
                        correlativoabc = HttpUtility.HtmlDecode(dr["correlativoabc"].ToString());
                        cellautomatico =
                        PhraseCell(
                            new Phrase(correlativoabc + " " + NombreEmpresa, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        cellautomatico.Colspan = 3;
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);

                        cellautomatico =
                        PhraseCell(
                            new Phrase(MesPeriodo, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                        cellautomatico =
                        PhraseCell(
                            new Phrase(anioPeriodo, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                        cellautomatico =
                        PhraseCell(
                            new Phrase(correlativoabc + " " + Convert.ToString(Convert.ToDouble(SalarioCotizable)), FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        cellautomatico.BorderColor = Color.BLACK;
                        cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                        tableautomatico.AddCell(cellautomatico);

                        cellautomatico =
                        PhraseCell(
                            new Phrase(doc, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.Colspan = 2;
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                        sumasalario = sumasalario + Convert.ToDouble(SalarioCotizable);
                    }
                }
                else
                {
                    cellautomatico =
                        PhraseCell(
                            new Phrase("a)", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_LEFT);
                    cellautomatico.Colspan = 3;
                    cellautomatico.BorderColor = Color.BLACK;
                    tableautomatico.AddCell(cellautomatico);

                    cellautomatico =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    cellautomatico.BorderColor = Color.BLACK;
                    tableautomatico.AddCell(cellautomatico);
                    cellautomatico =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    cellautomatico.BorderColor = Color.BLACK;
                    tableautomatico.AddCell(cellautomatico);
                    cellautomatico =
                    PhraseCell(
                        new Phrase("a)", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_LEFT);
                    cellautomatico.BorderColor = Color.BLACK;
                    cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    tableautomatico.AddCell(cellautomatico);

                    cellautomatico =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    cellautomatico.Colspan = 2;
                    cellautomatico.BorderColor = Color.BLACK;
                    tableautomatico.AddCell(cellautomatico);

                }
                //--------------------------------------

                //-------------------------------------------------
                cellautomatico =
                PhraseCell(
                    new Phrase("SUMA DEL O DE LOS SALARIOS COTIZABLES DECLARADOS", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_RIGHT);
                cellautomatico.Colspan = 5;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("Bs: " + Convert.ToString(sumasalario), FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellautomatico.Colspan = 3;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                cellautomatico =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.Colspan = 2;
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                /*cellautomatico =
                PhraseCell(
                    new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
               // cellautomatico.Rowspan = 3;
                tableautomatico.AddCell(cellautomatico);*/
                document.Add(tableautomatico);
                document.Add(new Paragraph(" "));//--salto de linea
                //---------------seccion3
                var tableseccion3 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableseccion3.WidthPercentage = 100;
                tableseccion3.HorizontalAlignment = 0;
                PdfPCell cellseccion3;
                cellseccion3 =
                PhraseCell(
                    new Phrase("SECCION 3 DETALLE DE EMPRESAS EN LAS QUE PRESTO SERVICIOS EL ASEGURADO (PRIVADAS Y PUBLICAS), PROCEDIMIENTO MANUAL", FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                //cellseccion3.Colspan = 5;
                cellseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellseccion3.BorderColor = Color.BLACK;
                tableseccion3.AddCell(cellseccion3);
                document.Add(tableseccion3);
                document.Add(new Paragraph(" "));//--salto de linea
                //------------------
                var tabledatosseccion3 = new PdfPTable(10) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tabledatosseccion3.WidthPercentage = 100;
                tabledatosseccion3.HorizontalAlignment = 0;
                PdfPCell celldatosseccion3;
                celldatosseccion3 =
                PhraseCell(
                   new Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion3.Colspan = 4;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                   new Phrase("FECHA DE INGRESO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion3.Colspan = 3;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                   new Phrase("FECHA DE RETIRO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion3.Colspan = 3;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);
                //-------------------
                celldatosseccion3 =
                PhraseCell(
                    new Phrase("RAZON SOCIAL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("SECTOR O ENTE GESTOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("DIA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("MES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("DIA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("MES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);

                celldatosseccion3 =
                PhraseCell(
                    new Phrase("AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion3.AddCell(celldatosseccion3);
                //----------------------------------------
                //    string IdTramite, idGrupoBeneficio, NombreEmpresa, RUC, IdEmpresa, doc, monedaEmp, PeriodoInicio, DiaPeriodoInicial, MesPeriodoInicial, AnioPeriodoInicial, Monto
                //, DiaPeriodoFin, MesPeriodoFin, AnioPeriodoFin, IdSector, descripcionSector
                //, NroPatronalRucAlt, NombreEmpresaDeclarada;
                //int swempresa = 0;
                //foreach (DataRow rowe in dt_Empresas.Rows)
                //{
                //    if (HttpUtility.HtmlDecode(rowe["NroPatronalRucAlt"].ToString()).Trim() == "")
                //    {
                //        swempresa++;
                //    }
                //}
                if (IdTipoTramite == "356")//manual
                {

                    foreach (DataRow rowe in dt_Empresas.Rows)
                    {
                        NombreEmpresaE = rowe["NombreEmpresa"].ToString();
                        RUCE = rowe["RUC"].ToString();
                        docE = rowe["doc"].ToString();
                        monedaEmpE = rowe["monedaEmp"].ToString();
                        PeriodoInicioE = rowe["PeriodoInicio"].ToString();
                        DiaPeriodoInicialE = rowe["DiaPeriodoInicial"].ToString();
                        MesPeriodoInicialE = rowe["MesPeriodoInicial"].ToString();
                        AnioPeriodoInicialE = rowe["AnioPeriodoInicial"].ToString();
                        MontoE = rowe["Monto"].ToString();
                        DiaPeriodoFinE = rowe["DiaPeriodoFin"].ToString();
                        MesPeriodoFinE = rowe["MesPeriodoFin"].ToString();
                        AnioPeriodoFinE = rowe["AnioPeriodoFin"].ToString();
                        descripcionSectorE = rowe["descripcionSector"].ToString();
                        NroPatronalRucAltE = rowe["NroPatronalRucAlt"].ToString();
                        if (HttpUtility.HtmlDecode(rowe["NroPatronalRucAlt"].ToString()).Trim() == "")
                        {
                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(NombreEmpresaE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(descripcionSectorE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(DiaPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(MesPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(AnioPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(DiaPeriodoFinE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(MesPeriodoFinE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);

                            celldatosseccion3 =
                            PhraseCell(
                                new Phrase(AnioPeriodoFinE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion3.BorderColor = Color.BLACK;
                            tabledatosseccion3.AddCell(celldatosseccion3);
                        }
                    }
                }
                else
                {
                    celldatosseccion3 =
                        PhraseCell(
                            new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                    celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);

                    celldatosseccion3 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion3.BorderColor = Color.BLACK;
                    tabledatosseccion3.AddCell(celldatosseccion3);
                }
                //-------------------------------------
                document.Add(tabledatosseccion3);
                //-------------------------------
                document.Add(new Paragraph(" "));//--salto de linea
                //---------------seccion4
                var tableseccion4 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableseccion4.WidthPercentage = 100;
                tableseccion4.HorizontalAlignment = 0;
                PdfPCell cellseccion4;
                cellseccion4 =
                PhraseCell(
                    new Phrase("SECCION 4 DECLARACION DE REGISTRO LABORAL DE EMPRESAS PRIVADAS", FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_LEFT);
                //cellseccion3.Colspan = 5;
                cellseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                cellseccion4.BorderColor = Color.BLACK;
                tableseccion4.AddCell(cellseccion4);
                document.Add(tableseccion4);
                document.Add(new Paragraph(" "));//--salto de linea
                //-----------------------------
                var tableSEC4DESCRIPCION = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableSEC4DESCRIPCION.WidthPercentage = 100;
                tableSEC4DESCRIPCION.HorizontalAlignment = 0;
                PdfPCell cellSEC4DESCRIPCION;
                cellSEC4DESCRIPCION =
                PhraseCell(
                    new Phrase("Yo .............................................con C.I. ......................, al no poder presentar la documentacion laboral requerida para el iniciode mi Tramite de Compensación de Cotizaciones, declaro haber trabajado y aportado en la siguientes empresas e instituciones privadas:", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)),
                    Element.ALIGN_LEFT);
                //cellseccion3.Colspan = 5;
                //cellSEC4DESCRIPCION.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC4DESCRIPCION.BorderColor = Color.BLACK;
                tableSEC4DESCRIPCION.AddCell(cellSEC4DESCRIPCION);
                document.Add(tableSEC4DESCRIPCION);
                document.Add(new Paragraph(" "));//--salto de linea
                //--------------------------------------
                var tabledatosseccion4 = new PdfPTable(12) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tabledatosseccion4.WidthPercentage = 100;
                tabledatosseccion4.HorizontalAlignment = 0;
                PdfPCell celldatosseccion4;
                celldatosseccion4 =
                PhraseCell(
                   new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 4;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //celldatosseccion3.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                   new Phrase("FECHA DE INGRESO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 3;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                   new Phrase("FECHA DE RETIRO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 3;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);
                celldatosseccion4 =
                PhraseCell(
                   new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 2;
                //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("RAZON SOCIAL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("SECTOR O ENTE GESTOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("DIA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("MES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("DIA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("MES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
                PhraseCell(
                    new Phrase("AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //celldatosseccion3.Colspan = 2;
                //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);

                celldatosseccion4 =
               PhraseCell(
                   new Phrase("No PATRONAL O RUC", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                   Element.ALIGN_CENTER);
                celldatosseccion4.Colspan = 2;
                //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                celldatosseccion4.BorderColor = Color.BLACK;
                tabledatosseccion4.AddCell(celldatosseccion4);
                //--------------------------------
                if (IdTipoTramite == "356")//manual
                {

                    foreach (DataRow rowe in dt_Empresas.Rows)
                    {
                        NombreEmpresaE = rowe["NombreEmpresa"].ToString();
                        RUCE = rowe["RUC"].ToString();
                        docE = rowe["doc"].ToString();
                        monedaEmpE = rowe["monedaEmp"].ToString();
                        PeriodoInicioE = rowe["PeriodoInicio"].ToString();
                        DiaPeriodoInicialE = rowe["DiaPeriodoInicial"].ToString();
                        MesPeriodoInicialE = rowe["MesPeriodoInicial"].ToString();
                        AnioPeriodoInicialE = rowe["AnioPeriodoInicial"].ToString();
                        MontoE = rowe["Monto"].ToString();
                        DiaPeriodoFinE = rowe["DiaPeriodoFin"].ToString();
                        MesPeriodoFinE = rowe["MesPeriodoFin"].ToString();
                        AnioPeriodoFinE = rowe["AnioPeriodoFin"].ToString();
                        descripcionSectorE = rowe["descripcionSector"].ToString();
                        NroPatronalRucAltE = rowe["NroPatronalRucAlt"].ToString();
                        NombreEmpresaDeclaradaE = rowe["NombreEmpresaDeclarada"].ToString();
                        descripcionSectorE = rowe["descripcionSector"].ToString();
                        if (HttpUtility.HtmlDecode(rowe["NroPatronalRucAlt"].ToString()).Trim() != "")
                        {
                            celldatosseccion4 =
                            PhraseCell(
                            new Phrase(NombreEmpresaDeclaradaE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                            celldatosseccion4.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(descripcionSectorE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            celldatosseccion4.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(DiaPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(MesPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(AnioPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(DiaPeriodoFinE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(MesPeriodoFinE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                            PhraseCell(
                                new Phrase(AnioPeriodoInicialE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                                Element.ALIGN_CENTER);
                            //celldatosseccion3.Colspan = 2;
                            //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);

                            celldatosseccion4 =
                           PhraseCell(
                               new Phrase(NroPatronalRucAltE, FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                               Element.ALIGN_CENTER);
                            celldatosseccion4.Colspan = 2;
                            //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldatosseccion4.BorderColor = Color.BLACK;
                            tabledatosseccion4.AddCell(celldatosseccion4);
                        }

                    }
                }
                else
                {
                    celldatosseccion4 =
                        PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    celldatosseccion4.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    celldatosseccion4.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion3.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                    PhraseCell(
                        new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                    //celldatosseccion3.Colspan = 2;
                    //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);

                    celldatosseccion4 =
                   PhraseCell(
                       new Phrase("", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                    celldatosseccion4.Colspan = 2;
                    //celldatosseccion4.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    celldatosseccion4.BorderColor = Color.BLACK;
                    tabledatosseccion4.AddCell(celldatosseccion4);
                }
                //-------------------
                document.Add(tabledatosseccion4);
                document.Add(new Paragraph(" "));//--salto de linea
                //----------------------------------------
                var tableSEC4DESCRIPCION2 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableSEC4DESCRIPCION2.WidthPercentage = 100;
                tableSEC4DESCRIPCION2.HorizontalAlignment = 0;
                PdfPCell cellSEC4DESCRIPCION2;
                cellSEC4DESCRIPCION2 =
                PhraseCell(
                    new Phrase("Por lo que solicito al SENASIR, efectuar la respectiva búsqueda en sus archivos y en caso de encontrar las planillas de la Empresas y/o Instituciones citadas, se me certifique los periodos señalados.", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)),
                    Element.ALIGN_JUSTIFIED);
                //cellseccion3.Colspan = 5;
                //cellSEC4DESCRIPCION2.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellSEC4DESCRIPCION2.BorderColor = Color.BLACK;
                tableSEC4DESCRIPCION2.AddCell(cellSEC4DESCRIPCION2);
                cellSEC4DESCRIPCION2 =
                PhraseCell(
                    new Phrase("Este Documento, NO constituye base para el reconocimiento de aportes(En calidad de documentación Supletoria), en caso de que el SENASIR no cuente con documentación.", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)),
                    Element.ALIGN_JUSTIFIED);

                tableSEC4DESCRIPCION2.AddCell(cellSEC4DESCRIPCION2);
                document.Add(tableSEC4DESCRIPCION2);
                document.Add(new Paragraph(" "));//--salto de linea
                //----------------------------------------------seccion 5
                var tableSEC5 = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tableSEC5.WidthPercentage = 100;
                tableSEC5.HorizontalAlignment = 0;

                PdfPCell cellSEC5;
                cellSEC5 =
                PhraseCell(
                    new Phrase("SECCION 5 CONSTANCIA DE VERASIDAD DE LA DOCUMENTACION PRESENTADA Y RECIBIDA", FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK)),
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
            Response.AddHeader("Content-Disposition", "attachment; filename=InicioTramiteCC_Form02.pdf");
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