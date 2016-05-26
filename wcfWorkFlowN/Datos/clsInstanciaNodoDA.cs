using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsInstanciaNodoDA : clsWorkflowBaseDA {

        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite { get; set; }
        public Int64 iIdSolicitud { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iContador { get; set; }
        public DateTime fFechaHrInicio { get; set; }
        public DateTime fFechaHrFin { get; set; }
        public Byte iNivelOficina { get; set; }
        public Int32? iIdOficina { get; set; }
        public Int32? iIdArea { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public string sComentarios { get; set; }
        public Int32 iSecuenciaPred { get; set; }
        public Int16 iIdNodoPred { get; set; }
        public Boolean bFlagCbteTrasladoDoc { get; set; }
        public Boolean bFlagCbteTrasladoDocOK { get; set; }
        public Int64 iIdCbteTrasladoDoc { get; set; }
        public string sEstado { get; set; }

        public string sIdListaNodoTrg { get; set; }
        public Int32 iIdUsuarioTrg { get; set; }
        public Boolean bFlagDesdeCbteTrasdoDoc { get; set; }

        public string sNemoNodoOrig { get; set; }
        public string sNemoNodoDest { get; set; }

        public Int64 iIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public DateTime? fFechaDesde { get; set; }
        public DateTime? fFechaHasta { get; set; }
        public string sNombreAsegurado { get; set; }

        public Boolean bFlagManual { get; set; }

        /// <summary>
        /// Consulta la bandeja de trámites para el usuario conectado
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneActividadesXUsuario () {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "Q");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaDesde", fFechaDesde);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaHasta", fFechaHasta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreAsegurado", sNombreAsegurado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);

                if (bAsignacionOK) {
                    if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        iNivelError = ObjSPExec.p_iNivelError;
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Consulta la bandeja de trámites para el usuario especificado
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneActividadesXUsuarioEspecifico () {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "P");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "P");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuarioTrg", iIdUsuarioTrg);

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
        /// Devuelve las actividades habilitada para transiciones masivas (asignaciones)
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneTransicionesParaAsignacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "W");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "W");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
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
        /// Devuelve las actividades habilitadas para generación de comprobantes de traslado de documentos 
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneTransicionesParaGeneracionDeCbte() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "Y");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Y");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
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

        /// <summary>
        /// Obtiene las actividade a las cuales es posible realizar la transición
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneTransicionesPosibles() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "S");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagManual", bFlagManual);
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
        /// Obtiene las actividades para realizar asignaciones dado el nemónico del nodo origen
        /// </summary>
        /// <param name="sNemoNodoOrig"></param>
        /// <returns></returns>
        public Boolean ObtieneActividadesParaAsignacion(string sNemoNodoOrig, string sNemoNodoDest) {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "A");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "A");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoOrig", sNemoNodoOrig);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoDest", sNemoNodoDest);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaDesde", fFechaDesde);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaHasta", fFechaHasta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreAsegurado", sNombreAsegurado);

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
        /// Obtiene las actividades para generación de comprobante de traslado de documentos
        /// </summary>
        /// <param name="sNemoNodoOrig"></param>
        /// <returns></returns>
        public Boolean ObtieneActividadesParaGeneracionCbte(string sNemoNodoOrig) {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "J");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "J");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
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

        /// <summary>
        /// Devuelve verdadero si existen actividades habilotadas para las asignaciones
        /// </summary>
        /// <param name="sNemoNodoOrig"></param>
        /// <returns></returns>
        public Boolean ExistenActividadesParaAsignacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "B");
            Boolean Ans = true;
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        Ans = false;
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                        Ans = (DSet.Tables[0].Rows.Count > 0);
                    }
                } else {
                    Ans = false;
                }
            }
            return (Ans);
        }

        /// <summary>
        /// Devuelve una bandera que indica si existen actividades pendientes que deben ser aceptadas con un comprobante de traslado de documentos
        /// </summary>
        /// <returns></returns>
        public Boolean ExistenActividadesParaGenerarConCbte() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "R");
            Boolean Ans = true;
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "R");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                        Ans = (DSet.Tables[0].Rows.Count > 0);
                    }
                   Ans = ObjSPExec.p_bEstadoOK;
                } else {
                    Ans = false;
                }
            }
            return (Ans);
        }

        /// <summary>
        /// Devuelve una bandera que indica si existen actividades pendientes que deben ser aceptadas con un comprobante de traslado de documentos
        /// </summary>
        /// <returns></returns>
        public Boolean ExistenActividadesParaAceptarConCbte() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "Q");
            Boolean Ans = true;
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        Ans = ObjSPExec.p_bEstadoOK;
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                        DataRow[] ArrDRow = DSet.Tables[0].Select("EstadoCod='W'");
                        Ans = (ArrDRow.Length > 0);
                    }
                } else {
                    Ans = false;
                }
            }
            return (Ans);
        }

        /// <summary>
        /// Obtiene el instorial de ejecución de un trámite
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneHistorialEjecucion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "H");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "H");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
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
        
        public Boolean ObtieneTramitesXUsuario() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "M");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "M");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficina", iIdOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdArea", iIdArea);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaDesde", fFechaDesde);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaHasta", fFechaHasta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sEstado", sEstado);

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
        /// Devuelve un actividad en ejecución específica
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
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

        /// <summary>
        /// Realiza la transición especificada
        /// </summary>
        /// <returns></returns>
        public Boolean RealizaTransicion () {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdListaNodoTrg", sIdListaNodoTrg);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagManual", bFlagManual);

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
        /// Obtiene los datos de la actividad en ejecución a partir de la identificación del mismo y 
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneActividadActiva() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaQry", "Q");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdNodoNemonico", sNemoNodoOrig);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sEstado", sEstado);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        Int64 iIdInstanciaTmp = 0;
                        if (!ObjSPExec.ObtenerValorParametro("@o_iIdInstancia", ref iIdInstanciaTmp)) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         } else {
                             iIdInstancia = iIdInstanciaTmp;
                        }
                        Int32 iSecuenciaTmp = 0;
                        if (!ObjSPExec.ObtenerValorParametro("@o_iSecuencia", ref iSecuenciaTmp)) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         } else {
                             iSecuencia = iSecuenciaTmp;
                        }

                   }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

    }

}