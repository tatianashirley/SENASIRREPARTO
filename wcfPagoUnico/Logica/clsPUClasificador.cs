using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;
using wcfPagoUnico.Datos;

namespace wcfPagoUnico.Logica
{
    public class clsPUClasificador
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsPUClasificadorDA ObjPUClasificadorDA = new clsPUClasificadorDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public DataTable ListarDocumentosTitular(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPUClasificadorDA.ListarDocumentosTitular(iIdConexion,cOperacion,sSessionTrabajo,sSNN,ref sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarDocumentosDH(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPUClasificadorDA.ListarDocumentosDH(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarParentesco(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPUClasificadorDA.ListarParentesco(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
                ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ClasTipoPlanilla(int iIdConexion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjPUClasificadorDA.ClasTipoPlanilla(iIdConexion, "Q", ref sMensajeError, ref DSetTmp))
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