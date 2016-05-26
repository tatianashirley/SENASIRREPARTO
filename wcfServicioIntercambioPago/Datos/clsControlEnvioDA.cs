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
using SQLSPExecuter;

namespace wcfServicioIntercambioPago.Datos
{
    public class clsControlEnvioDA
    {
        Database db = null;

        public clsControlEnvioDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        //Inserta datos del envio en ControlEnvioCC
        //public Boolean RegistraEnvioCC(string IdEntidad, string IdEnvio, string Periodo, int NumeroEnvio, string IdEstado
        //                                ,string CodigoSeguridad, string RutaEnvio,int CantidadRegistros)
        //{
        //    try
        //    {
        //        DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_RegistraEnvio", IdEntidad,IdEnvio,Periodo,NumeroEnvio
        //                                                        ,IdEstado,CodigoSeguridad,RutaEnvio,CantidadRegistros);
        //        db.ExecuteNonQuery(dbCommand);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //Actualiza el estado del envio en ControlEnvioCC
        //public Boolean ModificaEnvioCC(string Entidad, string TipoMedio, string Periodo, int NumeroEnvio, string IdEstado
        //                                     , string CodigoSeguridad, int CantidadRegistros)
        //{
        //    try
        //    {
        //        DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_ModificaEnvio", Entidad, TipoMedio, Periodo, NumeroEnvio
        //                                                        , IdEstado,CodigoSeguridad,CantidadRegistros);
        //        db.ExecuteNonQuery(dbCommand);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //obtiene el numero de envio esperado que corresponde para la carga
        //public IDataReader ObtieneEnvio(int IdEntidad, int IdEnvio, int Periodo)
        //{
        //    DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_ObtieneEnvio", IdEntidad,IdEnvio,Periodo);
        //    IDataReader dataReader = db.ExecuteReader(dbCommand);
        //    return dataReader;
        //}
        //obtiene vistas segun el tipo solicitado
        //public IDataReader ObtieneVistas(string TipoVista,string Entidad, string TipoMedio,string Periodo,string Estado, int NumeroEnvio)
        //{
        //    DbCommand dbCommand = db.GetStoredProcCommand("PagoCC.PR_Vistas", TipoVista,Entidad,TipoMedio,Periodo,Estado,NumeroEnvio);
        //    IDataReader dataReader = db.ExecuteReader(dbCommand);
        //    return dataReader;
        //}

        /*******************con seguridad****************************/
        public bool ObtieneVistas(int iIdConexion, string cOperacion, string TipoVista, string Entidad, string TipoMedio, string Periodo
                                    , string Estado, int NumeroEnvio, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_Vistas", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoVista", TipoVista);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Entidad", Entidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estado", Estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroEnvio", NumeroEnvio);


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

        public bool RegistraEnvioCC(int iIdConexion, string cOperacion, string Entidad, string TipoMedio, string Periodo, int NumeroEnvio
                                    , string Estado, string CodigoSeguridad, string RutaEnvio, int CantidadRegistros, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_RegistraEnvio", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroEnvio", NumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estado", Estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoSeguridad", CodigoSeguridad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@RutaEnvio", RutaEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CantidadRegistros", CantidadRegistros);

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

        public bool ModificaEnvioCC(int iIdConexion, string cOperacion, string Entidad, string TipoMedio, string Periodo, int NumeroEnvio
                                    , string Estado, string CodigoSeguridad, int CantidadRegistros, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoCC.PR_ModificaEnvio", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMedio", TipoMedio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroEnvio", NumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Estado", Estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CodigoSeguridad", CodigoSeguridad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CantidadRegistros", CantidadRegistros);

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