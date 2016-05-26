using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {
    public class clsInstanciaNodoDocumento : clsInstanciaNodoDocumentoBE {

        clsInstanciaNodoDocumentoDA ObjINodoDoc = new clsInstanciaNodoDocumentoDA();

        public Boolean Adicion() {
            ObjINodoDoc.iIdConexion = iIdConexion;
            ObjINodoDoc.iIdInstancia = iIdInstancia;
            ObjINodoDoc.iSecuencia = iSecuencia;
            ObjINodoDoc.iIdHisInstancia = iIdHisInstancia;
            ObjINodoDoc.iIdFlujo = iIdFlujo;
            ObjINodoDoc.iIdNodo = iIdNodo;
            ObjINodoDoc.iIdTipoDocumento = iIdTipoDocumento;
            ObjINodoDoc.iIdDocumento = iIdDocumento;

            Boolean AnsOK = ObjINodoDoc.Adicion();
            sMensajeError = ObjINodoDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjINodoDoc.iIdConexion = iIdConexion;
            ObjINodoDoc.iIdInstancia = iIdInstancia;
            ObjINodoDoc.iSecuencia = iSecuencia;
            ObjINodoDoc.iIdHisInstancia = iIdHisInstancia;
            ObjINodoDoc.iIdDocumento = iIdDocumento;

            Boolean AnsOK = ObjINodoDoc.Eliminacion();
            sMensajeError = ObjINodoDoc.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneDocumentosXActividad() {
            ObjINodoDoc.iIdConexion = iIdConexion;
            ObjINodoDoc.iIdInstancia = iIdInstancia;
            ObjINodoDoc.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjINodoDoc.ObtieneDocumentosXActividad();
            DSet = ObjINodoDoc.DSet;
            sMensajeError = ObjINodoDoc.sMensajeError;
            return (AnsOK);
        }

    }
}