using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsInstancia : clsInstanciaBE {

        clsInstanciaDA ObjInstanciaDA = new clsInstanciaDA();

         public Boolean ObtieneFila() {
            ObjInstanciaDA.iIdConexion = iIdConexion;
            ObjInstanciaDA.iIdInstancia = iIdInstancia;
            ObjInstanciaDA.iIdTramite = iIdTramite; 
            ObjInstanciaDA.iIdGrupoBeneficio = iIdGrupoBeneficio;
            Boolean AnsOK = ObjInstanciaDA.ObtieneFila();
            DSet = ObjInstanciaDA.DSet;
            sMensajeError = ObjInstanciaDA.sMensajeError;
            return (AnsOK);
        }


    }

}