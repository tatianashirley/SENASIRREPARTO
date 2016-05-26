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
    public class clsTopeSalarial
    {
        DataTable dt = new DataTable();
        clsTopeSalarialDA ObjTopeSalarialDA = new clsTopeSalarialDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public bool Inserta(int iIdConexion, string cOperacion, string sCrenta, int iIdGrupoBeneficio, string sPeriodoSalario, string sSalarioCotizable, int iMonedaSalario, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTopeSalarialDA.Inserta(iIdConexion, cOperacion, sCrenta, iIdGrupoBeneficio, sPeriodoSalario, sSalarioCotizable, iMonedaSalario, ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable ListaTopes(int iIdConexion, string cOperacion, string sCrenta,int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTopeSalarialDA.ListaTopes(iIdConexion, cOperacion, sCrenta, iIdGrupoBeneficio, ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool EstadoBajaTope(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, DateTime FechaRegistro, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTopeSalarialDA.EstadoBajaTope( iIdConexion,  cOperacion,  iIdTramite,  iIdGrupoBeneficio,  FechaRegistro, ref  sMensajeError);
            return (bAsignacionOK);
        }
        

    }
   

}
