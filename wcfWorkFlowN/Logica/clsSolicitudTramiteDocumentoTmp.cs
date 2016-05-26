using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsSolicitudTramiteDocumentoTmp : clsSolicitudTramiteDocumentoTmpBE {

        clsSolicitudTramiteDocumentoTmpDA ObjSolicTrmteCptoDA = new clsSolicitudTramiteDocumentoTmpDA();

        public Boolean Adicion() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjSolicTrmteCptoDA.iIdDocumento = iIdDocumento;
            Boolean AnsOK = ObjSolicTrmteCptoDA.Adicion();
            iSesionTrabajo = ObjSolicTrmteCptoDA.iSesionTrabajo;
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjSolicTrmteCptoDA.iIdDocumento = iIdDocumento;
            Boolean AnsOK = ObjSolicTrmteCptoDA.Eliminacion();
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean EliminacionTodos() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjSolicTrmteCptoDA.iIdDocumento = iIdDocumento;
            Boolean AnsOK = ObjSolicTrmteCptoDA.EliminacionTodos();
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

         public Boolean ObtieneFila() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjSolicTrmteCptoDA.iIdDocumento = iIdDocumento;
            Boolean AnsOK = ObjSolicTrmteCptoDA.ObtieneFila();
            DSet = ObjSolicTrmteCptoDA.DSet;
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

         public Boolean ObtieneDocumentosRegistrados() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            Boolean AnsOK = ObjSolicTrmteCptoDA.ObtieneDocumentosRegistrados();
            DSet = ObjSolicTrmteCptoDA.DSet;
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

    }

}