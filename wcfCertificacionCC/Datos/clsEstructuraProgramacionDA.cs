using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Resources;
using SQLSPExecuter;

namespace wcfCertificacionCC.Datos
{
    public class clsEstructuraProgramacionDA
    {
        string sMensajeError = "";
        public bool ConsultaEstructuraProgramacion(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionEstructura", cOperacion);

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

        public bool EstructuraProgramacionModifica(int iIdConexion, string cOperacion, int iIdEstructura, string sDescripcion,int iEstado, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionEstructura", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bEstadoEstructura", iEstado);
                

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
        public bool EstructuraProgramacionAdiciona(int iIdConexion,string cOperacion,string sDescripcion, ref string sMensajeError,ref int iIdEstructura)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionEstructura", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@o_iIdEstructura", ref iIdEstructura);
                        iIdEstructura = Convert.ToInt32(iIdEstructura);
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool EstructuraProgramacionElimina(int iIdConexion, string cOperacion, int iIdEstructura, int iIdRol, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_EstructuraDetalle", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                

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

        public bool EstructuraDetalleAdiciona(int iIdConexion, string cOperacion, int iIdEstructura, int iIdRolSuperior, int iIdRol,int iCantidad, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_EstructuraDetalle", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRolSuperior", iIdRolSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCantidad", iCantidad);

                

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

        ////public bool TransaccionModifica(int iIdConexion, string cOperacion, int iIdTransaccion, string sDescripcion, int iIdProcedimiento, int iFlagLog, string sOperacionTrn, int iSegsTimeout, int iIdEstado, ref string sMensajeError)
        ////{
        ////    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
        ////    if (!ObjSPExec.p_bEstadoOK)
        ////    {
        ////        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        ////    }
        ////    else
        ////    {
        ////        bool bAsignacionOK = true;
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransaccion", iIdTransaccion);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagLog", iFlagLog);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sOperacionTrn", sOperacionTrn);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSegsTimeout", iSegsTimeout);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstado", iIdEstado);

        ////        if (bAsignacionOK)
        ////        {
        ////            if (!ObjSPExec.EjecutarProcedimientoNonQry())
        ////            {
        ////                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        ////            }

        ////        }
        ////    }
        ////    return (ObjSPExec.p_bEstadoOK);
        ////}
        public bool ListaRolSuperior(int iIdConexion,string cOperacion,int iIdModulo,int iIdRolSuperior,string cLista, ref string  sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Rol", cOperacion);
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_cLista", cLista);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRolSuperior", iIdRolSuperior);


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
        
        public bool ConsultaEstructuraDetalle( int iIdConexion,string cOperacion,int iIdEstructura,ref string sMensajeError,ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_EstructuraDetalle", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
                


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
        
        public bool ProgramacionEstructuraListaPorId(int iIdConexion,string cOperacion,int  iIdEstructura, ref string sMensajeError,ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionEstructura", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
                


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
        ////public bool ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError, ref DataSet DSetTmp)
        ////{
        ////    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_Transaccion", cOperacion);
        ////    if (!ObjSPExec.p_bEstadoOK)
        ////    {
        ////        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        ////    }
        ////    else
        ////    {
        ////        bool bAsignacionOK = true;
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
        ////        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProcedimiento", iIdProcedimiento);


        ////        if (bAsignacionOK)
        ////        {
        ////            if (!ObjSPExec.EjecutarProcedimientoQry())
        ////            {
        ////                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        ////            }
        ////            else
        ////            {
        ////                DSetTmp = ObjSPExec.p_DataSetResultado;
        ////            }
        ////        }
        ////    }
        ////    return (ObjSPExec.p_bEstadoOK);
        ////}

    }


}