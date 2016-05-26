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
    public class clsProgramacion
    {
        DataTable dt = new DataTable();
        clsProgramacionDA ObjProgramacionDA = new clsProgramacionDA();        
        Int32 iIdConexion = 0;
        string sMensajeError = null;


        public DataTable PlazoProgramacion(int iIdConexion, string cOperacion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.PlazoProgramacion(iIdConexion, cOperacion,ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
       public DataTable EstructuraProgramacion(int iIdConexion,string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.EstructuraProgramacion(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        public DataTable ProgramacionResponsable(int iIdConexion,string cOperacion,int iIdEstructura, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.ProgramacionResponsable(iIdConexion, cOperacion,iIdEstructura, ref sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ProgramacionAdiciona(int iIdConexion, string cOperacion, int iIdEstructuraProgramacion, int iIdPlazoProgramacion,int iIdResponsable,string sFechaInicio, string sFechaFinal, ref string sMensajeError,ref int iIdProgramacion)
       {
           bool bAsignacionOK = ObjProgramacionDA.ProgramacionAdiciona(iIdConexion, cOperacion, iIdEstructuraProgramacion, iIdPlazoProgramacion, iIdResponsable,sFechaInicio, sFechaFinal, ref sMensajeError,ref iIdProgramacion);
           return (bAsignacionOK);
       }
      


        public DataTable ListaProgramacionPorId(int iIdConexion,string cOperacion,int iIdProgramacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.ListaProgramacionPorId(iIdConexion, cOperacion, iIdProgramacion, ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
       
        public bool ProgramacionMallaAdiciona(int iIdConexion,string cOperacion,int iIdProgramacion,string sFechaInicioParte,string sFechaConclusionParte,int iIdTipoProgramacion,int iIdUsuario,int iIdUsuarioSuperior,int iIdRol,int iIdEstadoProgramacion,ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.ProgramacionMallaAdiciona( iIdConexion, cOperacion, iIdProgramacion, sFechaInicioParte, sFechaConclusionParte, iIdTipoProgramacion, iIdUsuario,iIdUsuarioSuperior,iIdRol,iIdEstadoProgramacion,ref sMensajeError);
           return (bAsignacionOK);
       }

        public DataTable ProgramacionMallaAutomatico(int iIdConexion, string cOperacion, int iIdRol, string sFechaInicioPrg, string sFechaFinalPrg, int iCantidad, int iIdUsuarioSuperior, int iIdEstructura, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.ProgramacionMallaAutomatico(iIdConexion, cOperacion, iIdRol, sFechaInicioPrg,sFechaFinalPrg, iCantidad, iIdUsuarioSuperior, iIdEstructura, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
         public bool ProgramacionMallaModificaEstado(int iIdConexion,string cOperacion,int iIdProgramacion,int iIdEstructura,int iIdEstadoProgramacion, ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.ProgramacionMallaModificaEstado(iIdConexion, cOperacion, iIdProgramacion, iIdEstructura,iIdEstadoProgramacion, ref sMensajeError);
           return (bAsignacionOK);
       }
        
        public DataTable ConsultaProgramacionMalla(int iIdConexion,string cOperacion,int iIdEstructura,string sFechaInicioPrg,string sFechaFinalPrg,int iIdProgramacion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.ConsultaProgramacionMalla(iIdConexion, cOperacion, iIdEstructura, sFechaInicioPrg, sFechaFinalPrg,iIdProgramacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
         public DataTable ConsultaProgramacionMallaVigente(int iIdConexion,string cOperacion,int iIdProgramacion,int iIdEstadoProgramacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProgramacionDA.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion,   iIdProgramacion,iIdEstadoProgramacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }        
         public bool EliminaProgramacionMalla(int iIdConexion,string cOperacion,int iIdProgramacionM,int iIdUsuarioM,int iIdRolM, ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.EliminaProgramacionMalla(iIdConexion, cOperacion, iIdProgramacionM,iIdUsuarioM,iIdRolM, ref sMensajeError);
           return (bAsignacionOK);
       }
        
        public bool EliminaProgramacion(int iIdConexion,string cOperacion,int iIdProgramacion, ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.EliminaProgramacion(iIdConexion, cOperacion, iIdProgramacion, ref sMensajeError);
           return (bAsignacionOK);
       }
        
        public bool ProgramacionCabeceraModifica(int iIdConexion,string cOperacion,int iIdProgramacion,int iIdEstructuraProgramacion,int iIdPlazoProgramacion,int iIdResponsable,string sFechaInicio,string sFechaFinal,int iIdRol,int iIdEstadoProgramacion,ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.ProgramacionCabeceraModifica(iIdConexion, cOperacion, iIdProgramacion, iIdEstructuraProgramacion, iIdPlazoProgramacion, iIdResponsable, sFechaInicio, sFechaFinal, iIdRol, iIdEstadoProgramacion, ref sMensajeError);
           return (bAsignacionOK);
       }

        public bool ModificaProgramacionMallaEstado(int iIdConexion, string cOperacion, int iIdProgramacionM, int iIdUsuarioM, int iIdRolM, int iIdEstadoProgramacionM, string sFechaInicioParteM, string sFechaConclusionParteM, ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.ModificaProgramacionMallaEstado(iIdConexion, cOperacion, iIdProgramacionM, iIdUsuarioM, iIdRolM, iIdEstadoProgramacionM,sFechaInicioParteM,sFechaConclusionParteM, ref  sMensajeError);
           return (bAsignacionOK);
       }
        
      

         public DataTable ConsultaProgramacionMallaVigentexRol(int iIdConexion, string cOperacion, int iIdProgramacion, int iIdRol, ref string sMensajeError)
         {
             DataSet DSetTmp = new DataSet();
             if (ObjProgramacionDA.ConsultaProgramacionMallaVigentexRol(iIdConexion, cOperacion, iIdProgramacion, iIdRol, ref sMensajeError, ref DSetTmp))
             {
                 return (DSetTmp.Tables[0]);
             }
             else
             {
                 return (null);
             }
         }    
           public bool Reprogramacion(int iIdConexion,string cOperacion,int iIdProgramacionNueva,int iIdUsuarioNuevo,int iIdProgramacionAntigua,int iIdUsuarioAntiguo, ref string sMensajeError)
       {
           bool bAsignacionOK = ObjProgramacionDA.Reprogramacion(iIdConexion, cOperacion, iIdProgramacionNueva, iIdUsuarioNuevo, iIdProgramacionAntigua, iIdUsuarioAntiguo, ref sMensajeError);
           return (bAsignacionOK);
       }
           public DataTable ConsultaUsuarioxRol(int iIdConexion,string cOperacion,int iIdRol, ref string sMensajeError)
           {
               DataSet DSetTmp = new DataSet();
               if (ObjProgramacionDA.ConsultaUsuarioxRol(iIdConexion, cOperacion, iIdRol, ref sMensajeError, ref DSetTmp))
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