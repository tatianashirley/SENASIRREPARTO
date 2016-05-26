using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Resources;
using SQLSPExecuter;

namespace wcfCertificacionCC.Datos
{
    public class clsReprogramacionDA
    {
        string sMensajeError = "";


        public bool ProgramacionReasigna(int iIdConexion, string cOperacion, int iIdUsuarioAntiguo, int iIdProgramacionAntigua, int iIdUsuarioNuevo, int iIdProgramacionNueva, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ReAsignarTramite", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@UsuarioOrig", iIdUsuarioAntiguo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ProgramacionOrig", iIdProgramacionAntigua);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@UsuarioDestino", iIdUsuarioNuevo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ProgramacionDestino", iIdProgramacionNueva);
                

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }                    

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

      
        public bool ListaProgramacionPorId(int iIdConexion,string cOperacion,int iIdProgramacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_Programacion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
       
       public bool  ProgramacionMallaAdiciona(int iIdConexion,string cOperacion,int iIdProgramacion,string sFechaInicioParte,string sFechaConclusionParte,int iIdTipoProgramacion,int iIdUsuario,int iIdUsuarioSuperior,int iIdRol,int iIdEstadoProgramacion,ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaInicioParte", sFechaInicioParte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaConclusionParte", sFechaConclusionParte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoProgramacion", iIdTipoProgramacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuarioSuperior", iIdUsuarioSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoProgramacion", iIdEstadoProgramacion);
                


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

       public bool ProgramacionMallaAutomatico(int iIdConexion, string cOperacion, int iIdRol, string sFechaInicioPrg, string sFechaFinalPrg, int iCantidad, int iIdUsuarioSuperior, int iIdEstructura, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaInicioParte", sFechaInicioPrg);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaConclusionParte", sFechaFinalPrg);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCantidad", iCantidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuarioSuperior", iIdUsuarioSuperior);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
       public bool ProgramacionMallaModificaEstado(int iIdConexion,string cOperacion,int iIdProgramacion,int iIdEstructura,int iIdEstadoProgramacion, ref string sMensajeError)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_Programacion", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoProgramacion", iIdEstadoProgramacion);
           

               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   

               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }
       public bool ConsultaProgramacionMalla(int iIdConexion, string cOperacion, int iIdEstructura, string sFechaInicioPrg, string sFechaFinalPrg, int iIdProgramacion, ref string sMensajeError, ref DataSet DSetTmp)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructura);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaInicioParte", sFechaInicioPrg);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaConclusionParte", sFechaFinalPrg);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);
               


               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   else
                   {
                       DSetTmp = ObjSPExec.p_DataSetResultado;
                   }
               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }
        
       public bool ConsultaProgramacionMallaVigente(int iIdConexion,string cOperacion,int iIdProgramacion,int iIdEstadoProgramacion, ref string sMensajeError, ref DataSet DSetTmp)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);               
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoProgramacion", iIdEstadoProgramacion);
               


               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   else
                   {
                       DSetTmp = ObjSPExec.p_DataSetResultado;
                   }
               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }

       public bool EliminaProgramacionMalla(int iIdConexion, string cOperacion, int iIdProgramacionM, int iIdUsuarioM, int iIdRolM, ref string sMensajeError)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacionM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuarioM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRolM);
           

               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   

               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }
        
            public bool EliminaProgramacion(int iIdConexion,string cOperacion,int iIdProgramacion, ref string sMensajeError)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_Programacion", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);               
           

               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   

               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }

            public bool ProgramacionCabeceraModifica(int iIdConexion, string cOperacion, int iIdProgramacion, int iIdEstructuraProgramacion, int iIdPlazoProgramacion, int iIdResponsable, string sFechaInicio, string sFechaFinal, int iIdRol,int iIdEstadoProgramacion, ref string sMensajeError)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_Programacion", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstructura", iIdEstructuraProgramacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoPlazoProgramacion", iIdPlazoProgramacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdResponsable", iIdResponsable);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaInicioPrg", sFechaInicio);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaFinalPrg", sFechaFinal);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoProgramacion", iIdEstadoProgramacion);
               
           

               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   

               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }

            public bool ModificaProgramacionMallaEstado(int iIdConexion, string cOperacion, int iIdProgramacionM, int iIdUsuarioM, int iIdRolM, int iIdEstadoProgramacionM, string sFechaInicioParteM, string sFechaConclusionParteM, ref string sMensajeError)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacionM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuarioM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRolM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoProgramacion", iIdEstadoProgramacionM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaInicioParte", sFechaInicioParteM);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaConclusionParte", sFechaConclusionParteM);

               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   

               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }
            public bool ConsultaProgramacionMallaVigentexRol(int iIdConexion, string cOperacion, int iIdProgramacion, int iIdRol, ref string sMensajeError, ref DataSet DSetTmp)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);



                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            DSetTmp = ObjSPExec.p_DataSetResultado;
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);
            }
        
           

            public bool Reprogramacion(int iIdConexion, string cOperacion, int iIdProgramacionNueva, int iIdUsuarioNuevo, int iIdProgramacionAntigua, int iIdUsuarioAntiguo, ref string sMensajeError)
       {
           ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
           if (!ObjSPExec.p_bEstadoOK)
           {
               sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
           }
           else
           {
               bool bAsignacionOK = true;
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdProgramacion", iIdProgramacionNueva);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuarioNuevo);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdProgramacionAntigua);
               bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoProgramacion", iIdUsuarioAntiguo);

               if (bAsignacionOK)
               {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry())
                   {
                       sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   }
                   

               }
           }
           return (ObjSPExec.p_bEstadoOK);
       }
         public bool ConsultaUsuarioxRol(int iIdConexion,string cOperacion,int iIdRol, ref string sMensajeError, ref DataSet DSetTmp)
            {
                ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "CertificacionCC.PR_ProgramacionMalla", cOperacion);
                if (!ObjSPExec.p_bEstadoOK)
                {
                    sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                }
                else
                {
                    bool bAsignacionOK = true;
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);                    
                    bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);



                    if (bAsignacionOK)
                    {
                        if (!ObjSPExec.EjecutarProcedimientoQry())
                        {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                        }
                        else
                        {
                            DSetTmp = ObjSPExec.p_DataSetResultado;
                        }
                    }
                }
                return (ObjSPExec.p_bEstadoOK);
            }
    }


}