<%@ WebHandler Language="C#" Class="HandlerQR2" %>

using System;
using System.Web;
using System.Drawing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

public class HandlerQR2 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {

        string path = "Imagenes/";
        string imagen = context.Request.QueryString["sCodigo"];

        
        
        QRCodeWriter qr = new QRCodeWriter();

        var matrix = qr.encode(imagen, ZXing.BarcodeFormat.QR_CODE, 200, 200);

        ZXing.BarcodeWriter w = new ZXing.BarcodeWriter();

        w.Format = ZXing.BarcodeFormat.QR_CODE;

        Bitmap img = w.Write(matrix);        
       
        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);        
        context.Response.ContentType = "image/png";

     
            //context.Response.WriteFile(path + imagen + ".png");
        //context.Response.WriteFile(img+ ".png");
        

       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    

}