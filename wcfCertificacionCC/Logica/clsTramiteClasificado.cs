using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfCertificacionCC.Datos;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfCertificacionCC.Logica
{
    public class clsTramiteClasificado
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsTramiteClasificadoDA ObjTramiteClasificadoDA = new clsTramiteClasificadoDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;


        
        public DataTable ListarTramitesClasificados(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento,int CUA, string Tramite, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteClasificadoDA.ListarTramitesClasificados(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError, 
			FechaInicio, FechaFin, clasinicio, clasfin, numregistros,NumeroDocumento, CUA, Tramite,	ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarClasificacionTramite(int iIdConexion, string cOperacion)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteClasificadoDA.ListarClasificacionTramite(iIdConexion, cOperacion, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarTramitesNoAsigna(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError, int ClasificacionTramite)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteClasificadoDA.ListarTramitesNoAsigna(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError, ClasificacionTramite, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }


        public bool ReClasificarTramite(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError, int IdTramiteClasificado, int IdClasificacionTramite)
        {
            bool bAsignacionOK = ObjTramiteClasificadoDA.ReClasificarTramite(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError, IdTramiteClasificado, IdClasificacionTramite);
            return (bAsignacionOK);
        }



        //public DataTable ListaTransaccionPorId(int iIdConexion, string cOperacion, int iIdTransaccion, ref string sMensajeError)
        //{
        //    DataSet DSetTmp = new DataSet();
        //    if (ObjTransaccionDA.ListaTransaccionPorId(iIdConexion, cOperacion, iIdTransaccion, ref sMensajeError, ref DSetTmp))
        //    {
        //        return (DSetTmp.Tables[0]);
        //    }
        //    else
        //    {
        //        return (null);
        //    }
        //}
        //public DataTable ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError)
        //{
        //    DataSet DSetTmp = new DataSet();
        //    if (ObjTransaccionDA.ObtieneNroTransaccion(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
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