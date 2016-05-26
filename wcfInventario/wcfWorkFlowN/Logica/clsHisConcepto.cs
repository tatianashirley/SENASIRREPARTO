using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;
namespace wcfWorkFlowN.Logica
{
    public class clsHisConcepto : clsHisConceptoBE
    {

        clsHisConceptoDA ObjConceptoDA = new clsHisConceptoDA();

        //public Boolean Adicion()
        //{
        //    ObjConceptoDA.iIdConexion = iIdConexion;
        //    ObjConceptoDA.sIdConcepto = sIdConcepto;
        //    ObjConceptoDA.sDescripcion = sDescripcion;
        //    ObjConceptoDA.sComentarios = sComentarios;
        //    ObjConceptoDA.sTipoDato = sTipoDato;
        //    ObjConceptoDA.iLongitud = iLongitud;
        //    ObjConceptoDA.bFlagMayusculas = bFlagMayusculas;
        //    ObjConceptoDA.sMascara = sMascara;
        //    ObjConceptoDA.iIdTipoClasificador = iIdTipoClasificador;
        //    ObjConceptoDA.sAlias = sAlias;
        //    Boolean AnsOK = ObjConceptoDA.Adicion();
        //    iSesionTrabajo = ObjConceptoDA.iSesionTrabajo;
        //    sMensajeError = ObjConceptoDA.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean Modificacion()
        {
            ObjConceptoDA.iIdConexion = iIdConexion;
            ObjConceptoDA.iIdHisInstancia = iIdHisInstancia;
            ObjConceptoDA.sIdConcepto = sIdConcepto;
            ObjConceptoDA.sDescripcion = sDescripcion;
            ObjConceptoDA.sComentarios = sComentarios;
            ObjConceptoDA.sTipoDato = sTipoDato;
            ObjConceptoDA.iLongitud = iLongitud;
            ObjConceptoDA.bFlagMayusculas = bFlagMayusculas;
            ObjConceptoDA.sMascara = sMascara;
            ObjConceptoDA.iIdTipoClasificador = iIdTipoClasificador;
            ObjConceptoDA.sAlias = sAlias;
            Boolean AnsOK = ObjConceptoDA.Modificacion();
            sMensajeError = ObjConceptoDA.sMensajeError;
            return (AnsOK);
        }

        //public Boolean Eliminacion()
        //{
        //    ObjConceptoDA.iIdConexion = iIdConexion;
        //    ObjConceptoDA.sIdConcepto = sIdConcepto;
        //    Boolean AnsOK = ObjConceptoDA.Eliminacion();
        //    sMensajeError = ObjConceptoDA.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean ObtieneFila()
        {
            ObjConceptoDA.iIdConexion = iIdConexion;
            ObjConceptoDA.iIdHisInstancia = iIdHisInstancia;
            ObjConceptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjConceptoDA.ObtieneFila();
            DSet = ObjConceptoDA.DSet;
            sMensajeError = ObjConceptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneHisConceptos()
        {
            ObjConceptoDA.iIdConexion = iIdConexion;
            ObjConceptoDA.sIdConcepto = sIdConcepto;
            Boolean AnsOK = ObjConceptoDA.ObtieneHisConceptos();
            DSet = ObjConceptoDA.DSet;
            sMensajeError = ObjConceptoDA.sMensajeError;
            return (AnsOK);
        }

    }
}