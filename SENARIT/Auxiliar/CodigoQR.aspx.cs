using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

public partial class CodigoQR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sCadena=null;
        if (!Page.IsPostBack)
        {

            sCadena = Convert.ToString(Request.QueryString["sCadena"]);

           
                imagenQR(sCadena);
           
        }
    }
    private void imagenQR(string sCadena)
    {
        QRCodeWriter qr = new QRCodeWriter();        

        var matrix = qr.encode(sCadena, ZXing.BarcodeFormat.QR_CODE, 200, 200);

        ZXing.BarcodeWriter w = new ZXing.BarcodeWriter();

        w.Format = ZXing.BarcodeFormat.QR_CODE;

        Bitmap img = w.Write(matrix);
        //imgQR = img;
        //img.Save(@"C:\Temp\Data\myQR.png", System.Drawing.Imaging.ImageFormat.Png);
        //imgQR. = System.Drawing.Imaging.ImageFormat.Png;
        img.Save(Page.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
        Page.Response.ContentType = "image/Png";
        
        //imgQR.ImageUrl = "CodigoQR.aspx?sCadena=prueba";
        //Console.ReadLine();
    }
}