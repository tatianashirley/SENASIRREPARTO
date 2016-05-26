using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfNovedadesReparto.Logica;
//using wcfNovedadesReparto.

public partial class NovedadesReparto_wfrmEmpresa : System.Web.UI.Page
{
    clsEmpresa objEmp = new clsEmpresa();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime Fecha = Convert.ToDateTime(TextBox2.Text);
        decimal txt3=Convert.ToDecimal(TextBox3.Text);
        string res = objEmp.RegistrarDatos(TextBox1.Text, Fecha, txt3, (int)Session["IdConexion"], "I");
        if (res == null)
        {
            string Msg = "Se realizo la Operacion con exito";
            Master.MensajeOk(Msg);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = res;
            Master.MensajeError(Error, DetalleError);
        }           
    }

}