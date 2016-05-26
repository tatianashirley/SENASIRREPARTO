using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Drawing;
using wfcDoblePercepcion.Logica;
using System.Web.UI.HtmlControls;
using wcfServicioIntercambioPago.Logica;

public partial class DoblePercepcion_wfrmBuscarDatosAsegurado : System.Web.UI.Page
{

    DataTable Encontrados = null;
    string mensaje = null;
    clsInformacion info = new clsInformacion();
    clsManejoArchivo ManejoArchivo = new clsManejoArchivo();

    private void Page_Load(object sender, EventArgs e)
    {                                                                                

        if (!IsPostBack)
        {
            if (Session["CUAA"] != null)
            {
                Encontrados = Session["CUAA"] as DataTable; 
                if (Encontrados.Rows.Count != 0)
                {
                    gvBusqueda.Visible = true;
                    gvBusqueda.DataSourceID = null;
                    gvBusqueda.DataSource = Encontrados;
                    gvBusqueda.DataBind();

                }
            }
            CambiarInterfaz();
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
   {
        gvBusqueda.Visible = true;
        gvBusqueda.DataSourceID = null;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona", txtPrimerApellido.Text, txtSegundoApellido.Text, txtPrimerNombre.Text
        , txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, 0, 0, ref mensaje);
        gvBusqueda.DataSource = Encontrados;
        gvBusqueda.DataBind();
        Session["CUAA"] = Encontrados;
        
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SENARIT/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
        Session.Remove("CUAA"); 
        Response.Redirect("~/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
    }

    protected void gvBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fila2 = gvBusqueda.SelectedRow.RowIndex;
        CargarSeleccionado(fila2);
    }

    protected void gvBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusqueda.PageIndex = e.NewPageIndex;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona", txtPrimerApellido.Text, txtSegundoApellido.Text, txtPrimerNombre.Text
       , txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, 0, 0, ref mensaje);
        gvBusqueda.DataSource = Encontrados;
        gvBusqueda.DataBind();
    }   


    private void CargarSeleccionado(int fila)
    {
        //cargamos los datos en los textbox
        Session["NUPT"] = gvBusqueda.SelectedRow.Cells[2].Text;
        Session["CUAT"] = gvBusqueda.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        Session["MATRICULAT"]= gvBusqueda.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
        Session["PATERNOT"] = gvBusqueda.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        Session["MATERNOT"]= gvBusqueda.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        Session["PRIMERNOMBRET"] = gvBusqueda.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        Session["NUMERODOCUMENTO"] = gvBusqueda.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
        Response.Redirect("~/DoblePercepcion/wfrmCargarInformacionAsegurado.aspx");
        
    }


    protected void btnDp_Click(object sender, EventArgs e)
    {

        gvSinDP.Visible = true;
        gvSinDP.DataSourceID = null;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Sincon", "", "", "", "","", "","", 0, 0, ref mensaje);
        gvSinDP.DataSource = Encontrados;
        gvSinDP.DataBind();

       // gvSinDP2.Visible = true;

        gvSinDP2.DataSourceID = null;
        gvSinDP2.DataSource = Encontrados;
        gvSinDP2.DataBind();
        lblTitulo2.Visible = true;
        if (Encontrados.Rows.Count>0 )
        {
            btnImprimir.Visible=false;
            btnexcel.Visible = true;
        }

    }

    protected void gvSinDP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvSinDP.PageIndex = e.NewPageIndex;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Sincon", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        gvSinDP.DataSource = Encontrados;
        gvSinDP.DataBind();
        lblTitulo2.Visible=true;
       // exportar("Casos_Sin_Convenio.xls", gvSinDP);
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        gvSinDP2.Visible = true;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Sincon", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        gvSinDP2.DataSource = Encontrados;
        gvSinDP2.DataBind();
        if (gvSinDP2.Rows.Count != 0)
        {
            exportar("Casos_Sin_Convenio.xls", gvSinDP2);
        }
        else
        { 
            Master.MensajeError("Nose se puede descargar el Archivo","El archivo esta vacio");
        }
        gvSinDP2.Visible = false;
    }



    private void exportar(string nameReport, GridView wControl) // este es el metodo que crea el excel
    {
        HttpResponse response = Response;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pageToRender = new Page();
        HtmlForm form = new HtmlForm();
        form.Controls.Add(wControl);
        pageToRender.Controls.Add(form);
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
        response.Charset = "UTF-8";
        response.ContentEncoding = Encoding.Default;
        pageToRender.RenderControl(htw);
        response.Write(sw.ToString());
        response.End();
    }


    private void CrearArchivo(DataTable TablaArchivo, string NomArchivo, bool Solapar)
    {
        try
        {
            string RutaCrear = Session["CARPETA"].ToString();
            ManejoArchivo.CrearArchivo(TablaArchivo, RutaCrear + NomArchivo);
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al crear el Archivo.", ex.Message);
        }
    }

  
    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtPrimerApellido    , btnBuscar);
        AgregarJSAtributos(txtPrimerNombre, btnBuscar);
        AgregarJSAtributos(txtCI, btnBuscar);
        AgregarJSAtributos(txtCUA, btnBuscar);
        AgregarJSAtributos(txtSegundoApellido, btnBuscar);
        AgregarJSAtributos(txtSegundoNombre, btnBuscar);
        AgregarJSAtributos(txtMatricula, btnBuscar);


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
     
}