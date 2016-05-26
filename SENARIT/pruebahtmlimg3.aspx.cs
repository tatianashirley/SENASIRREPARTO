using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebahtmlimg3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string htmlurl = "www.google.com.bo";
        saveURLToImage(htmlurl);
    }
    private void saveURLToImage(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            string content = "";


            System.Net.WebRequest webRequest = WebRequest.Create(url);
            System.Net.WebResponse webResponse = webRequest.GetResponse();
            System.IO.StreamReader sr = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8"));
            content = sr.ReadToEnd();
            //save to file
            byte[] b = Convert.FromBase64String(content);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save(@"c:\pic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            img.Dispose();
            ms.Close();
        }
    }


}