using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos
{

    public class clsHisTipoTramiteDA : clsWorkflowBaseDA
    {
        public Int32 iIdHisInstancia { get; set; }
        public String sIdTipoTramite { get; set; }
        public String sDescripcion { get; set; }
        public String sIdTipoTramiteSup { get; set; }
        public Boolean bFlagAgrupador { get; set; }
        public Int32 iIdModulo { get; set; }
        public Boolean bFlagExcepcion { get; set; }
        public String sFlagReinicio { get; set; }
        public Int16 iMaxDiasIniTramite { get; set; }
        public Int16 iMaxDiasTramiteInactivo { get; set; }
        public Int32 iIdGrupoRestriccion { get; set; }

        //public bool Adicion()
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramite", "I");
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramiteSup", sIdTipoTramiteSup);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagAgrupador", bFlagAgrupador);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagExcepcion", bFlagExcepcion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sFlagReinicio", sFlagReinicio);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMaxDiasIniTramite", iMaxDiasIniTramite);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMaxDiasTramiteInactivo", iMaxDiasTramiteInactivo);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccion", iIdGrupoRestriccion);

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

        public bool Modificacion()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramite", "U");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", iIdHisInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramiteSup", sIdTipoTramiteSup);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagAgrupador", bFlagAgrupador);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagExcepcion", bFlagExcepcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sFlagReinicio", sFlagReinicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMaxDiasIniTramite", iMaxDiasIniTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMaxDiasTramiteInactivo", iMaxDiasTramiteInactivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccion", iIdGrupoRestriccion);

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

        //public bool Eliminacion()
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramite", "D");
        //    if (!ObjSPExec.p_bEstadoOK)
        //    {
        //        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
        //    }
        //    else
        //    {
        //        bool bAsignacionOK = true;
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramiteSup", sIdTipoTramiteSup);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagAgrupador", bFlagAgrupador);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdModulo", iIdModulo);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagExcepcion", bFlagExcepcion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sFlagReinicio", sFlagReinicio);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMaxDiasIniTramite", iMaxDiasIniTramite);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iMaxDiasTramiteInactivo", iMaxDiasTramiteInactivo);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccion", iIdGrupoRestriccion);

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

        public bool ObtieneFila()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisTipoTramite", "V");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", iIdHisInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Devuelve la totalidad de los conceptos
        /// </summary>
        /// <returns></returns>
        public bool ObtieneTiposDeTramite()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisTipoTramite", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

    }

}