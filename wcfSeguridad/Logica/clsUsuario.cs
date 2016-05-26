using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfSeguridad.Logica
{
    public class clsUsuario
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsUsuarioDA ObjUsuarioDA = new clsUsuarioDA();

        public DataTable ListaUsuarios(int iIdConexion, string cOperacion, string sLogin, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjUsuarioDA.ListaUsuarios(iIdConexion, cOperacion, sLogin, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool UsuarioAdicion(int iIdConexion, string cOperacion, int iCarnet, string sCuentaUsuario, DateTime fFechaVigencia, DateTime? fFechaExpiracion, int iTipoUsuario, int iIdEstado, string sClaveUsuario, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjUsuarioDA.UsuarioAdicion(iIdConexion, cOperacion, iCarnet, sCuentaUsuario, fFechaVigencia, fFechaExpiracion, iTipoUsuario, iIdEstado, sClaveUsuario, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool UsuarioModifica(int iIdConexion,string cOperacion,int iIdUsuario,int iCarnet,string sCuentaUsuario,DateTime fFechaVigencia,string fFechaExpiracion,int iTipoUsuario,int iIdEstado,string sClaveUsuario, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjUsuarioDA.UsuarioModifica(iIdConexion, cOperacion, iIdUsuario, iCarnet, sCuentaUsuario, fFechaVigencia, fFechaExpiracion, iTipoUsuario, iIdEstado, sClaveUsuario, ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable UsuarioPorId(int iIdConexion,string cOperacion,int iIdUsuario)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjUsuarioDA.UsuarioPorId(iIdConexion, cOperacion, iIdUsuario, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
       
        //public bool UsuarioModificaPassword(int iIdConexion,string cOperacion,int iIdUsuario,string sClaveUsuario, ref string sMensajeError)
        //{
        //    bool bAsignacionOK = ObjUsuarioDA.UsuarioModificaPassword(iIdConexion, cOperacion, iIdUsuario, sClaveUsuario, ref sMensajeError);
        //    return (bAsignacionOK);
        //}

        

    }
}