using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfCertificacionCC.Datos;
using System.Security.Cryptography;
using System.Text;


namespace wcfCertificacionCC.Logica
{
    public class clsEmpresa
    {
        DataTable dt = new DataTable();
        clsEmpresaDA ObjEmpresaDA = new clsEmpresaDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public bool RegistraEmpresa(int iIdConexion, string cOperacion, string sRUC,string sNombreEmpresa,string sSector,string sPatronal,int iValido,int iEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmpresaDA.RegistraEmpresa( iIdConexion,  cOperacion,  sRUC, sNombreEmpresa, sSector, sPatronal, iValido,iEstado, ref  sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable BuscaEmpresa(int iIdConexion,string cOperacion, string sOpcionBusqueda, string sDatoBusqueda,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmpresaDA.BuscaEmpresa(iIdConexion, cOperacion, sOpcionBusqueda,  sDatoBusqueda,ref  sMensajeError, ref DSetTmp))
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
