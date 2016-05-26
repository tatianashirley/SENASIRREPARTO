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
    public class clsEmisionFormularioCalculo
    {
        DataTable dt = new DataTable();
        clsEmisionFormularioCalculoDA ObjEmisionFormularioCalculoDA = new clsEmisionFormularioCalculoDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;


        public DataTable DatosAsegurado(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.DatosAsegurado(iIdConexion, cOperacion,iIdTramite,iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable DatosAseguradoCrenta(int iIdConexion, string cOperacion, string iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.DatosAseguradoCrenta(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable DatosAseguradoCCR(int iIdConexion, string cOperacion, string iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.DatosAseguradoCCR(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool GenerarFormularioCC(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmisionFormularioCalculoDA.GenerarFormularioCC( iIdConexion,  cOperacion,  iIdTramite,  iIdGrupoBeneficio, ref  sMensajeError);
            return (bAsignacionOK);
        }
        
        public bool GenerarDescripcionFormularioCC(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,DateTime? sFechaActual, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmisionFormularioCalculoDA.GenerarDescripcionFormularioCC( iIdConexion,  cOperacion,  iIdTramite,  iIdGrupoBeneficio,sFechaActual,ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool GenerarFormularioManual(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,string sFechaCalculo, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmisionFormularioCalculoDA.GenerarFormularioManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,sFechaCalculo, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable rptFormularioAutomatico(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,int iComponente,string sRUC,int iIdTipoCC, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.rptFormularioAutomatico(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,iComponente, sRUC,iIdTipoCC,ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool RegistraImpresion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmisionFormularioCalculoDA.RegistraImpresion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable ListaInformes(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.ListaInformes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable TramiteUrl(int iIdConexion, string cOperacion, string iIdTramite, int iIdGrupoBeneficio, int iChkRecurso, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.TramiteUrl(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,iChkRecurso, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable TramiteUrlCertificacion(int iIdConexion, string cOperacion, string iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.TramiteUrlCertificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool CuatroTrentaInterno(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmisionFormularioCalculoDA.CuatroTrentaInterno(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable BandejaCertificacion(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEmisionFormularioCalculoDA.BandejaCertificacion(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool CambioEstado(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEmisionFormularioCalculoDA.CambioEstado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref  sMensajeError);
            return (bAsignacionOK);
        }
     
    }
}