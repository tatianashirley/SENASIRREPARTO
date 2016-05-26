using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsHisFlujoNodoLink : clsHisFlujoNodoLinkBE {

        clsHisFlujoNodoLinkDA ObjFNodoLnkDA = new clsHisFlujoNodoLinkDA();

        public Boolean ObtieneDefinicionLinksXActividad() {
            ObjFNodoLnkDA.iIdConexion = iIdConexion;
            ObjFNodoLnkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLnkDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoLnkDA.ObtieneDefinicionLinksXActividad();
            DSet = ObjFNodoLnkDA.DSet;
            sMensajeError = ObjFNodoLnkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoLnkDA.iIdConexion = iIdConexion;
            ObjFNodoLnkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLnkDA.iIdNodo = iIdNodo;
            ObjFNodoLnkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjFNodoLnkDA.ObtieneFila();
            DSet = ObjFNodoLnkDA.DSet;
            sMensajeError = ObjFNodoLnkDA.sMensajeError;
            return (AnsOK);
        }

    }

}