using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsTipoTramiteConceptoDA : clsWorkflowBaseDA {

        public string sIdTipoTramite { get; set; }
        public string sIdConcepto { get; set; }
        public Int16 iOrden { get; set; }
        public Boolean bFlagSolicitud { get; set; }
        public Boolean bFlagModificable { get; set; }
        public Boolean bFlagObligatorio { get; set; }
        public Boolean bFlagDeterminaFlujo { get; set; }
        public Int32? iValorInt { get; set; }
        public Decimal? mValorMoney { get; set; }
        public Double? dValorFloat { get; set; }
        public String sValorChar { get; set; }
        public DateTime? fValorDate { get; set; }
        public Int32? iValorCatalog { get; set; }
        public Boolean? bValorBoolean { get; set; }

        /// <summary>
        /// Añade un concepto al tipo de trámite
        /// </summary>
        /// <returns></returns>
        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramiteConcepto", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iOrden", iOrden);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagSolicitud", bFlagSolicitud);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagModificable", bFlagModificable);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagObligatorio", bFlagObligatorio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagDeterminaFlujo", bFlagDeterminaFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorInt", iValorInt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValorMoney", mValorMoney);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValorFloat", dValorFloat);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValorChar", sValorChar);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValorDate", fValorDate);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorCatalog", iValorCatalog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValorBoolean", bValorBoolean);

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
        /// Modifica un concepto asociado al tipo de trámite
        /// </summary>
        /// <returns></returns>
        public bool Modificacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramiteConcepto", "U");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iOrden", iOrden);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagSolicitud", bFlagSolicitud);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagModificable", bFlagModificable);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagObligatorio", bFlagObligatorio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagDeterminaFlujo", bFlagDeterminaFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorInt", iValorInt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValorMoney", mValorMoney);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValorFloat", dValorFloat);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValorChar", sValorChar);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValorDate", fValorDate);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorCatalog", iValorCatalog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValorBoolean", bValorBoolean);
                
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        } 

        /// <summary>
        /// Modifica un concepto asociado al tipo de trámite
        /// </summary>
        /// <returns></returns>
        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramiteConcepto", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        } 

        /// <summary>
        /// Devuelve la definición de un concepto específico asociado a un tipo de trámite
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramiteConcepto", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
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

        /// <summary>
        /// Devuelve la totalidad de los conceptos
        /// </summary>
        /// <returns></returns>
        public bool ObtieneConceptosXTipoTramite() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TipoTramiteConcepto", "Q");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);

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