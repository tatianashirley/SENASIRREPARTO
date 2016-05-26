using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsTipoTramiteConcepto : clsTipoTramiteConceptoBE {

        clsTipoTramiteConceptoDA ObjTTrmteCptoDA = new clsTipoTramiteConceptoDA();

        public Boolean Adicion() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.sIdConcepto = sIdConcepto;
            ObjTTrmteCptoDA.iOrden = iOrden;
            ObjTTrmteCptoDA.bFlagSolicitud = bFlagSolicitud;
            ObjTTrmteCptoDA.bFlagModificable = bFlagModificable;
            ObjTTrmteCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjTTrmteCptoDA.bFlagDeterminaFlujo = bFlagDeterminaFlujo;
            ObjTTrmteCptoDA.iValorInt = iValorInt;
            ObjTTrmteCptoDA.mValorMoney = mValorMoney;
            ObjTTrmteCptoDA.dValorFloat = dValorFloat;
            ObjTTrmteCptoDA.sValorChar = sValorChar;
            ObjTTrmteCptoDA.fValorDate = fValorDate;
            ObjTTrmteCptoDA.iValorCatalog = iValorCatalog;
            ObjTTrmteCptoDA.bValorBoolean = bValorBoolean;
            Boolean AnsOK = ObjTTrmteCptoDA.Adicion();
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.sIdConcepto = sIdConcepto;
            ObjTTrmteCptoDA.iOrden = iOrden;
            ObjTTrmteCptoDA.bFlagSolicitud = bFlagSolicitud;
            ObjTTrmteCptoDA.bFlagModificable = bFlagModificable;
            ObjTTrmteCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjTTrmteCptoDA.bFlagDeterminaFlujo = bFlagDeterminaFlujo;
            ObjTTrmteCptoDA.iValorInt = iValorInt;
            ObjTTrmteCptoDA.mValorMoney = mValorMoney;
            ObjTTrmteCptoDA.dValorFloat = dValorFloat;
            ObjTTrmteCptoDA.sValorChar = sValorChar;
            ObjTTrmteCptoDA.fValorDate = fValorDate;
            ObjTTrmteCptoDA.iValorCatalog = iValorCatalog;
            ObjTTrmteCptoDA.bValorBoolean = bValorBoolean;
            Boolean AnsOK = ObjTTrmteCptoDA.Modificacion();
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjTTrmteCptoDA.Eliminacion();
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjTTrmteCptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjTTrmteCptoDA.ObtieneFila();
            DSet = ObjTTrmteCptoDA.DSet;
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneConceptosXTipoTramite() {
            ObjTTrmteCptoDA.iIdConexion = iIdConexion;
            ObjTTrmteCptoDA.iSesionTrabajo = iSesionTrabajo;
            ObjTTrmteCptoDA.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjTTrmteCptoDA.ObtieneConceptosXTipoTramite();
            DSet = ObjTTrmteCptoDA.DSet;
            sMensajeError = ObjTTrmteCptoDA.sMensajeError;
            return (AnsOK);
        }

    }

}