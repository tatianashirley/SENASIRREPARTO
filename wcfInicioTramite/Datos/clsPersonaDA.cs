using SQLSPExecuter;
using System.Data;
using wcfInicioTramite.Logica;

namespace wcfInicioTramite.Datos
{
    public class clsPersonaDA
    {
        //Buscar personas por identificador
        public bool BuscarPorIdentificador(int iIdConexion, string cOperacion, string sTipoBusqueda, string sTipoDocumento, string sNumeroDocumento, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_BusquedaPorIdentificador", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoBusqueda", sTipoBusqueda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoDocumento", sTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", sNumeroDocumento);

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

        //Buscar personas por avanzada
        public bool BuscarPorAvanzada(int iIdConexion, string cOperacion, string sTipoBusqueda, string sApellidoPaterno, string sApellidoMaterno, string sPrimerNombre, string sSegundoNombre, string sNumeroDocumento, string sFechaNacimiento, string sPrecision, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_BusquedaAvanzada", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipoBusqueda", sTipoBusqueda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoPaterno", sApellidoPaterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoMaterno", sApellidoMaterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", sPrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", sSegundoNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", sNumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sFechaNacimiento", sFechaNacimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrecision", sPrecision);

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

        //Obtener datos persona FFAA
        public bool ObtenerDatosPersonaFFAA(int iIdConexion, string cOperacion, string sNumeroDocumento, string sNUA, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_ObtenerDatosFFAA", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", sNumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNUA", sNUA);

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

        //Procedimiento para registrar persona
        public bool RegistrarPersona(int iIdConexion, string cOperacion, ref clsPersona cPersona, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_Persona", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", cPersona.Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUB", cPersona.NUB);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", cPersona.NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComplementoSEGIP", cPersona.ComplementoSEGIP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumentoExpedido", cPersona.DocumentoExpedido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", cPersona.PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", cPersona.SegundoNombres);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", cPersona.PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", cPersona.SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoCasada", cPersona.ApellidoCasada);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaNacimiento", ((new clsFormatoFecha()).newFechaBD(cPersona.FechaNacimiento)));
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaFallecimiento", ((new clsFormatoFecha()).newFechaBD(cPersona.FechaFallecimiento)));
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdPaisResidencia", cPersona.IdPaisResidencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCorreoElectronico", cPersona.CorreoElectronico);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelular", cPersona.Celular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelularReferencia", cPersona.CelularReferencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDireccion", cPersona.Direccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdLocalidad", cPersona.IdLocalidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTelefono", cPersona.Telefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", cPersona.RegistroActivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHuella", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMotivo", cPersona.motivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatriculaOriginal", cPersona.MatriculaOriginal);
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

        //Procedimiento para registrar persona
        public bool BuscarPersona(int iIdConexion, string cOperacion, ref clsPersona cPersona, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_Persona", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", cPersona.NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", cPersona.PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", cPersona.PrimerApellido);

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

        //Procedimiento para obtener datos de la persona
        public bool ObtenerPersona(int iIdConexion, string cOperacion, ref clsPersona cPersona, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_Persona", cOperacion);

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

        //Procedimiento para obtener datos referencial de la persona
        public bool ObtenerDatosReferencial(int iIdConexion, string cOperacion, ref clsPersona cPersona, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Persona.PR_ObtenerDatosReferencial", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", cPersona.Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPeriodo", cPersona.Periodo);
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