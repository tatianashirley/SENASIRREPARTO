using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoPredecesorTDocCond : clsFlujoNodoPredecesorTDocCondBE {

        clsFlujoNodoPredecesorTDocCondDA ObjFlujoDA = new clsFlujoNodoPredecesorTDocCondDA();

        public Boolean Adicion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            ObjFlujoDA.iIdNodoPred = iIdNodoPred;
            ObjFlujoDA.iIdNodo = iIdNodo;
            ObjFlujoDA.sIdTipoTramite = sIdTipoTramite;
            ObjFlujoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjFlujoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFlujoDA.Adicion();
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            ObjFlujoDA.iIdNodoPred = iIdNodoPred;
            ObjFlujoDA.iIdNodo = iIdNodo;
            ObjFlujoDA.iIdTipoDocumento = iIdTipoDocumento;
            ObjFlujoDA.sEstado = sEstado;
            Boolean AnsOK = ObjFlujoDA.Modificacion();
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            ObjFlujoDA.iIdNodoPred = iIdNodoPred;
            ObjFlujoDA.iIdNodo = iIdNodo;
            ObjFlujoDA.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjFlujoDA.Eliminacion();
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            ObjFlujoDA.iIdNodoPred = iIdNodoPred;
            ObjFlujoDA.iIdNodo = iIdNodo;
            ObjFlujoDA.iIdTipoDocumento = iIdTipoDocumento;
            Boolean AnsOK = ObjFlujoDA.ObtieneFila();
            DSet = ObjFlujoDA.DSet;
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneTDocsXTransicion() {
            ObjFlujoDA.iIdConexion = iIdConexion;
            ObjFlujoDA.iIdFlujo = iIdFlujo;
            ObjFlujoDA.iIdNodoPred = iIdNodoPred;
            ObjFlujoDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFlujoDA.ObtieneTDocsXTransicion();
            DSet = ObjFlujoDA.DSet;
            sMensajeError = ObjFlujoDA.sMensajeError;
            return (AnsOK);
        }

    }

}