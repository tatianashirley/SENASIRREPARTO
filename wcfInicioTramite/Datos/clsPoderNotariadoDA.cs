using SQLSPExecuter;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Datos
{
    public class clsPoderNotariadoDA : clsPoderNotariadoBE
    {
        //Procedimiento para obtener poder notarial
        public bool Obtener()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_PoderNotariado", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdtramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoBeneficio);

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

        //Procedimiento para registrar poder notarial
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_PoderNotariado", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroPoderNotarial", NroPoder);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sAdministracion", Administracion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoInicio", VigenciaDesde);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoFinal", VigenciaHasta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdtramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoBeneficio);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", SegundoNombres);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoCasada", ApellidoCasada);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComplementoSEGIP", ComplementoSEGIP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumentoExpedido", DocumentoExpedido);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDireccion", Direccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelular", Celular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelularReferencia", CelularReferencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTelefono", Telefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRegional", IdRegional);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para actualizar poder notarial
        public bool Actualizar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_PoderNotariado", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroPoderNotarial", NroPoder);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sAdministracion", Administracion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoInicio", VigenciaDesde);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoFinal", VigenciaHasta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdtramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoBeneficio);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerNombre", PrimerNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoNombre", SegundoNombres);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", PrimerApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sApellidoCasada", ApellidoCasada);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComplementoSEGIP", ComplementoSEGIP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumentoExpedido", DocumentoExpedido);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDireccion", Direccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelular", Celular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCelularReferencia", CelularReferencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTelefono", Telefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservacion", Observacion);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

    }
}