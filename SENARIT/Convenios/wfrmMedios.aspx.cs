using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using wcfServicioIntercambioPago.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfConvenios.Logica;

public partial class Convenios_wfrmMedios : System.Web.UI.Page
{
    clsInformacionLO Info = new clsInformacionLO();
    clsManejoArchivo ManejoArchivo = new clsManejoArchivo();
    string mensaje = null;
    DataTable Encontrados;
    Int64 NUP;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVistaPreviaMedio_Click(object sender, EventArgs e)
    {

        //Info.ActualizaEstados((int)Session["IdConexion"], "U", 1, ref mensaje);

        Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Medio", "", "", ""
                                                , "", "", "", "", 0, 0, ref mensaje);

        Session["Encontrados"] = Encontrados;
        gvMedio.Visible = true;
        gvMedio.DataSourceID = null;
        gvMedio.DataSource = Encontrados;
        gvMedio.DataBind();

        Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Resumen", "", "", ""
                                                , "", "", "", "", 0, 0, ref mensaje);

        gvResumen.Visible = true;
        gvResumen.DataSourceID = null;
        gvResumen.DataSource = Encontrados;
        gvResumen.DataBind();

        if (mensaje == null)
        {
            btnMedioExcel.Enabled = true;
            btnMedioTxt.Enabled = true;
            lblMensaje.Text = "SE GENERO EL MEDIO DE FORMA CORRECTA";
            this.ModalPopupExtender3pnlMensaje.Show();
        }
        else
        { 
        
        }
   }

    private bool CrearArchivo(DataTable TablaArchivo, string NomArchivo, bool Solapar)
    {
        try
        {

            //String CarpetaMedio = txtrutaID.Text+"/";
            String CarpetaMedio = Server.MapPath("~/Medios/Convenios/");

            //String CarpetaMedio = Server.MapPath("~/Medios/CruceDoblePercepcion/");
            //string RutaCrear = CarpetaMedio.ToString();
            string RutaCrear = CarpetaMedio;

            Session["CARPETA"] = CarpetaMedio;
            ManejoArchivo.CrearArchivo(TablaArchivo, RutaCrear + NomArchivo);
            return true;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al crear el Archivo.", ex.Message);
            return false;
        }
    }

    private void GenerarCRC(string RutaCompleta)
    {
        try
        {
            lblCRCtxt.Text = ManejoArchivo.GenerarCRC(RutaCompleta);
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al generar el código de seguridad", ex.Message);
        }
    }

    protected void btnMedioTxt_Click(object sender, EventArgs e)
    {
        Encontrados = Session["Encontrados"] as DataTable;
        //Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Medio", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        if (CrearArchivo(Encontrados, "MedioConvenio.TXT", true))
        {

            GenerarCRC(Session["CARPETA"] + "MedioConvenio.TXT");
            Master.MensajeOk("Se creo el medio correctamente");
            lblCRCtxt.Visible = true;
            lbl1.Visible = true;
            lbltxtDescarga.Visible = true;
            lbltxtDescargaCRC.Visible = true;
            btnActualizarParteEstado2.Enabled = true;

        }
    }
    protected void lbltxtDescarga_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/txt";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + "MedioConvenio.TXT");
        Response.WriteFile(Session["CARPETA"].ToString() + "MedioConvenio.TXT");
        Response.End();
    }
    protected void lbltxtDescargaCRC_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/txt";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + "MedioConvenio_CRC.TXT");
        Response.WriteFile(Session["CARPETA"].ToString() + "MedioConvenio_CRC.TXT");
        Response.End();
    }
    protected void btnMedioExcel_Click(object sender, EventArgs e)
    {

        Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Medio", "", "", ""
                                               , "", "", "", "", 0, 0, ref mensaje);
        if (gvMedio.Rows.Count != 0)
        {
            exportar("Medio_Covenio.xls", gvMedio);
        }
        else
        {
            Master.MensajeError("Nose se puede descargar el Archivo", "El archivo esta vacio");
        }
        gvMedio.Visible = false;
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
        //response1.End();
    }


    protected void btnActualizarEstados_Click(object sender, EventArgs e)
    {
        Info.ActualizaEstados((int)Session["IdConexion"], "U", 1, ref mensaje);
        if (mensaje == null)
        {
            lblMensaje.Text = "SE ACTUALIZÓ LOS ESTADOS DE FORMA CORRECTA YA PUEDE GENERAR EL MEDIO";
            this.ModalPopupExtender3pnlMensaje.Show();
            btnVistaPreviaMedio.Enabled = true;
        }
        else 
        {
            Master.MensajeError("NO SE PUDO ACTUALIZAR LOS ESTADOS", mensaje);
        }
    }
    protected void btnActualizarParteEstado2_Click(object sender, EventArgs e)
    {
        Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "CambioEstado", "", "", ""
                                               , "", "", "", "", 0, 0, ref mensaje);
        gvCambioEstado.Visible = true;
        gvCambioEstado.DataSourceID = null;
        gvCambioEstado.DataSource = Encontrados;
        gvCambioEstado.DataBind();

        Encontrados = Info.ObtieneDatos((int)Session["IdConexion"], "Q", "Resumen2", "", "", ""
                                       , "", "", "", "", 0, 0, ref mensaje);
        gvCantidadDeCasos.Visible = true;
        gvCantidadDeCasos.DataSourceID = null;
        gvCantidadDeCasos.DataSource = Encontrados;
        gvCantidadDeCasos.DataBind();

        if (mensaje == null)
        {
            lblMensaje.Text = "RESUEMEN DE LOS CASOS QUE CAMBIARAN DE ESTADO";
            this.ModalPopupExtender3pnlMensaje.Show();
            btnActualizar.Enabled = true;
            btnActualizar.Visible = true;
        }
        else
        {
            Master.MensajeError("NO SE PUDO ACTUALIZAR LOS ESTADOS", mensaje);
        }

    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        Info.ActualizaEstados((int)Session["IdConexion"], "U", 2, ref mensaje);
        if (mensaje == null)
        {
            Master.MensajeOk("se actualizo de forma correcta los estados");
            lblMensaje.Text = "SE ACTUALIZO LOS ESTADOS DE FORMA CORRECTA";
            this.ModalPopupExtender3pnlMensaje.Show();
        }
        else
        {
            Master.MensajeError("Nose Actualizo de forma Correcta los estados", mensaje);
        }
    }
}