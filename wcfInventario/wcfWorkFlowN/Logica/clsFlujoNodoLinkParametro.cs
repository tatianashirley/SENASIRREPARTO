using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoLinkParametro : clsFlujoNodoLinkParametroBE {

        clsFlujoNodoLinkParametroDA ObjFNodoLinkDA = new clsFlujoNodoLinkParametroDA();

        public Boolean Adicion() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            ObjFNodoLinkDA.sIdConcepto = sIdConcepto;
            ObjFNodoLinkDA.bFlagSolicitud = bFlagSolicitud;
            ObjFNodoLinkDA.sComentarios = sComentarios;
            Boolean AnsOK = ObjFNodoLinkDA.Adicion();
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            ObjFNodoLinkDA.sIdConcepto = sIdConcepto;
            ObjFNodoLinkDA.bFlagSolicitud = bFlagSolicitud;
            ObjFNodoLinkDA.sComentarios = sComentarios;
            Boolean AnsOK = ObjFNodoLinkDA.Modificacion();
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            ObjFNodoLinkDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjFNodoLinkDA.Eliminacion();
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            ObjFNodoLinkDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjFNodoLinkDA.ObtieneFila();
            DSet = ObjFNodoLinkDA.DSet;
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneParametrosXLinkNodo() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjFNodoLinkDA.ObtieneParametrosXLinkNodo();
            DSet = ObjFNodoLinkDA.DSet;
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

    }

}