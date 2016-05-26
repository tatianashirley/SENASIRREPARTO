using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using wcfSeguridad.Logica;
using wcfNotificacion.Logica;
using Microsoft.Reporting.WebForms;
using Color = iTextSharp.text.Color;
using Font = iTextSharp.text.Font;
using System.Security.Principal;
using System.Net;
using System.Configuration;

public partial class Notificaciones_wfrmCodigos : System.Web.UI.Page
{
    #region inicio
    //string Tramite, GrupoB, Fecha, NroDoc, IdDoc;

    Warning[] warnings;
    string[] streamids;
    string mimeType;
    string encoding;
    string extension;
    string deviceInfo;
    byte[] bytes;
    clsSeguridad ObjSeguridad = new clsSeguridad();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Int64 Tramite = Convert.ToInt64(Request.QueryString["IdTramite"]);
            Int32 GrupoB = Convert.ToInt32(Request.QueryString["IdGrupo"]);
            string Fecha = Request.QueryString["Fecha"];
            Int32 NroDoc = Convert.ToInt32(Request.QueryString["NoDoc"]);
            Int32 IdDoc = Convert.ToInt32(Request.QueryString["IdDoc"]);

        //    string UsrRep;
        //    string PassUsrRep;
        //    string DomRep;
        //    string ServRep;
        //    string ServApl;

        //    ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

        //    try
        //    {
        //        ReportParameter[] repParams = new ReportParameter[5];
        //        repParams[0] = new ReportParameter("i_iIdTramite", Tramite);
        //        repParams[1] = new ReportParameter("i_iIdGrupoBeneficio", GrupoB);
        //        repParams[2] = new ReportParameter("FechaIni", Fecha);
        //        repParams[3] = new ReportParameter("i_iNroDocumento", NroDoc);
        //        repParams[4] = new ReportParameter("i_iIdDocumento", IdDoc);

        //        rptCodigos.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        //        //rptCertificacionSalarios.ServerReport.ReportServerCredentials = new CustomReportCredentials("VLOPEZ", "123456Vl16", "SENASIR");
        //        rptCodigos.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
        //        //rptCertificacionSalarios.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");                
        //        rptCodigos.ServerReport.ReportServerUrl = new Uri(ServRep);
        //        rptCodigos.ServerReport.ReportPath = "/CertificacionCC/rptReporteCertificacionSalarios";
        //        rptCodigos.ServerReport.SetParameters(repParams);
        //        rptCodigos.ServerReport.Refresh();
        //        extension = "pdf";
        //        deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
        //        bytes = rptCodigos.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
        //        Response.Buffer = true;
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("charset", "UTF-8");
        //        Response.AddHeader("Content-Disposition", "attachment; filename=" + "Codificacion.pdf");
        //        Response.BinaryWrite(bytes);
        //        Response.Flush();
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
            Reporte_form_02(Tramite, GrupoB, Fecha, NroDoc, IdDoc);
        }
    }

    #endregion

    #region Credenciales
    //public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    //{

    //    // local variable for network credential.
    //    private string _UserName;
    //    private string _PassWord;
    //    private string _DomainName;
    //    private WindowsIdentity _ImpersonationUser;
    //    public CustomReportCredentials(string UserName, string PassWord, string DomainName)
    //    {
    //        _UserName = UserName;
    //        _PassWord = PassWord;
    //        _DomainName = DomainName;
    //        // _ImpersonationUser = ImpersonationUser;
    //    }
    //    public WindowsIdentity ImpersonationUser
    //    {
    //        get
    //        {
    //            return null; // not use ImpersonationUser
    //        }
    //    }
    //    public ICredentials NetworkCredentials
    //    {
    //        get
    //        {

    //            // use NetworkCredentials
    //            return new NetworkCredential(_UserName, _PassWord, _DomainName);
    //        }
    //    }
    //    public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
    //    {

    //        // not use FormsCredentials unless you have implements a custom autentication.
    //        authCookie = null;
    //        user = password = authority = null;
    //        return false;
    //    }

    //}
    #endregion

    #region datos reporte
    DataTable DatosReporte(Int64 IdTramite, Int32 GrupoB, string Fecha, Int32 NroDoc, Int32 IdDoc) //Obtiene
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "F";

        clsNotificaciones Codigos = new clsNotificaciones();
        DataTable datos = new DataTable();
        datos = Codigos.ObtieneDatosCodigos(iIdConexion, cOperacion, IdTramite, GrupoB, Fecha, NroDoc, IdDoc, ref sMensajeError);
        return datos;
    }

    #endregion

    #region generacion

    void Reporte_form_02(Int64 IdTramite, Int32 GrupoB, string Fecha, Int32 NroDoc, Int32 IdDoc)
    {
        byte[] bytes;
        DataTable Codigos = DatosReporte(IdTramite, GrupoB, Fecha, NroDoc, IdDoc);
        //Inicio de Documento
        var document = new Document(PageSize.LETTER, 10, 10, 10, 10);
        document.SetMargins(10, 10, 30, 10);
        document.SetPageSize(iTextSharp.text.PageSize.LETTER);
        FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
        using (var memoryStream = new System.IO.MemoryStream())
        {

            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();


            var table1 = new PdfPTable(4) { TotalWidth = 750f, LockedWidth = true };
            table1.WidthPercentage = 100;
            table1.SetWidths(new float[] { 30f, 10f, 10f, 10f });
            PdfPCell cell;
            string c1, c2;

            c1 = Codigos.Rows[0]["CodigoImpresion"].ToString();
            c2 = Codigos.Rows[0]["CodigoEncriptado"].ToString();

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            cell.Colspan = 4;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            cell.Colspan = 4;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            cell.Colspan = 4;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            cell.Colspan = 4;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            //cell.BorderColor = Color.BLACK;
            cell.Rotation = 90;
            table1.AddCell(cell);

            cell = PhraseCell(new Phrase(c2 + "\n" + c1, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)), Element.ALIGN_LEFT);
            cell.Colspan = 3;
            cell.Rotation = 90;
            table1.AddCell(cell);

            document.Add(table1);

            document.Close();
            bytes = memoryStream.ToArray();
            memoryStream.Close();
        }

        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=Ren_Rec_FORM-SIP-CC-A-001.pdf");
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }


    #endregion

    #region partes

    // Celdas para Reporte
    private PdfPCell PhraseCell(Phrase phrase, int align)
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


    #endregion

}