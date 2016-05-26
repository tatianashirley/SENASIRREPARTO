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
    public class clsMensajeError
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsMensajeErrorDA ObjMensajeErrorDA = new clsMensajeErrorDA();


        public DataTable ListaMensajeErrorPorModulo(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdProcedimiento, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjMensajeErrorDA.ListaMensajeErrorPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool MensajeErrorAdiciona(int iIdConexion, string cOperacion,int iIdMensajeError, string sDescripcionMensajeError, int iIdModulo, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjMensajeErrorDA.MensajeErrorAdiciona(iIdConexion, cOperacion, iIdMensajeError,sDescripcionMensajeError, iIdModulo, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool MensajeErrorModifica(int iIdConexion, string cOperacion,int  iIdMensaje,string sDescripcion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjMensajeErrorDA.MensajeErrorModifica(iIdConexion, cOperacion, iIdMensaje, sDescripcion, ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable ListaMensajeErrorPorId(int iIdConexion, string cOperacion, int iIdMensaje, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjMensajeErrorDA.ListaMensajeErrorPorId(iIdConexion, cOperacion, iIdMensaje, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ObtieneNroMensaje(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjMensajeErrorDA.ObtieneNroMensaje(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

    }
}