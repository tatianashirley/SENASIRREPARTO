using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Resources;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using wcfServicioIntercambioPago.Entidades;
using SQLSPExecuter;

namespace wcfServicioIntercambioPago.Datos
{
    public class clsPagoCCDA
    {

        Database db = null;

        public clsPagoCCDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
         /*Ejecuta Prevalidacion y Recupera Errores si existen*/
        public IDataReader Prevalida(string IdEntidad, string Periodo, string CodigoMedio, int NumeroEnvio, bool Continuo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_Prevalida", CodigoMedio, IdEntidad, Periodo, NumeroEnvio, Continuo);
            cmd.CommandTimeout = 0;
            IDataReader dr = db.ExecuteReader(cmd);
            return dr;
        }
        /*prueba con parametro de salida*/
        /*public string Prevalida(string IdEntidad, string Periodo, string CodigoMedio,out string prueba)
        {
            DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_Prevalida", IdEntidad, Periodo, CodigoMedio, prueba);
            prueba = db.ExecuteReader(cmd).ToString();
            return prueba;
        }*/
         /*Obtine datos segun el parametro Tipo*/
        //public IDataReader ObtieneDatos(string Tipo, string Paterno, string Materno, string Nombre1, string Nombre2, string NumeroDocumento
        //                                , string Matricula, string CUA, Int64 NUP)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_BuscaHistorial", Tipo, Paterno, Materno, Nombre1, Nombre2, NumeroDocumento
        //                                               , Matricula, CUA, NUP);
        //    IDataReader dr = db.ExecuteReader(cmd);
        //    return dr;
        //}
        //agrega una excepcion
        //public Boolean RegistraExcepcion(string CodigoError,Int64 NUP, Int64 IDHT,string Justificacion, string PeriodoInicio
        //                                ,string PeriodoFinal)
        //{
        //    try
        //    {
        //        DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_RegistraExcepcion", CodigoError, NUP, IDHT, Justificacion
        //                                                        , PeriodoInicio, PeriodoFinal);
        //        db.ExecuteNonQuery(dbCommand);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //Modifica o desactiva la excepcion
        //public Boolean ModificaExcepcion(string Tipo,int IdExcepcion,string CodigoError, string Justificacion, string PeriodoInicio
        //                                , string PeriodoFinal)
        //{
        //    try
        //    {
        //        DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_ModificaExcepcion", Tipo, IdExcepcion, CodigoError, Justificacion
        //                                                        , PeriodoInicio, PeriodoFinal);
        //        db.ExecuteNonQuery(dbCommand);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //Ejecuta la validacion general
        public IDataReader ValidacionCentral(string TipoMedio, string Entidad, string Periodo, Int32 NumeroEnvio,bool Continuo)
        {
            DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_ValidacionCentral", TipoMedio, Entidad, Periodo,NumeroEnvio,Continuo);
            cmd.CommandTimeout = 0;
            IDataReader dr = db.ExecuteReader(cmd);
            return dr;
        }
        //// Modificar la revision en las temporales 
        public void CambiarEstadoRevision(string TipoMedio, Int64 CUA, int NumeroCertificado, string TipoCC, Int64 NumeroDocumento
                                            , string PeriodoPlanilla, string FechaInicio, int CodigoTransaccion, string Revision,decimal Monto)
        {
            DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_CambiarEstadoRevision", TipoMedio, CUA, NumeroCertificado,
                                                    TipoCC, NumeroDocumento, PeriodoPlanilla, FechaInicio, CodigoTransaccion, Revision,Monto);
            db.ExecuteNonQuery(cmd);
        }
        public Boolean GeneraConvenios(string TipoMEdio, string Entidad)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_GeneraTransConvenio", TipoMEdio,Entidad);
                dbCommand.CommandTimeout = 0;
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataReader RevisaMediosFinales(string TipoMedio, string Entidad)
        {
            DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_RevisaMediosFinales", TipoMedio, Entidad);
            cmd.CommandTimeout = 0;
            IDataReader dr = db.ExecuteReader(cmd);
            return dr;
        }

        public void GenerarConvenios(string Entidad)
        {
            DbCommand cmd = db.GetStoredProcCommand("PagoCC.PR_ObtenerDeuda", Entidad);
            cmd.CommandTimeout = 0;
            db.ExecuteNonQuery(cmd);
        }   
        /*************con seguridad*********************/
        public bool ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1, string Nombre2
                                , string NumeroDocumento, string Matricula, string CUA, Int64 NUP, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_BuscaHistorial", cOperacion);
            
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Paterno", Paterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Materno", Materno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre1", Nombre1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre2", Nombre2);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CI", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Matricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);

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

        public bool ModificaExcepcion(int iIdConexion, string cOperacion, string Tipo, int IdExcepcion, string CodigoError, string Justificacion
                                    , string PeriodoInicio, string PeriodoFinal, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ModificaExcepcion", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdExcepcion", IdExcepcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoError", CodigoError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Justificacion", Justificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoInicio", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoFinal", PeriodoFinal);

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

        public bool RegistraExcepcion(int iIdConexion, string cOperacion, string CodigoError, Int64 NUP, Int64 IDHT, string Justificacion
                                        , string PeriodoInicio, string PeriodoFinal, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_RegistraExcepcion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoError", CodigoError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IDHT", IDHT);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Justificacion", Justificacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoInicio", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoFinal", PeriodoFinal);

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

        public bool ForzarError(int iIdConexion, string cOperacion, Int64 CUA, int NumeroCertificado, Int64 NumeroDocumento, int Transaccion
                                , string PeriodoPlanilla, string FechaInicio, string CodigoError,string Entidad, string TipoMedio
                                , string Periodo, int NumeroEnvio, string TipoCC, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ForzarError", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCertificado", NumeroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Transaccion", Transaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoPlanilla", PeriodoPlanilla);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaInicio", FechaInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoError", CodigoError);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroEnvio", NumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoCC", TipoCC);

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

        //public bool ConsolidaTitulares(int iIdConexion, string cOperacion, string TipoMedio, string Entidad,ref string sMensajeError)
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ConsolidaTitulares", cOperacion);
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);

        //        if (bAsignacionOK)
        //        {
        //            if (!ObjSPExec.EjecutarProcedimientoNonQry())
        //            {
        //                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //            }

        //        }
        //    }
        //    return (ObjSPExec.p_bEstadoOK);
        //}

        //public bool ConsolidaBeneficiarios(int iIdConexion, string cOperacion, string TipoMedio, string Entidad, ref string sMensajeError)
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ConsolidaBeneficiarios", cOperacion);
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);

        //        if (bAsignacionOK)
        //        {
        //            if (!ObjSPExec.EjecutarProcedimientoNonQry())
        //            {
        //                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //            }

        //        }
        //    }
        //    return (ObjSPExec.p_bEstadoOK);
        //}

        //public bool ConsolidaPagos(int iIdConexion, string cOperacion, string TipoMedio, string Entidad, string Planilla, string Periodo, ref string sMensajeError)
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ConsolidaPagos", cOperacion);
        //    //ObjSPExec.p_SegsTimeout = 0;//revisar si esto lo deja sin limite time out
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Planilla", Planilla);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoSol", Periodo);

        //        if (bAsignacionOK)
        //        {
        //            if (!ObjSPExec.EjecutarProcedimientoNonQry())
        //            {
        //                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //            }

        //        }
        //    }
        //    return (ObjSPExec.p_bEstadoOK);
        //}

        //public bool ConsolidaConciliaciones(int iIdConexion, string cOperacion, string TipoMedio, string Entidad, string Planilla, string Periodo, ref string sMensajeError)
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ConsolidaConciliaciones", cOperacion);
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Planilla", Planilla);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoSol", Periodo);

        //        if (bAsignacionOK)
        //        {
        //            if (!ObjSPExec.EjecutarProcedimientoNonQry())
        //            {
        //                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //            }

        //        }
        //    }
        //    return (ObjSPExec.p_bEstadoOK);
        //}

        public bool ConsolidaProceso(int iIdConexion, string cOperacion, string TipoProceso, string Entidad, string Periodo, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ConsolidaProceso", cOperacion);
            ObjSPExec.p_SegsTimeout = 0;
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoProceso", TipoProceso);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoSolicitud", Periodo);

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

        public bool RegistraFormC31(int iIdConexion, string cOperacion, string Entidad, string Periodo, int FormC31
                                    , string Anio, string Mes, int IdFinanciera, int IdGrupoBeneficio, int IdBeneficio
                                    , decimal Monto, string Observaciones, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_RegistraC31", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FormC31", FormC31);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Anio", Anio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Mes", Mes);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdFinanciera", IdFinanciera);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdGrupoBeneficio", IdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdBeneficio", IdBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoFormulario", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", Observaciones);

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

        public bool ModificaFormC31(int iIdConexion, string cOperacion, string Entidad, string Periodo, int FormC31
                                    , string Anio, string Mes, int IdFinanciera, decimal Monto, string Observaciones
                                    , ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ModificaC31", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FormC31", FormC31);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Anio", Anio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Mes", Mes);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdFinanciera", IdFinanciera);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoFormulario", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", Observaciones);

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

        public bool RegistraIncremento(int iIdConexion, string cOperacion, int Gestion, int IdTipoCC,decimal MontoInferior
                                        , decimal MontoSuperior, decimal Incremento, decimal Porcentaje, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_RegistraIncremento", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Gestion", Gestion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCC", IdTipoCC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoInferior", MontoInferior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoSuperior", MontoSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Incremento", Incremento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Porcentaje", Porcentaje);

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

        public bool ModificaIncremento(int iIdConexion, string cOperacion, string Tipo, int Gestion, int IdIntervalo, int IdTipoCC, decimal MontoInferior
                                        , decimal MontoSuperior, decimal Incremento, decimal Porcentaje, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ModificaIncremento", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Gestion", Gestion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdIntervalo", IdIntervalo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoCC", IdTipoCC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoInferior", MontoInferior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoSuperior", MontoSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Incremento", Incremento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Porcentaje", Porcentaje);

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