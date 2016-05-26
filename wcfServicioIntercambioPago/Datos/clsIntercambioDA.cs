using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Resources;
using SQLSPExecuter;


namespace wcfServicioIntercambioPago.Datos
{
    public class clsIntercambioDA
    {
        Database db = null;
      
        public clsIntercambioDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }

        //// Adiciona un Tipo de Intercambio
        //public void AdicionarTipoIntercambio(int IdTransaccion, string Descripcion, string Prefijo, string Formato, string TipoMedio,
        //                                    string Extension,string ExpReg,string TTemporal,string TFinal, string Procedimiento,
        //                                    string Alta, string Baja)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_RegistraPropiedadesArchivo", IdTransaccion,Descripcion,
        //                                            Prefijo,Formato,TipoMedio,Extension,ExpReg,TTemporal,TFinal,Procedimiento,
        //                                            Alta,Baja); 
        //    db.ExecuteNonQuery(cmd);
        //}

        //// Modificar un Tipo de Intercambio 
        //public void ModificarTipoIntercambio(string Tipo,int IdArchivo,int IdTransaccion, string Descripcion, string Prefijo, string Formato, string TipoMedio,
        //                                    string Extension, string ExpReg, string TTemporal, string TFinal, string Procedimiento,
        //                                    string Alta, string Baja)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ModificaPropiedadesArchivo", Tipo, IdArchivo, IdTransaccion, Descripcion,
        //                                            Prefijo, Formato, TipoMedio, Extension, ExpReg, TTemporal, TFinal, Procedimiento,
        //                                            Alta, Baja);
        //    db.ExecuteNonQuery(cmd);
        //}
        ////Adiciona un formato de registro
        //public void AdicionarFormatoRegistro(int IdArchivo, string NombreCampo, string TipoDato, int Tamaño, string Tabla,
        //                                    string Campo, string Observacion, string ExpReg)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_RegistraFormatoRegistro", IdArchivo, NombreCampo,
        //                                            TipoDato, Tamaño, Tabla, Campo, Observacion, ExpReg);
        //    db.ExecuteNonQuery(cmd);
        //}
        ////Modifica un formato de registro
        //public void ModificarFormatoRegistro(string Tipo, int IdRegistro, int IdArchivo, string NombreCampo, string TipoDato, int Tamaño, string Tabla,
        //                                    string Campo, string Observacion, string ExpReg)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ModificaEstructura", Tipo, IdRegistro,IdArchivo, NombreCampo,
        //                                            TipoDato, Tamaño, Tabla, Campo, Observacion, ExpReg);
        //    db.ExecuteNonQuery(cmd);
        //}
        //// Listar tipos de Intercambio
        //public IDataReader ListarTipoIntercambio(int IdArchivo, string Tipo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ListarTipoIntercambio", IdArchivo,Tipo);
        //    IDataReader dataReader = db.ExecuteReader(cmd);
        //    return dataReader;
        //}
        //// Listar tipos de Registro
        //public IDataReader ListarTipoRegistro(int IdArchivo, string Tipo)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("Intercambio.PR_ListarCampoIntercambio", IdArchivo,Tipo);
        //    IDataReader dataReader = db.ExecuteReader(cmd);
        //    return dataReader;
        //}


        /******************con modulo de seguridad**************************/
        /*para tipos de medios*/
        public bool ListarTipoMedio(int iIdConexion, string cOperacion, int IdArchivo, string Tipo,  ref string sMensajeError,  ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_ListarTipoIntercambio", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdArchivo", IdArchivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool ModificaTipoMedio(int iIdConexion, string cOperacion, string Tipo, int IdArchivo, int IdTransaccion, string Descripcion
                                        , string Prefijo, string Formato, string TipoMedio, string Extension, string ExpReg, string TTemporal
                                        , string TFinal, string Procedimiento, string Alta, string Baja, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_ModificaPropiedadesArchivo", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdArchivo", IdArchivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTransaccion", IdTransaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Descripcion", Descripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Prefijo", Prefijo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Formato", Formato);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Extension", Extension);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ExpresionRegular", ExpReg);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TablaTemporal", TTemporal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TablaFinal", TFinal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Procedimiento", Procedimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Alta", Alta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Baja", Baja);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool RegistraTipoMedio(int iIdConexion, string cOperacion, int IdTransaccion, string Descripcion, string Prefijo
                                    , string Formato, string TipoMedio, string Extension, string ExpReg, string TTemporal, string TFinal
                                    , string Procedimiento, string Alta, string Baja, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_RegistraPropiedadesArchivo", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTransaccion", IdTransaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Descripcion", Descripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Prefijo", Prefijo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Formato", Formato);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Extension", Extension);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ExpresionRegular", ExpReg);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TablaTemporal", TTemporal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TablaFinal", TFinal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Procedimiento", Procedimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Alta", Alta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Baja", Baja);



                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /*para campos del tipo medios*/
        public bool ListarCampoMedio(int iIdConexion, string cOperacion, int IdArchivo, string Tipo, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_ListarCampoIntercambio", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdArchivo", IdArchivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool ModificaCampoMedio(int iIdConexion, string cOperacion, string Tipo, int IdRegistro, string TipoMedio, string NombreCampo, string TipoDato, int Tamaño, string Tabla,
                                            string Campo, string Observacion, string ExpReg, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_ModificaCampoIntercambio", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRegistro", IdRegistro);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NombreCampo", NombreCampo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoDato", TipoDato);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tamaño", Tamaño);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tabla", Tabla);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Campo", Campo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", Observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ExpresionRegular", ExpReg);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool RegistraCampoMedio(int iIdConexion, string cOperacion, string TipoMedio, string NombreCampo, string TipoDato, int Tamaño, string Tabla,
                                            string Campo, string Observacion, string ExpReg, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Intercambio.PR_RegistraFormatoRegistro", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NombreCampo", NombreCampo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoDato", TipoDato);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tamaño", Tamaño);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tabla", Tabla);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Campo", Campo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", Observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ExpresionRegular", ExpReg);



                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
    }
}