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
using wcfEmisionCertificadoCC.Entidades;

namespace wcfEmisionCertificadoCC.Datos
{
    public class clsTipoCambioDA
    {
         Database db = null;
      
        public clsTipoCambioDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        /* Adiciona un Tipo de Cambio */
        public void AdicionarTipoCambio( int IdMoneda, int Resolucion, DateTime FechaResolucion, string TasaCambio, int RegistroActivo) //PARA BORRAR
        {
            
            string fec = Convert.ToString(FechaResolucion);
            fec= fec.Substring(0,10);
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioAdicionar",  IdMoneda, Resolucion, fec, Convert.ToString(TasaCambio), RegistroActivo); 
            db.ExecuteNonQuery(cmd);
        }
        //Adiciona un nuevo registro de Tipo de Cambio y Numero de Resolucion
        public bool AdcionaResolucionTipoCambio(int iIdConexion, string cOperacion,string FechaCambio,Int32 Moneda,string TipoCambio,string FechaResolucion,string Resolucion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fechaTipoCambio", FechaCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Moneda", Moneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipoCambio", TipoCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", FechaResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@resolucion", Resolucion);
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

        /* Elimina logicamente un Tipo de Cambio */
        public Boolean EliminarTipoCambio(DateTime Fecha)
        {
            try
            {
                string fec = Convert.ToString(Fecha);
                fec = fec.Substring(0, 10);
                DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioEliminar", fec);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /* Modificar un Tipo de Cambio */
        public void ModificarTipoCambio(DateTime Fecha, int IdMoneda, int Resolucion, DateTime FechaResolucion, string TasaCambio, int RegistroActivo)//PARA BORRAR
        {
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioModificar", Fecha, IdMoneda, Resolucion, FechaResolucion, TasaCambio, RegistroActivo);
            db.ExecuteNonQuery(cmd);
        }
        /* Lista tipos de Cambio */
        public IDataReader ListarTipoCambio() //PARA BORRAR
        {
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioListar");
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        /* Obtener tipos de Cambio*/
        public IDataReader ObtenerTipoCambio(DateTime Fecha) //PARA BORRAR
        {
            DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioObtener", Fecha);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;

        }
        /* Verificar Tipos de Cambio*/
        public IDataReader VerificarTipoCambio(DateTime Fecha,  int Resolucion) // PARA BORRAR
           {
               string fec = Convert.ToString(Fecha).Substring(0, 10);
               DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioVerificar", fec, Resolucion);
               IDataReader dataReader = db.ExecuteReader(dbCommand);
               return dataReader;
           }
        /* Verificar TipoCambio en los Certificado */
        public IDataReader VerificarTipoCambio_Certificado(DateTime Fecha) //PARA BORRAR
        {
            string fec = Convert.ToString(Fecha).Substring(0,10);
            DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_TipoCambioCertificadosVerificar", fec);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
        //Efectua la modificacion de el tipo de cambio y la resolucion del sello 11-06-2015
        public bool ActualizaCambioXresolucion(int iIdConexion, string cOperacion, string Fecha, int IdMoneda, string Resolucion, string FechaResolucion, string TasaCambio, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", FechaResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Moneda", IdMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@resolucion", Resolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fechaTipoCambio", Fecha);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipocambio", TasaCambio);
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

        //Verifica si existe la resolucion introducida es valida para la insercion 12-06-2015
        public bool VerificaResolucion(int iIdConexion, string cOperacion, string Resolucion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@resolucion", Resolucion);
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

        //Verifica si existen certificados emitidos con la resolucion a ser modificada 10-06-2015
        public bool VerificaCertificadosEmitidos(int iIdConexion, string cOperacion,string Fecha, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", Fecha);
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

        //Efectua la modificacion de el tipo de cambio y la resolucion del sello 11-06-2015
        public bool ActualizaTipoCambio(int iIdConexion, string cOperacion, string Fecha, int IdMoneda, string TasaCambio,string Observacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", Fecha);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Moneda", IdMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipocambio", TasaCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", Observacion);
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

        //Listado de los típos de Cambio 07-06-2015
        public bool ListarTiposdeCambios(int iIdConexion, string cOperacion,Int32 seleccion,ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@seleccion", seleccion);
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

        //Obtiene si existen registros para realizar la nueva adicion 12-06-2015
        public bool VerificaResolucionTipoCambio(int iIdConexion, string cOperacion,string FechaCambio,string Resolucion, Int32 IdMoneda,ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fechaTipoCambio", FechaCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@resolucion", Resolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Moneda", IdMoneda);
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

        //Carga el Combo de Tipos de Moneda 08-06-2015
        public bool ListaTiposMoneda(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
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

        //Obtiene Datos para efectuar modificaiones 08-06-2015
        public bool ObtieneDatosResolucion(int iIdConexion, string cOperacion,string FechaResolucion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                //ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", FechaResolucion);
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

        //Obtiene datos del Tipo de Cambio
        public bool DatosTipoCambio(int iIdConexion, string cOperacion, Int32 IdMoneda,string Fecha, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                //ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", Fecha);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Moneda", IdMoneda);
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

        //Obtiene la fecha del mes anterior para registrar el tipo de cambio 12-06-2015
        public bool FechaMesAnterior(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                //ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
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

        //Inserta el Dato dentro de la tabla TipoCambio
        public bool InsertaTipoCambio(int iIdConexion, string cOperacion, int IdMoneda, string Fecha, string TasaCambio,string Observacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_ResolucionSello", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Moneda", IdMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@fecha", Fecha);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@tipocambio", TasaCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observacion", Observacion);
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