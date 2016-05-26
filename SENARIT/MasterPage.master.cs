using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using AjaxControlToolkit;
using System.Web;
using System.Linq;
using System.Globalization;
using System.Threading;

using wcfSeguridad.Logica;
using System.Net.Sockets;

public partial class MasterPage : System.Web.UI.MasterPage
{


    clsSeguridad obj = new clsSeguridad();
    public Button btnCerrarSesion
    {
        get { return btnCerrar; }
        set { btnCerrar = value; }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));

        //if (Session["SesionActiva"] == null)
        //    Response.Redirect("index.aspx");
       
        if (Page.Session.Count.Equals(0)) //(num.Equals(0))
        {
            Response.Redirect("~/LoginLDAP.aspx");
        }
        Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES", false);
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
       
        
        if (!Page.IsPostBack)
        {
            //string path =GetCurrentPageName();

            lblCodUsr.Text = Session["CodUsuario"].ToString();            ////// 1dw ind
            lblNombreCompleto.Text = Session["CuentaUsuario"].ToString(); ////// 1dw ind

            lblCodOficina.Text = Session["CodOficina"].ToString();             ////// 1dw ind
            //lblSistema.Text = Session["NombreOficina"].ToString();         ////// 1dw ind

            lblCodRol.Text = Session["RolUsuario"].ToString();            ////// 1dw ind

           
            Conexion();
            //Transacciones();

            if (lblCodUsr.Text != null)
            {

                if (lblCodUsr.Text !="")
                {
                    BindMenuControl();
                    lblFecha.Text = obj.ObtenerFecha();
                }
                else
                    Response.Redirect("~/LoginLDAP.aspx");
            }
            else
            {
                Response.Redirect("~/LoginLDAP.aspx");
            }           
            
            PermisosUrl();
            ObtenerVersion();
            
          
        }
    }

   
    public Label lblMasterError
    {
        get { return lblError; }
        set { lblError = value; }
    }
    public Label lblMasterSistema
    {
        get { return lblSistema; }
        set { lblSistema = value; }
    } 

    public Label lblMasterOk
    {
        get { return lblOk; }
        set { lblOk = value; }
    }
    public Label lblMasterWarning
    {
        get { return lblWarning; }
        set { lblWarning = value; }
    }
  
    public ModalPopupExtender mpePopup
    {
        get { return pnlMensaje_ModalPopupExtender; }
        set {pnlMensaje_ModalPopupExtender =value;}
    }
    public Image imgMasterOk
    {
        get { return imgOk; }
        set { imgOk = value; }
    }
    public Image imgMasterWarning
    {
        get { return imgWarning; }
        set { imgWarning = value; }
    }
    public Image imgMasterError
    {
        
        get { return imgError; }
        set { imgError = value; }
    }

    public Label lblMasterDetalleError
    {
        get { return lblDetalleError ; }
        set { lblDetalleError = value; }
    }
    protected void Conexion()
    {

        if (Session["IdConexion"] == null)
        {
            int IdConexion;

            String iIdConexion = null;
            String Operacion = "I";
            String sSSN = null;
            //String idEstacion = "2";
            //String NombreEstacion = System.Environment.MachineName;
            
            //String IpAddres = getIP();
            //String NombreEstacion = Address();
           
            String IpAddres = GetIP4Address();
            string NombreEstacion = null;
            try
            {
                IPAddress hostIPAddress = IPAddress.Parse(IpAddres);
                IPHostEntry hostInfo = Dns.GetHostByAddress(hostIPAddress);
                // Get the IP address list that resolves to the host names contained in 
                // the Alias property.
                IPAddress[] address = hostInfo.AddressList;
                // Get the alias names of the addresses in the IP address list.
                String[] alias = hostInfo.Aliases;

                NombreEstacion = hostInfo.HostName;

            }
            catch (Exception ex)
            {
                //MessageBoxShow(this, ex.Message);
                NombreEstacion = "s/n";
            }
            //String NombreEstacion = Address(IpAddres);
            //String NombreEstacion = null;
            //String IpAddres = LocalIPAddress();
            
            //String IpAddres = null;
            
                
            //String MacAddress = GetMACAddress();
            String MacAddress = null;
            
            

            int IdUsuario = (int)Session["CodUsuario"];
            String CuentaUsuario = (string)Session["CuentaUsuario"];
            int IdOficina = (int)Session["CodOficina"];
            int IdModulo = (int)Session["IdModulo"];
            int IdRol = (int)Session["RolUsuario"];

            IdConexion = obj.Conexion(iIdConexion, Operacion, sSSN,NombreEstacion,IpAddres,MacAddress, IdUsuario, CuentaUsuario, IdRol, IdOficina, IdModulo);

            if (IdConexion > 0)
            {
                Session["IdConexion"] = IdConexion;                
            }

        }

    }
    public int HabilitaTransaccion(int IdTransaccion)
    {
        int retorno = 0;
        if (Session["IdConexion"] != null)
        {            
            String iIdConexion =Convert.ToString((int)Session["IdConexion"]);
            String Operacion = "A";
            String iSesionTrabajo = null;
            String sSSN = null;
            String iIdRol = null;
            retorno = obj.HabilitaTransaccion(iIdConexion, Operacion, iSesionTrabajo, sSSN, iIdRol,IdTransaccion);
        }
        return retorno;

    }
    public void MensajeOk(string Ok)
    {
        lblError.Visible = false;
        imgError.Visible = false;
        imgWarning.Visible = false;
        lblWarning.Visible = false;
    
        imgOk.Visible = true;
        lblOk.Visible = true;
        lblOk.Text = Ok;
    }
    public void TituloSistema(string TituloSistema)
    {        
        lblSistema.Text = TituloSistema;
    }
    public void MensajeError(string Error,string DetalleError)
    {
        imgOk.Visible = false;        
        lblOk.Visible = false;
        imgWarning.Visible = false;
        lblWarning.Visible = false;
        lblError.Visible = true;
        imgError.Visible = true;
        lblError.Text =Error;
        lblDetalleError.Text =DetalleError;
        //pnlMensaje_ModalPopupExtender.Show();
    }
    public void MensajeErrorVisible()
    {
        pnlMensaje_ModalPopupExtender.Show();
    }
    public void MensajeWarning(string Error)
    {
        if (Error == null)
        {
            imgWarning.Visible = false;
            lblWarning.Visible = false;
            
        }
        else
        {
           

            imgOk.Visible = false;
            lblOk.Visible = false;
            lblError.Visible = false;
            imgError.Visible = false;


            imgWarning.Visible = true;
            lblWarning.Visible = true;


            lblWarning.Text = Error;

        }
        
    }
    public void MensajeCancel()
    {
        lblError.Visible = false;
        imgError.Visible = false;
        imgWarning.Visible = false;
        lblWarning.Visible = false;
        imgOk.Visible = false;
        lblOk.Visible = false;
    }

    
    protected void PermisosUrl()
    {

        int IdConexion;
        int Permisos;
        
            IdConexion = (int)Session["IdConexion"];
            string URL = HttpContext.Current.Request.Url.ToString();            
            int tam_var = URL.Length;
            String Var_Sub = URL.Substring((tam_var - 19), 19);

            if (Var_Sub != "SENARIT/Inicio.aspx")
            {
                Permisos = obj.PermisosUrl(IdConexion, URL);
                if (Permisos == 0)
                {                 
                    Response.Redirect("~/Inicio.aspx");
                }

            }
        
    }
    protected void ObtenerVersion()
    {

       
        DataTable Version = obj.Version();
        if (Version != null && Version.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in Version.Rows)
            {
                lblVersion.Text = Convert.ToString(drDataRow["Version"]);
            }
        }

       

    }

    protected void Obtener_Fecha_Sevidor()
    {
        SqlConnection sqlConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnstr"].ConnectionString.ToString());
        SqlCommand cmd = new SqlCommand();
        string lblfecha1;

        cmd.CommandText = "SELECT CONVERT(Char(11), GETDATE(), 106)"; // 103
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConexion;

        sqlConexion.Open();
        lblfecha1 = Convert.ToString(cmd.ExecuteScalar());
        lblfecha1 = Convert.ToDateTime(lblfecha1).ToLongDateString();
        lblfecha1 = Convert.ToString(lblfecha1);
        lblFecha.Text = lblfecha1;
        sqlConexion.Close();
    }
    public string getIP()
    {
        string clientIP;
        clientIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (clientIP == null)
        {
            clientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return clientIP;
        //IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
        //IPAddress[] addr = ipEntry.AddressList;
        //string ip = string.Empty;
        //foreach (var ipAddress in addr)
        //{
        //    if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
        //    {
        //        ip = ipAddress.ToString();
        //        break;
        //    }
        //}
        //return ip;
    }
    public static string GetIP4Address()
    {
        string IP4Address = String.Empty;

        foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        if (IP4Address != String.Empty)
        {
            return IP4Address;
        }

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    } 
    public string Address(string ip)
    {
        //string x = (System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName);
        //string IP = getIP();
        System.Net.IPAddress myIP = System.Net.IPAddress.Parse(ip);
        System.Net.IPHostEntry GetIPHost = System.Net.Dns.GetHostEntry(myIP);
        List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
        return compName.First();
        //string HostName = System.Net.Dns.GetHostByAddress(ip).HostName;
        //return HostName;
    }
    
    public string GetMACAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String sMacAddress = string.Empty;
        foreach (NetworkInterface adapter in nics)
        {
            if (sMacAddress == String.Empty)// only return MAC Address from first card  
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        } return sMacAddress;
    }
    
   
    protected void BindMenuControl()
    {

        DataTable dtDataTable = null;
        DataTable dtDataTableConexion = null;
        try
        {
            
            int IdConexion = (int)Session["IdConexion"];
            string Operacion = "M";
            string SesionTrabajo = null;
            string SSN = null;

            //dtDataTable = obj.menuprivilegiosUsuario(Convert.ToInt32(lblCodUsr.Text), Convert.ToInt32(lblCodOficina.Text),Convert.ToInt32(lblCodRol.Text));
            dtDataTable = obj.menuprivilegiosUsuario(IdConexion, Operacion, SesionTrabajo, SSN);
            if (dtDataTable != null && dtDataTable.Rows.Count > 0)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    if (Convert.ToInt32(drDataRow["IdMenu"]) == Convert.ToInt32(drDataRow["IdMenuSuperior"]))
                    {
                        MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow["Descripcion"]), Convert.ToString(drDataRow["IdMenu"]), String.Empty, Convert.ToString(drDataRow["URL"]));
                        this.Menu.Items.Add(miMenuItem);
                        AddChildItem(ref miMenuItem, dtDataTable);
                    }
                }
                dtDataTableConexion = obj.ListaDatosConexion(IdConexion);
                if (dtDataTableConexion != null && dtDataTableConexion.Rows.Count > 0)
                {
                    foreach (DataRow drDataRowConexion in dtDataTableConexion.Rows)
                    {

                        lblOficina.Text = Convert.ToString(drDataRowConexion["Oficina"]);
                        lblRol.Text=Convert.ToString(drDataRowConexion["Rol"]);
                        lblArea.Text = Convert.ToString(drDataRowConexion["Area"]);
                        Session["IdArea"] = Convert.ToInt32(drDataRowConexion["IdArea"]);
                        ViewState["IdOficina"] = Convert.ToInt32(drDataRowConexion["IdOficina"]);
                        ViewState["IdRol"] = Convert.ToInt32(drDataRowConexion["IdRol"]);
                        ViewState["CuentaUsuario"] = Convert.ToString(drDataRowConexion["CuentaUsuario"]);
                        ViewState["IdUsuario"] = Convert.ToInt32(drDataRowConexion["IdUsuario"]);

                        if (Convert.ToInt32(drDataRowConexion["IdTipoUsuario"]) == 677)
                        {
                            MenuItem miMenuPassword = new MenuItem("Cambiar Password", "", String.Empty, "~/Seguridad/wfrmCambiarPassword.aspx");
                            this.Menu.Items.Add(miMenuPassword);
                        }
                    }
                }


                MenuItem miMenuOficina = new MenuItem("Seleccionar Oficina", "", String.Empty,"~/Auxiliar/ListaOficinasU.aspx");
                this.Menu.Items.Add(miMenuOficina);
                MenuItem miMenuRol = new MenuItem("Seleccionar Rol", "",String.Empty, "~/Auxiliar/ListaRolesU.aspx");
                this.Menu.Items.Add(miMenuRol);

            }
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

        finally
        {
          
            dtDataTable.Dispose();
        }
    }

    protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
    {
        foreach (DataRow drDataRow in dtDataTable.Rows)
        {
            
            if (Convert.ToInt32(drDataRow["IdMenuSuperior"]) == Convert.ToInt32(miMenuItem.Value) && Convert.ToInt32(drDataRow["IdMenu"]) != Convert.ToInt32(drDataRow["IdMenuSuperior"]))
            {
                MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow["Descripcion"]), Convert.ToString(drDataRow["IdMenu"]), String.Empty, Convert.ToString(drDataRow["URL"]));
                miMenuItem.ChildItems.Add(miMenuItemChild);
                AddChildItem(ref miMenuItemChild, dtDataTable);
            }
        }
    }

    
   
    protected void btnCerrar_Click(object sender, EventArgs e)

    {
        //int IdConexion;

        int iIdConexion = (int)Session["IdConexion"];
        String Operacion = "C";
        
        
        obj.CerrarConexion(iIdConexion, Operacion);
        Session.Abandon();
        Response.Redirect("~/LoginLDAP.aspx");

    }
}
