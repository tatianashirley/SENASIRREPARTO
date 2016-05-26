using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsHisFlujoNodoLinkDA : clsWorkflowBaseDA {

        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iSecuencia { get; set; }
        public string sDescripcion { get; set; }
        public string sLink { get; set; }
        public Boolean bFlagObligatorio { get; set; }
        public string sEstado { get; set; }

        public Int64 iIdInstanciaEjecucion { get; set; }
        public Int32 iSecuenciaEjecucion { get; set; }

        public bool ObtieneDefinicionLinksXActividad () {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "V");
            bool bAsignacionOK = true;

            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstanciaEjecucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuenciaEjecucion);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        iIdHisInstancia = Int32.Parse(ObjSPExec.p_DataSetResultado.Tables[0].Rows[0]["IdHisInstancia"].ToString());
                        iIdFlujo = Int32.Parse(ObjSPExec.p_DataSetResultado.Tables[0].Rows[0]["IdFlujo"].ToString());
                        iIdNodo = Int16.Parse(ObjSPExec.p_DataSetResultado.Tables[0].Rows[0]["IdNodo"].ToString());
                        ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisFlujoNodoLink", "V");

                        if (!ObjSPExec.p_bEstadoOK) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        } else {
                            bAsignacionOK = true;
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", iIdHisInstancia);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);

                            if (bAsignacionOK) {
                               if (!ObjSPExec.EjecutarProcedimientoQry()) {
                                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                                } else {
                                    DSet = ObjSPExec.p_DataSetResultado;
                                }
                            }
                        }
                    }
                }
            }

            return (ObjSPExec.p_bEstadoOK);        
        }

        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisFlujoNodoLink", "V");

            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", iIdHisInstancia);
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