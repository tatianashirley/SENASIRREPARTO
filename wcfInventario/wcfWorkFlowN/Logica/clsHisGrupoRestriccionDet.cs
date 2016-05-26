using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica
{

    public class clsHisGrupoRestriccionDet : clsHisGrupoRestriccionDetBE
    {

        clsHisGrupoRestriccionDetDA ObjGrpRestriccDet = new clsHisGrupoRestriccionDetDA();

        //public Boolean Adicion()
        //{
        //    ObjGrpRestriccDet.iIdConexion = iIdConexion;
        //    ObjGrpRestriccDet.iIdGrupoRestriccion = iIdGrupoRestriccion;
        //    ObjGrpRestriccDet.iIdRestriccion = iIdRestriccion;
        //    ObjGrpRestriccDet.iOrden = iOrden;
        //    ObjGrpRestriccDet.iSubGrupo = iSubGrupo;
        //    ObjGrpRestriccDet.bFlagInclusivo = bFlagInclusivo;
        //    ObjGrpRestriccDet.sReglaEvaluacion = sReglaEvaluacion;
        //    ObjGrpRestriccDet.iIdProcedimiento = iIdProcedimiento;
        //    ObjGrpRestriccDet.sIdParametro = sIdParametro;
        //    Boolean AnsOK = ObjGrpRestriccDet.Adicion();
        //    iSesionTrabajo = ObjGrpRestriccDet.iSesionTrabajo;
        //    sMensajeError = ObjGrpRestriccDet.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean Modificacion()
        {
            ObjGrpRestriccDet.iIdConexion = iIdConexion;
            ObjGrpRestriccDet.iIdHisInstancia = iIdHisInstancia;
            ObjGrpRestriccDet.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjGrpRestriccDet.iIdRestriccion = iIdRestriccion;
            ObjGrpRestriccDet.iOrden = iOrden;
            ObjGrpRestriccDet.iSubGrupo = iSubGrupo;
            ObjGrpRestriccDet.bFlagInclusivo = bFlagInclusivo;
            ObjGrpRestriccDet.sReglaEvaluacion = sReglaEvaluacion;
            ObjGrpRestriccDet.iIdProcedimiento = iIdProcedimiento;
            ObjGrpRestriccDet.sIdParametro = sIdParametro;
            Boolean AnsOK = ObjGrpRestriccDet.Modificacion();
            sMensajeError = ObjGrpRestriccDet.sMensajeError;
            return (AnsOK);
        }

        //public Boolean Eliminacion()
        //{
        //    ObjGrpRestriccDet.iIdConexion = iIdConexion;
        //    ObjGrpRestriccDet.iIdGrupoRestriccion = iIdGrupoRestriccion;
        //    ObjGrpRestriccDet.iIdRestriccion = iIdRestriccion;
        //    Boolean AnsOK = ObjGrpRestriccDet.Eliminacion();
        //    sMensajeError = ObjGrpRestriccDet.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean ObtieneFila()
        {
            ObjGrpRestriccDet.iIdConexion = iIdConexion;
            ObjGrpRestriccDet.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjGrpRestriccDet.iIdRestriccion = iIdRestriccion;
            ObjGrpRestriccDet.iIdHisInstancia = iIdHisInstancia;
            Boolean AnsOK = ObjGrpRestriccDet.ObtieneFila();
            DSet = ObjGrpRestriccDet.DSet;
            sMensajeError = ObjGrpRestriccDet.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneDetalleGrupoDeRestricciones()
        {
            ObjGrpRestriccDet.iIdConexion = iIdConexion;
            ObjGrpRestriccDet.iIdGrupoRestriccion = iIdGrupoRestriccion;
            ObjGrpRestriccDet.iIdHisInstancia = iIdHisInstancia;
            Boolean AnsOK = ObjGrpRestriccDet.ObtieneDetalleGrupoDeRestricciones();
            DSet = ObjGrpRestriccDet.DSet;
            sMensajeError = ObjGrpRestriccDet.sMensajeError;
            return (AnsOK);
        }


    }

}