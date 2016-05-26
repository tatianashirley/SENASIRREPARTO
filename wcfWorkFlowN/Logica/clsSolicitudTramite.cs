using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsSolicitudTramite : clsSolicitudTramiteBE {

        clsSolicitudTramiteDA ObjSolicTrmteDA = new clsSolicitudTramiteDA();

        public Boolean Adicion() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteDA.sDescripcion = sDescripcion;
            ObjSolicTrmteDA.sComentarios = sComentarios;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;

            Boolean AnsOK = ObjSolicTrmteDA.Adicion();
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteDA.sDescripcion = sDescripcion;
            ObjSolicTrmteDA.sComentarios = sComentarios;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjSolicTrmteDA.Modificacion();
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

         public Boolean ObtieneFila() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.iIdSolicitud = iIdSolicitud;
            Boolean AnsOK = ObjSolicTrmteDA.ObtieneFila();
            DSet = ObjSolicTrmteDA.DSet;
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneDocumentosRequeridos() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjSolicTrmteDA.ObtieneDocumentosRequeridos();
            DSet = ObjSolicTrmteDA.DSet;
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean RestriccionesDocumentosOK() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjSolicTrmteDA.RestriccionesDocumentosOK();
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Busqueda() {
            ObjSolicTrmteDA.iIdConexion = iIdConexion;
            ObjSolicTrmteDA.sNombres = sNombres;
            ObjSolicTrmteDA.sApellidoPaterno = sApellidoPaterno;
            ObjSolicTrmteDA.sApellidoMaterno = sApellidoMaterno;
            ObjSolicTrmteDA.sNumeroDocumento = sNumeroDocumento;
            ObjSolicTrmteDA.iIdTramite = iIdTramite;
            Boolean AnsOK = ObjSolicTrmteDA.Busqueda();
            DSet = ObjSolicTrmteDA.DSet;
            NroFilas = ObjSolicTrmteDA.NroFilas;
            sMensajeError = ObjSolicTrmteDA.sMensajeError;
            return (AnsOK);
        }

    }
}