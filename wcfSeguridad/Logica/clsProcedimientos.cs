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
    public class clsProcedimientos
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsProcedimientosDA ObjProcedimientoDA = new clsProcedimientosDA();

        public DataTable ListaProcedimientoPorModulo(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdModulo,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoDA.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        public DataTable ObtieneNroProcedimiento(int iIdConexion,string  cOperacion,int  iIdModulo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoDA.ObtieneNroProcedimiento(iIdConexion, cOperacion, iIdModulo, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ProcedimientoAdiciona(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,int iIdProcedimiento,string sNombreProcedimiento, string sScript, string sDescripcion, int iIdModulo, int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoDA.ProcedimientoAdiciona(iIdConexion, cOperacion, sSessionTrabajo, sSNN,iIdProcedimiento, sNombreProcedimiento, sScript, sDescripcion, iIdModulo, iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool ProcedimientoModifica(int iIdConexion,string  cOperacion,int iIdProcedimiento,string sNombreProcedimiento,string sScript,string sDescripcion,int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoDA.ProcedimientoModifica(iIdConexion, cOperacion,iIdProcedimiento, sNombreProcedimiento, sScript, sDescripcion, iIdEstado, ref  sMensajeError);
            return (bAsignacionOK);
        }
        

        public DataTable ListaProcedimientoPorId(int iIdConexion,string  cOperacion,int iIdProcedimiento,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoDA.ListaProcedimientoPorId(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
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