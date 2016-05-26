using System;
using System.Linq;
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

using System.Drawing;
using Microsoft.Reporting.WebForms;

public partial class Reportes_wfrmVistaCertificadoCC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //e.InputParameters["Tramite"] = (Int64)Session["Tramite"];
        //e.InputParameters["GrupoB"] = (int)Session["beneficio"];
        //e.InputParameters["TipoForm"] = (int)Session["TipoFormulario"];
        //e.InputParameters["NoFormCalculo"] = (int)Session["NroFormCalculo"];
        int t = (int)Session["Tramite"];
        int b = (int)Session["beneficio"];
        int tf = (int)Session["TipoFormulario"];
        int nc = (int)Session["NroFormCalculo"];
        int certi = (int)Session["ImprCertificado"];
        string newvalue = (string)Session["Newvalue"];

        e.InputParameters["Tramite"] = t;
        e.InputParameters["GrupoB"] = b;
        e.InputParameters["TipoForm"] = tf;
        e.InputParameters["NoFormCalculo"] = nc;
        e.InputParameters["Certi"] = certi;
        e.InputParameters["Montoaceptado"] = newvalue;

        

        //e.InputParameters["Tramite"] = 103341;
        //e.InputParameters["GrupoB"] = 3;
        //e.InputParameters["TipoForm"] = 7;
        //e.InputParameters["NoFormCalculo"] = 25319;
    }
}