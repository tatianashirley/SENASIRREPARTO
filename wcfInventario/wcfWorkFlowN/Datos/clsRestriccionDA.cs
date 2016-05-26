using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

	public class clsRestriccionDA : clsWorkflowBaseDA {

        public Int32 iIdRestriccion { get; set; }
        public string sDescripcion { get; set; }
        public string sIdConcepto { get; set; }
        public Int32 iIdTipoDocumento { get; set; }
        public string sTipoDato { get; set; }
        public string sComentarios { get; set; }
        public string sTipoRestriccion { get; set; }
        public Int32? iValor1Int { get; set; }
        public decimal? mValor1Money { get; set; }
        public double? dValor1Float { get; set; }
        public string sValor1Char { get; set; }
        public DateTime? fValor1Date { get; set; }
        public Int32? iValor1Catalog { get; set; }
        public Boolean? bValor1Bit { get; set; }
        public Int32? iValor2Int { get; set; }
        public decimal? mValor2Money { get; set; }
        public double? dValor2Float { get; set; }
        public DateTime? fValor2Date { get; set; }
        public Boolean bFlagNegacion { get; set; }
        public Int32 iIdRestriccionDesde { get; set; }
        public Int32 iIdRestriccionHasta { get; set; }

        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_Restriccion", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRestriccion", iIdRestriccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", iIdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoDato", sTipoDato);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoRestriccion", sTipoRestriccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValor1Int", iValor1Int);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValor1Money", mValor1Money);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValor1Float", dValor1Float);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValor1Char", sValor1Char);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValor1Date", fValor1Date);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValor1Catalog", iValor1Catalog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValor1Bit", bValor1Bit);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValor2Int", iValor2Int);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValor2Money", mValor2Money);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValor2Float", dValor2Float);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValor2Date", fValor2Date);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagNegacion", bFlagNegacion);

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
        
        public bool Modificacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_Restriccion", "U");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRestriccion", iIdRestriccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDescripcion", sDescripcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", iIdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoDato", sTipoDato);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarios", sComentarios);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoRestriccion", sTipoRestriccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValor1Int", iValor1Int);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValor1Money", mValor1Money);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValor1Float", dValor1Float);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValor1Char", sValor1Char);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValor1Date", fValor1Date);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValor1Catalog", iValor1Catalog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValor1Bit", bValor1Bit);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValor2Int", iValor2Int);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValor2Money", mValor2Money);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValor2Float", dValor2Float);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValor2Date", fValor2Date);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bFlagNegacion", bFlagNegacion);

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

        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_Restriccion", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRestriccion", iIdRestriccion);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }  

        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_Restriccion", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRestriccion", iIdRestriccion);
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

        public bool ObtieneRestricciones() { 
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_Restriccion", "Q");
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
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

	}
}