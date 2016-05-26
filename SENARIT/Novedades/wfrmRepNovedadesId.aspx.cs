using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfNovedades.Logica;

using System.Drawing;
using Microsoft.Reporting.WebForms;

//using WcfServicioClasificador.Logica;

public partial class Novedades_wfrmRepNovedadesId : System.Web.UI.Page
{
    Int32 IdActualizacion;
    Int32 IdConexion;


    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Browser.Browser.Equals("IE"))
        {
            BtnImprimir.Visible = false;
            BtnImprimir.Enabled = false;
            lblImprimir.Visible = false;
        }
    }

    protected void DsNovedadesId_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
 
        IdActualizacion = (int)Session["IdActualizacion"];
        e.InputParameters["IdActualizacion"] = IdActualizacion;
    }

    protected void VolverBuscaNoves(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBusquedaNovedades.aspx");
    }
    protected void ReportViewer1_Load(object sender, EventArgs e)
    {

    }
    protected void ReportViewer1_Init(object sender, EventArgs e)
    {
        IdConexion = (int)Session["IdConexion"];
        clsNovedades busca = new clsNovedades();
        string Usuario = busca.UsuarioConectado(IdConexion);
        ReportParameter parametro = new ReportParameter();
        parametro = new ReportParameter("usuario", Usuario);
        ReportViewer1.LocalReport.SetParameters(parametro);
    }
}
