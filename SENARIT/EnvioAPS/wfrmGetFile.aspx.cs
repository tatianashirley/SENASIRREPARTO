using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using wcfEnvioAPS.Logica;

public partial class EnvioAPS_wfrmGetFile : System.Web.UI.Page
{
    clsContrlEnvios objContrlEnvios = new clsContrlEnvios();
    
    int IdConexion;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];
            //IdConexion = 4039;
            //IdConexion = 5679;
        }
        
        int fc = Convert.ToInt16(Request.QueryString["FC"]);
        // Get the file id from the query string
        string NumeroEnvio = Request.QueryString["NumeroEnvio"];
        int IdEntidad = int.Parse(Request.QueryString["IdEntidad"]);

        // Get the file from the database
        DataTable file = new DataTable();
        objContrlEnvios.iIdConexion = IdConexion;
        objContrlEnvios.sNumeroEnvio = NumeroEnvio;
        objContrlEnvios.iIdEntidad = IdEntidad;
        if (objContrlEnvios.GetRowMedioEnvioAPS())
        {
            file = objContrlEnvios.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objContrlEnvios.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
 
        DataRow row = file.Rows[0];

        string name = (string)row["ArchivoEnvioNombre"];
        string contentType = (string)row["ArchivoEnvioContTipo"];
        Byte[] data = (Byte[])row["ArchivoEnvioDatos"];
        if (fc == 1)
        {
            name = (string)row["ArchivoEnvioCRCNombre"];
            data = (Byte[])row["ArchivoEnvioCRCDatos"];
        }

        // Send the file to the browser
        Response.AddHeader("Content-type", contentType);
        Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
    }
}