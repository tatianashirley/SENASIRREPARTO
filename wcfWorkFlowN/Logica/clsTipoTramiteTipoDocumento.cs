using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsTipoTramiteTipoDocumento : clsTipoTramiteTipoDocumentoBE {

        clsTipoTramiteTipoDocumentoDA ObjTTrmteCptoDA = new clsTipoTramiteTipoDocumentoDA();

        public Boolean Adicion() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjTTrmteCptoDA.sComentarios = sComentarios;
            ObjTTrmteCptoDA.bFlagSolicitud = bFlagSolicitud;
            ObjTTrmteCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjTTrmteCptoDA.bFlagRepeticion = bFlagRepeticion;
            Boolean AnsOK = ObjTTrmteCptoDA.Adicion();
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjTTrmteCptoDA.sComentarios = sComentarios;
            ObjTTrmteCptoDA.bFlagSolicitud = bFlagSolicitud;
            ObjTTrmteCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjTTrmteCptoDA.bFlagRepeticion = bFlagRepeticion;
            Boolean AnsOK = ObjTTrmteCptoDA.Modificacion();
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjTTrmteCptoDA.Eliminacion();
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjTTrmteCptoDA.ObtieneFila();
            DSet = ObjTTrmteCptoDA.DSet;
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneConceptosXTipoTramite() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjTTrmteCptoDA.ObtieneTiposDocXTipoTramite();
            DSet = ObjTTrmteCptoDA.DSet;
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

    }

}