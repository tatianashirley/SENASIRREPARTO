using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wfrmPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["CodUsuario"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        //else
        //{
        //    lblCodUsuario.Text = Session["CodUsuario"].ToString();

        //    //lblCuentaUsuario.Text = Session["CuentaUsuario"].ToString(); // desbloquear si sera por login

        //    lblModulo.Text = Session["CodModulo"].ToString();
        //    //lblRol.Text = Session["CodRol"].ToString();
        //    lblRol.Text = Session["AccessRol"].ToString();
        //}

        if (!Page.IsPostBack)
        {
            lnkAcercaDe.Attributes["onclick"] = "javascript:ModalPopup()";
        }

        // ocultar panel para los NO administradores
    }

    protected void lnkAcercaDe_Click(object sender, EventArgs e)
    {
        //lnkAcercaDe.Attributes["onclick"] = "javascript";
        lnkAcercaDe.Attributes["onclick"] = "javascript:ModalPopup()";
    }


}