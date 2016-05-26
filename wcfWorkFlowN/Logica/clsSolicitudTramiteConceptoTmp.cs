using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsSolicitudTramiteConceptoTmp : clsSolicitudTramiteConceptoTmpBE {

        clsSolicitudTramiteConceptoTmpDA ObjSolicTrmteCptoDA = new clsSolicitudTramiteConceptoTmpDA();

        public Boolean Adicion() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjSolicTrmteCptoDA.sIdConcepto = sIdConcepto;
            ObjSolicTrmteCptoDA.iValorInt = iValorInt;
            ObjSolicTrmteCptoDA.mValorMoney = mValorMoney;
            ObjSolicTrmteCptoDA.dValorFloat = dValorFloat;
            ObjSolicTrmteCptoDA.sValorChar = sValorChar;
            ObjSolicTrmteCptoDA.fValorDate = fValorDate;
            ObjSolicTrmteCptoDA.iValorCatalog = iValorCatalog;
            ObjSolicTrmteCptoDA.bValorBoolean = bValorBoolean;
            Boolean AnsOK = ObjSolicTrmteCptoDA.Adicion();
            iSesionTrabajo = ObjSolicTrmteCptoDA.iSesionTrabajo;
            iSecuencia = ObjSolicTrmteCptoDA.iSecuencia; 
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdConcepto = sIdConcepto;
            ObjSolicTrmteCptoDA.iValorInt = iValorInt;
            ObjSolicTrmteCptoDA.mValorMoney = mValorMoney;
            ObjSolicTrmteCptoDA.dValorFloat = dValorFloat;
            ObjSolicTrmteCptoDA.sValorChar = sValorChar;
            ObjSolicTrmteCptoDA.fValorDate = fValorDate;
            ObjSolicTrmteCptoDA.iValorCatalog = iValorCatalog;
            ObjSolicTrmteCptoDA.bValorBoolean = bValorBoolean;
            Boolean AnsOK = ObjSolicTrmteCptoDA.Modificacion();
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjSolicTrmteCptoDA.Modificacion();
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

         public Boolean ObtieneFila() {
            ObjSolicTrmteCptoDA.iIdConexion = iIdConexion;
            ObjSolicTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjSolicTrmteCptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjSolicTrmteCptoDA.ObtieneFila();
            DSet = ObjSolicTrmteCptoDA.DSet;
            sMensajeError = ObjSolicTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

    }
}