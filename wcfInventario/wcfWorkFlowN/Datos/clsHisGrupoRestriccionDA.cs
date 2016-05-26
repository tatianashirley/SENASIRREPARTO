using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos
{

    public class clsHisGrupoRestriccionDA : clsWorkflowBaseDA
    {
        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdGrupoRestriccion { get; set; }
        public string sDescripcion { get; set; }
        public string sComentarios { get; set; }
        public string sReglaEvaluacion { get; set; }

        public Int32 iIdGrupoRestriccionDesde { get; set; }
        public Int32 iIdGrupoRestriccionHasta { get; set; }

        //public bool Adicion()
        //{
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_GrupoRestriccion", "I");
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
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccion", iIdGrupoRestriccion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sReglaEvaluacion", sReglaEvaluacion);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccionDesde", iIdGrupoRestriccionDesde);
        //        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccionHasta", iIdGrupoRestriccionHasta);

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
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisGrupoRestriccion", "U");
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccion", iIdGrupoRestriccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sReglaEvaluacion", sReglaEvaluacion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccionDesde", iIdGrupoRestriccionDesde);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccionHasta", iIdGrupoRestriccionHasta);

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
        //    ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_GrupoRestriccion", "D");
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
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisGrupoRestriccion", "V");
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoRestriccion", iIdGrupoRestriccion);

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

        public bool ObtieneGruposDeRestricciones()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisGrupoRestriccion", "Q");
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