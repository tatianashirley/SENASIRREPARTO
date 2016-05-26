using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsComprobanteTrasladoDocumentoDetTmp : clsComprobanteTrasladoDocumentoDetTmpBE {

        clsComprobanteTrasladoDocumentoDetTmpDA ObjCbteTrsldoDocDetTmpDA = new clsComprobanteTrasladoDocumentoDetTmpDA();

        public Boolean Adicion() {
            ObjCbteTrsldoDocDetTmpDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDetTmpDA.iSesionTrabajo = iSesionTrabajo;
            ObjCbteTrsldoDocDetTmpDA.iIdInstancia= iIdInstancia;
            ObjCbteTrsldoDocDetTmpDA.iSecuencia = iSecuencia;
            ObjCbteTrsldoDocDetTmpDA.sComentario = sComentario;
            Boolean AnsOK = ObjCbteTrsldoDocDetTmpDA.Adicion();
            iSesionTrabajo = ObjCbteTrsldoDocDetTmpDA.iSesionTrabajo;
            sMensajeError = ObjCbteTrsldoDocDetTmpDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjCbteTrsldoDocDetTmpDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDetTmpDA.iSesionTrabajo = iSesionTrabajo;
            ObjCbteTrsldoDocDetTmpDA.iIdInstancia= iIdInstancia;
            ObjCbteTrsldoDocDetTmpDA.iSecuencia = iSecuencia;
            ObjCbteTrsldoDocDetTmpDA.sComentario = sComentario;
            Boolean AnsOK = ObjCbteTrsldoDocDetTmpDA.Modificacion();
            sMensajeError = ObjCbteTrsldoDocDetTmpDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjCbteTrsldoDocDetTmpDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDetTmpDA.iSesionTrabajo = iSesionTrabajo;
            ObjCbteTrsldoDocDetTmpDA.iIdInstancia= iIdInstancia;
            ObjCbteTrsldoDocDetTmpDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjCbteTrsldoDocDetTmpDA.Eliminacion();
            sMensajeError = ObjCbteTrsldoDocDetTmpDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjCbteTrsldoDocDetTmpDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDetTmpDA.iSesionTrabajo = iSesionTrabajo;
            ObjCbteTrsldoDocDetTmpDA.iIdInstancia = iIdInstancia;
            ObjCbteTrsldoDocDetTmpDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjCbteTrsldoDocDetTmpDA.ObtieneFila();
            DSet = ObjCbteTrsldoDocDetTmpDA.DSet;
            sMensajeError = ObjCbteTrsldoDocDetTmpDA.sMensajeError;
            return (AnsOK);
        }

    }

}