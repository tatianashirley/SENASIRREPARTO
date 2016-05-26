
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
using wcfServicioIntercambioPago.Entidades;
using wcfServicioIntercambioPago.Datos;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace wcfServicioIntercambioPago.Logica
{
    public class clsIntercambio : clsIntercambioBE
    {
        clsIntercambioDA Intercambio = new clsIntercambioDA();
       // Adiciona Medio Intercambio
       // public void AdicionarTipoIntercambio(int IdTransaccion, string Descripcion, string Prefijo, string Formato, string TipoMedio,
       //                                     string Extension, string ExpReg, string TTemporal, string TFinal, string Procedimiento,
       //                                     string Alta, string Baja) 
       // {
       //     try
       //     {
       //         clsIntercambioDA adi = new clsIntercambioDA();
       //         adi.AdicionarTipoIntercambio(IdTransaccion, Descripcion, Prefijo, Formato, TipoMedio, Extension, ExpReg, TTemporal,
       //                                     TFinal, Procedimiento, Alta, Baja);
       //     }
       //     catch (Exception ex)
       //     {
       //         throw ex;
       //     }
       // }

       // // Modifica medio Intercambio
       // public void ModificarTipoIntercambio(string Tipo,int IdArchivo, int IdTransaccion, string Descripcion, string Prefijo, string Formato
       //                                     , string TipoMedio,string Extension, string ExpReg, string TTemporal, string TFinal
       //                                     , string Procedimiento, string Alta, string Baja) 
       // {
       //     try
       //     {
       //         clsIntercambioDA mod = new clsIntercambioDA();
       //         mod.ModificarTipoIntercambio(Tipo, IdArchivo, IdTransaccion, Descripcion, Prefijo, Formato, TipoMedio, Extension, ExpReg
       //                                     , TTemporal, TFinal, Procedimiento, Alta, Baja);
       //     }
       //     catch (Exception ex)
       //     {
       //         throw ex;
       //     }
       // }

       //// lista uno o todos los tipos de Intercambio segun el parametro
       //public List<clsIntercambio> ListarTipoIntercambio(int IdArchivo,string Tipo)
       //{
       //    clsIntercambio p;
       //    clsIntercambioDA permiso = new clsIntercambioDA();
       //    List<clsIntercambio> ListaClas = new List<clsIntercambio>();

       //    using (IDataReader dr = permiso.ListarTipoIntercambio(IdArchivo,Tipo))
       //    {
       //        while (dr.Read())
       //        {
       //            p = new clsIntercambio();

       //            p.IdArchivo = (int)dr["IdArchivo"];
       //            p.IdTransaccion = (int)dr["IdTransaccion"];
       //            p.Descripcion = (string)dr["Descripcion"];
       //            p.Prefijo = (string)dr["PrefijoNombreArchivo"];
       //            p.Formato = (string)dr["FormatoMedio"];
       //            p.CodigoMedio = (string)dr["CodigoTipoMedio"];
       //            p.Extension = (string)dr["Extencion"];
       //            p.ExpReg = (string)dr["ExpresionRegular"];
       //            p.TablaTemporal = (string)dr["TablaDestinoTemporal"];
       //            p.TablaFinal = (string)dr["TablaDestinoFinal"];
       //            p.Procedimiento = (string)dr["NombreProcedimiento"];
       //            p.Alta = (string)dr["PeriodoAlta"];
       //            p.Baja = (string)dr["PeriodoBaja"];
       //            p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
       //            ListaClas.Add(p);
       //        }
       //    }
       //    return ListaClas;
       //}
       // /*Ahora para los registros*/
       //public List<clsIntercambio> ListarTipoRegistro(int IdArchivo, string Tipo)
       //{
       //    clsIntercambio p;
       //    clsIntercambioDA permiso = new clsIntercambioDA();
       //    List<clsIntercambio> ListaClas = new List<clsIntercambio>();

       //    using (IDataReader dr = permiso.ListarTipoRegistro(IdArchivo, Tipo))
       //    {
       //        while (dr.Read())
       //        {
       //            p = new clsIntercambio();

       //            p.IdTransaccion = (int)dr["IdRegistro"];
       //            p.IdArchivo = (int)dr["IdArchivo"];
       //            p.CampoMedio = (string)dr["NombreCampo"];
       //            p.Tipo = (string)dr["TipoDato"];
       //            p.Tamaño = (int)dr["Tamaño"];
       //            p.TablaFinal = (string)dr["Tabla"];
       //            p.CampoTabla = (string)dr["Campo"];
       //            p.Observacion = (string)dr["Observacion"];
       //            p.ExpReg = (string)dr["ExpresionRegular"];
       //            p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
       //            ListaClas.Add(p);
       //        }
       //    }
       //    return ListaClas;
       //}
       //// Adiciona Registro Intercambio
       //public void AdicionarRegistroIntercambio(int IdArchivo, string NombreCampo, string TipoDato, int Tamaño, string Tabla,
       //                                     string Campo, string Observacion, string ExpReg)
       //{
       //    try
       //    {
       //        clsIntercambioDA adi = new clsIntercambioDA();
       //        adi.AdicionarFormatoRegistro(IdArchivo, NombreCampo, TipoDato, Tamaño, Tabla, Campo, Observacion, ExpReg);
       //    }
       //    catch (Exception ex)
       //    {
       //        throw ex;
       //    }
       //}

       //// Modifica Registro Intercambio
       //public void ModificarRegistroIntercambio(string Tipo, int IdRegistro, int IdArchivo, string NombreCampo, string TipoDato, int Tamaño, string Tabla,
       //                                     string Campo, string Observacion, string ExpReg)
       //{
       //    try
       //    {
       //        clsIntercambioDA mod = new clsIntercambioDA();
       //        mod.ModificarFormatoRegistro(Tipo, IdRegistro, IdArchivo, NombreCampo, TipoDato, Tamaño, Tabla, Campo, Observacion, ExpReg);
       //    }
       //    catch (Exception ex)
       //    {
       //        throw ex;
       //    }
       //}

        /*******************con modulo de seguridad******************/
        /*para tipos de  medios*/
       public DataTable ListarTipoMedio(int iIdConexion, string cOperacion, int IdArchivo, string Tipo, ref string sMensajeError)
       {
           DataSet DSetTmp = new DataSet();
           if (Intercambio.ListarTipoMedio(iIdConexion, cOperacion, IdArchivo, Tipo, ref sMensajeError, ref DSetTmp))
           {
               return (DSetTmp.Tables[0]);
           }
           else
           {
               return (null);
           }
       }

       public bool ModificaTipoMedio(int iIdConexion, string cOperacion, string Tipo, int IdArchivo, int IdTransaccion, string Descripcion
                                        , string Prefijo, string Formato, string TipoMedio, string Extension, string ExpReg, string TTemporal
                                        , string TFinal, string Procedimiento, string Alta, string Baja, ref string sMensajeError)
       {
           bool Respuesta = Intercambio.ModificaTipoMedio(iIdConexion, cOperacion, Tipo, IdArchivo, IdTransaccion, Descripcion, Prefijo
                                   , Formato, TipoMedio, Extension, ExpReg, TTemporal, TFinal, Procedimiento, Alta, Baja, ref sMensajeError);
           return (Respuesta);
       }

       public bool RegistraTipoMedio(int iIdConexion, string cOperacion, int IdTransaccion, string Descripcion, string Prefijo
                                    , string Formato, string TipoMedio, string Extension, string ExpReg, string TTemporal, string TFinal
                                    , string Procedimiento, string Alta, string Baja, ref string sMensajeError)
       {
           bool Respuesta = Intercambio.RegistraTipoMedio(iIdConexion, cOperacion, IdTransaccion, Descripcion, Prefijo, Formato, TipoMedio
                                                    , Extension, ExpReg, TTemporal, TFinal, Procedimiento, Alta, Baja, ref sMensajeError);
           return (Respuesta);
       }

        /*para campos del Tipo Medio*/
       public DataTable ListarCampoMedio(int iIdConexion, string cOperacion, int IdArchivo, string Tipo, ref string sMensajeError)
       {
           DataSet DSetTmp = new DataSet();
           if (Intercambio.ListarCampoMedio(iIdConexion, cOperacion, IdArchivo, Tipo, ref sMensajeError, ref DSetTmp))
           {
               return (DSetTmp.Tables[0]);
           }
           else
           {
               return (null);
           }
       }

       public bool ModificaCampoMedio(int iIdConexion, string cOperacion, string Tipo, int IdRegistro, string TipoMedio, string NombreCampo
                      , string TipoDato, int Tamaño, string Tabla, string Campo, string Observacion, string ExpReg, ref string sMensajeError)
       {
           bool Respuesta = Intercambio.ModificaCampoMedio(iIdConexion, cOperacion, Tipo, IdRegistro, TipoMedio, NombreCampo, TipoDato
                                                            , Tamaño, Tabla, Campo, Observacion, ExpReg, ref sMensajeError);
           return (Respuesta);
       }

       public bool RegistraCampoMedio(int iIdConexion, string cOperacion, string TipoMedio, string NombreCampo, string TipoDato, int Tamaño
                                    , string Tabla, string Campo, string Observacion, string ExpReg, ref string sMensajeError)
       {
           bool Respuesta = Intercambio.RegistraCampoMedio(iIdConexion, cOperacion, TipoMedio, NombreCampo, TipoDato, Tamaño, Tabla, Campo
                                                            , Observacion, ExpReg, ref sMensajeError);
           return (Respuesta);
       }
    }
}