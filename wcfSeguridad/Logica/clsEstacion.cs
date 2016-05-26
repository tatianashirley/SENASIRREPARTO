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
    public class clsEstacion
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsEstacionDA ObjEstacionDA = new clsEstacionDA();

        public DataTable ListaEstacion(int iIdConexion,string cOperacion,int iIdOficina, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEstacionDA.ListaEstacion(iIdConexion, cOperacion, iIdOficina, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool EstacionAdiciona(int iIdConexion, string cOperacion, string sEstacion,string sIp, string sMac,int iIdOficina, int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEstacionDA.EstacionAdiciona(iIdConexion,cOperacion,sEstacion,sIp,sMac,iIdOficina,iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool EstacionModifica(int iIdConexion,string cOperacion,int iIdEstacion,string sEstacion,string sIp,string sMac,int iIdOficina,int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEstacionDA.EstacionModifica(iIdConexion,cOperacion,iIdEstacion,sEstacion,sIp,sMac,iIdOficina,iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable ListaEstacionPorId(int iIdConexion, string cOperacion, int iIdEstacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEstacionDA.ListaEstacionPorId(iIdConexion, cOperacion, iIdEstacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        //public DataTable ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError)
        //{
        //    DataSet DSetTmp = new DataSet();
        //    if (ObjEstacionDA.ObtieneNroTransaccion(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
        //    {
        //        return (DSetTmp.Tables[0]);
        //    }
        //    else
        //    {
        //        return (null);
        //    }
        //}
        

        

    }
}