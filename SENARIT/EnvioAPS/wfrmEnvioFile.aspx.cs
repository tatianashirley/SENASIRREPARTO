using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

public partial class EnvioAPS_wfrmEnvioFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string file = @"D:\\ListadoAltasPreliminar.xlsx";

        // Obtienes ubicación física
        //string filePath = Server.MapPath(filename);
        string filePath = Server.UrlDecode(Request.QueryString["filePath"].ToString());
        ////Este objeto permite manipular archivos
        FileInfo file1 = new FileInfo(filePath);
        //Si el archivo existe
        if (file1.Exists)
        {
            //Response.Clear();
            //Response.ClearHeaders();
            //Limpias las cabeceras y contenido del response
            Response.ClearContent();
            // Es esta linea declaras que el response tendrá un Archivo 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file1.Name);
            //Declaras el tamaño del archivo
            Response.AddHeader("Content-Length", file1.Length.ToString());
            // Estableces el tipo de contenido según la extensión del archivo
            Response.ContentType = ReturnExtension(file1.Extension.ToLower());
            //Response.Flush();
            // Eso permite cargar el archivo desde el cliente
            Response.TransmitFile(file1.FullName);
            // Se finaliza el response
            Response.End();
        }
    }
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
}