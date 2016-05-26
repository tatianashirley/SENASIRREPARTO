using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

 
public partial class PruebaImgHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
    }

   
   protected void CreateThumbnailImage(object sender, EventArgs e)
        {
            string url = string.Format("hola", txtWebsiteAddress.Text);
          


            int width = Int32.Parse(txtWidth.Text);
            int height = Int32.Parse(txtHeight.Text);
            Thumbnail thumbnail = new Thumbnail(url, 800, 600, width, height);
            Bitmap image = thumbnail.GenerateThumbnail();
            image.Save(Server.MapPath("~") + "/Thumbnail.bmp");
            imgThumbnailImage.ImageUrl = "~/Thumbnail.bmp";
            imgThumbnailImage.Visible = true;
        }     
   
}
public class Thumbnail
{
    public string Url { get; set; }
    public Bitmap ThumbnailImage { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int BrowserWidth { get; set; }
    public int BrowserHeight { get; set; }
 
    public Thumbnail(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
    {
        this.Url = Url;
        this.BrowserWidth = BrowserWidth;
        this.BrowserHeight = BrowserHeight;
        this.Height = ThumbnailHeight;
        this.Width = ThumbnailWidth;
    }
    public Bitmap GenerateThumbnail()
    {
        Thread thread = new Thread(new ThreadStart(GenerateThumbnailInteral));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
        return ThumbnailImage;
    }
    private void GenerateThumbnailInteral()
    {
        WebBrowser webBrowser = new WebBrowser();
        webBrowser.ScrollBarsEnabled = false;
        webBrowser.Navigate(this.Url);
        webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
        
        while (webBrowser.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();
        webBrowser.Dispose();
    }
    private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser webBrowser = (WebBrowser)sender;
        webBrowser.ClientSize = new Size(this.BrowserWidth, this.BrowserHeight);
        webBrowser.ScrollBarsEnabled = false;
        this.ThumbnailImage = new Bitmap(webBrowser.Bounds.Width, webBrowser.Bounds.Height);
        webBrowser.BringToFront();
        webBrowser.DrawToBitmap(ThumbnailImage, webBrowser.Bounds);
        this.ThumbnailImage = (Bitmap)ThumbnailImage.GetThumbnailImage(Width, Height, null, IntPtr.Zero);
    }
}