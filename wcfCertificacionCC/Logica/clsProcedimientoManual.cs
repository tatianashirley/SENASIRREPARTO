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
    public class clsProcedimientoManual
    {
        DataTable dt = new DataTable();
        clsProcedimientoManualDA ObjProcedimientoManualDA = new clsProcedimientoManualDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;



        public DataTable CalculoAniosMeses(int iIdConexion, string cOperacion, string sFechaInicio,string sFechaFin, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.CalculoAniosMeses(iIdConexion, cOperacion, sFechaInicio, sFechaFin, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ComibolSalarioConvenio(int iIdConexion, string cOperacion, string sRUC,int iIdTramite, int iIdGrupoBeneficio,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.ComibolSalarioConvenio(iIdConexion, cOperacion, sRUC, iIdTramite,iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaAprobaciones(int iIdConexion,string cOperacion, int iIdTramite,int  iIdGrupoBeneficio, int iVersion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.ListaAprobaciones(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion,ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool InsertaComponentes(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iComponente, string sRUC, int iIdTipoDocumento, string sPeriodoSalario, string sSalarioCotizable, string sSalarioCotizableActualizado, int iMonedaSalario, int ?iIdParametrizacion, string sGlosa, int iCertificado,int iMitas,string sSector,string sDetalleGeneral, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.InsertaComponentes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iComponente, sRUC, iIdTipoDocumento, sPeriodoSalario, sSalarioCotizable, sSalarioCotizableActualizado, iMonedaSalario, iIdParametrizacion, sGlosa, iCertificado,iMitas,sSector,sDetalleGeneral, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool ActualizaDensidad(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,int iVersion, int iComponente,  ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.ActualizaDensidad(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion,iComponente, ref sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable DatosProcedimientoManual(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.DatosProcedimientoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool ModificaOrdenComponente(int iIdConexion,string cOperacion,int iIdTramite,int iIdGrupoBeneficio,int iVersion,int iComponente,string sRUC, string cSubOperacion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.ModificaOrdenComponente(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, sRUC,  cSubOperacion,ref sMensajeError);
            return (bAsignacionOK);
        }

        public bool InsertaActualizacionCC(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, int iComponente, string sRUC, string sFechaAfiliacion, string sFechaBaja, string sFechaAfiliacionAnt, string sFechaBajaAnt, int iPeriodoVerificado, int iIdParametrizacion, string sGlosa, int iAnio, int iMes, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.InsertaActualizacionCC( iIdConexion, cOperacion,  iIdTramite,  iIdGrupoBeneficio, iVersion, iComponente, sRUC, sFechaAfiliacion, sFechaBaja,sFechaAfiliacionAnt,sFechaBajaAnt,iPeriodoVerificado, iIdParametrizacion,  sGlosa, iAnio,iMes, ref  sMensajeError);
            return (bAsignacionOK);
        }
        
        public DataTable ListaActualizacionCC(int iIdConexion,string  cOperacion,int iIdTramite,int iIdGrupoBeneficio,int iVersion,string sRuc,int iComponente, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.ListaActualizacionCC(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,iVersion,sRuc,iComponente, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool Apruebaconinforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sInforme, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.Apruebaconinforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sInforme, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool IngresaInforme(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sInforme,int iIdTipoInforme, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.IngresaInforme(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sInforme,iIdTipoInforme, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool ActualizaInforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, string NroControl, string sInforme,int iIdTipoInforme, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.ActualizaInforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, NroControl, sInforme,iIdTipoInforme, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool EliminarInforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, string NroControl, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.EliminarInforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, NroControl, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool LevantaInforme_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, string NroControl, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoManualDA.LevantaInforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, NroControl, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable ListaInforme(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.ListaInforme(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        public DataTable ObtenerUltimoRUC(int iIdConexion,string cOperacion,int iIdTramite,int iIdGrupoBeneficio,int iVersion,int iComponente, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoManualDA.ObtenerUltimoRUC( iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        //public bool ApruebaRechaza_CCR(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sRUC, int iComponente, int iEstadoAprobacion, ref string sMensajeError)
        //{
        //    bool bAsignacionOK = ObjProcedimientoValidoManualDA.ApruebaRechaza_CCR(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sRUC, iComponente, iEstadoAprobacion, ref  sMensajeError);
        //    return (bAsignacionOK);
        //}
        
        




    }
}