using NReco.ImageGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prueba4hmtlimage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        var html = String.Format("<body>Hello world: {0}</body>", DateTime.Now);
        var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
        var jpegBytes = htmlToImageConv.GenerateImage(html, ImageFormat.Jpeg);
        //Response.Clear();
        Response.ContentType = "image/png";
        //Response.AddHeader("Content-Disposition", "attachment; filename=HTML.png");
        //Response.Buffer = true;
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(jpegBytes);
        Response.End();
    }
}