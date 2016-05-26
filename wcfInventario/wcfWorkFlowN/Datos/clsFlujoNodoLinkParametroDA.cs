using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsFlujoNodoLinkParametroDA : clsWorkflowBaseDA {

        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iSecuencia { get; set; }
        public String sIdConcepto { get; set; }
        public Boolean bFlagSolicitud { get; set; }
        public String sComentarios { get; set; }

        /// <summary>
        /// Adiciona un enlace asociado a la actividad 
        /// </summary>
        /// <returns></returns>
        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_FlujoNodoLinkParametro", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagSolicitud", bFlagSolicitud);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
                
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                } else {
                    return (false);
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }  

        /// <summary>
        /// Modifica el parámetro asociado a un enlace determinado
        /// </summary>
        /// <returns></returns>
        public bool Modificacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_FlujoNodoLinkParametro", "U");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagSolicitud", bFlagSolicitud);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
                
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                } else {
                    return (false);
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }  

        /// <summary>
        /// Elimina el parámetro asociado a un enlace determinado
        /// </summary>
        /// <returns></returns>
        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_FlujoNodoLinkParametro", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                } else {
                    return (false);
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }  

        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_FlujoNodoLinkParametro", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool ObtieneParametrosXLinkNodo() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_FlujoNodoLinkParametro", "Q");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }


    }

}