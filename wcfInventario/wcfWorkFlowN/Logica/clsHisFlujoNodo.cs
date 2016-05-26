using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsHisFlujoNodo : clsHisFlujoNodoBE {

        clsHisFlujoNodoDA ObjFNodoDA = new clsHisFlujoNodoDA();

        /// <summary>
        /// Recupera una fila a partir de la llave primaria 
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneFila() {
            ObjFNodoDA.iIdConexion = iIdConexion;
            ObjFNodoDA.iIdFlujo = iIdFlujo;
            ObjFNodoDA.iIdNodo = iIdNodo;
            ObjFNodoDA.sNemonico = sNemonico;
            Boolean AnsOK = ObjFNodoDA.ObtieneFila();
            DSet = ObjFNodoDA.DSet;
            sMensajeError = ObjFNodoDA.sMensajeError;
            return (AnsOK);
        }

    }

}