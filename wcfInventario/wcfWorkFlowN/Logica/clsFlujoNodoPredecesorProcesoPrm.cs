using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoPredecesorProcesoPrm : clsFlujoNodoPredecesorProcesoPrmBE {

        clsFlujoNodoPredecesorProcesoPrmDA ObjFNodoPredProcPrmDA = new clsFlujoNodoPredecesorProcesoPrmDA();

        public Boolean Adicion() {
            ObjFNodoPredProcPrmDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcPrmDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcPrmDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcPrmDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcPrmDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcPrmDA.iIdProcedimiento = iIdProcedimiento;
            ObjFNodoPredProcPrmDA.sIdParametro = sIdParametro;
            ObjFNodoPredProcPrmDA.sIdConcepto = sIdConcepto;
            ObjFNodoPredProcPrmDA.bFlagSolicitud = bFlagSolicitud;
            Boolean AnsOK = ObjFNodoPredProcPrmDA.Adicion();
            sMensajeError = ObjFNodoPredProcPrmDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoPredProcPrmDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcPrmDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcPrmDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcPrmDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcPrmDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcPrmDA.iIdProcedimiento = iIdProcedimiento;
            ObjFNodoPredProcPrmDA.sIdParametro = sIdParametro;
            ObjFNodoPredProcPrmDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjFNodoPredProcPrmDA.Modificacion();
            sMensajeError = ObjFNodoPredProcPrmDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoPredProcPrmDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcPrmDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcPrmDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcPrmDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcPrmDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcPrmDA.iIdProcedimiento = iIdProcedimiento;
            ObjFNodoPredProcPrmDA.sIdParametro = sIdParametro;
            ObjFNodoPredProcPrmDA.bFlagSolicitud = bFlagSolicitud;
            Boolean AnsOK = ObjFNodoPredProcPrmDA.Eliminacion();
            sMensajeError = ObjFNodoPredProcPrmDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoPredProcPrmDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcPrmDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcPrmDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcPrmDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcPrmDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcPrmDA.iIdProcedimiento = iIdProcedimiento;
            ObjFNodoPredProcPrmDA.sIdParametro = sIdParametro;
            Boolean AnsOK = ObjFNodoPredProcPrmDA.ObtieneFila();
            DSet = ObjFNodoPredProcPrmDA.DSet;
            sMensajeError = ObjFNodoPredProcPrmDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneParametrosXProceso() {
            ObjFNodoPredProcPrmDA.iIdConexion = iIdConexion;
            ObjFNodoPredProcPrmDA.iIdFlujo = iIdFlujo;
            ObjFNodoPredProcPrmDA.iIdNodoPred = iIdNodoPred;
            ObjFNodoPredProcPrmDA.iIdNodo = iIdNodo;
            ObjFNodoPredProcPrmDA.iSecuencia = iSecuencia;
            ObjFNodoPredProcPrmDA.iIdProcedimiento = iIdProcedimiento;
            Boolean AnsOK = ObjFNodoPredProcPrmDA.ObtieneParametrosXProceso();
            DSet = ObjFNodoPredProcPrmDA.DSet;
            sMensajeError = ObjFNodoPredProcPrmDA.sMensajeError;
            return (AnsOK);
        }


    }

}