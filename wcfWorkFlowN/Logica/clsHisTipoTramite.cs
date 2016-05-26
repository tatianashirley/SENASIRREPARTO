using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica
{

    public class clsHisTipoTramite : clsHisTipoTramiteBE
    {

        clsHisTipoTramiteDA ObjTipoTrmte = new clsHisTipoTramiteDA();

        //public Boolean Adicion()
        //{
        //    ObjTipoTrmte.iIdConexion = iIdConexion;
        //    ObjTipoTrmte.sIdTipoTramite = sIdTipoTramite;
        //    ObjTipoTrmte.sDescripcion = sDescripcion;
        //    ObjTipoTrmte.sIdTipoTramiteSup = sIdTipoTramiteSup;
        //    ObjTipoTrmte.bFlagAgrupador = bFlagAgrupador;
        //    ObjTipoTrmte.iIdModulo = iIdModulo;
        //    ObjTipoTrmte.bFlagExcepcion = bFlagExcepcion;
        //    ObjTipoTrmte.sFlagReinicio = sFlagReinicio;
        //    ObjTipoTrmte.iMaxDiasIniTramite = iMaxDiasIniTramite;
        //    ObjTipoTrmte.iMaxDiasTramiteInactivo = iMaxDiasTramiteInactivo;
        //    ObjTipoTrmte.iIdGrupoRestriccion = iIdGrupoRestriccion;
        //    Boolean AnsOK = ObjTipoTrmte.Adicion();
        //    iSesionTrabajo = ObjTipoTrmte.iSesionTrabajo;
        //    sMensajeError = ObjTipoTrmte.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean Modificacion()
        {
            ObjTipoTrmte.iIdConexion = iIdConexion;
            ObjTipoTrmte.sIdTipoTramite = sIdTipoTramite;
            ObjTipoTrmte.sDescripcion = sDescripcion;
            ObjTipoTrmte.sIdTipoTramiteSup = sIdTipoTramiteSup;
            ObjTipoTrmte.bFlagAgrupador = bFlagAgrupador;
            ObjTipoTrmte.iIdModulo = iIdModulo;
            ObjTipoTrmte.bFlagExcepcion = bFlagExcepcion;
            ObjTipoTrmte.sFlagReinicio = sFlagReinicio;
            ObjTipoTrmte.iMaxDiasIniTramite = iMaxDiasIniTramite;
            ObjTipoTrmte.iMaxDiasTramiteInactivo = iMaxDiasTramiteInactivo;
            ObjTipoTrmte.iIdGrupoRestriccion = iIdGrupoRestriccion;
            Boolean AnsOK = ObjTipoTrmte.Modificacion();
            sMensajeError = ObjTipoTrmte.sMensajeError;
            return (AnsOK);
        }

        //public Boolean Eliminacion()
        //{
        //    ObjTipoTrmte.iIdConexion = iIdConexion;
        //    ObjTipoTrmte.sIdTipoTramite = sIdTipoTramite;
        //    Boolean AnsOK = ObjTipoTrmte.Eliminacion();
        //    sMensajeError = ObjTipoTrmte.sMensajeError;
        //    return (AnsOK);
        //}

        public Boolean ObtieneFila()
        {
            ObjTipoTrmte.iIdConexion = iIdConexion;
            ObjTipoTrmte.iIdHisInstancia = iIdHisInstancia;
            ObjTipoTrmte.sIdTipoTramite = sIdTipoTramite;
            Boolean AnsOK = ObjTipoTrmte.ObtieneFila();
            DSet = ObjTipoTrmte.DSet;
            sMensajeError = ObjTipoTrmte.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneTiposDeTramite()
        {
            ObjTipoTrmte.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjTipoTrmte.ObtieneTiposDeTramite();
            DSet = ObjTipoTrmte.DSet;
            sMensajeError = ObjTipoTrmte.sMensajeError;
            return (AnsOK);
        }

    }

}