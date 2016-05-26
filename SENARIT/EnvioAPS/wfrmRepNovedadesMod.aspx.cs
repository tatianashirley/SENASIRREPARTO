using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfNovedades.Logica;

using System.Drawing;
using Microsoft.Reporting.WebForms;

public partial class EnvioAPS_wfrmRepNovedadesMod : System.Web.UI.Page
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
        if (!IsPostBack) //check if the webpage is loaded for the first time.
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
        }
    }
    protected void DsNovedadesId_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //IdActualizacion = (int)Session["IdActualizacion"];
        IdActualizacion = Convert.ToInt32(Server.UrlDecode(Request.QueryString["idAct"].ToString()));
        e.InputParameters["IdActualizacion"] = IdActualizacion;
    }

    protected void VolverBuscaNoves(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString()); 
        }        
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