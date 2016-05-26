using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfDocumento.Entidades;
using wcfDocumento.Datos;

namespace wcfDocumento.Logica {

    public class clsDocumento : clsDocumentoBE {

    clsDocumentoDA ObjDoc = new clsDocumentoDA();

        public Boolean Adicion() {
            ObjDoc.iIdConexion = iIdConexion;
            ObjDoc.iIdDocumento = iIdDocumento;
            ObjDoc.sCodigo = ObjDoc.sCodigo;
            ObjDoc.sDescripcion = sDescripcion;
            ObjDoc.sResumen = sResumen;
            ObjDoc.iIdTipoDocumento = iIdTipoDocumento;
            ObjDoc.fFechaRegistro = fFechaRegistro;
            ObjDoc.bFlagDigital = ObjDoc.bFlagDigital;
            ObjDoc.iIdEstado = iIdEstado;
            Boolean AnsOK = ObjDoc.Adicion();
            iSesionTrabajo = ObjDoc.iSesionTrabajo;
            sMensajeError = ObjDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjDoc.iIdConexion = iIdConexion;
            ObjDoc.iIdDocumento = iIdDocumento;
            ObjDoc.sCodigo = ObjDoc.sCodigo;
            ObjDoc.sDescripcion = sDescripcion;
            ObjDoc.sResumen = sResumen;
            ObjDoc.iIdTipoDocumento = iIdTipoDocumento;
            ObjDoc.fFechaRegistro = fFechaRegistro;
            ObjDoc.bFlagDigital = ObjDoc.bFlagDigital;
            ObjDoc.iIdEstado = iIdEstado;
            Boolean AnsOK = ObjDoc.Modificacion();
            sMensajeError = ObjDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjDoc.iIdConexion = iIdConexion;
            ObjDoc.iIdDocumento = iIdDocumento;
            Boolean AnsOK = ObjDoc.Eliminacion();
            sMensajeError = ObjDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjDoc.iIdConexion = iIdConexion;
            ObjDoc.iIdDocumento = iIdDocumento;
            Boolean AnsOK = ObjDoc.ObtieneFila();
            DSet = ObjDoc.DSet;
            sMensajeError = ObjDoc.sMensajeError;
            return (AnsOK);
        }

         public Boolean ObtieneTiposDeDocumento() {
            ObjDoc.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjDoc.ObtieneDocumentos();
            DSet = ObjDoc.DSet;
            sMensajeError = ObjDoc.sMensajeError;
            return (AnsOK);
        }

    }
}