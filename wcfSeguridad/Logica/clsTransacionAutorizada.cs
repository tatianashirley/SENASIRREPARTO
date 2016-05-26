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
    public class clsTransaccionAutorizada
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsTransaccionAutorizadaDA TransaccionAutorizadaDA = new clsTransaccionAutorizadaDA();


        public DataTable ListaTransaccionAutorizadaPorModulo(int iIdConexion, string cOperacion, int iIdModulo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (TransaccionAutorizadaDA.ListaTransaccionAutorizadaPorModulo(iIdConexion, cOperacion, iIdModulo, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaTransaccionAutorizadaPorModuloyRol(int iIdConexion, string cOperacion, int iIdModulo, int iIdRol,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (TransaccionAutorizadaDA.ListaTransaccionAutorizadaPorModuloyRol(iIdConexion, cOperacion, iIdModulo,iIdRol, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool TransaccionAutorizadaAdiciona(int iIdConexion,string  cOperacion,int  iIdRol,int iIdTransaccion, ref string sMensajeError)
        {
            bool bAsignacionOK = TransaccionAutorizadaDA.TransaccionAutorizadaAdiciona(iIdConexion, cOperacion, iIdRol, iIdTransaccion, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool TransaccionAutorizadaModifica(int iIdConexion, string cOperacion, int iIdTransaccionAutorizada, string sDescripcion, int iIdProcedimiento, int iFlagLog, string sOperacionTrn, int iSegsTimeout, int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = TransaccionAutorizadaDA.TransaccionAutorizadaModifica(iIdConexion, cOperacion, iIdTransaccionAutorizada, sDescripcion, iIdProcedimiento, iFlagLog, sOperacionTrn, iSegsTimeout, iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        
        public bool TransaccionAutorizadaElimina(int iIdConexion,string cOperacion,int iIdRol,int iIdTransaccion, ref string sMensajeError)
        {
            bool bAsignacionOK = TransaccionAutorizadaDA.TransaccionAutorizadaElimina(iIdConexion, cOperacion, iIdRol, iIdTransaccion, ref sMensajeError);
            return (bAsignacionOK);
        }

        public DataTable ListaTransaccionAutorizadaPorId(int iIdConexion, string cOperacion, int iIdTransaccionAutorizada, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (TransaccionAutorizadaDA.ListaTransaccionAutorizadaPorId(iIdConexion, cOperacion, iIdTransaccionAutorizada, ref sMensajeError, ref DSetTmp))
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