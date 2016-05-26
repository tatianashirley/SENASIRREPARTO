using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsInstanciaNodoLink : clsInstanciaNodoLinkBE {

        clsInstanciaNodoLinkDA ObjINodoLnkDA = new clsInstanciaNodoLinkDA();

        public Boolean ObtieneLinksDisponibles() {
            ObjINodoLnkDA.iIdConexion = iIdConexion;
            ObjINodoLnkDA.iIdInstancia = iIdInstancia;
            ObjINodoLnkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjINodoLnkDA.ObtieneLinksDisponibles();
            DSet = ObjINodoLnkDA.DSet;
            sMensajeError = ObjINodoLnkDA.sMensajeError;
            return (AnsOK);
        }

    }

}