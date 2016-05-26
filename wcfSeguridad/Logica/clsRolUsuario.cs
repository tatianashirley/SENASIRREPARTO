using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfSeguridad.Entidades;
using wcfSeguridad.Datos;

namespace wcfSeguridad.Logica {

    public class clsRolUsuario : clsRolUsuarioBE {

        clsRolUsuarioDA ObjRolUsr = new clsRolUsuarioDA();

        public bool ObtieneUsuariosXRol() {
            ObjRolUsr.iIdConexion = iIdConexion;
            ObjRolUsr.iIdRol = iIdRol;
            Boolean AnsOK = ObjRolUsr.ObtieneUsuariosXRol();
            DSet = ObjRolUsr.DSet;
            sMensajeError = ObjRolUsr.sMensajeError;
            return (AnsOK);
        }

    }

}