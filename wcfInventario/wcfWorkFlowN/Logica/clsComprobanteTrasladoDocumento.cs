using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsComprobanteTrasladoDocumento : clsComprobanteTrasladoDocumentoBE {

        clsComprobanteTrasladoDocumentoDA ObjCbteTrsldoDocDA = new clsComprobanteTrasladoDocumentoDA();

        public Boolean Adicion() {
            ObjCbteTrsldoDocDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDA.iSesionTrabajo = iSesionTrabajo;
            ObjCbteTrsldoDocDA.sComentarioGeneral = sComentarioGeneral;
            Boolean AnsOK = ObjCbteTrsldoDocDA.Adicion();
            iIdComprobante = ObjCbteTrsldoDocDA.iIdComprobante;
            sMensajeError = ObjCbteTrsldoDocDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjCbteTrsldoDocDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDA.iIdComprobante = iIdComprobante;
            Boolean AnsOK = ObjCbteTrsldoDocDA.Modificacion();
            sMensajeError = ObjCbteTrsldoDocDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjCbteTrsldoDocDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDA.iIdComprobante = iIdComprobante;
            Boolean AnsOK = ObjCbteTrsldoDocDA.ObtieneFila();
            DSet = ObjCbteTrsldoDocDA.DSet;
            sMensajeError = ObjCbteTrsldoDocDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneCbtesPendientesXUsuario() {
            ObjCbteTrsldoDocDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjCbteTrsldoDocDA.ObtieneCbtesPendientesXUsuario();
            DSet = ObjCbteTrsldoDocDA.DSet;
            sMensajeError = ObjCbteTrsldoDocDA.sMensajeError;
            return (AnsOK);
        }

    }
}