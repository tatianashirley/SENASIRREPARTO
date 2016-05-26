using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsTransicionMasivaDetDA : clsWorkflowBaseDA {

        public Int32 iIdTransicionMsva { get; set; }
        public Int16 iSecuencia { get; set; }
        public Int64 iIdInstanciaEjecucion { get; set; }
        public Int32 iSecuenciaEjecucion { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public byte iNivelOficina { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdArea { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iIdNodoPred { get; set; }
        public string sNemoNodoOrig { get; set; }
        public string sNemoNodoDest { get; set; }

        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TransicionMasivaDet", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransicionMsva", iIdTransicionMsva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstanciaEjecucion", iIdInstanciaEjecucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuenciaEjecucion", iSecuenciaEjecucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoDest", sNemoNodoDest);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoOrig", sNemoNodoOrig);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        Int32 iIdTransicionMsvaTmp = 0;
                        if (!ObjSPExec.ObtenerValorParametro("@o_iIdTransicionMsva", ref iIdTransicionMsvaTmp)) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         } else {
                             iIdTransicionMsva = iIdTransicionMsvaTmp;
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TransicionMasivaDet", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransicionMsva", iIdTransicionMsva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstanciaEjecucion", iIdInstanciaEjecucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuenciaEjecucion", iSecuenciaEjecucion);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Obtiene las actividades pendientes de un usuario específico y las actividades asignadas pero no confirmadas
        /// </summary>
        /// <returns></returns>
        public bool ObtieneActividadesPendientesXUsuario() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TransicionMasivaDet", "B");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransicionMsva", iIdTransicionMsva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);

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

        public bool ObtieneUsuarios() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
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
                        DataSet DSetINodo = new DataSet();
                        DSetINodo = ObjSPExec.p_DataSetResultado.Copy() ;
                        ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisFlujoNodo", "V");
                        if (!ObjSPExec.p_bEstadoOK) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        } else {
                            bAsignacionOK = true;
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", (Int32)DSetINodo.Tables[0].Rows[0]["IdHisInstancia"]);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", (Int32)DSetINodo.Tables[0].Rows[0]["IdFlujo"]);
                            bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemonico", sNemoNodoDest);
                            if (bAsignacionOK) {
                                if (!ObjSPExec.EjecutarProcedimientoQry()) {
                                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                                } else {
                                    DataSet DSetHFNodo = new DataSet();
                                    DSetHFNodo = ObjSPExec.p_DataSetResultado.Copy();
                                    ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_HisTipoTramiteRolUsuario", "S");
                                    if (!ObjSPExec.p_bEstadoOK) {
                                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                                    } else {
                                        bAsignacionOK = true;
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", (Int32)DSetINodo.Tables[0].Rows[0]["IdHisInstancia"]);
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", DSetINodo.Tables[0].Rows[0]["IdTipoTramite"].ToString());
                                        bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", DSetHFNodo.Tables[0].Rows[0]["IdRol"].ToString());
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

                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool ObtieneActividadesDisponilesParaAsignacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_TransicionMasivaDet", "Q");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTransicionMsva", iIdTransicionMsva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoOrig", sNemoNodoOrig);

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