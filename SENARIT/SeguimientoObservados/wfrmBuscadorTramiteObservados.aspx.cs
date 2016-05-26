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
using wcfObservados.Logica;

public partial class SeguimientoObservados_wfrmBuscadorTramiteObservados : System.Web.UI.Page
{
    int iIdGrupoBeneficio;
    string cOperacion;
    int iIdConexion;
    string sMensajeError;
    clsSeguimientoObservados ObjObservados = new clsSeguimientoObservados();
    DataTable Busqueda = new DataTable();
    string sUrl;
    string Error;
    string DetalleError;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            BandejaTramitesObservados();
        }

    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtIdtramite, btnEnviar);        

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {

        iIdConexion = (int)Session["IdConexion"];
        cOperacion = "V";
        sMensajeError = null;
        string NoCrenta = txtIdtramite.Text;
        iIdGrupoBeneficio =3 ;
        Int64 iIdTramite;
        Int32 vBool;
        Busqueda = ObjObservados.VerificaAcceso(iIdConexion,cOperacion,NoCrenta,iIdGrupoBeneficio,ref sMensajeError);
        iIdTramite = Convert.ToInt64(Busqueda.Rows[0]["IdTramite"]);
        vBool = Convert.ToInt32(Busqueda.Rows[0]["vBool"]);
        if (Busqueda != null && Busqueda.Rows.Count > 0 && vBool == 1)
        {
            
            sUrl = "~/SeguimientoObservados/wfrmSeguimientoObservados.aspx";
            Response.Redirect(sUrl + "?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
        }
        else
        {
            Error= "Error al realizar la operación";
            DetalleError = "El tramite no esta disponible para ejecutar la actividad";
            Master.MensajeError(Error, DetalleError);
        }
    }
    public void BandejaTramitesObservados()
    {
        //OnRowDataBound="gvBandeja_RowDataBound" 
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "R";
        string mensajeError = null;
        DataTable tblBandeja = null;
        tblBandeja = ObjObservados.BandejaObservados(iIdConexion, cOperacion, ref mensajeError);
        if (tblBandeja != null && tblBandeja.Rows.Count > 0)
        {
            lblCantidad.Text = Convert.ToString(tblBandeja.Rows.Count);
            gvBandeja.DataSource = tblBandeja;
            gvBandeja.DataBind();
        }
    }
    protected void gvBandeja_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandeja.PageIndex = e.NewPageIndex;
        BandejaTramitesObservados();
    }
}