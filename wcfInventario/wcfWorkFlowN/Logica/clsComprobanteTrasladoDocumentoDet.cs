using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsComprobanteTrasladoDocumentoDet : clsComprobanteTrasladoDocumentoDetBE {

        clsComprobanteTrasladoDocumentoDetDA ObjCbteTrsldoDocDetDA = new clsComprobanteTrasladoDocumentoDetDA();

        public Boolean Modificacion() {
            ObjCbteTrsldoDocDetDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDetDA.iIdComprobante = iIdComprobante;
            ObjCbteTrsldoDocDetDA.iIdInstancia = iIdInstancia;
            ObjCbteTrsldoDocDetDA.iSecuencia = iSecuencia;
            ObjCbteTrsldoDocDetDA.bFlagAceptacion = bFlagAceptacion;
            Boolean AnsOK = ObjCbteTrsldoDocDetDA.Modificacion();
            sMensajeError = ObjCbteTrsldoDocDetDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneDetalleComprobante() {
            ObjCbteTrsldoDocDetDA.iIdConexion = iIdConexion;
            ObjCbteTrsldoDocDetDA.iIdComprobante = iIdComprobante;
            Boolean AnsOK = ObjCbteTrsldoDocDetDA.ObtieneDetalleComprobante();
            DSet = ObjCbteTrsldoDocDetDA.DSet;
            sMensajeError = ObjCbteTrsldoDocDetDA.sMensajeError;
            return (AnsOK);
        }


    }

}