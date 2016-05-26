using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.IO;
using System.Globalization;
using wcfServicioIntercambioPago.Entidades;
using wcfServicioIntercambioPago.Datos;

namespace wcfServicioIntercambioPago.Logica
{
    public class clsServicioIntercambio : clsServicioIntercambioBE
    {
        clsIntercambioDA DesdeIntercambio = new clsIntercambioDA();
        clsServicioIntercambioDA ServicioIntercambio = new clsServicioIntercambioDA();
        /****************propios de intercambio************************/
        //public List<clsServicioIntercambio> ListarTipoArchivo()
        //{
        //    clsServicioIntercambio p;
        //    clsServicioIntercambioDA permiso = new clsServicioIntercambioDA();
        //    List<clsServicioIntercambio> ListaArchivos = new List<clsServicioIntercambio>();

        //    using (IDataReader dr = permiso.ListarTipoArchivo(0,"TODOS"))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsServicioIntercambio();
        //            p.IdArchivo = (int)dr["IdArchivo"];
        //            p.Descripcion = (string)dr["Descripcion"];
        //            p.Prefijo = (string)dr["PrefijoNombreArchivo"];
        //            p.Extencion = (string)dr["Extencion"];
        //            p.TablaDestino = (string)dr["TablaDestinoTemporal"];
        //            p.PeriodoAlta = (string)dr["PeriodoAlta"];
        //            p.PeriodoBaja = (string)dr["PeriodoBaja"];
        //            ListaArchivos.Add(p);
        //        }
        //    }
        //    return ListaArchivos;
        //}
        //public List<clsServicioIntercambio> ListarCampoArchivo()
        //{
        //    clsServicioIntercambio p;
        //    clsServicioIntercambioDA permiso = new clsServicioIntercambioDA();
        //    List<clsServicioIntercambio> ListaCampos = new List<clsServicioIntercambio>();

        //    using (IDataReader dr = permiso.ListarCamposArchivo(0,"TODOS"))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsServicioIntercambio();
        //            p.IdArchivo = (int)dr["IdTipoArchivo"];
        //            p.NombreCampo = (string)dr["NombreCampo"];
        //            p.TipoDato = (string)dr["TipoDato"];
        //            p.Tamanio = (string)dr["Tamaño"];
        //            p.Tabla = (string)dr["Tabla"];
        //            p.Campo = (string)dr["Campo"];
        //            p.Precision = (int)dr["Precision"];
        //            p.CarateresNoValidados = (string)dr["CaracteresNoValidos"];
        //            ListaCampos.Add(p);
        //        }
        //    }
        //    return ListaCampos;
        //}

        //public DataTable ListarArchivoTodo(int IdArchivo,string Tipo)
        //{
        //    DataTable dt = new DataTable();
        //    clsServicioIntercambioDA tab = new clsServicioIntercambioDA();
        //    IDataReader dr = tab.ListarTipoArchivo(IdArchivo,Tipo);
        //    dt.Load(dr);
        //    return dt;
        //}
        //public DataTable ListarCampoTodo(int IdArchivo, string Tipo)
        //{
        //    DataTable dt = new DataTable();
        //    clsServicioIntercambioDA tab = new clsServicioIntercambioDA();
        //    IDataReader dr = tab.ListarCamposArchivo(IdArchivo,Tipo);
        //    dt.Load(dr);
        //    return dt;
        //}
        //obtiene todo el registro del archivo recibido
        //public DataTable ObtenerArchivoIntercambio(string NombreArchivo)
        //{
        //    DataTable dt = new DataTable();
        //    clsServicioIntercambioDA tab = new clsServicioIntercambioDA();
        //    IDataReader dr = tab.ObtenerArchivoIntercambio(NombreArchivo);
        //    dt.Load(dr);
        //    return dt;
        //}
        // Registrar Envio Intercambio
        //public void RegistraEnvio(string TipoMedio,string Estado, string NombreArchivo)
        //{
        //    try
        //    {
        //        clsServicioIntercambioDA adi = new clsServicioIntercambioDA();
        //        adi.RegistrarEnvio(TipoMedio,Estado,NombreArchivo);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        // Actualiza Envio Intercambio
        //public void ModificaEnvio(string NombreArchivo, string Estado)
        //{
        //    try
        //    {
        //        clsServicioIntercambioDA adi = new clsServicioIntercambioDA();
        //        adi.ModificarEnvio(NombreArchivo, Estado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        // Registrar Envio Intercambio
        //public void RegistraErrorArchivo(int IdControlArchivo, int Fila, int Campo, string Descripcion)
        //{
        //    try
        //    {
        //        clsServicioIntercambioDA adi = new clsServicioIntercambioDA();
        //        adi.RegistrarErrorEnvio(IdControlArchivo,Fila,Campo,Descripcion);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
       
        /*************con modulos de seguridad*************/

        public DataTable ListarTipoMedio(int iIdConexion, string cOperacion, int IdArchivo, string TipoMedio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (DesdeIntercambio.ListarTipoMedio(iIdConexion, cOperacion, IdArchivo, TipoMedio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarCampoMedio(int iIdConexion, string cOperacion, int IdArchivo, string Tipo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (DesdeIntercambio.ListarCampoMedio(iIdConexion, cOperacion, IdArchivo, Tipo, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListarArchivoIntercambio(int iIdConexion, string cOperacion, string NombreArchivo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ServicioIntercambio.ListarArchivoIntercambio(iIdConexion, cOperacion, NombreArchivo, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ModificaArchivoIntercambio(int iIdConexion, string cOperacion, string NombreArchivo, string Estado, ref string sMensajeError)
        {
            bool Respuesta = ServicioIntercambio.ModificaArchivoIntercambio(iIdConexion, cOperacion, NombreArchivo, Estado, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraArchivoIntercambio(int iIdConexion, string cOperacion, string TipoMedio, string Estado, string NombreArchivo
                                                , ref string sMensajeError)
        {
            bool Respuesta = ServicioIntercambio.RegistraArchivoIntercambio(iIdConexion, cOperacion, TipoMedio, Estado, NombreArchivo
                                                                             , ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraErroresArchivo(int iIdConexion, string cOperacion, int IdControlArchivo, int Fila, int Campo, string Descripcion
                                               , ref string sMensajeError)
        {
            bool Respuesta = ServicioIntercambio.RegistraErroresArchivo(iIdConexion, cOperacion, IdControlArchivo, Fila, Campo
                                                                             , Descripcion, ref sMensajeError);
            return (Respuesta);
        }

        //***************automatas***********************/
        #region Automata
        //revisa nombre de archivo
        public bool RevisaNombre(int IdConexion,string NombreArchivo, string TipoMedio,ref string Mensaje)
        {
            DataRow expresion = ListarTipoMedio(IdConexion,"Q",0, TipoMedio,ref Mensaje).Rows[0];
            System.Text.RegularExpressions.Regex revisor = new Regex(expresion.ItemArray[7].ToString());
            bool respuesta = revisor.IsMatch(NombreArchivo);
            return respuesta;
        }
        //crea tabla dinamicamente segun campos cargados
        public DataSet GenerarTablaDinamica(int IdConexion, string TipoMedio, ref string Mensaje)
        {
            DataTable TablaError = new DataTable("TablaError");
            TablaError.Columns.Add(new DataColumn("Linea", Type.GetType("System.String")));
            TablaError.Columns.Add(new DataColumn("Columna", Type.GetType("System.String")));
            TablaError.Columns.Add(new DataColumn("Detalle", Type.GetType("System.String")));
            int IdArchivo = Convert.ToInt32(ListarTipoMedio(IdConexion,"Q",0, TipoMedio,ref Mensaje).Rows[0].ItemArray[0].ToString());
            DataTable t = ListarCampoMedio(IdConexion,"Q",IdArchivo, "MEDIO",ref Mensaje);
            DataTable Itabla = new DataTable("Itabla");
            foreach (DataRow r in t.Rows)
            {
                Itabla.Columns.Add(new DataColumn(r.ItemArray[6].ToString(), Type.GetType("System." + r.ItemArray[3].ToString().Replace("Datetime","DateTime"))));
            }
            DataSet TablasDin = new DataSet();
            TablasDin.Tables.Add(Itabla);
            TablasDin.Tables.Add(TablaError);
            return TablasDin;
        }
        //carga los datos del txt en la tabla dinamicamente
        public DataSet CargaTablaDinamica(DataTable TablaOK,DataTable TablaError,DataTable Expresiones,string ruta)
        {
            TablaOK.Clear();
            TablaError.Clear();
             int nf = 1;
             using (StreamReader sr = new StreamReader(ruta, System.Text.Encoding.GetEncoding(1252)))
             {
                 String line;
                 string[] Archivo;
                 line = sr.ReadLine();
                 //int veces = line.Split('|').Length - 1; 
                 Archivo = line.Split('|');
                 int col = 0;
                 while (line != null)
                 {
                 //Brinco:
                     col = 0;
                     try
                     {
                         Archivo = line.Split('|');
                         DataRow fila = TablaOK.NewRow();
                         foreach (DataColumn c in TablaOK.Columns)
                         {
                             //if (c.Ordinal == 15 && c.n )
                             //{
                             //    fila[col] = "J";
                             //}
                             if ((c.DataType == typeof(decimal) || (c.DataType == typeof(Int16)) || (c.DataType == typeof(Int32))) && Archivo[col].ToString().Length == 0)
                             {
                                 fila[col] = 0;
                                 //col += 1;
                             }
                             else
                             {
                                 fila[col] = Archivo[col].ToString();
                                 //col += 1;
                             }
                             col += 1;
                         }
                         if (Archivo.Length == TablaOK.Columns.Count)
                         {
                             TablaOK.Rows.Add(fila);
                         }
                         else
                         {
                             TablaError.Rows.Add(nf, 0, "La linea no cuenta con la cantidad de campos exacta.");
                         }
                         line = sr.ReadLine();
                         if (line == "")
                         {
                             line = sr.ReadLine();
                         }
                         nf += 1;   
                     }
                     catch (Exception ex1)
                     {
                         if (Archivo.Length != 1 && Archivo[0].ToString() != "")
                         {
                             TablaError.Rows.Add(nf, 0, ex1.Message);
                         }
                         line = sr.ReadLine();
                         nf += 1;
                     }
                 }
             }
            //DataTable t1,t2;
            DataSet Cargados=new DataSet();
            //t1 = TablaOK.Copy() ;
            //t2 = TablaError.Copy();
            Cargados.Tables.Add(TablaOK.Copy());
            Cargados.Tables.Add(TablaError.Copy());
            //DataTable t1 = TablaOK, t2 = TablaError;
            return Cargados;
        }
        //valida la fila campo x campo
        public DataTable ValidarCampos(/*string[] fila*/DataTable TablaOK ,DataTable Expresiones, DataTable TablaError)
        {
            Regex FormatoCampos;
            int nc = 0, nf = 1;
            //bool resultado = true;

            foreach (DataRow fila in TablaOK.Rows)
            {
                foreach (DataRow c in Expresiones.Rows)
                {
                    FormatoCampos = new Regex(@Expresiones.Rows[nc][8].ToString());
                    if (!FormatoCampos.IsMatch(fila.ItemArray[nc].ToString()))
                    {
                        TablaError.Rows.Add(nf, nc+1, "El campo: " + Expresiones.Rows[nc][2].ToString() + ", no cumple con el formato");
                        //resultado = false;
                    }
                    if (fila.ItemArray[nc] == null)
                    {
                        TablaError.Rows.Add(nf, 0, "La fila no tiene la cantidad de campos correta");
                    }
                    nc += 1;
                }
                nc = 0;
                nf += 1;
            }
            //agregamos algunas validaciones escenciales
            /*if (fila[0].ToString() != ddlEntidad.SelectedValue.ToString())
            {
                TablaError.Rows.Add(NumeroFila, 1, "cod_fuente no es el correspondiente");
                resultado = false;
            }
            if (TablaOK.Columns.Count != Expresiones.Rows.Count)
            {
                TablaError.Rows.Add(nf, 0, "La fila no tiene la cantidad de campos correta");
            }*/
            return TablaError;
        }
        //agrega columnas (interno) a las tablas
        public DataTable AgregaColumnas(DataTable TablaOK, string NombreColumna, string Tipo, string Valor)
        {
            TablaOK.Columns.Add(new DataColumn(NombreColumna, Type.GetType("System." + Tipo)));
            foreach (DataRow r in TablaOK.Rows)
            {
                r[NombreColumna] = Valor;
            }
            return TablaOK;
        }
#endregion
    }
}