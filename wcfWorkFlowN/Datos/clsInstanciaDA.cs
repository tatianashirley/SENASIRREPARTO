using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsInstanciaDA : clsWorkflowBaseDA {

        public Int64 iIdInstancia { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public String sIdTipoTramite { get; set; }
        public Int32 iIdFlujo { get; set; }
        public DateTime fFechaHrInicio { get; set; }
        public DateTime fFechaHrFin { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int64 iIdSolicitud { get; set; }
        public String sEstado { get; set; }
        public DateTime fCambioEstadoFechaHr { get; set; }
        public String sCancelaJustificacion { get; set; }
        public Int32 iCancelaIdOficina { get; set; }
        public Int32 iCancelaIdRol { get; set; }
        public Int32 iCancelaIdUsuario { get; set; }

        public Int64 iIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }

        /// <summary>
        /// Consulta una instancia específica
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_Instancia", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);

                if (bAsignacionOK) {
                    if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        iNivelError = ObjSPExec.p_iNivelError;
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                } else {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    iNivelError = ObjSPExec.p_iNivelError;
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

    }
}