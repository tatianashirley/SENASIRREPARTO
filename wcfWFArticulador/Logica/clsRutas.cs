using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using wcfWFArticulador.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfWFArticulador.Logica
{
    public class clsRutas
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsRutaDA ObjRutaDA = new clsRutaDA();   
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public DataTable ListaFlujo(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjRutaDA.ListaFlujo(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaAreaDestino(int iIdConexion, string cOperacion,int ?iIdArea,int iIdTipoFlujo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjRutaDA.ListaAreaDestino(iIdConexion, cOperacion,iIdArea,iIdTipoFlujo, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaAreaOrigen(int iIdConexion, string cOperacion, int ?iIdArea, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjRutaDA.ListaAreaOrigen(iIdConexion, cOperacion, iIdArea, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaRolDestino(int iIdConexion, string cOperacion, int? iIdArea, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjRutaDA.ListaRolDestino(iIdConexion, cOperacion, iIdArea, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool InsertarRuta(int iIdConexion, string cOperacion, int iIdTipoFlujo,int iIdAreaOrigen,int iIdAreaDestino,int iIdRolOrigen,int iIdRolDestino, string sJustificacion,ref string sMensajeError)
        {
            bool bAsignacionOK = ObjRutaDA.InsertarRuta(iIdConexion, cOperacion, iIdTipoFlujo, iIdAreaOrigen, iIdAreaDestino,iIdRolOrigen, iIdRolDestino,sJustificacion, ref sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable ListaRutas(int iIdConexion, string cOperacion, int iIdTipoFlujo,int iIdArea, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjRutaDA.ListaRutas(iIdConexion, cOperacion, iIdTipoFlujo, iIdArea, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public bool EliminaRuta(int iIdConexion, string cOperacion, int iIdRuta, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjRutaDA.EliminaRuta(iIdConexion, cOperacion, iIdRuta, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool DeshabilitaRuta(int iIdConexion, string cOperacion, int iIdRuta, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjRutaDA.EliminaRuta(iIdConexion, cOperacion, iIdRuta, ref sMensajeError);
            return (bAsignacionOK);
        }


        /*
        public DataTable ListaTransacionporprocedimiento(int IdProcedimiento)
        {
            return ObjTransaccionDA.ListaTransacionporprocedimiento(IdProcedimiento);
        }
        public DataTable ListaTransaccionPorModulo(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdModulo, int iIdProcedimiento, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTransaccionDA.ListaTransaccionPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, iIdProcedimiento, ref sMensajeError, ref sNivelError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
       

        public bool TransaccionAdiciona(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,int iNroTransaccion,string sDescripcionTransaccion, int iIdProcedimiento, int iFlag, string sOperacionTrn, int iSegsTimeout, int iIdEstado, int iIdModulo, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTransaccionDA.TransaccionAdiciona(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iNroTransaccion,sDescripcionTransaccion, iIdProcedimiento, iFlag, sOperacionTrn, iSegsTimeout, iIdEstado, iIdModulo, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool TransaccionModifica(int iIdConexion, string cOperacion,int  iIdTransaccion,string sDescripcion,int  iIdProcedimiento,int  iFlagLog, string sOperacionTrn, int iSegsTimeout, int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTransaccionDA.TransaccionModifica(iIdConexion, cOperacion, iIdTransaccion, sDescripcion, iIdProcedimiento, iFlagLog, sOperacionTrn, iSegsTimeout, iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable ListaTransaccionPorId(int iIdConexion, string cOperacion, int iIdTransaccion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTransaccionDA.ListaTransaccionPorId(iIdConexion, cOperacion, iIdTransaccion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTransaccionDA.ObtieneNroTransaccion(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        */
        

    }
}