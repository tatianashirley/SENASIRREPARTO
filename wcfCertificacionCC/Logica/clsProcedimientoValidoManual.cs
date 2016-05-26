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
    public class clsProcedimientoValidoManual
    {
        DataTable dt = new DataTable();
        clsProcedimientoValidoManualDA ObjProcedimientoValidoManualDA = new clsProcedimientoValidoManualDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;


        public DataTable DatosProcedimientoValidoManual(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoValidoManualDA.DatosProcedimientoValidoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaDetalleClasificador(int TipoClas)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjProcedimientoValidoManualDA.ListaDetalleClasificador(TipoClas);
            dt.Load(dr);
            return dt;
        }
        public DataTable DescripcionRuc(string RUC)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjProcedimientoValidoManualDA.DescripcionRuc(RUC);
            dt.Load(dr);
            return dt;
        }


        public bool InsertaModificaComponentes(int iIdConexion,string cOperacion,int iIdTramite,int iIdGrupoBeneficio,int iComponente,string sRUC,int iIdTipoDocumento,string sPeriodoSalario,string sSalarioCotizable, string sSalarioCotizableActualizado,int iMonedaSalario,int ?iIdParametrizacion,string sGlosa,int iCertificado,string sSector, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoValidoManualDA.InsertaModificaComponentes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iComponente, sRUC, iIdTipoDocumento, sPeriodoSalario, sSalarioCotizable, sSalarioCotizableActualizado, iMonedaSalario, iIdParametrizacion, sGlosa, iCertificado,sSector, ref sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable CalculoSalarioCotizableActualizado(int iIdTramite, int iIdGrupoBeneficio, string sFechaCalculo, string sTipoAct, string sPeriodoSalario, string sSalarioCotizable, string sRUC)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjProcedimientoValidoManualDA.CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sFechaCalculo, sTipoAct, sPeriodoSalario, sSalarioCotizable, sRUC);
            dt.Load(dr);
            return dt;
        }

        public bool EliminayAprueba_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sRUC, int iComponente, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoValidoManualDA.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sRUC, iComponente, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool ApruebaRechaza_CCR(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, string sRUC, int iComponente,int iEstadoAprobacion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoValidoManualDA.ApruebaRechaza_CCR(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sRUC, iComponente, iEstadoAprobacion, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool RecursoReclamacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio, int iVersion, int iComponente,int iAnulaCerti, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoValidoManualDA.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente,iAnulaCerti, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool AsignacionWFArticulador(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,int iIdUsuarioSuperior,string sObservacion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoValidoManualDA.AsignacionWFArticulador(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iIdUsuarioSuperior, sObservacion, ref  sMensajeError);
            return (bAsignacionOK);
        }
        public bool Rechaza_Certificacion(int iIdConexion, string cOperacion, int iIdTramite, int iIdGrupoBeneficio,  ref string sMensajeError)
        {
            bool bAsignacionOK = ObjProcedimientoValidoManualDA.Rechaza_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref  sMensajeError);
            return (bAsignacionOK);
        }

        public DataTable ObtenerTipoMoneda(int iIdConexion, string cOperacion, string sPeriodoSalario, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcedimientoValidoManualDA.ObtenerTipoMoneda(iIdConexion, cOperacion, sPeriodoSalario, ref sMensajeError, ref DSetTmp))
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