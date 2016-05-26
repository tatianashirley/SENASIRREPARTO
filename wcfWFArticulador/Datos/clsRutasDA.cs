﻿using System;
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

namespace wcfWFArticulador.Datos
{

    public class clsRutaDA
    {
        string sMensajeError = "";
        Database db = null;
        public clsRutaDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }
        SqlConnection xconSenarit = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnsenarit"].ConnectionString.ToString());


        public bool ListaFlujo(int iIdConexion, string cOperacion, ref string sMensajeError,  ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
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
        public bool ListaAreaDestino(int iIdConexion, string cOperacion,int ?iIdArea,int iIdTipoFlujo, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaOrigen", iIdArea);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoFlujo", iIdTipoFlujo);
                ObjSPExec.p_RemplazarCeroPorDBNull = false;


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
        public bool ListaAreaOrigen(int iIdConexion, string cOperacion, int ?iIdArea,  ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);            
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaOrigen", iIdArea);
               


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
        public bool ListaRolDestino(int iIdConexion, string cOperacion, int? iIdArea, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaDestino", iIdArea);



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
        public bool InsertarRuta(int iIdConexion, string cOperacion, int iIdTipoFlujo, int iIdAreaOrigen, int iIdAreaDestino,int iIdRolOrigen, int iIdRolDestino,string sJustificacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoFlujo", iIdTipoFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaOrigen", iIdAreaOrigen);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaDestino", iIdAreaDestino);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRolDestino", iIdRolDestino);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRolOrigen", iIdRolOrigen);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sJustificacion", sJustificacion);
                


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
        public bool ListaRutas(int iIdConexion, string cOperacion, int iIdTipoFlujo,int iIdArea, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdAreaOrigen", iIdArea);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoFlujo", iIdTipoFlujo);



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
        public bool EliminaRuta(int iIdConexion, string cOperacion,int iIdRuta, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRuta", iIdRuta);
                



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
        public bool DeshabilitaRuta(int iIdConexion, string cOperacion, int iIdRuta, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_Rutas", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRuta", iIdRuta);
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

        /*
        public DataTable ListaTransacionporprocedimiento(int IdProcedimiento)
        {
            try
            {
                xconSenarit.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter("Seguridad.PR_ListaTransaccionporprocedimiento", xconSenarit);
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                adap.SelectCommand.Parameters.Add("@i_iIdProcedimiento", SqlDbType.Int).Value = IdProcedimiento;
                adap.Fill(dt);
                xconSenarit.Close();
                return dt;
            }
            catch
            {
                xconSenarit.Close();
                return null;

            }
        }
        public bool ListaTransaccionPorModulo(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdModulo, int iIdProcedimiento, ref string sMensajeError, ref string sNivelError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        //sNivelError = ObjSPExec.p_iNivelError.ToString();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        
        public bool TransaccionAdiciona(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iNroTransaccion, string sDescripcionTransaccion, int iIdProcedimiento, int iFlag, string sOperacionTrn, int iSegsTimeout, int iIdEstado, int iIdModulo, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", iNroTransaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcionTransaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagLog", iFlag);                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sOperacionTrn", sOperacionTrn);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSegsTimeout", iSegsTimeout);                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);



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

        public bool TransaccionModifica(int iIdConexion, string cOperacion, int iIdTransaccion, string sDescripcion, int iIdProcedimiento, int iFlagLog, string sOperacionTrn, int iSegsTimeout, int iIdEstado, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", iIdTransaccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagLog", iFlagLog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sOperacionTrn", sOperacionTrn);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSegsTimeout", iSegsTimeout);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);
                
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
        public bool ListaTransaccionPorId(int iIdConexion, string cOperacion, int iIdTransaccion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", iIdTransaccion);


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

        public bool ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);


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
         */

    }


}