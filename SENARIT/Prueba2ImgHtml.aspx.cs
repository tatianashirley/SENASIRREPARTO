using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Importamos el espacio de nombre que declara la clase Bitmap, Graphics, Font y SolidBrush
using System.Drawing;
//Importamos el espacio de nombre que declara la clase ImageFormat
using System.Drawing.Imaging;
using System.IO;

public partial class Prueba2ImgHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = 0;
        Bitmap newBitmap = null;
        Graphics g = null;

        //string str2Render = Request.QueryString.Get("HitCount");
        string str2Render = string.Format("<div align=center width=500>prueba</div>");
        string linea, contenido = "";


        if (null == str2Render) str2Render = "no count specified";
        string strFont = Request.QueryString.Get("HitFontName");
        if (null == strFont) strFont = "Lucida Sans Unicode";

        int nFontSize = 12;
        try
        {
            nFontSize = Int32.Parse(Request.QueryString.Get("HitFontSize"));
        }
        catch
        {
            // do nothing, just ignore
        }

        string strBackgroundColorname = Request.QueryString.Get("HitBackgroundColor");
        Color clrBackground = Color.White;
        try
        {
            // Format in the URL: %23xxXXxx
            if (null != strBackgroundColorname)
                clrBackground = ColorTranslator.FromHtml(strBackgroundColorname);
        }
        catch
        {
        }

        string strFontColorName = Request.QueryString.Get("HitFontColor");
        Color clrFont = Color.Black;
        try
        {
            // Format in the URL: %23xxXXxx
            if (null != strFontColorName)
                clrFont = ColorTranslator.FromHtml(strFontColorName);
        }
        catch
        {
        }

        try
        {
            Font fontCounter = new Font(strFont, nFontSize);

            // calculate size of the string.
            newBitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(newBitmap);
            SizeF stringSize = g.MeasureString(str2Render, fontCounter);
            int nWidth = (int)stringSize.Width;
            int nHeight = (int)stringSize.Height;
            g.Dispose();
            newBitmap.Dispose();

            newBitmap = new Bitmap(nWidth, nHeight, PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(newBitmap);
            g.FillRectangle(new SolidBrush(clrBackground), new Rectangle(0, 0, nWidth, nHeight));

            g.DrawString(str2Render, fontCounter, new SolidBrush(clrFont), 0, 0);

            MemoryStream tempStream = new MemoryStream();
            newBitmap.Save(tempStream, ImageFormat.Png);

            Response.ClearContent();
            Response.ContentType = "image/png";
            Response.BinaryWrite(tempStream.ToArray());
            Response.End();
            // newBitmap.Save(Response.OutputStream, ImageFormat.Png);
            // newBitmap.Save("o:\\TestApps\\TestServer\\test.png", ImageFormat.Png) ;
        }
        
        finally
        {
            if (null != g) g.Dispose();
            if (null != newBitmap) newBitmap.Dispose();
        }
    }
}


    