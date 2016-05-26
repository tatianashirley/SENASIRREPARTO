using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfDocumento.Entidades;
using wcfDocumento.Datos;

namespace wcfDocumento.Logica {

    public class clsTipoDocumento : clsTipoDocumentoBE {

        clsTipoDocumentoDA ObjTDoc = new clsTipoDocumentoDA();

        public Boolean Adicion() {
            ObjTDoc.iIdConexion = iIdConexion;
            ObjTDoc.iIdTipoDocumento = iIdTipoDocumento;
            ObjTDoc.sDescripcion = sDescripcion;
            ObjTDoc.iIdTipoArchivo = iIdTipoArchivo;
            ObjTDoc.iIdEstado = iIdEstado;
            Boolean AnsOK = ObjTDoc.Adicion();
            iSesionTrabajo = ObjTDoc.iSesionTrabajo;
            sMensajeError = ObjTDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjTDoc.iIdConexion = iIdConexion;
            ObjTDoc.iIdTipoDocumento = iIdTipoDocumento;
            ObjTDoc.sDescripcion = sDescripcion;
            ObjTDoc.iIdTipoArchivo = iIdTipoArchivo;
            ObjTDoc.iIdEstado = iIdEstado;
            Boolean AnsOK = ObjTDoc.Modificacion();
            sMensajeError = ObjTDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjTDoc.iIdConexion = iIdConexion;
            ObjTDoc.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjTDoc.Eliminacion();
            sMensajeError = ObjTDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjTDoc.iIdConexion = iIdConexion;
            ObjTDoc.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjTDoc.ObtieneFila();
            DSet = ObjTDoc.DSet;
            sMensajeError = ObjTDoc.sMensajeError;
            return (AnsOK);
        }

         public Boolean ObtieneTiposDeDocumento() {
            ObjTDoc.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjTDoc.ObtieneTiposDeDocumento();
            DSet = ObjTDoc.DSet;
            sMensajeError = ObjTDoc.sMensajeError;
            return (AnsOK);
        }

    }
}