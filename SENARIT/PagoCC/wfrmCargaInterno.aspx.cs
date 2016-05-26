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
using WcfServicioClasificador.Logica;
using wcfServicioIntercambioPago.Logica;
using wcfSeguridad.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;

public partial class PagoCC_wfrmCargaInterno : System.Web.UI.Page
{
    #region variables
    string prefijo = "",ruta;
    bool ban = false;
    int IDTM;
    Regex FormatoCampos;
    DataTable DTExpresiones;
    DataRow DRFormato;
    DataTable tabla = new DataTable("tabla");
    DataTable TablaErrores = new DataTable("TablaErrores");
    clsDetalleClasificador ides = new clsDetalleClasificador();
    clsManejoArchivo ManejoArchivo = new clsManejoArchivo();
    clsServicioIntercambio Automata = new clsServicioIntercambio();
    clsPagoCC PagoCC = new clsPagoCC();
    clsControlEnvios EnvioCC = new clsControlEnvios();
    clsSeguridad Seguridad = new clsSeguridad();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //HttpContext.Current.Server.ScriptTimeout = 360000;
        //ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 360000;
        if (!Page.IsPostBack)
        {
            ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 360000;
            HttpContext.Current.Server.ScriptTimeout = 360000;
            CargarTipoMedio();
            CargarEntidad();
            CargaPeriodos();
            Master.MensajeCancel();
            lblDescargaError.Visible = false;
        }
        else
        {
            lblDescargaError.Visible = false;
        }
    }

    #region Cargado

    protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int IdRol = Convert.ToInt32(Seguridad.ListaDatosConexion((int)Session["IdConexion"]).Rows[0][2].ToString());
        if (ddlEntidad.SelectedIndex == 0 || ddlTipoMedio.SelectedIndex == 0)
        {
            Response.Write("<script>window.alert('Por favor debe seleccionar Entidad y/o Tipo de Medio.');</script>");
            ddlPeriodo.SelectedIndex = 0;
            return;
        }
        if (Convert.ToInt32(ddlPeriodo.SelectedItem.ToString())<201512 && IdRol==115)
        {
            Response.Write("<script>window.alert('Este periodo ya fue cargado en los históricos');</script>");
            ddlPeriodo.SelectedIndex = 0;
            return;
        }
        if (Convert.ToInt32(ddlPeriodo.SelectedItem.ToString()) < 201603 && IdRol == 86)
        {
            Response.Write("<script>window.alert('Este periodo ya fue cargado en los históricos');</script>");
            ddlPeriodo.SelectedIndex = 0;
            return;
        }
        chbMedioFinal.Checked = false;
        chbSoloCRC.Checked = false;
        int nn = ObtieneNumeroEnvio();
        btnCarga.Enabled = true;
        fulArchivo.Enabled = true;
        if (nn < 100)
        {
            lblNumEnvio.Text = nn.ToString();
        }
        else if (nn > 120)//envio culminado... revisar CRC
        {
            chbSoloCRC.Checked = true;
            chbMedioFinal.Checked = false;
            lblNumEnvio.Text = (nn - 120).ToString();
            Response.Write("<script>window.alert('El envio fué culminado, solo verificar CRC.');</script>");
            chbContinuo.Checked = false;
            chbContinuo.Enabled = false;
        }
        else if (nn > 100 && nn < 120)//envio aprobado... revisar medio final
        {
            chbMedioFinal.Checked = true;
            chbSoloCRC.Checked = false;
            lblNumEnvio.Text = (nn - 100).ToString();
            Response.Write("<script>window.alert('El envio fué aprobado, solo cargar como medio final.');</script>");
            chbContinuo.Checked = false;
            chbContinuo.Enabled = false;
        }
        else
        {
            //Label5.Text = "No puede volver a cargar este tipo de envio, aún no se dio respuesta.";
            Response.Write("<script>window.alert('No puede volver a cargar este tipo de envio, aún no se dio respuesta.');</script>");
            chbContinuo.Checked = false;
            chbContinuo.Enabled = false;
            btnCarga.Enabled = false;
            fulArchivo.Enabled = false;
        }
        ddlEntidad.Enabled = false;
        ddlTipoMedio.Enabled = false;
        //string mensaje = null;--esto para comprobar que no esten con errores
        //DataTable RevisaFinal = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "RespuestaErrores", ddlEntidad.SelectedValue
        //                                     , ddlTipoMedio.SelectedValue, ddlPeriodo.SelectedItem.ToString(), "X", 0, ref mensaje);
        //if (mensaje == null)//(RevisaFinal.Rows.Count == 0)
        //{
        //    chbMedioFinal.Checked = true;
        //    chbMedioFinal.Enabled = true;
        //}
    }

    protected void btnCarga_Click(object sender, EventArgs e)
    {
        gvErrores.DataSource = null;
        gvErrores.DataBind();
        ObtenerExpresiones(ddlTipoMedio.SelectedValue);
        Boolean fileOK = false;
        String CarpetaMedio = Server.MapPath("~/Medios/Intercambio/");//si no descarga usar este + el resto de la ruta para direccionar arcivos de download
        Session["ARCH"] = fulArchivo.FileName.ToUpper();
        if (fulArchivo.HasFile && fulArchivo.FileBytes.Length>10)
        {
            fileOK = RevisarFormato(fulArchivo.FileName.ToUpper());
        }
        else
        {
            Master.MensajeError("Archivo vacío", "No es necesario cargar el archivo vacío");
        }
        if (fileOK && fulArchivo.HasFile)
        {
            btnCarga.Enabled = false;
            fulArchivo.Enabled = false;
            try
            {
                CarpetaMedio += ddlTipoMedio.SelectedValue + ddlEntidad.SelectedValue + "\\" + ddlPeriodo.SelectedItem.ToString() + "\\";
                Directory.CreateDirectory(CarpetaMedio);
                Session["CARPETA"] = CarpetaMedio;
                if (chbMedioFinal.Checked)
                {
                    ruta = CarpetaMedio + fulArchivo.FileName.ToUpper().Replace(".TXT", "_Final.TXT");
                }
                else if (chbSoloCRC.Checked)
                {
                    ruta = CarpetaMedio + fulArchivo.FileName.ToUpper().Replace(".TXT","_Oficial.TXT");
                    fulArchivo.PostedFile.SaveAs(ruta);
                    CompararCRC(ruta);
                    return;
                }
                else
                {
                    ruta = CarpetaMedio + fulArchivo.FileName.ToUpper();
                }
                fulArchivo.PostedFile.SaveAs(ruta);
                ControlEnvio("Registro", "P");
                GeneraTablaDinamica(Convert.ToInt32(DRFormato.ItemArray[0]));
                CargarEstructuraDinamica();
                RevisaColumnas(ddlTipoMedio.SelectedValue.ToString());//agrega columnas para la temp que no estan en el medio
                if (tabla.Rows.Count > 0 && ban)
                {
                    if (!chbMedioFinal.Checked)
                    {
                        EliminaTemporal(ddlTipoMedio.SelectedValue.ToString(), ddlEntidad.SelectedValue.ToString(), Convert.ToInt32((lblNumEnvio.Text)));
                    }
                    else
                    {
                        EliminaTemporal(ddlTipoMedio.SelectedValue.ToString()+"F", ddlEntidad.SelectedValue.ToString(), Convert.ToInt32((lblNumEnvio.Text)));
                    }
                    string ErrorCarga = null;
                    ErrorCarga= inserta_temporal(ddlTipoMedio.SelectedValue.ToString());
                    if (ErrorCarga == null)
                    {
                        ControlEnvio("Aceptado", "A");
                        Master.MensajeOk("El archivo está correcto, se procede a la Pre-validación");
                    }
                    else
                    {
                        lblMuestra.Text = "El archivo no pudo ser cargado por " + ErrorCarga;
                        Master.MensajeError("El archivo no pudo ser cargado...", ErrorCarga);
                    }
                    if (chbMedioFinal.Checked && ErrorCarga==null)
                    {
                        RevisaMedioFinal(ddlTipoMedio.SelectedValue, ddlEntidad.SelectedValue);
                    }
                    else if (chbMedioFinal.Checked == false && ErrorCarga == null && chbContinuo.Checked==false)
                    {
                        Prevalida(ddlEntidad.SelectedValue, ddlPeriodo.SelectedValue, ddlTipoMedio.SelectedValue, Convert.ToInt32(lblNumEnvio.Text));
                    }
                    else if (chbContinuo.Checked == true && ErrorCarga == null)
                    {
                        RevisionContinua(ddlEntidad.SelectedValue, ddlPeriodo.SelectedValue, ddlTipoMedio.SelectedValue, Convert.ToInt32(lblNumEnvio.Text));
                    }
                }
                if (tabla.Rows.Count == 0 && !ddlTipoMedio.SelectedValue.ToString().StartsWith("A"))
                {
                    Response.Write("<script>window.alert('El archivo que intenta cargar esta vacio\nNo se realizó la carga');</script>");
                }
            }
            catch (Exception ex)
            {
                lblMuestra.Text = "El archivo no pudo ser cargado por " + ex.Message;
                Master.MensajeError("El archivo no pudo ser cargado...", ex.Message);
            }
        }
        else
        {
            Master.MensajeError("El archivo que intenta cargar no es el correcto o esta vacio", "Intente cargando otro archivo");
        }
    }

    private void Prevalida(string Entidad, string Periodo, string CodigoTipoMedio, int NumEnvio)
    {
        clsPagoCC pv = new clsPagoCC();
        DataTable DTErroresPrevalida = pv.Prevalida(Entidad, Periodo, CodigoTipoMedio, NumEnvio,false);
        Session["ERRORES"] = DTErroresPrevalida;
        if (DTErroresPrevalida.Rows.Count > 0)
        {
            ControlEnvio("Error", "E");
            gvErrores.DataSource = DTErroresPrevalida;
            gvErrores.DataBind();
            Session["ARCH_RESP"] = "Error_" + Session["ARCH"].ToString();
            CrearArchivo(DTErroresPrevalida, Session["ARCH_RESP"].ToString(), true);
            gvErrores.Visible = true;
            lblTituloGrid.Text = DTErroresPrevalida.Rows.Count.ToString() + " Errores en la Prevalidación";
            lblTituloGrid.Visible = true;
            lblDescargaError.Visible = true;
            Master.MensajeError("Se encontró " + DTErroresPrevalida.Rows.Count.ToString() + " casos con error!", "Por favor revise la respuesta de errores y corrija");
        }
        else
        {
            gvErrores.Visible = false;
            gvErrores2.Visible = false;
            lblDescargaError.Visible = false;
            lblTituloGrid.Visible = false;
            //Response.Write("<script>window.alert('El archivo no tiene errores de pre-validación.\nSe procederá a la revisión general');</script>");
            Master.MensajeOk("El archivo no tiene errores de estructura, ni pre - validación, se procederá a su revisión general");
            hfRuta.Value = Session["CARPETA"].ToString() + Session["ARCH"].ToString();
            GenerarCRC(hfRuta.Value);
            ControlEnvioCC("REGISTRO", "P", 0);
        }
        odsBandejaInterno.Update();
        gvBandeja.DataBind();
    }

    protected void gvErrores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvErrores.PageIndex = e.NewPageIndex;
        gvErrores.DataSource = Session["ERRORES"] as DataTable;
        gvErrores.DataBind();
        int x = gvErrores.PageIndex;
        lblDescargaError.Visible = true;
    }

    protected void gvErrores2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvErrores2.PageIndex = e.NewPageIndex;
        gvErrores2.DataSource = Session["ERRORES"] as DataTable;
        gvErrores2.DataBind();
        int x = gvErrores2.PageIndex;
        lblDescargaError.Visible = true;
    }

    private void RevisaMedioFinal(string TipoMedio, string Entidad)
    {
        try
        {
            DataTable fallas = PagoCC.RevisaMediosFinales(TipoMedio, Entidad);
            if (fallas.Rows.Count > 0)
            {
                ControlEnvio("Error", "E");
                gvErrores2.DataSource = fallas;
                gvErrores2.DataBind();
                gvErrores2.Visible = true;
                lblTituloGrid.Text = "Errores en el Medio Final";
                lblTituloGrid.Visible = true;
                lblDescargaError.Visible = true;
                Master.MensajeError("El archivo tiene diferencias con el envio aprobado.","Revise el detalle de diferencias y corrija.");
                if (fallas.Rows[0][0].ToString().StartsWith("Caso"))
                {
                    Master.MensajeError("El envío cargado no cuenta con la cantidad de casos correcta", "Por favor revice y cargue el envío Aprobado");
                    //solo generar el arhcivo para su descarga
                    //ManejoArchivo.CrearArchivo(fallas, ruta.Replace(".TXT", "_Errores.TXT"));
                    lblDescargaError.Visible = false;
                    lblTituloGrid.Text += " - Casos Faltantes";
                }
                else
                {
                    lblDescargaError.Visible = false;
                    lblTituloGrid.Text += " - Campos Modificados";
                    //mostrar la grilla de campos diferentes resaltar las cells
                    if (TipoMedio == "PR" || TipoMedio == "PF")
                    {
                        foreach (GridViewRow fila in gvErrores2.Rows)
                        {
                            for (int z = 0; z < 13; z++)
                            {
                                if (z % 2 == 0)
                                {
                                    if (fila.Cells[z + 6].Text != fila.Cells[z + 7].Text)
                                    {
                                        fila.Cells[z + 6].BackColor = Color.GreenYellow;
                                        fila.Cells[z + 7].BackColor = Color.OrangeRed;
                                    }
                                }
                            }
                        }
                    }
                    if (TipoMedio == "CR" || TipoMedio == "CF" || TipoMedio=="CT")
                    {
                        foreach (GridViewRow fila in gvErrores2.Rows)
                        {
                            for (int z = 0; z < 41; z++)
                            {
                                if (z % 2 == 0)
                                {
                                    if (fila.Cells[z + 6].Text != fila.Cells[z + 7].Text)
                                    {
                                        fila.Cells[z + 6].BackColor = Color.GreenYellow;
                                        fila.Cells[z + 7].BackColor = Color.OrangeRed;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string mensaje=null;
                ControlEnvio("Culminado", "C");
                string CRCfinal = ManejoArchivo.GenerarCRC(ruta);
                int cantidad = Convert.ToInt32(hfCantidad.Value);
                EnvioCC.ModificaEnvio((int)Session["IdConexion"], "U", ddlEntidad.SelectedValue, ddlTipoMedio.SelectedValue
                      , ddlPeriodo.SelectedItem.ToString(), Convert.ToInt32(lblNumEnvio.Text), "C", CRCfinal, cantidad, ref mensaje);
                Master.MensajeOk("Medio Final correcto y fue CULMINADO con Código de Seguridad: "+ CRCfinal);
                Response.Write("<script>window.alert('El Medio Final está correcto\nPuede enviar esta información como medio oficial');</script>");
                lblTituloGrid.Visible = false;
                gvErrores.Visible = false;
                gvErrores2.Visible = false;
                if (TipoMedio == "CR" || TipoMedio == "CF")
                {
                    //SOLO CONCIL: si todo esta correcto borrar los anteriores y conservar el medio final con los cmabios de SD a DC + fechaDev
                    EliminaTemporal(ddlTipoMedio.SelectedValue.ToString() + "FOK", ddlEntidad.SelectedValue.ToString(), Convert.ToInt32((lblNumEnvio.Text)));
                }
                
            }
            EliminaTemporal(ddlTipoMedio.SelectedValue.ToString() + "F", ddlEntidad.SelectedValue.ToString(), Convert.ToInt32((lblNumEnvio.Text)));
            odsBandejaInterno.Update();
            gvBandeja.DataBind();
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al comparar el medio final", ex.Message);
        }
    }

    private void CompararCRC(string r)
    {
        string mensaje = null;
        string NuevoCRC = ManejoArchivo.GenerarCRC(r);
        string CRCculminado = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ObtieneEnvio", ddlEntidad.SelectedValue
                                                    , ddlTipoMedio.SelectedValue, ddlPeriodo.SelectedItem.ToString(), "C", 0
                                                    , ref mensaje).Rows[0]["CodigoSeguridad"].ToString();
        if (NuevoCRC != CRCculminado)
        {
            Master.MensajeError("Archivo Erroneo\nNo se culminó el envío con este archivo", "El CRC correcto es: " + CRCculminado);
        }
        else
        {
            Master.MensajeOk("El archivo es correcto!!\nSe almacenó el archivo como medio oficial");
        }
    }

    private void RevisionContinua(string Entidad, string Periodo, string CodigoTipoMedio, int NumEnvio)
    {
        string mensaje = null;
        DataTable DTErroresPreva = PagoCC.Prevalida(Entidad, Periodo, CodigoTipoMedio, NumEnvio, true);
        if (DTErroresPreva.Rows.Count == 0)
        {
            hfRuta.Value = Session["CARPETA"].ToString() + Session["ARCH"].ToString();
            GenerarCRC(hfRuta.Value);
            ControlEnvioCC("REGISTRO", "P", 0);
        }
        DataTable DTErrorCentral = PagoCC.ValidacionCentral(CodigoTipoMedio, Entidad, Periodo, NumEnvio , true);
        if (DTErrorCentral.Rows.Count == 0)
        {
            Master.MensajeOk("Se realizó la revisión completa y no se encontraron errores");
            if (DTErroresPreva.Rows.Count==0)//(CodigoTipoMedio != "RR" && CodigoTipoMedio != "RF")
            {
                EnvioCC.ModificaEnvio((int)Session["IdConexion"], "U", Entidad, CodigoTipoMedio, ddlPeriodo.SelectedItem.ToString()
                                        ,NumEnvio,"A",hfCRC.Value,Convert.ToInt32(hfCantidad.Value), ref mensaje);
                odsBandejaInterno.Update();
                gvBandeja.DataBind();
            }   
        }
        else
        {
            Session["ERRORES"] = DTErrorCentral;
            Session["ARCH_RESP"] = "R" + Session["ARCH"].ToString();
            gvErrores.DataSource = DTErrorCentral;
            gvErrores.DataBind();
            gvErrores.Visible = true;
            lblTituloGrid.Text = DTErrorCentral.Rows.Count.ToString() + " Errores en la Revisón Continua";
            lblTituloGrid.Visible = true;
            lblDescargaError.Visible = true;
            Master.MensajeError("Se realizó la revisión completa y se detectaron " + DTErrorCentral.Rows.Count.ToString() + " errores", "Por favor despliegue los errores desde la bandeja");
            CrearArchivo(DTErrorCentral, Session["ARCH_RESP"].ToString(), true);
            if (DTErroresPreva.Rows.Count == 0)//(CodigoTipoMedio != "RR" && CodigoTipoMedio != "RF")
            {
                EnvioCC.ModificaEnvio((int)Session["IdConexion"], "U", Entidad, CodigoTipoMedio, ddlPeriodo.SelectedItem.ToString()
                                            , NumEnvio, "E", hfCRC.Value, Convert.ToInt32(hfCantidad.Value), ref mensaje);
                odsBandejaInterno.Update();
                gvBandeja.DataBind();
            }
        }

    }

    #endregion

    #region Inicializa

    private void CargarTipoMedio()
    {
        clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlTipoMedio.DataSource = clas.ListarDetalleClasificador(12);
        ddlTipoMedio.DataValueField = "CodigoDetalleClasificador";
        ddlTipoMedio.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoMedio.DataBind();
        ddlTipoMedio.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlTipoMedio.SelectedValue = "0";
        //ahora eliminamos los tipos de medios que no deben cargar
        //esto mejor hacerlo desde el SP, pero como esta con clasificadores esto
        DataTable DatosConex = Seguridad.ListaDatosConexion((int)Session["IdConexion"]);
        int IdRol = Convert.ToInt32(DatosConex.Rows[0][2].ToString());
        if (IdRol == 86)
        {
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("CF")); //.RemoveAt(5);
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("CR"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("CT"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("RR"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("RF"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("PE"));
        }
        if (IdRol == 115)
        {
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("ATR")); //.RemoveAt(1);
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("ATF"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("ABR"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("ABF"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("PR"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("PF"));
            ddlTipoMedio.Items.Remove(ddlTipoMedio.Items.FindByValue("PE"));
        }
    }

    private void CargarEntidad()
    {
        clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlEntidad.DataSource = clas.ListarDetalleClasificador(16);
        ddlEntidad.DataValueField = "CodigoDetalleClasificador";
        ddlEntidad.DataTextField = "DescripcionDetalleClasificador";
        ddlEntidad.DataBind();
        ddlEntidad.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlEntidad.SelectedValue = "0";
        ddlEntidad.Items.Remove(ddlEntidad.Items.FindByValue("11"));
        ddlEntidad.Items.Remove(ddlEntidad.Items.FindByValue("03"));
    }

    private void CargaPeriodos()
    {
        DateTime fecha = DateTime.Now.Date;
        ddlPeriodo.Items.Capacity = 36;
        for (int x = 0; x <= 35; x++)
        {
            ddlPeriodo.Items.Add(fecha.Year.ToString() + fecha.Month.ToString("00"));
            fecha = fecha.AddMonths(-1);
        }
        ddlPeriodo.Items.Insert(0, new ListItem("--", "0"));
        ddlPeriodo.SelectedValue = "0";
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PagoCC/wfrmCargaInterno.aspx");
    }

    #endregion

    #region Importacion

    private string inserta_temporal(string TipoMedio)
    {
        clsCargarMedios cargar = new clsCargarMedios();
        string mensaje = null;
        if (TipoMedio == "ATF")
        {
            //tabla.Columns.Add("TipoPension", Type.GetType("System.String"));
            tabla.Columns[28].SetOrdinal(27);
        }
        mensaje = cargar.InsertaBulk(tabla, DRFormato.ItemArray[8].ToString().Trim());
        if (mensaje==null)
        {
            //Response.Write("<script>window.alert('El archivo no tiene errores de estructura.\nSe procede a la revisión general');</script>");
            lblMuestra.Text = tabla.Rows.Count.ToString() + " registros cargados exitosamente.";
            Master.MensajeOk("El archivo no tiene errores de estructura.\nSe procede a la prevalidación");
        }
        return mensaje;
    }

    private bool EliminaTemporal(string TipoMedio, string Entidad, int Envio)
    {
        clsCargarMedios elim = new clsCargarMedios();
        try
        {
            elim.EliminarTemporal(TipoMedio, Entidad, Envio);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Intercambio

    private bool RevisarFormato(string NombreArchivo)
    {
        //System.Text.RegularExpressions.Regex automata = new Regex(@DRFormato.ItemArray[7].ToString());
        string mensaje = null;
        bool resultado = Automata.RevisaNombre((int)Session["IdConexion"],NombreArchivo, ddlTipoMedio.SelectedValue,ref mensaje);
        if (resultado && !chbMedioFinal.Checked && !chbSoloCRC.Checked)
        {
            int pos = NombreArchivo.IndexOf("2");
            if (NombreArchivo.Substring(pos, 8) != ddlPeriodo.SelectedItem.ToString() + "0" + ObtieneNumeroEnvio().ToString())
            {
                resultado = false;
            }
        }
        return resultado;
    }

    private void ObtenerExpresiones(string TipoMedio)
    {
        clsServicioIntercambio inter = new clsServicioIntercambio();
        //DRFormato = inter.ListarArchivoTodo(0, TipoMedio).Rows[0];
        string mensaje = null;
        DRFormato = inter.ListarTipoMedio((int)Session["IdConexion"],"Q",0, TipoMedio,ref mensaje).Rows[0];
        IDTM = Convert.ToInt16(DRFormato.ItemArray[0]);
        //DTExpresiones = inter.ListarCampoTodo(IDTM, "MEDIO");
        DTExpresiones = inter.ListarCampoMedio((int)Session["IdConexion"],"Q", IDTM, "MEDIO",ref mensaje);
    }

    private void GeneraTablaDinamica(int IdArchivo)
    {
        try
        {
            //generamos nuestra propia tabla de respuesta
            /*TablaErrores.Columns.Add(new DataColumn("Linea", Type.GetType("System.String")));
            TablaErrores.Columns.Add(new DataColumn("Columna", Type.GetType("System.String")));
            TablaErrores.Columns.Add(new DataColumn("Detalle", Type.GetType("System.String")));*/
            //generamos automaticamente la tabla segun tipo medio
            string mensaje = null;
            DataSet tablas = Automata.GenerarTablaDinamica((int)Session["IdConexion"],ddlTipoMedio.SelectedValue,ref mensaje);
            tabla=tablas.Tables[0];
            TablaErrores = tablas.Tables[1];
        }
        catch (Exception er)
        {
            Master.MensajeError("Error al generar la tabla dinamicamente",er.Message);
        }
    }

    private void CargarEstructuraDinamica()
    {
        DataSet Dinamico = Automata.CargaTablaDinamica(tabla, TablaErrores, DTExpresiones, ruta);
        tabla=Dinamico.Tables[0];
        TablaErrores=Dinamico.Tables[1];
        TablaErrores = Automata.ValidarCampos(tabla, DTExpresiones, TablaErrores);
        ValidacionPropia();
            if (TablaErrores.Rows.Count > 0)
            {
                lblMuestra.Text = "El medio contiene errores\nPor favor revisar";
                MostrarErrores();
            }
            else
            {
                ban = true;
                hfCantidad.Value = (tabla.Rows.Count).ToString();
            }

    }

    private void ValidacionPropia()
    {
        int nfp = 0;
        foreach (DataRow fila in tabla.Rows)
        {
            if (fila.ItemArray[0].ToString() != ddlEntidad.SelectedValue)
            {
                TablaErrores.Rows.Add(nfp+1, 1, "cod_fuente no es el correspondiente");
            }
            nfp += 1;
        }
    }

    private void RevisaColumnas(string Valor)
    {
        //agregamos filas propias
        string v = "";//esto para distinguir medios finales
        if (chbMedioFinal.Checked)
        {
            v = "F";
        }
        switch (Valor)
        {
            case "PR":
            case "PF":
                //Automata.AgregaColumnas(tabla, "PorcentajeAsignacion", "String", "0");//12 //este ya entra en los nuevos medios
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);//12
                Automata.AgregaColumnas(tabla, "NUP", "String", "0");//12
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");
                break;
            case "ATR":
                //Automata.AgregaColumnas(tabla, "TipoPension", "String", "J");//12//estos 3 entra nuevos medios
                //Automata.AgregaColumnas(tabla, "ComplementoSEGIP", "String", "");//12
                Automata.AgregaColumnas(tabla, "FraccionComplementaria", "Decimal", "0");//26
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);//27
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");//28
                break;
            case "ATF":
                Automata.AgregaColumnas(tabla, "TipoPension", "String", "J");//12 modifico los medios pa se pueda cargar
                //Automata.AgregaColumnas(tabla, "ComplementoSEGIP", "String", "");//12 idem arriba
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);//27
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");//28
                break;
            case "ABR":
            case "ABF":
                //Automata.AgregaColumnas(tabla, "FechaFallecimiento", "String", "");//12 estos 2 ya en nuevos medios
                //Automata.AgregaColumnas(tabla, "ComplementoSEGIP", "String", "");//12
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");
                break;
            case "CR":
            case "CF":
            case "CT":
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");//12
                Automata.AgregaColumnas(tabla, "CodigoProceso", "String", "");//12
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);
                Automata.AgregaColumnas(tabla, "NUP", "String", "0");
                break;
            case "RR":
            case "RF":
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);
                break;
        }
    }

    #endregion

    #region Archivo

    private void MostrarErrores()
    {
        Session["ERRORES"] = TablaErrores;
        gvErrores2.DataSource = TablaErrores;
        gvErrores2.DataBind();
        lblTituloGrid.Text = "Errores de Estructura";
        lblTituloGrid.Visible = true;
        //Response.Write("<script>window.alert('El archivo tiene errores de estructura.\nPor favor revisar');</script>");
        Master.MensajeError("El archivo tiene errores de estructura.", "Por favor revice la estructura del contenido del archivo");
        CrearArchivo(TablaErrores, "Respuesta_" + fulArchivo.FileName, true);
        ControlEnvio("Error","E");
        RegistraError(TablaErrores, Session["ARCH"].ToString());
        lblDescargaError.Visible = true;
        Session["ARCH_RESP"] = "Respuesta_" + fulArchivo.FileName;
    }

    private void ControlEnvio(string TipoControl,string Estado)
    {
        try
        {
            string NombreArchivo;
            if (chbMedioFinal.Checked)
            {
                NombreArchivo = fulArchivo.FileName.ToUpper() + "_Final";
            }
            else
            {
                NombreArchivo = fulArchivo.FileName.ToUpper();
            }
            string mensaje = null;
            ManejoArchivo.ControlEnvio((int)Session["IdConexion"],TipoControl, ddlTipoMedio.SelectedValue
                        , ddlEntidad.SelectedValue + "-" + NombreArchivo, Estado,ref mensaje);
            if (mensaje != null)
            {
                Master.MensajeError("Error al registrar el Envio", mensaje);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al registrar el Envio", ex.Message);
        }
    }

    private void RegistraError(DataTable DTErrores, string NomArchivo)
    {
        clsServicioIntercambio err = new clsServicioIntercambio();
        //int IDCA = Convert.ToInt32(err.ObtenerArchivoIntercambio(ddlEntidad.SelectedValue + "-" + NomArchivo).Rows[0][0]);
        string mensaje = null;
        int IDCA = Convert.ToInt32(err.ListarArchivoIntercambio((int)Session["IdConexion"],"Q",ddlEntidad.SelectedValue + "-" + NomArchivo
                                    ,ref mensaje).Rows[0][0]);
        foreach (DataRow r in DTErrores.Rows)
        {
            err.RegistraErroresArchivo((int)Session["IdConexion"], "I", IDCA, Convert.ToInt32(r.ItemArray[0]), Convert.ToInt32(r.ItemArray[1])
                                        , r.ItemArray[2].ToString(), ref mensaje);
        }
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

    protected void lblDescargaError_Click(object sender, EventArgs e)
    {
        string rutaDescarga = Session["CARPETA"].ToString() + Session["ARCH_RESP"].ToString();
        if (File.Exists(rutaDescarga))
        {
            Response.Clear();
            Response.ContentType = "application/txt";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Session["ARCH_RESP"].ToString());
            Response.WriteFile(Session["CARPETA"].ToString() + Session["ARCH_RESP"].ToString());
            Response.End();
        }
        else
        {
            Master.MensajeError("Imposible Descargar el archivo", "El archivo no se encuentra disponible o no existe");
        }
    }

    private void GenerarCRC(string RutaCompleta)
    {
        try
        {
            hfCRC.Value = ManejoArchivo.GenerarCRC(RutaCompleta);
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al generar el código de seguridad", ex.Message);
        }
    }

    #endregion

    #region Envio

    private void ControlEnvioCC(string Tipo, string Estado, int Fila)
    {
        int NE = ObtieneNumeroEnvio();
        string mensaje = null;
        clsControlEnvios env = new clsControlEnvios();
        if (Tipo == "REGISTRO")
        {
            env.RegistraEnvio((int)Session["IdConexion"], "I", ddlEntidad.SelectedValue, ddlTipoMedio.SelectedValue, ddlPeriodo.SelectedItem.ToString()
                                , NE, Estado, hfCRC.Value, hfRuta.Value, Convert.ToInt32(hfCantidad.Value), ref mensaje);
        }
        if (Tipo == "ACTUALIZA")
        {
            string CodEntidad = gvBandeja.DataKeys[Fila].Values["CodigoEntidad"].ToString();
            string CodMedio = gvBandeja.DataKeys[Fila].Values["CodigoMedio"].ToString();
            env.ModificaEnvio((int)Session["IdConexion"], "U", CodEntidad, CodMedio, gvBandeja.Rows[Fila].Cells[5].Text, Convert.ToInt32(gvBandeja.Rows[Fila].Cells[6].Text)
                               , Estado, gvBandeja.Rows[Fila].Cells[8].Text, Convert.ToInt32(gvBandeja.Rows[Fila].Cells[11].Text), ref mensaje);
        }
    }

    private int ObtieneNumeroEnvio()
    {
        clsControlEnvios env = new clsControlEnvios();
        string mensaje = null;
        DataTable envio = env.ObtieneVista((int)Session["IdConexion"], "Q", "ObtieneEnvio", ddlEntidad.SelectedValue, ddlTipoMedio.SelectedValue, ddlPeriodo.SelectedItem.ToString(), "", 0, ref mensaje);
        if (envio == null)//si no hay envio
        {
            return 1;
        }
        else
        {
            if (envio.Rows[0]["Estado"].ToString() == "ERROR")//estado de ERROR--respuesta de envio despues de la revison central
            {
                return Convert.ToInt32(envio.Rows[0]["NumeroEnvio"]) + 1;
            }
            else if (envio.Rows[0]["Estado"].ToString() == "FALLIDO")//cuando no paso la prevalidacion sigue con el mismo numero de envio
            {
                return Convert.ToInt32(envio.Rows[0]["NumeroEnvio"]);
            }
            else if (envio.Rows[0]["Estado"].ToString() == "CULMINADO")
            {
                return 120 + Convert.ToInt32(envio.Rows[0]["NumeroEnvio"]);//el envio está culminado, solo se puede verificar CRC,igual pasamos el num envio
            }
            else if (envio.Rows[0]["Estado"].ToString() == "APROBADO")
            {
                return 100 + Convert.ToInt32(envio.Rows[0]["NumeroEnvio"]);//Envio aprobado, solo puede revisarse medio final, igual pasmos el numero envio
            }
            else
            {
                return 100;//cuando no puede cargar
            }
        }
    }

    protected void gvBandeja_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvBandeja.Rows)
        {
            if (row.Cells[7].Text == "APROBADO" || row.Cells[7].Text == "PENDIENTE")
            {
                //12-revisar;13-ver errores;14-vermedio
                row.Cells[13].Enabled = false;
                row.Cells[13].ForeColor = Color.Gray;
            }
            if (row.Cells[7].Text == "EJECUTANDO")
            {
                row.Cells[12].Enabled = false;
                row.Cells[12].ForeColor = Color.Gray;
                row.Cells[13].Enabled = false;
                row.Cells[13].ForeColor = Color.Gray;
                row.Cells[14].Enabled = false;
                row.Cells[14].ForeColor = Color.Gray;
            }
            /*
            else if (row.Cells[7].Text == "PENDIENTE")
            {
                //row.Cells[13].Enabled = false;
                row.Cells[14].Enabled = false;
                //row.Cells[13].ForeColor = Color.Gray;
                row.Cells[14].ForeColor = Color.Gray;
            }*/
        }
    }

    protected void gvBandeja_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        string CodEntidad = gvBandeja.DataKeys[indice].Values["CodigoEntidad"].ToString();
        string CodMedio = gvBandeja.DataKeys[indice].Values["CodigoMedio"].ToString();
        string RutaRep= gvBandeja.DataKeys[indice].Values["RutaRepositorio"].ToString();
        Session["FilaBandeja"] = indice;
        //int IdControl =Convert.ToInt32(gvBandeja.DataKeys[indice].Values["IdControlEnvio"]);
        //obtenemos el archivo y la ruta para ponerlos en sesion
            int f = RutaRep.Length;
            int i = RutaRep.LastIndexOf("\\");
            string archivo = RutaRep.Substring(i + 1, f - i - 1);
            Session["ARCH_RESP"] = "R" + archivo;
            //Session["CARPETA"] = RutaRep.Replace(archivo, "R" + archivo);
            string carpeta = RutaRep.Substring(0, i + 1);
            Session["CARPETA"] = RutaRep.Substring(0, i+1);
        string mensaje = null;
        if (e.CommandName == "cmdRevisar")
        {
            gvMedios.Visible = false;
            lblTituloMedio.Visible = false;
            txtCUA.Visible = false;
            btnBuscar.Visible = false;
            ControlEnvioCC("ACTUALIZA", "X", indice);
            RevisionCentral(CodEntidad, gvBandeja.Rows[indice].Cells[5].Text, CodMedio, Convert.ToInt32(gvBandeja.Rows[indice].Cells[6].Text), indice,"R"+archivo);
        }
        if (e.CommandName == "cmdErrores")
        {
            Session["ERRORES"] = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "RespuestaErrores", CodEntidad, CodMedio, gvBandeja.Rows[indice].Cells[5].Text
                                                    , gvBandeja.Rows[indice].Cells[7].Text, Convert.ToInt32(gvBandeja.Rows[indice].Cells[6].Text), ref mensaje);
            gvErrores.DataSource = Session["ERRORES"] as DataTable;
            gvErrores.DataBind();
            gvErrores.Visible = true;
            lblTituloGrid.Text = (Session["ERRORES"] as DataTable).Rows.Count.ToString() + " errores en Validación Central";
            lblTituloGrid.Visible = true;
            lblDescargaError.Visible = true;
            gvMedios.Visible = false;
            lblTituloMedio.Visible = false;
            txtCUA.Visible = false;
            btnBuscar.Visible = false;
        }
        if (e.CommandName == "cmdMedio")
        {
            Session["VERMEDIO"] = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "VerMedio", CodEntidad, CodMedio, gvBandeja.Rows[indice].Cells[5].Text
                                , gvBandeja.Rows[indice].Cells[7].Text, Convert.ToInt32(gvBandeja.Rows[indice].Cells[6].Text), ref mensaje);
            gvMedios.DataSource = Session["VERMEDIO"] as DataTable;
            gvMedios.DataBind();
            gvMedios.Visible = true;
            lblTituloMedio.Visible = true;
            txtCUA.Visible = true;
            btnBuscar.Visible = true;
            lblTituloMedio.Text = (Session["VERMEDIO"] as DataTable).Rows.Count.ToString() + " registros en " + gvBandeja.Rows[indice].Cells[4].Text;
            //string rutacompleta = gvBandeja.DataKeys[indice].Values["RutaCompleta"].ToString();
            //Response.WriteFile(rutacompleta);
            hfRutaArchivoError.Value = Session["ARCH_RESP"].ToString();
        }
    }

    private void RevisionCentral(string Entidad, string Periodo, string TipoMedio, int NumeroEnvio, int Indice, string Archivo)
    {
        DataTable Resultado = PagoCC.ValidacionCentral(TipoMedio, Entidad, Periodo, NumeroEnvio,false);
        lblDescargaError.Visible = false;
        gvErrores.Visible = false;
        gvErrores2.Visible = false;
        lblTituloGrid.Visible = false;
        if (Resultado.Rows.Count == 0)
        {
            Master.MensajeOk("Se realizó la revisión central y no se encontraron errores");
            if (TipoMedio != "RR" && TipoMedio != "RF")
            {
                ControlEnvioCC("ACTUALIZA", "A", Indice);
            }
            odsBandejaInterno.Update();
            gvBandeja.DataBind();
        }
        else
        {
            Master.MensajeError("Se realizó la revisión central y se detectaron " + Resultado.Rows.Count.ToString() + " errores", "Por favor despliegue los errores desde la bandeja");
            ControlEnvioCC("ACTUALIZA", "E", Indice);
            CrearArchivo(Resultado, Archivo, true);
            odsBandejaInterno.Update();
            gvBandeja.DataBind();
        }
    }

    #endregion

    #region Medios

    protected void gvMedios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMedios.PageIndex = e.NewPageIndex;
        gvMedios.DataSource = Session["VERMEDIO"] as DataTable;
        gvMedios.DataBind();
    }

    protected void gvMedios_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvMedios.Rows)
        {
            if (row.Cells[3].Text == "A")
            {
                row.Cells[1].Enabled = true;
                row.Cells[0].Enabled = false;
                row.Cells[0].ForeColor = Color.Gray;
            }
            else
            {
                row.Cells[1].Enabled = false;
                row.Cells[1].ForeColor = Color.Gray;
                row.Cells[0].Enabled = true;
            }
        }
    }

    protected void gvMedios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        //string CodEntidad = gvBandeja.DataKeys[indice].Values["CodigoEntidad"].ToString();
        //string CodMedio = gvBandeja.DataKeys[indice].Values["CodigoMedio"].ToString();
        //int IdControl =Convert.ToInt32(gvBandeja.DataKeys[indice].Values["IdControlEnvio"]);
        //string mensaje = null;
        if (e.CommandName == "cmdError")
        {
            try
            {
                btnAccionar.Text = "Adicionar Error";
                lblTitulo.Text = "Adicion de Error";
                txtPeriodoInicio.Text = gvBandeja.Rows[Convert.ToInt32(Session["FilaBandeja"])].Cells[5].Text;
                txtPeriodoFinal.Text = gvBandeja.Rows[Convert.ToInt32(Session["FilaBandeja"])].Cells[5].Text;
                hfIdArchivo.Value = indice.ToString();
                CargarErrores();
                LimpiaPopUp();
                this.pnlDatos_ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar Forzar el Error", ex.Message);
            }
        }
        if (e.CommandName == "cmdExcepcion")
        {
            try
            {
                btnAccionar.Text = "Adicionar Excepcion";
                lblTitulo.Text = "Adicion de Excepcion";
                txtPeriodoInicio.Text = gvBandeja.Rows[Convert.ToInt32(Session["FilaBandeja"])].Cells[5].Text;
                txtPeriodoFinal.Text = gvBandeja.Rows[Convert.ToInt32(Session["FilaBandeja"])].Cells[5].Text;
                hfIdArchivo.Value = indice.ToString();
                CargarErrores();
                this.pnlDatos_ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar Adicionar la Excepción", ex.Message);
            }
        }
    }

    protected void LimpiaPopUp()
    {
        ddlError.SelectedIndex = 0;
        txtJustificacion.Text = "";
        txtCodigoError.Text = "";
    }

    protected void ddlError_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoError.Text = ddlError.SelectedValue;
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        int indice = Convert.ToInt32(hfIdArchivo.Value);
        string cc, estado, fini = "", entidad, medio, periodo, perpla="",mensaje = null;
        int cua, certificado, ci, envio, trans = 0;
        cua = Convert.ToInt32(gvMedios.Rows[indice].Cells[4].Text);
        certificado = Convert.ToInt32(gvMedios.Rows[indice].Cells[5].Text);
        cc = gvMedios.Rows[indice].Cells[6].Text;
        ci = Convert.ToInt32(gvMedios.Rows[indice].Cells[7].Text);
        int IndBandeja = (int)Session["FilaBandeja"];
        entidad = gvBandeja.DataKeys[(int)Session["FilaBandeja"]].Values["CodigoEntidad"].ToString(); //gvBandeja.Rows[(int)Session["FilaBandeja"]].Cells[1].Text;//Session["CodEntidad"].ToString();
        medio = gvBandeja.DataKeys[(int)Session["FilaBandeja"]].Values["CodigoMedio"].ToString();//Session["CodMedio"].ToString();
        periodo = gvBandeja.Rows[(int)Session["FilaBandeja"]].Cells[5].Text;
        envio = Convert.ToInt32(gvBandeja.Rows[(int)Session["FilaBandeja"]].Cells[6].Text);
        if (medio == "ATR" || medio == "ATF")
        {
            estado = gvMedios.Rows[indice].Cells[24].Text;
        }
        if (medio == "ABR" || medio == "ABF")
        {
            estado = gvMedios.Rows[indice].Cells[21].Text;
        }
        if (medio == "PR" || medio == "PF")
        {
            perpla = gvMedios.Rows[indice].Cells[9].Text;
            fini = gvMedios.Rows[indice].Cells[10].Text;
            trans = Convert.ToInt32(gvMedios.Rows[indice].Cells[12].Text);
        }
        if (medio == "CR" || medio == "CF" || medio == "CT")
        {
            perpla = gvMedios.Rows[indice].Cells[8].Text;
            fini = gvMedios.Rows[indice].Cells[9].Text;
            trans = Convert.ToInt32(gvMedios.Rows[indice].Cells[10].Text);
        }
        if (medio == "RR" || medio == "RF" )
        {
            perpla = gvMedios.Rows[indice].Cells[8].Text;
            fini = gvMedios.Rows[indice].Cells[9].Text;
            trans = Convert.ToInt32(gvMedios.Rows[indice].Cells[10].Text);
        }
        if (btnAccionar.Text == "Adicionar Error")
        {
            DataTable Errores = PagoCC.ForzarError((int)Session["IdConexion"], "I", cua, certificado, ci, trans, perpla, fini, txtCodigoError.Text, entidad, medio, periodo
                                , envio, cc, ref mensaje);
            if (mensaje == null && Errores != null)
            {
                Master.MensajeOk("Se forzó el error correctamente!!!");
                gvMedios.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "VerMedio", entidad, medio, periodo
                                                        , gvBandeja.Rows[IndBandeja].Cells[7].Text, envio, ref mensaje);
              
                ControlEnvioCC("ACTUALIZA", "E", (int)Session["FilaBandeja"]);
                CrearArchivo(Errores, hfRutaArchivoError.Value, true);
                odsBandejaInterno.Update();
                gvMedios.DataBind();
                lblTituloMedio.Text = (Session["VERMEDIO"] as DataTable).Rows.Count.ToString() + " registros en " + gvBandeja.Rows[indice].Cells[4].Text;
                //q ForzarError en es sp que lo agrgue los casos al medio de error y devuelva el datatable
                //luego creamos el archivo identico q en RevisionCentral
                
            }
            else
            {
                Master.MensajeError("Imposible forzar el error", mensaje);
            }
        }
        else if (btnAccionar.Text == "Adicionar Excepcion")
        {
            try
            {
                PagoCC.CambiarEstadoRevision(medio, cua, certificado, cc, ci, perpla, fini, trans, "A",0);
                DataTable convertir = PagoCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona", "", "", "", "", ci.ToString(), "", cua.ToString()
                                                            , 0, cc, ref mensaje);
                int nup = Convert.ToInt32(convertir.Rows[0].ItemArray[1]);
                int ht = Convert.ToInt32(convertir.Rows[0].ItemArray[11]);
                PagoCC.RegistraExcepcion((int)Session["IdConexion"], "I", txtCodigoError.Text, nup, ht, txtJustificacion.Text, periodo, periodo
                                            , ref mensaje);
                PagoCC.CambiarEstadoRevision(medio, cua, certificado, cc, ci, perpla,fini, trans, "P",0);
                Master.MensajeOk("Se registro la excepción exitosamente!!! debe volver a revisar el medio");
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al generar la excepción", ex.Message);
            }
        }
    }

    private void CargarErrores()
    {
        clsControlEnvios Medios = new clsControlEnvios();
        string mensaje = null;
        ddlError.DataSource = Medios.ObtieneVista((int)Session["IdConexion"], "Q", "CargaErrores", "", "", "", "", 0, ref mensaje);
        ddlError.DataValueField = "CodigoError";
        ddlError.DataTextField = "Descripcion";
        ddlError.DataBind();
        ddlTipoMedio.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlTipoMedio.SelectedValue = "0";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DataTable EnvioFiltrado = Session["VERMEDIO"] as DataTable;
        string Filtro = "CUA = " + txtCUA.Text;
        DataRow[] Resultados = EnvioFiltrado.Select(Filtro);
        DataTable Encontrados;
        Encontrados = EnvioFiltrado.Clone();
        foreach (DataRow r in Resultados)
        {
            Encontrados.ImportRow(r);
        }
        gvMedios.DataSource = Encontrados;
        gvMedios.DataBind();
        lblTituloMedio.Text = Encontrados.Rows.Count.ToString() + " registros coincidentes";
    }

    #endregion

}