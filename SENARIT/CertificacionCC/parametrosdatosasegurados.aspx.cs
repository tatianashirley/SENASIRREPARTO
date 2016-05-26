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
using wcfSeguridad.Logica;
using wcfCertificacionCC.Logica;
using wcfGeo.Logica;


public partial class CertificacionCC_parametrosdatosasegurados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();        
        string iIdTramite = txtIdtramite.Text;
        string iIdGrupoBeneficio = txtIdgrupobeneficio.Text;
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        
        Response.Redirect("wfrmProcedimientoAutomatico.aspx?iIdTramite="+iIdTramite+"&iIdGrupoBeneficio="+iIdGrupoBeneficio+" "); 
        
    }
    protected void btnEnviar2_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = txtIdtramite.Text;
        string iIdGrupoBeneficio = txtIdgrupobeneficio.Text;
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        Response.Redirect("wfrmProcedimientoValidoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
    }
    protected void btnEmisionManual_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = txtIdtramite.Text;
        string iIdGrupoBeneficio = txtIdgrupobeneficio.Text;
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        Response.Redirect("wfrmEmisionProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " "); 
    }
    protected void btnProcedimientoManual_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = txtIdtramite.Text;
        string iIdGrupoBeneficio = txtIdgrupobeneficio.Text;
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        Response.Redirect("wfrmProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " "); 
    }
    protected void btnProcedimientoManual0_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = txtIdtramite.Text;
        string iIdGrupoBeneficio = txtIdgrupobeneficio.Text;
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        Response.Redirect("wfrmProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
    }
    protected void btnProcedimientoManualCabecera_Click(object sender, EventArgs e)
    {

    }
}