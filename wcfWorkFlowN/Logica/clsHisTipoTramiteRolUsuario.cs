using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsHisTipoTramiteRolUsuario : clsHisTipoTramiteRolUsuarioBE {

        clsHisTipoTramiteRolUsuarioDA ObjHTipoTramRosUsrDA = new clsHisTipoTramiteRolUsuarioDA();

        public Boolean ObtieneActividadesXUsuario() {
            ObjHTipoTramRosUsrDA.iIdConexion = iIdConexion;
            ObjHTipoTramRosUsrDA.iIdHisInstancia = iIdHisInstancia;
            ObjHTipoTramRosUsrDA.sIdTipoTramite = sIdTipoTramite;
            ObjHTipoTramRosUsrDA.iIdRol = iIdRol;
            ObjHTipoTramRosUsrDA.iIdUsuario = iIdUsuario;
            Boolean AnsOK = ObjHTipoTramRosUsrDA.ObtieneUsuariosDisponiblesXNodo();
            DSet = ObjHTipoTramRosUsrDA.DSet;
            sMensajeError = ObjHTipoTramRosUsrDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneUsuariosSubordinados() {
            ObjHTipoTramRosUsrDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjHTipoTramRosUsrDA.ObtieneUsuariosSubordinados();
            DSet = ObjHTipoTramRosUsrDA.DSet;
            sMensajeError = ObjHTipoTramRosUsrDA.sMensajeError;
            return (AnsOK);
        }


    }

}