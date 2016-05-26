<%@ WebHandler Language="C#" Class="FormatoTexto" %>


using System;
using System.Web;
using NReco.ImageGenerator;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
public class FormatoTexto : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        string texto= context.Request.QueryString["sTexto"];
        int iWidth =Convert.ToInt32(context.Request.QueryString["iWidth"]);
        int iHeight = Convert.ToInt32(context.Request.QueryString["iHeight"]);
        string sfuente=context.Request.QueryString["sFuente"];
        int iZoom=Convert.ToInt32(context.Request.QueryString["iZoom"]);
        texto = texto.Replace("%lt;", "<");
        texto = texto.Replace("%gt;", ">");

        string imagen = "<div " + sfuente + ";>";
        imagen += texto;
        imagen += "</div>";
        //int iWidth = 756;        
        context.Response.Clear();
        var html = String.Format(imagen, DateTime.Now);
        var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
        htmlToImageConv.Width = iWidth;
        htmlToImageConv.Height = iHeight;
        htmlToImageConv.Zoom =iZoom;        
        var jpegBytes = htmlToImageConv.GenerateImage(html, ImageFormat.Bmp);
        
        
         
        
        //Response.Clear();
        context.Response.ContentType = "image/png";
        
        //Response.AddHeader("Content-Disposition", "attachment; filename=HTML.png");
        //Response.Buffer = true;
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.BinaryWrite(jpegBytes);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}