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
using System.Data;
using System.Globalization;
using System.Drawing;

public partial class PagoCC_wfrmIntercambioCarga : System.Web.UI.Page
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
    clsControlEnvios EnvioCC = new clsControlEnvios();
    clsPagoCC PagoCC = new clsPagoCC();
    clsConciliacion Concil = new clsConciliacion();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HttpContext.Current.Server.ScriptTimeout = 2400;
            CargarTipoMedio();
            CargarEntidad();
            CargaPeriodos();
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
        if (ddlEntidad.SelectedIndex == 0 || ddlTipoMedio.SelectedIndex == 0)
        {
            Response.Write("<script>window.alert('Por favor debe seleccionar Entidad y/o Tipo de Medio.');</script>");
            ddlPeriodo.SelectedIndex = 0;
            return;
        }
        chbMedioFinal.Checked = false;
        int nn = ObtieneNumeroEnvio();
        FileUpload1.Enabled = true;
        btnCargar.Enabled = true;
        if (nn < 100)
        {
            lblNumEnvio.Text = nn.ToString();
        }
        else if (nn > 120)//envio culminado... revisar CRC
        {
            chbMedioFinal.Checked = false;
            lblNumEnvio.Text = (nn - 120).ToString();
            Response.Write("<script>window.alert('El envio fué culminado, intente cargar otro envío');</script>");
            //Response.Redirect("~/PagoCC/wfrmIntercambioCarga.aspx");
            FileUpload1.Enabled = false;
            btnCargar.Enabled = false;
        }
        else if (nn > 100 && nn < 120)//envio aprobado... revisar medio final
        {
            chbMedioFinal.Checked = true;
            lblNumEnvio.Text = (nn - 100).ToString();
            Response.Write("<script>window.alert('El envio fué aprobado, solo cargar como medio final.');</script>");
        }
        else
        {
            //Label5.Text = "No puede volver a cargar este tipo de envio, aún no se dio respuesta.";
            Response.Write("<script>window.alert('No puede volver a cargar este tipo de envio, aún no se dio respuesta.');</script>");
            btnCargar.Enabled = false;
            FileUpload1.Enabled = false;
        }
        //string mensaje = null;--esto para comprobar que no esten con errores
        //DataTable RevisaFinal = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "RespuestaErrores", ddlEntidad.SelectedValue
        //                                     , ddlTipoMedio.SelectedValue, ddlPeriodo.SelectedItem.ToString(), "X", 0, ref mensaje);
        //if (mensaje == null)//(RevisaFinal.Rows.Count == 0)
        //{
        //    chbMedioFinal.Checked = true;
        //    chbMedioFinal.Enabled = true;
        //}
        lblDetalle.Visible = false;
        lblMontos.Visible = false;
        gvResumenConcil.Visible = false;
        gvMontosActas.Visible = false;
        gvBandeja_DataBound(sender,e);
        ddlEntidad.Enabled = false;
        ddlTipoMedio.Enabled = false;
    }

    protected void btnCargar_Click(object sender, EventArgs e)
    {
        gvErrores.DataSource = null;
        gvErrores.DataBind();
        gvErrores2.DataSource = null;
        gvErrores2.DataBind();
        ObtenerExpresiones(ddlTipoMedio.SelectedValue);
        Boolean fileOK = false;
        String CarpetaMedio = Server.MapPath("~/Medios/Intercambio/");
        Session["ARCH"] = FileUpload1.FileName.ToUpper();
        if (FileUpload1.HasFile && FileUpload1.FileBytes.Length > 10)
        {
            fileOK = RevisarFormato(FileUpload1.FileName.ToUpper());
        }
        else
        {
            Master.MensajeError("Archivo vacío", "No es necesario cargar el archivo vacío");
        }
        if (fileOK && FileUpload1.HasFile && FileUpload1.FileBytes.Length > 10)
        {
            btnCargar.Enabled = false;
            FileUpload1.Enabled = false;
            try
            {
                CarpetaMedio += ddlTipoMedio.SelectedValue + ddlEntidad.SelectedValue + "\\" + ddlPeriodo.SelectedItem.ToString() + "\\";//agregar sub carpeta periodo
                Directory.CreateDirectory(CarpetaMedio);
                Session["CARPETA"] = CarpetaMedio;
                if (chbMedioFinal.Checked)
                {
                    ruta = CarpetaMedio + FileUpload1.FileName.ToUpper().Replace(".TXT", "_Final.TXT");
                }
                else
                {
                    ruta = CarpetaMedio + FileUpload1.FileName.ToUpper();
                }
                FileUpload1.PostedFile.SaveAs(ruta);
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
                    string ErrorCarga = null;
                    ErrorCarga = inserta_temporal(ddlTipoMedio.SelectedValue.ToString());
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
                    if (chbMedioFinal.Checked && ErrorCarga == null)
                    {
                        RevisaMedioFinal(ddlTipoMedio.SelectedValue, ddlEntidad.SelectedValue);
                    }
                    else if (chbMedioFinal.Checked == false && ErrorCarga == null)
                    {
                        Prevalida(ddlEntidad.SelectedValue, ddlPeriodo.SelectedValue, ddlTipoMedio.SelectedValue, Convert.ToInt32(lblNumEnvio.Text));
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
            Session["ARCH_RESP"] = "R" + Session["ARCH"].ToString();
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
            ControlEnvioCC("REGISTRO", "PENDIENTE", 0);
        }
        odsBandejaExterno.Update();
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

    private void RevisaMedioFinal(string TipoMedio, string Entidad)
    {
        try
        {
            //EliminaTemporal(ddlTipoMedio.SelectedValue.ToString() + "F", ddlEntidad.SelectedValue.ToString(), Convert.ToInt32((lblNumEnvio.Text)));
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
                Master.MensajeError("El archivo tiene diferencias con el envio aprobado.", "Revise el detalle de diferencias y corrija.");
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
                    if (TipoMedio == "CR" || TipoMedio == "CF" || TipoMedio == "CT")
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
                string mensaje = null;
                ControlEnvio("Culminado", "C");
                string CRCfinal = ManejoArchivo.GenerarCRC(ruta);
                int cantidad = Convert.ToInt32(hfCantidad.Value);
                EnvioCC.ModificaEnvio((int)Session["IdConexion"], "U", ddlEntidad.SelectedValue, ddlTipoMedio.SelectedValue
                      , ddlPeriodo.SelectedItem.ToString(), Convert.ToInt32(lblNumEnvio.Text), "C", CRCfinal, cantidad, ref mensaje);
                Master.MensajeOk("Medio Final correcto y fue CULMINADO con Código de Seguridad: " + CRCfinal);
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
            odsBandejaExterno.Update();
            gvBandeja.DataBind();
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al comparar el medio final", ex.Message);
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
    }

    private void CargaPeriodos()
    {
        DateTime fecha = DateTime.Now.Date;
        ddlPeriodo.Items.Capacity = 12;
        for (int x = 0; x <= 11; x++)
        {
            ddlPeriodo.Items.Add(fecha.Year.ToString() + fecha.Month.ToString("00"));
            fecha = fecha.AddMonths(-1);
        }
        ddlPeriodo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlPeriodo.SelectedValue = "0";
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PagoCC/wfrmIntercambioCarga.aspx");
    }

    #endregion

    #region Importacion

    private string inserta_temporal(string TipoMedio)
    {
        clsCargarMedios cargar = new clsCargarMedios();
        string mensaje = null;
        mensaje = cargar.InsertaBulk(tabla, DRFormato.ItemArray[8].ToString().Trim());
        if (mensaje == null)
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
        bool resultado = Automata.RevisaNombre((int)Session["IdConexion"], NombreArchivo, ddlTipoMedio.SelectedValue, ref mensaje);
        if (resultado && !chbMedioFinal.Checked)
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
        string mensaje = null;
        DRFormato = inter.ListarTipoMedio((int)Session["IdConexion"],"Q", 0, TipoMedio,ref mensaje).Rows[0];
        IDTM = Convert.ToInt16(DRFormato.ItemArray[0]);
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
            DataSet tablas = Automata.GenerarTablaDinamica((int)Session["IdConexion"], ddlTipoMedio.SelectedValue,ref mensaje);
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
                Automata.AgregaColumnas(tabla, "PorcentajeAsignacion", "String", "0");//12
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);//12
                Automata.AgregaColumnas(tabla, "NUP", "String", "0");//12
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");
                break;
            case "ATR":
                Automata.AgregaColumnas(tabla, "TipoPension", "String", "J");//12
                Automata.AgregaColumnas(tabla, "ComplementoSEGIP", "String", "");//12
                Automata.AgregaColumnas(tabla, "FraccionComplementaria", "Decimal", "0");//26
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);//27
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");//28
                break;
            case "ATF":
                //Automata.AgregaColumnas(tabla, "TipoPension", "String", "CC");//12 modifico los medios pa se pueda cargar
                //Automata.AgregaColumnas(tabla, "ComplementoSEGIP", "String", "");//12 idem arriba
                Automata.AgregaColumnas(tabla, "TipoPlanilla", "String", Valor + v);//27
                Automata.AgregaColumnas(tabla, "Revision", "String", "P");//28
                break;
            case "ABR":
            case "ABF":
                Automata.AgregaColumnas(tabla, "FechaFallecimiento", "String", "");//12
                Automata.AgregaColumnas(tabla, "ComplementoSEGIP", "String", "");//12
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
        CrearArchivo(TablaErrores, "Respuesta_" + FileUpload1.FileName, true);
        ControlEnvio("Error", "E");
        RegistraError(TablaErrores, Session["ARCH"].ToString());
        lblDescargaError.Visible = true;
        Session["ARCH_RESP"] = "Respuesta_" + FileUpload1.FileName;
    }

    private void ControlEnvio(string TipoControl, string Estado)
    {
        try
        {
            string NombreArchivo;
            if (chbMedioFinal.Checked)
            {
                NombreArchivo = FileUpload1.FileName.ToUpper() + "_Final";
            }
            else
            {
                NombreArchivo = FileUpload1.FileName.ToUpper();
            }
            string mensaje = null;
            ManejoArchivo.ControlEnvio((int)Session["IdConexion"], TipoControl, ddlTipoMedio.SelectedValue
                        , ddlEntidad.SelectedValue + "-" + NombreArchivo, Estado, ref mensaje);
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
        string mensaje=null;
        int IDCA = Convert.ToInt32(err.ListarArchivoIntercambio((int)Session["IdConexion"],"Q",NomArchivo,ref mensaje).Rows[0][0]);
        foreach (DataRow r in DTErrores.Rows)
        {
            err.RegistraErroresArchivo((int)Session["IdConexion"],"I",IDCA, Convert.ToInt32(r.ItemArray[0]), Convert.ToInt32(r.ItemArray[1]), r.ItemArray[2].ToString(),ref mensaje);
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
                                , NE, Estado, hfCRC.Value, hfRuta.Value, Convert.ToInt32(hfCantidad.Value), ref mensaje);//REVIASR la RUTA del hf
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
            if (row.Cells[7].Text != "ERROR" && row.Cells[7].Text != "GENERADO" &&
                !(row.Cells[4].Text.StartsWith("PLANILLA DE CONCI") && row.Cells[7].Text == "APROBADO"))
            {
                row.Cells[12].ToolTip = "No hay respuesta para descargar";
                row.Cells[12].Controls.Clear();
            }
            else if (row.Cells[4].Text.StartsWith("PLANILLA DE CONCI") && row.Cells[7].Text == "APROBADO")
            {
                row.Cells[12].ToolTip = "Resumen de la Conciliación";
            }
            else if (row.Cells[4].Text.StartsWith("PLANILLA DE PAGO") && row.Cells[7].Text == "GENERADO")
            {
                row.Cells[12].ToolTip = "Planillas con Transacciones de Convenios";
            }
            else
            {
                row.Cells[12].ToolTip = "Descargar respuesta de errores";
            }
        }
    }

    protected void gvBandeja_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String CarpetaMedio = Server.MapPath("~/Medios/Intercambio/");
        int indice = Convert.ToInt32(e.CommandArgument);
        string mensaje = null;
        string archivo="";
        string CodEntidad = gvBandeja.DataKeys[indice].Values["CodigoEntidad"].ToString();
        string CodMedio = gvBandeja.DataKeys[indice].Values["CodigoMedio"].ToString();
        string Periodo = gvBandeja.Rows[indice].Cells[5].Text;
        string EstadoEnvio = gvBandeja.Rows[indice].Cells[7].Text;
        //string eCarpeta = CarpetaMedio + CodMedio + CodEntidad + "\\" + Periodo + "\\";//logica nu muy buen
        //string eArchivo = "R" + Automata.ListarTipoMedio((int)Session["IdConexion"], "Q", 0, CodMedio, ref mensaje).Rows[0][3].ToString()
        //                    + gvBandeja.Rows[indice].Cells[5].Text + ".TXT";
        string RutaMedio = gvBandeja.DataKeys[indice].Values["RutaRepositorio"].ToString();//directamente obtener la ruta del archivo
        int f = RutaMedio.Length;
        int i = RutaMedio.LastIndexOf("\\");
        archivo = RutaMedio.Substring(i + 1, f - i - 1);
        if (gvBandeja.Rows[indice].Cells[7].Text == "ERROR")
        {
            RutaMedio = RutaMedio.Substring(0, i) + "\\R" + archivo; 
        }
        if (e.CommandName == "cmdDescargar")
        {
            if (gvBandeja.Rows[indice].Cells[7].Text != "APROBADO")//si no esta habilitado el boton para detalle concil
            {
                try
                {
                    if (File.Exists(RutaMedio))
                    {
                        string ArchDescarga = "";
                        if (EstadoEnvio == "GENERADO")
                        {
                            ArchDescarga = archivo;
                        }
                        else
                        {
                            ArchDescarga = "R" + archivo;
                        }
                        Response.Clear();
                        Response.ContentType = "application/txt";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + ArchDescarga);
                        Response.WriteFile(RutaMedio);
                        Response.End();
                    }
                    else
                    {
                        Master.MensajeError("Imposible Descargar el archivo", "El archivo no se encuentra disponible o no existe");
                    }
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al intentar descargar el archivo", ex.Message);
                }
            }
            else
            {
                DatosConciliacion(CodEntidad, Periodo);
            }
        }
        if (e.CommandName == "cmdExcepcion")
        {
            try
            {

            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ejecutar la Revisión Central", ex.Message);
            }
        }
        gvBandeja_DataBound(sender, e);
    }

    private void DatosConciliacion(string Entidad, string Periodo)
    {
        string mensaje=null;
        gvResumenConcil.Visible = true;
        gvResumenConcil.DataSource = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", "ResumenConcilTemp", Entidad, "", Periodo
                                                                , Periodo, ref mensaje);
        gvResumenConcil.DataBind();

        gvMontosActas.Visible = true;
        gvMontosActas.DataSource = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", "MontosActasTemp", Entidad, "", Periodo
                                                                , Periodo, ref mensaje);
        gvMontosActas.DataBind();
    }

    #endregion

    protected void gvErrores2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvErrores2.PageIndex = e.NewPageIndex;
        gvErrores2.DataSource = Session["ERRORES"] as DataTable;
        gvErrores2.DataBind();
        int x = gvErrores2.PageIndex;
        lblDescargaError.Visible = true;
    }
}