using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Web;
using wcfInicioTramite.Tramite.Logica;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;

public partial class InicioTramite_wfrmReport : System.Web.UI.Page
{
    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string tramite = Request.QueryString["tramite"];
        Generar_Reporte(tramite);
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

    DataTable datosDocumentos(long idtramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtReporte = new DataTable();
        dtReporte = ObjTramite.ObtenerDatosReporte(iIdConexion, cOperacion, idtramite, "DatosDocumentos", ref sMensajeError);
        return dtReporte;
    }

    #endregion

    #region generacion

    void Generar_Reporte(string tramite)
    {
        byte[] bytes;
        DataTable dt_persona = datosPersonales(Convert.ToInt64(tramite));
        if (dt_persona.Rows.Count > 0)
        {
            string NROTRAMITE = "";
            NROTRAMITE = HttpUtility.HtmlDecode(dt_persona.Rows[0]["IdTramite"].ToString());
            string Matricula = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Matricula"].ToString());
            string NumeroDocumento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["NumeroDocumento"].ToString());
            string ComplementoSEGIP = HttpUtility.HtmlDecode(dt_persona.Rows[0]["ComplementoSEGIP"].ToString());
            string PrimerNombre = HttpUtility.HtmlDecode(dt_persona.Rows[0]["PrimerNombre"].ToString());
            string SegundoNombre = HttpUtility.HtmlDecode(dt_persona.Rows[0]["SegundoNombre"].ToString());
            string PrimerApellido = HttpUtility.HtmlDecode(dt_persona.Rows[0]["PrimerApellido"].ToString());
            string SegundoApellido = HttpUtility.HtmlDecode(dt_persona.Rows[0]["SegundoApellido"].ToString());
            string FechaNacimiento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaNacimiento"].ToString());
            string FechaFallecimiento = HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaFallecimiento"].ToString());

            string OficinaNotificacion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["OficinaNotificacion"].ToString());
            string EntidadGestora = HttpUtility.HtmlDecode(dt_persona.Rows[0]["EntidadGestora"].ToString());
            string CUA = HttpUtility.HtmlDecode(dt_persona.Rows[0]["CUA"].ToString());
            string EstadoCivil = HttpUtility.HtmlDecode(dt_persona.Rows[0]["EstadoCivil"].ToString());
            string Direccion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Direccion"].ToString());
            string Telefono = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Telefono"].ToString());
            string TipoTramite = HttpUtility.HtmlDecode(dt_persona.Rows[0]["TipoTramite"].ToString());
            string sector = HttpUtility.HtmlDecode(dt_persona.Rows[0]["Sector"].ToString());
            string fechaafiliacion = HttpUtility.HtmlDecode((dt_persona.Rows[0]["FechaAfiliacion"]).ToString());
            string FechaInicioTramite = (HttpUtility.HtmlDecode(dt_persona.Rows[0]["FechaInicioTramite"].ToString()));
            string CuentaUsuario = HttpUtility.HtmlDecode(dt_persona.Rows[0]["CuentaUsuario"].ToString());
            string DocExpedicion = HttpUtility.HtmlDecode(dt_persona.Rows[0]["DocExpedicion"].ToString());

            string IdTipoTramite = HttpUtility.HtmlDecode(dt_persona.Rows[0]["IdTipoTramite"].ToString());
            string IdOrigen = HttpUtility.HtmlDecode(dt_persona.Rows[0]["IdOrigen"].ToString());

            //------------------------
            DataTable dt_salarios = datossalarioautomatico(Convert.ToInt64(tramite));
            string EstadoSalario = "";
            if (IdTipoTramite == "357")
            {
                EstadoSalario = HttpUtility.HtmlDecode(dt_salarios.Rows[0]["EstadoSalario"].ToString());
            }
            string
            IdTramite, IdGrupoBeneficio, NombreEmpresa, RUC, doc, MonedaDescripcion, PeriodoSalario,
            MesPeriodo, anioPeriodo, SalarioCotizable, IdSector, descripcionSector, correlativoabc;
            //------------------------
            DataTable dt_documentos = datosDocumentos(Convert.ToInt64(tramite));
            string
            documento;
            //---------------------------

            //---------------------------

            var document = new Document(PageSize.LETTER, 20, 20, 20, 20);
            FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
            using (var memoryStream = new System.IO.MemoryStream())
            {
                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                var table = new PdfPTable(5) { TotalWidth = 550f, LockedWidth = true };
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                PdfPCell cell;
                //-----------------
                cell = ImageCell("~/Imagenes/InicioTramite/ESCUDO_BOLIVIA.JPG", 17f, Element.ALIGN_LEFT);
                table.AddCell(cell);
                //-----------------
                cell = ImageCell("~/Imagenes/InicioTramite/icono_senasir.JPG", 25f, Element.ALIGN_LEFT);
                table.AddCell(cell);
                //-----------------
                var phrase = new Phrase
                {
                    new Chunk("INICIO TRAMITE \n COMPENSACION DE COTIZACIONES",
                        FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK))
                };

                cell = PhraseCell(phrase, Element.ALIGN_CENTER);
                cell.Colspan = 2;
                table.AddCell(cell);
                //-----------------
                cell =
                    PhraseCell(
                        new Phrase(("Fecha y Hora de Impresión: " + (DateTime.Now).ToString()), FontFactory.GetFont("Arial", 5, Font.NORMAL, Color.BLACK)),
                        Element.ALIGN_RIGHT);
                table.AddCell(cell);
                document.Add(table);
                //--------------------------------------tabla2
                var table2 = new PdfPTable(5) { TotalWidth = 550f, LockedWidth = true };
                table2.WidthPercentage = 100;
                table2.HorizontalAlignment = 0;
                PdfPCell cell2;
                //SECCION :1 DATOS DE INICIO DE TRAMITE
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;
                table2.AddCell(cell2);

                var phrase2 = new Phrase
                {
                    new Chunk("Sección 1: DATOS INICIO TRAMITE",
                        FontFactory.GetFont("Arial Black", 12, Font.UNDERLINE, Color.BLACK))
                };
                cell2 = PhraseCell(phrase2, Element.ALIGN_LEFT);
                cell2.Colspan = 5;
                table2.AddCell(cell2);
                //------------------
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;

                table2.AddCell(cell2);
                //----------
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(Matricula, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(NROTRAMITE, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(FechaInicioTramite, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(TipoTramite, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(fechaafiliacion, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                //-

                cell2 =
                    PhraseCell(
                        new Phrase("MATRICULA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("TRAMITE", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("INICIO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("TIPO TRAMITE", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("AFILIACION", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                //--------------columna2
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;
                table2.AddCell(cell2);

                cell2 =
                   PhraseCell(
                       new Phrase("Sección 2: DATOS PERSONALES", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                       Element.ALIGN_LEFT);
                cell2.Colspan = 5;
                table2.AddCell(cell2);
                cell2 =
                   PhraseCell(
                       new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                       Element.ALIGN_LEFT);
                cell2.Colspan = 5;
                table2.AddCell(cell2);

                cell2 =
                    PhraseCell(
                        new Phrase(EntidadGestora, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(CUA, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(PrimerApellido, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(SegundoApellido, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(PrimerNombre + " " + SegundoNombre, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);

                //------------------------------------------------           
                cell2 =
                    PhraseCell(
                        new Phrase("AFP", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("CUA", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("PATERNO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("MATERNO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("NOMBRES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                //-------
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;
                table2.AddCell(cell2);
                //--------------------
                cell2 =
                    PhraseCell(
                        new Phrase(FechaNacimiento, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(FechaFallecimiento, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(NumeroDocumento + " " + ComplementoSEGIP + " " + DocExpedicion, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(OficinaNotificacion, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(sector, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                //----------
                cell2 =
                    PhraseCell(
                        new Phrase("NACIMIENTO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("DEFUNCION", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("CI", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("REGIONAL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("SECTOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                //------------------------
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;
                table2.AddCell(cell2);
                //-----------------
                cell2 =
                   PhraseCell(
                       new Phrase(EstadoCivil, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                       Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(Direccion, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 3;
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(Telefono, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                //-----------
                cell2 =
                   PhraseCell(
                       new Phrase("ESTADO CIVIL", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                       Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("DIRECCION", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 3;
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase("TELEFONO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;
                table2.AddCell(cell2);
                cell2 =
                    PhraseCell(
                        new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                        Element.ALIGN_CENTER);
                cell2.Colspan = 5;
                table2.AddCell(cell2);
                //-------------------
                table2.AddCell(cell2);
                document.Add(table2);
                //---------
                var tableautomaticodes = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                tableautomaticodes.WidthPercentage = 100;
                tableautomaticodes.HorizontalAlignment = 0;
                PdfPCell cellautomaticodes;
                cellautomaticodes =
                PhraseCell(
                    new Phrase("Sección 3: DATOS DOCUMENTOS", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                    Element.ALIGN_LEFT);
                tableautomaticodes.AddCell(cellautomaticodes);
                document.Add(tableautomaticodes);
                document.Add(new Paragraph(" "));//--salto de linea
                //-----------
                var tableautomatico = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                tableautomatico.WidthPercentage = 100;
                tableautomatico.HorizontalAlignment = 0;
                PdfPCell cellautomatico;
                cellautomatico =
                PhraseCell(
                    new Phrase("Detalle Documentos Presentados", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                cellautomatico.BorderColor = Color.BLACK;
                tableautomatico.AddCell(cellautomatico);
                if (dt_documentos != null && dt_documentos.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_documentos.Rows)
                    {
                        documento = HttpUtility.HtmlDecode(dr["Descripcion"].ToString());
                        cellautomatico =
                        PhraseCell(
                            new Phrase(documento, FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);

                    }
                }
                document.Add(tableautomatico);
                document.Add(new Paragraph(" "));//--salto de linea
                //--
                if (IdOrigen != "342" || IdOrigen != "343")
                {
                    if (IdTipoTramite == "357")
                    {
                        tableautomaticodes = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                        tableautomaticodes.WidthPercentage = 100;
                        tableautomaticodes.HorizontalAlignment = 0;
                        cellautomaticodes =
                        PhraseCell(
                            new Phrase("Sección 4: DATOS SOBRE EL ÚLTIMO SALARIO COTIZADO AL SISTEMA DE REPARTO", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                            Element.ALIGN_LEFT);
                        tableautomaticodes.AddCell(cellautomaticodes);
                        document.Add(tableautomaticodes);
                        document.Add(new Paragraph(" "));//--salto de linea
                        //-----------
                        tableautomatico = new PdfPTable(8) { TotalWidth = 570f, LockedWidth = true };
                        tableautomatico.WidthPercentage = 100;
                        tableautomatico.HorizontalAlignment = 0;
                        cellautomatico =
                        PhraseCell(
                            new Phrase("Nombre o Razon Social del Empleador", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.Colspan = 3;
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                        cellautomatico =
                        PhraseCell(
                            new Phrase("MES", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                        cellautomatico =
                        PhraseCell(
                            new Phrase("AÑO", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);
                        cellautomatico =
                        PhraseCell(
                            new Phrase("Total Salario Cotizable", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);

                        cellautomatico =
                        PhraseCell(
                            new Phrase("Documento de Respaldo del Empleador", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)),
                            Element.ALIGN_CENTER);
                        cellautomatico.Colspan = 2;
                        cellautomatico.BorderColor = Color.BLACK;
                        tableautomatico.AddCell(cellautomatico);

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
                                    new Phrase(correlativoabc + " " + NombreEmpresa, FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                                    Element.ALIGN_LEFT);
                                cellautomatico.Colspan = 3;
                                cellautomatico.BorderColor = Color.BLACK;
                                tableautomatico.AddCell(cellautomatico);

                                cellautomatico =
                                PhraseCell(
                                    new Phrase(MesPeriodo, FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                                    Element.ALIGN_CENTER);
                                //cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                                cellautomatico.BorderColor = Color.BLACK;
                                tableautomatico.AddCell(cellautomatico);
                                cellautomatico =
                                PhraseCell(
                                    new Phrase(anioPeriodo, FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                                    Element.ALIGN_CENTER);
                                //cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                                cellautomatico.BorderColor = Color.BLACK;
                                tableautomatico.AddCell(cellautomatico);
                                cellautomatico =
                                PhraseCell(
                                    new Phrase(correlativoabc + " " + SalarioCotizable, FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                                    Element.ALIGN_LEFT);
                                cellautomatico.BorderColor = Color.BLACK;
                                //cellautomatico.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                                tableautomatico.AddCell(cellautomatico);

                                cellautomatico =
                                PhraseCell(
                                    new Phrase(doc, FontFactory.GetFont("Arial", 6, Font.BOLD, Color.BLACK)),
                                    Element.ALIGN_CENTER);
                                cellautomatico.Colspan = 2;
                                cellautomatico.BorderColor = Color.BLACK;
                                tableautomatico.AddCell(cellautomatico);
                                //sumasalario = sumasalario + Convert.ToDouble(SalarioCotizable);
                            }
                        }
                        tableautomatico.AddCell(cellautomatico);
                        document.Add(tableautomatico);
                        //---------------------------densidad negativa
                        if (EstadoSalario == "29")
                        {
                            document.Add(new Paragraph(" "));//--salto de linea
                            var tabledensidadneg = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                            //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                            tabledensidadneg.WidthPercentage = 100;
                            tabledensidadneg.HorizontalAlignment = 0;
                            PdfPCell celldensidadneg;
                            celldensidadneg =
                            PhraseCell(
                                new Phrase("Sección 5: Renuncia al Procedimiento Automatico por Densidad Negativa", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                                Element.ALIGN_LEFT);
                            //cellautomatico.Colspan = 3;
                            //cellautomaticodes.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            //cellautomacellautomaticodestico.BorderColor = Color.BLACK;
                            tabledensidadneg.AddCell(celldensidadneg);
                            document.Add(tabledensidadneg);
                            document.Add(new Paragraph(" "));//--salto de linea

                            var tabledensidadnegdes = new PdfPTable(1) { TotalWidth = 570f, LockedWidth = true };
                            //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                            tabledensidadnegdes.WidthPercentage = 100;
                            tabledensidadnegdes.HorizontalAlignment = 0;
                            PdfPCell celldensidadnegdes;
                            celldensidadnegdes =
                            PhraseCell(
                                new Phrase("Debido a la Densidad Negativa en la Base de Datos Institucional con los documentos que mi persona ha presentado, se ha evidenciado que de acuerdo con la fecha de afiliación registrada en su Base de Datos Institucional (Registro de Afiliación AVC Seguro de Corto Plazo) y los antecedentes que presento a través del cual menciona registrar mi actividad laboral a partir del 3-1985 y según el registro de afiliación se tiene 01-1994, es por este motivo que renuncio al Procedimiento Automático para proseguir mi tramite por Procedimiento Manual.", FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK)),
                                Element.ALIGN_JUSTIFIED);
                            //cellautomatico.Colspan = 3;
                            //cellautomaticodes.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldensidadnegdes.BorderColor = Color.BLACK;
                            tabledensidadnegdes.AddCell(celldensidadnegdes);
                            document.Add(tabledensidadnegdes);

                            var tabledensidadnegfirmas = new PdfPTable(4) { TotalWidth = 570f, LockedWidth = true };
                            //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                            tabledensidadnegfirmas.WidthPercentage = 100;
                            tabledensidadnegfirmas.HorizontalAlignment = 0;
                            PdfPCell celldensidadnegfirmas;
                            celldensidadnegfirmas =
                            PhraseCell(
                                new Phrase("\n\n\n\n-------------------------------------------------------\nNombre Completo", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                                Element.ALIGN_LEFT);
                            celldensidadnegfirmas.Colspan = 2;
                            //celldensidadnegfirmas.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldensidadnegfirmas.BorderColor = Color.BLACK;
                            tabledensidadnegfirmas.AddCell(celldensidadnegfirmas);
                            celldensidadnegfirmas =
                            PhraseCell(
                                new Phrase("\n\n\n\n--------------------------------------\nCarnet de Identidad", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                                Element.ALIGN_LEFT);
                            //celldensidadnegfirmas.Colspan = 2;
                            //celldensidadnegfirmas.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldensidadnegfirmas.BorderColor = Color.BLACK;
                            tabledensidadnegfirmas.AddCell(celldensidadnegfirmas);
                            celldensidadnegfirmas =
                            PhraseCell(
                                new Phrase("\n\n\n\n-------------------------------\nFirma", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, Color.BLACK)),
                                Element.ALIGN_LEFT);
                            //celldensidadnegfirmas.Colspan = 2;
                            //celldensidadnegfirmas.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            celldensidadnegfirmas.BorderColor = Color.BLACK;
                            tabledensidadnegfirmas.AddCell(celldensidadnegfirmas);
                            document.Add(tabledensidadnegfirmas);
                            document.Add(new Paragraph(" "));//--salto de linea
                        }
                        //-----------------------------
                    }
                }
                document.Add(new Paragraph(" "));//--salto de linea
                //------------------------------------------
                var tablefirmas = new PdfPTable(2) { TotalWidth = 570f, LockedWidth = true };
                //table.SetWidths(new[] { 0.1f, 0.1f, 0.1f, 0.1f });
                tablefirmas.WidthPercentage = 100;
                tablefirmas.HorizontalAlignment = 0;
                PdfPCell cellfirmas;
                cellfirmas =
                PhraseCell(
                    new Phrase("Expreso mi conformidad con los datos presentados :\n\n\n\n\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)),
                    Element.ALIGN_LEFT);
                cellfirmas.Colspan = 2;
                //cellautomaticodes.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellautomacellautomaticodestico.BorderColor = Color.BLACK;
                tablefirmas.AddCell(cellfirmas);

                cellfirmas =
                PhraseCell(
                    new Phrase("--------------------------------------------------------\n" + PrimerNombre + " " + SegundoNombre + " " + PrimerApellido + " " + SegundoApellido + " - " + NumeroDocumento + " " + ComplementoSEGIP + " " + DocExpedicion + "\nTITULAR", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellfirmas.Colspan = 2;
                //cellautomaticodes.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellautomacellautomaticodestico.BorderColor = Color.BLACK;
                tablefirmas.AddCell(cellfirmas);
                cellfirmas =
                PhraseCell(
                    new Phrase("------------------------------------------------------------\n" + CuentaUsuario + "\n SERVIDOR PUBLICO SENASIR", FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK)),
                    Element.ALIGN_CENTER);
                //cellfirmas.Colspan = 2;
                //cellautomaticodes.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                //cellautomacellautomaticodestico.BorderColor = Color.BLACK;
                tablefirmas.AddCell(cellfirmas);
                document.Add(tablefirmas);
                document.Add(new Paragraph(" "));//--salto de linea
                //------------------------------------------linea
                //DrawLine(writer, 18, 80, 18, 690, Color.BLACK)
                DrawLine(writer, 18, 480, 18, 705, Color.BLACK);
                DrawLine(writer, 590, 480, 590, 705, Color.BLACK);

                DrawLine(writer, 18, 705, 590, 705, Color.BLACK);
                DrawLine(writer, 18, 480, 590, 480, Color.BLACK);
                //--------
                document.Close();
                bytes = memoryStream.ToArray();
                memoryStream.Close();
            }
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=InicioTramiteCC.pdf");
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
            PaddingTop = 0f
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