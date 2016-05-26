using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AjaxControlToolkit;
using wcfNotificacion.Logica;
using wcfSeguridad.Logica;


public partial class Notificaciones_pruebaDatosNotificaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string ID_TRAMITE = txtIdtramite.Text;
        string GRUPO_BENEF = txtIdgrupobeneficio.Text;
        //ID_TRAMITE = ObjSeguridad.Encriptar(ID_TRAMITE);
        //GRUPO_BENEF = ObjSeguridad.Encriptar(GRUPO_BENEF);
        Response.Redirect("../Notificaciones/wfrmNotificaciones.aspx?iIdTramite=" + ID_TRAMITE + "&iIdGrupobeneficio=" + GRUPO_BENEF + " "); 
    }
    protected void btnEmisionP(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string ID_TRAMITE = txtIdtramite.Text;
        string GRUPO_BENEF = txtIdgrupobeneficio.Text;
        //ID_TRAMITE = ObjSeguridad.Encriptar(ID_TRAMITE);
        //GRUPO_BENEF = ObjSeguridad.Encriptar(GRUPO_BENEF);
        Response.Redirect("../EmisionCertificadoCC/wfrmEmisionCertificado.aspx?iIdTramite=" + ID_TRAMITE + "&iIdGrupobeneficio=" + GRUPO_BENEF + " "); 
    }

    protected void Observados(object sender,EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string ID_TRAMITE = txtIdtramite.Text;
        string GRUPO_BENEF = txtIdgrupobeneficio.Text;
        //ID_TRAMITE = ObjSeguridad.Encriptar(ID_TRAMITE);
        //GRUPO_BENEF = ObjSeguridad.Encriptar(GRUPO_BENEF);
        Response.Redirect("../SeguimientoObservados/wfrmSeguimientoObservados.aspx?iIdTramite=" + ID_TRAMITE + "&iIdGrupobeneficio=" + GRUPO_BENEF + " "); 
    }

    protected void RegDocumentos(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string ID_TRAMITE = txtIdtramite.Text;
        string GRUPO_BENEF = txtIdgrupobeneficio.Text;
        //ID_TRAMITE = ObjSeguridad.Encriptar(ID_TRAMITE);
        //GRUPO_BENEF = ObjSeguridad.Encriptar(GRUPO_BENEF);
        Response.Redirect("../Notificaciones/wfrmRegistroDocumento.aspx?iIdTramite=" + ID_TRAMITE + "&iIdGrupobeneficio=" + GRUPO_BENEF + " ");
    }
}