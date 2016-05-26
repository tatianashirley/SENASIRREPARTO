using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfSeguridad.Logica;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using AjaxControlToolkit;

using System.Linq;
using System.Net.Sockets;


public partial class LoginLDAP : System.Web.UI.Page
{
    clsSeguridad obj = new clsSeguridad();
    clsConexionFallida ObjConexionFallida = new clsConexionFallida();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            txtLogin.Focus();
        }            
    }
    private void BusquedaUsuario(string UsuarioRed,int Opcion)
    {
        DataTable dtDataTable = null;        
        dtDataTable = obj.BusquedaUsuario(UsuarioRed, Opcion);
        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in dtDataTable.Rows)
            {
                Session["CuentaUsuario"] = Convert.ToString(drDataRow["CuentaUsuario"]);
                Session["CodUsuario"] = Convert.ToString(drDataRow["IdUsuario"]);

            }
            Response.Redirect("~/Auxiliar/ListaOficinasU.aspx");
        }
    }
    #region INTERFAZ
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtLogin, txtPassword);
        //AgregarJSAtributos(txtPassword, txtDomi);        
        AgregarJSAtributos(txtPassword, btnAceptar);        
        AgregarJSAtributos(txtDomi,btnAceptar);
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");
            //controlActual.Attributes.Add("onFocus", "  JavaScript:this.style.backgroundColor='#ffff00'; SelectAll(this)");
            //controlActual.Attributes.Add("onBlur", "  JavaScript:this.style.backgroundColor='#ffffff'; return focusNext('" + ctrlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "', null)  ");

        }
    }
    #endregion
   
    
    #region AUTENTICACION LDAP y OTRO
    public void btnAceptar_Click(object sender, EventArgs e)
    {
        Session.Remove("IdConexion");
        int CodUsuario = 0;
        /* Autenticacion LDAP */
        string dominio = "", user = "", pass = "";

        dominio = txtDomi.Text;
        user = txtLogin.Text;
        pass = txtPassword.Text;
        
               
        //String IpAddress = getIP();
        
        String IpAddress = GetIP4Address();
        string NombreEstacion = null;
        try 
    {
       IPAddress hostIPAddress = IPAddress.Parse(IpAddress);
       IPHostEntry hostInfo = Dns.GetHostByAddress(hostIPAddress);
       // Get the IP address list that resolves to the host names contained in 
       // the Alias property.
       IPAddress[] address = hostInfo.AddressList;
       // Get the alias names of the addresses in the IP address list.
       String[] alias = hostInfo.Aliases;

        NombreEstacion = hostInfo.HostName;
       
    }
        catch (Exception ex) { 
            //MessageBoxShow(this, ex.Message);
            NombreEstacion = "s/n";
        }

        //String NombreEstacion = System.Net.Dns.GetHostByAddress
        //String NombreEstacion = Environment.MachineName;
        //String NombreEstacion = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName;
        //String NombreEstacion = Address();
        //String NombreEstacion = (System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName);
        //String IpAddress = null;
        //IPHostEntry NombreEstacion = Dns.GetHostEntry(Dns.GetHostName()); 
        string sMensajeError = null;
        string DSetTmp = null;
        string sOperacion = "P";

        //Modificado VLC
        if (dominio == "")
        {
                
            DataTable dtDataTable = null;
            DataTable dtPruebaconexion=null;
            
            dtPruebaconexion = ObjConexionFallida.ConexionDB(user, "Q", ref sMensajeError);
            if (sMensajeError == null && dtPruebaconexion.Rows.Count > 0)
            {
                lblObservaciones.Text = "La operacion se realizo con exito";
                try
                {
                    int tipousuario = 0;

                    dtDataTable = obj.privilegiosUsuario(txtLogin.Text);
                    if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                    {
                        DateTime ?fFechaVigencia=null;
                        DateTime ?fFechaExpiracion=null;

                        foreach (DataRow drDataRow in dtDataTable.Rows)
                        {
                            Session["CuentaUsuario"] = Convert.ToString(drDataRow["CuentaUsuario"]);
                            Session["Password"] = Convert.ToString(drDataRow["ClaveUsuario"]);
                            Session["CodUsuario"] = Convert.ToInt32(drDataRow["IdUsuario"]);
                            user = Session["CuentaUsuario"].ToString();
                            pass = Session["Password"].ToString();
                            pass = obj.Desencriptar(pass);
                            fFechaVigencia = Convert.ToDateTime(drDataRow["FechaVigencia"]);
                            fFechaExpiracion = Convert.ToDateTime(drDataRow["FechaExpiracion"]);
                            tipousuario = Convert.ToInt32(drDataRow["IdTipoUsuario"]);

                            
                        }
                        if (fFechaExpiracion != null)
                        {
                            if (DateTime.Today > fFechaExpiracion)
                            {
                                lblObservaciones.Text = "Finalizo la fecha de vigencia de su cuenta" + Convert.ToString(fFechaExpiracion).Substring(0, 10) + " - Comuniquese con el Administrador del Sistema ";
                            }
                            else
                            {
                                if (user == txtLogin.Text)
                                {
                                    if (tipousuario == 676)
                                    {
                                        lblObservaciones.Text = "Error el tipo de usuario que usted tiene asignado es INTERNO, debe introducir el DOMINIO";
                                        ObjConexionFallida.ConexionFallidaAdiciona(user, NombreEstacion, IpAddress, ref sMensajeError);
                                    }
                                    else
                                    {
                                        if (pass == txtPassword.Text)
                                        {

                                            Response.Redirect("~/Auxiliar/ListaOficinasU.aspx");
                                        }
                                        else
                                        {
                                            lblObservaciones.Text = "Error al Autenticar la contraseña no es valida";
                                            ObjConexionFallida.ConexionFallidaAdiciona(user, NombreEstacion, IpAddress, ref sMensajeError);

                                        }
                                    }
                                }

                            }
                        }

                        
                    }
                    else
                    {
                        lblObservaciones.Text = "Error la Cuenta de Usuario no se encuentra registrada";
                        ObjConexionFallida.ConexionFallidaAdiciona(user, NombreEstacion, IpAddress, ref sMensajeError);
                    }


                }
                catch (Exception ex) { MessageBoxShow(this, ex.Message); }
                finally
                {
                    dtDataTable.Dispose();
                }

            }
            else
            {
                lblObservaciones.Visible = true;
                lblObservaciones.Text = sMensajeError;

            }
           

        }

            // hasta aqui la primera modificacion

        else
        {

            //Aquí va el path URL del servicio de directorio LDAP                     
            string path = "LDAP://" + dominio + ".local/CN=Users, DC=" + dominio + ", DC=local";

            if (estaAutenticado(dominio, user, pass, path) == true)
            {
                //pass = obj.Encriptar(pass);
                DataTable dtDataTable = null;
                DataTable dtPruebaconexion = null;
                
                dtPruebaconexion = ObjConexionFallida.ConexionDB(user,"Q", ref sMensajeError);
                if (sMensajeError == null && dtPruebaconexion.Rows.Count > 0)
                {
                    lblObservaciones2.Text = "La operacion se realizo con exito";
                    lblObservaciones2.Visible = false;
                    try
                    {
                        dtDataTable = obj.privilegiosUsuario(txtLogin.Text);

                        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
                        {
                            DateTime? fFechaVigencia = null;
                            DateTime? fFechaExpiracion = null;
                            foreach (DataRow drDataRow in dtDataTable.Rows)
                            {
                                Session["CuentaUsuario"] = Convert.ToString(drDataRow["CuentaUsuario"]);
                                //Session["Password"] = Convert.ToString(drDataRow[2]);
                                Session["CodUsuario"] = Convert.ToInt32(drDataRow["IdUsuario"]);
                                user = Session["CuentaUsuario"].ToString();
                                fFechaVigencia = Convert.ToDateTime(drDataRow["FechaVigencia"]);
                                fFechaExpiracion = Convert.ToDateTime(drDataRow["FechaExpiracion"]);

                            }
                            if (fFechaExpiracion != null)
                            {
                                if (DateTime.Today > fFechaExpiracion)
                                {
                                    lblObservaciones.Text = "Finalizo la fecha de vigencia de su cuenta" + Convert.ToString(fFechaExpiracion).Substring(0,10) + "  - Comuniquese con el Administrador del Sistema ";
                                }
                                else
                                {
                                    if (user == txtLogin.Text)
                                    {

                                        Response.Redirect("~/Auxiliar/ListaOficinasU.aspx");
                                    }
                                    else
                                    {
                                        lblObservaciones.Text = "Error la Cuenta de Usuario no se encuentra registrada";
                                        ObjConexionFallida.ConexionFallidaAdiciona(user, NombreEstacion, IpAddress, ref sMensajeError);
                                    }
                                }
                            }
                        }
                        else
                        {
                            lblObservaciones.Text = "Error la Cuenta de Usuario no se encuentra registrada";
                            ObjConexionFallida.ConexionFallidaAdiciona(user, NombreEstacion, IpAddress, ref sMensajeError);
                        }
                    }
                    catch (Exception ex) { MessageBoxShow(this, ex.Message); }
                    finally
                    {
                        dtDataTable.Dispose();
                    }

                }
                else
                {
                    lblObservaciones2.Visible = true;
                    lblObservaciones2.Text = sMensajeError;

                }
               
            }
            else
            {
                lblObservaciones.Text = "Error al Autenticar";
                ObjConexionFallida.ConexionFallidaAdiciona(user, NombreEstacion, IpAddress, ref sMensajeError);
                
            }
        }
    }
    private void MessageBoxShow(Page page, string message)
    {
        Literal ltr = new Literal();
        ltr.Text = @"<script type='text/javascript'> alert('" + message + "')</script>";
        page.Controls.Add(ltr);
    }

    public bool estaAutenticado(string dominio, string usuario, string pwd, string path)
    {
        string domainAndUsername = dominio + @"\" + usuario;
        DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, pwd);
        try
        {
            DirectorySearcher search = new DirectorySearcher(entry);
            SearchResult result = search.FindOne();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            
            return false;
        }
    }
    #endregion
    protected void lnkCambioPassword_Click(object sender, EventArgs e)
    {
        lblPass.Text = "Password Actual :";
        btnAceptar.Text = "Modificar";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
    protected void Limpiar()
    {
        txtLogin.Text = "";
        txtPassword.Text = "";
        txtDomi.Text = "SENASIR";
        lblObservaciones.Text = "";
    }
    protected void imgCC_Click(object sender, ImageClickEventArgs e)
    {
        lblPass.Text = "Password Actual :";
        btnAceptar.Text = "Modificar";
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
       
       
    }
    public string Address()
    {
        //string x = (System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName);
        //string IP = getIP();
        //System.Net.IPAddress myIP = System.Net.IPAddress.Parse(ip);
        //System.Net.IPHostEntry GetIPHost = System.Net.Dns.GetHostEntry(ip);
        //List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
        //return compName.First();
        //string HostName = System.Net.Dns.GetHostEntry(ip).HostName;
        //return HostName;
        //string host=System.Net.Dns.GetHostByAddress(ip).HostName;
        //string host =
        //return host;
        //System.Net.IPHostEntry host = new System.Net.IPHostEntry();
        string host ="172.17.5.141";
        string s1 = Request.ServerVariables["REMOTE_HOST"];
        string hostNameLocal = Dns.GetHostEntry(s1).HostName;
        return hostNameLocal;
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
               // IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }
    
}