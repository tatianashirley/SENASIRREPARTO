using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica
{

    public class clsHisGrupoRestriccion : clsHisGrupoRestriccionBE
    {

        clsHisGrupoRestriccionDA ObjGrpRestricc = new clsHisGrupoRestriccionDA();

        //public Boolean Adicion()
        //{
        //    ObjGrpRestricc.iIdConexion = iIdConexion;
        //    ObjGrpRestricc.iIdGrupoRestriccion = iIdGrupoRestriccion;
        //    ObjGrpRestricc.sDescripcion = sDescripcion;
        //    ObjGrpRestricc.sComentarios = sComentarios;
        //    ObjGrpRestricc.sReglaEvaluacion = sReglaEvaluacion;
        //    Boolean AnsOK = ObjGrpRestricc.Adicion();
        //    iSesionTrabajo = ObjGrpRestricc.iSesionTrabajo;
        //    sMensajeError = ObjGrpRestricc.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean Modificacion()
        {
            ObjGrpRestricc.iIdConexion = iIdConexion;
            ObjGrpRestricc.iIdHisInstancia = iIdHisInstancia;
            ObjGrpRestricc.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjGrpRestricc.sDescripcion = sDescripcion;
            ObjGrpRestricc.sComentarios = sComentarios;
            ObjGrpRestricc.sReglaEvaluacion = sReglaEvaluacion;
            Boolean AnsOK = ObjGrpRestricc.Modificacion();
            sMensajeError = ObjGrpRestricc.sMensajeError;
            return (AnsOK);
        }

        //public Boolean Eliminacion()
        //{
        //    ObjGrpRestricc.iIdConexion = iIdConexion;
        //    ObjGrpRestricc.iIdGrupoRestriccion = iIdGrupoRestriccion;
        //    Boolean AnsOK = ObjGrpRestricc.Eliminacion();
        //    sMensajeError = ObjGrpRestricc.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean ObtieneFila()
        {
            ObjGrpRestricc.iIdConexion = iIdConexion;
            ObjGrpRestricc.iIdHisInstancia = iIdHisInstancia;
            ObjGrpRestricc.iIdGrupoRestriccion = iIdGrupoRestriccion;
            Boolean AnsOK = ObjGrpRestricc.ObtieneFila();
            DSet = ObjGrpRestricc.DSet;
            sMensajeError = ObjGrpRestricc.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneGruposDeRestricciones()
        {
            ObjGrpRestricc.iIdConexion = iIdConexion;
            //ObjGrpRestricc.iIdHisInstancia = iIdHisInstancia;
            //ObjGrpRestricc.iIdGrupoRestriccion = iIdGrupoRestriccion;
            Boolean AnsOK = ObjGrpRestricc.ObtieneGruposDeRestricciones();
            DSet = ObjGrpRestricc.DSet;
            sMensajeError = ObjGrpRestricc.sMensajeError;
            return (AnsOK);
        }

    }

}