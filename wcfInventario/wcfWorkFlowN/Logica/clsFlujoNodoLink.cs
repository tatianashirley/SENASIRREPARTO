using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsFlujoNodoLink : clsFlujoNodoLinkBE {

        clsFlujoNodoLinkDA ObjFNodoLinkDA = new clsFlujoNodoLinkDA();

        public Boolean Adicion() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            ObjFNodoLinkDA.sDescripcion = sDescripcion;
            ObjFNodoLinkDA.sLink = sLink;
            ObjFNodoLinkDA.bFlagObligatorio = bFlagObligatorio;
            ObjFNodoLinkDA.sEstado = sEstado;
            ObjFNodoLinkDA.iIdGrupoRestriccion = iIdGrupoRestriccion;
            Boolean AnsOK = ObjFNodoLinkDA.Adicion();
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            ObjFNodoLinkDA.sDescripcion = sDescripcion;
            ObjFNodoLinkDA.sLink = sLink;
            ObjFNodoLinkDA.bFlagObligatorio = bFlagObligatorio;
            ObjFNodoLinkDA.sEstado = sEstado;
            ObjFNodoLinkDA.iIdGrupoRestriccion = iIdGrupoRestriccion;
            Boolean AnsOK = ObjFNodoLinkDA.Modificacion();
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjFNodoLinkDA.Eliminacion();
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            ObjFNodoLinkDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjFNodoLinkDA.ObtieneFila();
            DSet = ObjFNodoLinkDA.DSet;
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneLinksXNodo() {
            ObjFNodoLinkDA.iIdConexion = iIdConexion;
            ObjFNodoLinkDA.iIdFlujo = iIdFlujo;
            ObjFNodoLinkDA.iIdNodo = iIdNodo;
            Boolean AnsOK = ObjFNodoLinkDA.ObtieneLinksXNodo();
            DSet = ObjFNodoLinkDA.DSet;
            sMensajeError = ObjFNodoLinkDA.sMensajeError;
            return (AnsOK);
        }


    }

}