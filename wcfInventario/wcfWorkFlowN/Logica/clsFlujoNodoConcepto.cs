using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoConcepto :  clsFlujoNodoConceptoBE {

        clsFlujoNodoConceptoDA ObjFNodoCptoDA = new clsFlujoNodoConceptoDA();

        public Boolean Adicion() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.sIdTipoTramite = sIdTipoTramite;
            ObjFNodoCptoDA.sIdConcepto = sIdConcepto;
            ObjFNodoCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjFNodoCptoDA.bFlagModificable = bFlagModificable;
            ObjFNodoCptoDA.sEstado = sEstado;
            ObjFNodoCptoDA.iValorInt = iValorInt;
            ObjFNodoCptoDA.mValorMoney = mValorMoney;
            ObjFNodoCptoDA.dValorFloat = dValorFloat;
            ObjFNodoCptoDA.sValorChar = sValorChar;
            ObjFNodoCptoDA.fValorDate = fValorDate;
            ObjFNodoCptoDA.iValorCatalog = iValorCatalog;
            ObjFNodoCptoDA.bValorBoolean = bValorBoolean;
            Boolean AnsOK = ObjFNodoCptoDA.Adicion();
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.sIdConcepto = sIdConcepto;
            ObjFNodoCptoDA.bFlagObligatorio = bFlagObligatorio;
            ObjFNodoCptoDA.bFlagModificable = bFlagModificable;
            ObjFNodoCptoDA.sEstado = sEstado;
            ObjFNodoCptoDA.iValorInt = iValorInt;
            ObjFNodoCptoDA.mValorMoney = mValorMoney;
            ObjFNodoCptoDA.dValorFloat = dValorFloat;
            ObjFNodoCptoDA.sValorChar = sValorChar;
            ObjFNodoCptoDA.fValorDate = fValorDate;
            ObjFNodoCptoDA.iValorCatalog = iValorCatalog;
            ObjFNodoCptoDA.bValorBoolean = bValorBoolean;
            Boolean AnsOK = ObjFNodoCptoDA.Modificacion();
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjFNodoCptoDA.Eliminacion();
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            ObjFNodoCptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjFNodoCptoDA.ObtieneFila();
            DSet = ObjFNodoCptoDA.DSet;
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneConceptosXNodo() {
            ObjFNodoCptoDA.iIdConexion = iIdConexion;
            ObjFNodoCptoDA.iIdFlujo = iIdFlujo;
            ObjFNodoCptoDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoCptoDA.ObtieneConceptosXNodo();
            DSet = ObjFNodoCptoDA.DSet;
            sMensajeError = ObjFNodoCptoDA.sMensajeError;
            return (AnsOK);
        }

    }

}