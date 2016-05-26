using System;
using System.Data;
using SQLSPExecuter;
using wcfPagoUnico.Entidades;
using wcfPagoUnico.Logica;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace wcfPagoUnico.Datos
{
    public class clsPUPersonaDA
    {
        clsPUUtilitarios objUtil = new clsPUUtilitarios();

        //Procedimiento para registrar persona
        public bool RegistrarPersona(int iIdConexion, string cOperacion, ref clsPUPersonaB cPersona, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_RegistraPersona", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", cPersona.NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", cPersona.IdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoCivil", cPersona.IdEstadoCivil);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidadGestora", cPersona.IdEntidadGestora);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSexo", cPersona.IdSexo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCUA", cPersona.CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", objUtil.GenerarMatricula(cPersona.PrimerApellido, cPersona.SegundoApellido, cPersona.PrimerNombre, cPersona.FechaNacimiento, cPersona.IdSexo.ToString() ) );
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUB", cPersona.NUB);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", cPersona.NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComplementoSEGIP", cPersona.ComplementoSEGIP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumentoExpedido", cPersona.DocumentoExpedido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", cPersona.PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", cPersona.SegundoNombres);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", cPersona.PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", cPersona.SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoCasada", cPersona.ApellidoCasada);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaNacimiento", ((new clsPUFormatoFecha()).nuevaFechaBD(cPersona.FechaNacimiento)));
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaFallecimiento", ((new clsPUFormatoFecha()).nuevaFechaBD(cPersona.FechaFallecimiento)));
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdPaisResidencia", cPersona.IdPaisResidencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCorreoElectronico", cPersona.CorreoElectronico);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelular", cPersona.Celular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDireccion", cPersona.Direccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdLocalidad", cPersona.IdLocalidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTelefono", cPersona.Telefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", cPersona.RegistroActivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHuella", null);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lNup = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iNUP", ref lNup);
                        cPersona.NUP = lNup;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para registrar titular y DH
        public bool RegistraTitularDH(int iIdConexion, string cOperacion, ref clsPUPersonaB cPersona, ref string sMensajeError, long NUPDH)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "PagoU.PR_RegTitularDH", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdParentesco", cPersona.Parentesco);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUPTitular", cPersona.NUPTitular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUPDH", NUPDH);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lNup = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iNUP", ref lNup);
                        cPersona.NUP = lNup;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Buscar personas por avanzada
        public bool BusquedaAvanzada(int iIdConexion, string cOperacion, string sApellidoPaterno, string sApellidoMaterno, string sPrimerNombre, string sSegundoNombre, string sNumeroDocumento, string sFechaNacimiento, string sMatricula, int NumeroTramite, long NumeroCertidicado, string ComplementoSEGIP, int IdDocumentoExpedido, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_BuscarPersona", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", sApellidoPaterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", sApellidoMaterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", sPrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", sSegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaNacimiento", sFechaNacimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", sMatricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNumeroTramite", NumeroTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@vNumeroCertidicado", NumeroCertidicado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", sNumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComplementoSEGIP", ComplementoSEGIP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumentoExpedido", IdDocumentoExpedido);

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

        //Buscar personas por CUA
        public bool BusquedaNUP(int iIdConexion, string cOperacion, long vNUP, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_BuscaPersonaPorNUP", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", vNUP);
                
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

        //Registra la fecha de fallecimiento del titular
        public bool RegistrarFechaFallecimientoPersona(int iIdConexion, string cOperacion, ref string sMensajeError, 
            long vNUP, DateTime vFechaFallecimmiento, string vGlosario)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Novedades.PR_PersonaModFechas", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", vNUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaFallecimiento", vFechaFallecimmiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GlosaRespaldo", vGlosario);
                

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        long lNup = 0;
                        ObjSPExec.ObtenerValorParametro("@NUP", ref lNup);
                        sMensajeError = lNup.ToString();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Buscar personas derechohabientes por NUP del titular
        public bool BuscaDH(int iIdConexion, string cOperacion, long vNUP, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_BuscaDH", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", vNUP);

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

        //Obtiene los datos de las personas por NUP del titular
        public IDataReader ObtieneDatosPersona(long vNUP, string vOpcion)
        {
            Database db = null;
            db = DatabaseFactory.CreateDatabase("cadena");

            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_ObtieneDatosPersona", vNUP, vOpcion);
            cmd.CommandTimeout = 0;
            IDataReader dr = db.ExecuteReader(cmd);
            return dr;
        }

        
    }
}