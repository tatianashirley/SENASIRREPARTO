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
    public class clsEstructuraProgramacion
    {
        DataTable dt = new DataTable();
        clsEstructuraProgramacionDA ObjEstructuraProgramacionDA = new clsEstructuraProgramacionDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;


        public DataTable ConsultaEstructuraProgramacion(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEstructuraProgramacionDA.ConsultaEstructuraProgramacion(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        

        public bool EstructuraProgramacionAdiciona(int iIdConexion,string cOperacion,string sDescripcion, ref string sMensajeError,ref int iIdEstructura)
        {
            bool bAsignacionOK = ObjEstructuraProgramacionDA.EstructuraProgramacionAdiciona(iIdConexion, cOperacion, sDescripcion, ref sMensajeError,ref iIdEstructura);
            return (bAsignacionOK);
        }
        
        public bool EstructuraProgramacionModifica(int iIdConexion,string cOperacion,int  iIdEstructura,string sDescripcion,int iEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEstructuraProgramacionDA.EstructuraProgramacionModifica(iIdConexion, cOperacion, iIdEstructura,sDescripcion,iEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        
        public bool EstructuraDetalleAdiciona(int iIdConexion,string cOperacion,int iIdEstructura,int iIdRolSuperior,int iIdRol,int iCantidad,ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEstructuraProgramacionDA.EstructuraDetalleAdiciona(iIdConexion, cOperacion, iIdEstructura, iIdRolSuperior, iIdRol, iCantidad, ref sMensajeError);
            return (bAsignacionOK);
        }
        
        public bool EstructuraProgramacionElimina(int iIdConexion,string cOperacion,int iIdEstructura,int iIdRol, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjEstructuraProgramacionDA.EstructuraProgramacionElimina(iIdConexion, cOperacion, iIdEstructura, iIdRol, ref sMensajeError);
            return (bAsignacionOK);
        }        

        public DataTable ListaRolSuperior(int iIdConexion,string cOperacion,int iIdModulo,int iIdRolSuperior,string cLista, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEstructuraProgramacionDA.ListaRolSuperior(iIdConexion, cOperacion, iIdModulo, iIdRolSuperior, cLista, ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }        
        }
        
        public DataTable ConsultaEstructuraDetalle(int iIdConexion,string cOperacion,int iIdEstructura,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEstructuraProgramacionDA.ConsultaEstructuraDetalle( iIdConexion, cOperacion, iIdEstructura,ref  sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }        
        }
        
        public DataTable ProgramacionEstructuraListaPorId(int iIdConexion, string cOperacion,int  iIdEstructura, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjEstructuraProgramacionDA.ProgramacionEstructuraListaPorId(iIdConexion, cOperacion, iIdEstructura, ref sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }        
        }
        ////public DataTable ObtieneNroTransaccion(int iIdConexion, string cOperacion, int iIdProcedimiento, ref string sMensajeError)
        ////{
        ////    DataSet DSetTmp = new DataSet();
        ////    if (ObjTransaccionDA.ObtieneNroTransaccion(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError, ref DSetTmp))
        ////    {
        ////        return (DSetTmp.Tables[0]);
        ////    }
        ////    else
        ////    {
        ////        return (null);
        ////    }
        ////}




    }
}