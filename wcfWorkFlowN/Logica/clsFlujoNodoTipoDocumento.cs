using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoTipoDocumento : clsFlujoNodoTipoDocumentoBE {

        clsFlujoNodoTipoDocumentoDA ObjFNodoCptoDA = new clsFlujoNodoTipoDocumentoDA();

        public Boolean Adicion() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjFNodoCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjFNodoCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjFNodoCptoDA.bFlagModificable = bFlagModificable;
            ObjFNodoCptoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFNodoCptoDA.Adicion();
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjFNodoCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjFNodoCptoDA.bFlagModificable = bFlagModificable;
            ObjFNodoCptoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFNodoCptoDA.Modificacion();
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjFNodoCptoDA.Eliminacion();
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjFNodoCptoDA.ObtieneFila();
            DSet = ObjFNodoCptoDA.DSet;
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneTDocsXNodo() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoCptoDA.ObtieneTDocsXNodo();
            DSet = ObjFNodoCptoDA.DSet;
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

    }

}