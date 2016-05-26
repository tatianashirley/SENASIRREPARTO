using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoPredecesorLink : clsFlujoNodoPredecesorLinkBE {

        clsFlujoNodoPredecesorLinkDA ObjFNodoPredLnkDA = new clsFlujoNodoPredecesorLinkDA();

        public Boolean Adicion() {
            ObjFNodoPredLnkDA.iIdConexion = iIdConexion;
            ObjFNodoPredLnkDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredLnkDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredLnkDA.iIdNodo = iIdNodo;
            ObjFNodoPredLnkDA.iSecuencia = iSecuencia; 
            Boolean AnsOK = ObjFNodoPredLnkDA.Adicion();
            sMensajeError = ObjFNodoPredLnkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoPredLnkDA.iIdConexion = iIdConexion;
            ObjFNodoPredLnkDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredLnkDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredLnkDA.iIdNodo = iIdNodo;
            ObjFNodoPredLnkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjFNodoPredLnkDA.Eliminacion();
            sMensajeError = ObjFNodoPredLnkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoPredLnkDA.iIdConexion = iIdConexion;
            ObjFNodoPredLnkDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredLnkDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredLnkDA.iIdNodo = iIdNodo;
            ObjFNodoPredLnkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjFNodoPredLnkDA.ObtieneFila();
            DSet = ObjFNodoPredLnkDA.DSet;
            sMensajeError = ObjFNodoPredLnkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneEnlacesXTransicion() {
            ObjFNodoPredLnkDA.iIdConexion = iIdConexion;
            ObjFNodoPredLnkDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredLnkDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredLnkDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoPredLnkDA.ObtieneEnlacesXTransicion();
            DSet = ObjFNodoPredLnkDA.DSet;
            sMensajeError = ObjFNodoPredLnkDA.sMensajeError;
            return (AnsOK);
        }

    }

}