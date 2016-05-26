using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsRestriccion : clsRestriccionBE {

        clsRestriccionDA ObjRestriccion = new clsRestriccionDA();

        public Boolean Adicion() {
            ObjRestriccion.iIdConexion = iIdConexion;
            ObjRestriccion.iSesionTrabajo = iSesionTrabajo;
            ObjRestriccion.iIdRestriccion = iIdRestriccion;
            ObjRestriccion.sDescripcion = sDescripcion;
            ObjRestriccion.sIdConcepto = sIdConcepto;
            ObjRestriccion.iIdTipoDocumento = iIdTipoDocumento;
            ObjRestriccion.sTipoDato = sTipoDato;
            ObjRestriccion.sComentarios = sComentarios;
            ObjRestriccion.sTipoRestriccion = sTipoRestriccion;
            ObjRestriccion.iValor1Int = iValor1Int;
            ObjRestriccion.mValor1Money = mValor1Money;
            ObjRestriccion.dValor1Float = dValor1Float;
            ObjRestriccion.sValor1Char = sValor1Char;
            ObjRestriccion.fValor1Date = fValor1Date;
            ObjRestriccion.iValor1Catalog = iValor1Catalog;
            ObjRestriccion.bValor1Bit = bValor1Bit;
            ObjRestriccion.iValor2Int = iValor2Int;
            ObjRestriccion.mValor2Money = mValor2Money;
            ObjRestriccion.dValor2Float = dValor2Float;
            ObjRestriccion.fValor2Date = fValor2Date;
            ObjRestriccion.bFlagNegacion = bFlagNegacion;
            ObjRestriccion.iIdRestriccionDesde = iIdRestriccionDesde;
            ObjRestriccion.iIdRestriccionHasta = iIdRestriccionHasta;
            Boolean AnsOK = ObjRestriccion.Adicion();
            iSesionTrabajo = ObjRestriccion.iSesionTrabajo;
            sMensajeError = ObjRestriccion.sMensajeError;
            return (AnsOK);
        }

        public Boolean Modificacion() {
            ObjRestriccion.iIdConexion = iIdConexion;
            ObjRestriccion.iSesionTrabajo = iSesionTrabajo;
            ObjRestriccion.iIdRestriccion = iIdRestriccion;
            ObjRestriccion.sDescripcion = sDescripcion;
            ObjRestriccion.sIdConcepto = sIdConcepto;
            ObjRestriccion.iIdTipoDocumento = iIdTipoDocumento;
            ObjRestriccion.sTipoDato = sTipoDato;
            ObjRestriccion.sComentarios = sComentarios;
            ObjRestriccion.sTipoRestriccion = sTipoRestriccion;
            ObjRestriccion.iValor1Int = iValor1Int;
            ObjRestriccion.mValor1Money = mValor1Money;
            ObjRestriccion.dValor1Float = dValor1Float;
            ObjRestriccion.sValor1Char = sValor1Char;
            ObjRestriccion.fValor1Date = fValor1Date;
            ObjRestriccion.iValor1Catalog = iValor1Catalog;
            ObjRestriccion.bValor1Bit = bValor1Bit;
            ObjRestriccion.iValor2Int = iValor2Int;
            ObjRestriccion.mValor2Money = mValor2Money;
            ObjRestriccion.dValor2Float = dValor2Float;
            ObjRestriccion.fValor2Date = fValor2Date;
            ObjRestriccion.bFlagNegacion = bFlagNegacion;
            ObjRestriccion.iIdRestriccionDesde = iIdRestriccionDesde;
            ObjRestriccion.iIdRestriccionHasta = iIdRestriccionHasta;
            Boolean AnsOK = ObjRestriccion.Modificacion();
            sMensajeError = ObjRestriccion.sMensajeError;
            return (AnsOK);
        }

        public Boolean Eliminacion() {
            ObjRestriccion.iIdConexion = iIdConexion;
            ObjRestriccion.iSesionTrabajo = iSesionTrabajo;
            ObjRestriccion.iIdRestriccion = iIdRestriccion;
            Boolean AnsOK = ObjRestriccion.Eliminacion();
            sMensajeError = ObjRestriccion.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneFila() {
            ObjRestriccion.iIdConexion = iIdConexion;
            ObjRestriccion.iSesionTrabajo = iSesionTrabajo;
            ObjRestriccion.iIdRestriccion = iIdRestriccion;
            Boolean AnsOK = ObjRestriccion.ObtieneFila();
            DSet = ObjRestriccion.DSet;
            sMensajeError = ObjRestriccion.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneRestricciones() {
            ObjRestriccion.iIdConexion = iIdConexion;
            ObjRestriccion.iSesionTrabajo = iSesionTrabajo;
            Boolean AnsOK = ObjRestriccion.ObtieneRestricciones();
            DSet = ObjRestriccion.DSet;
            sMensajeError = ObjRestriccion.sMensajeError;
            return (AnsOK);
        }

    }

}