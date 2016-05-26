using SQLSPExecuter;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Datos
{
    public class clsEmpresaPersonaDA : clsEmpresaPersonaBE
    {
        //Procedimiento para registrar empresas de la persona
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_EmpresaPersonaRegistro", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEmpresaPersona", IdEmpresaPersona);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iidGrupoBeneficio", idGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdEmpresa", IdEmpresa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreEmpresaDeclarada", NombreEmpresaDeclarada);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservacion", Observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoInicio", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoFin", PeriodoFin);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mMonto", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMoneda", IdMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bEstadoRegistro", EstadoRegistro);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNroPatronalRucAlt", NroPatronalRucAlt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSector", IdSector);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocSalario", IdTipoDocSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSectorSSLP", IdSectorSSLP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValidaPFA", ValidaPFA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatriculaORG", MatriculaORG);
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int lIdEmpresaPersona = 0;
                        ObjSPExec.ObtenerValorParametro("@i_iIdEmpresaPersona", ref lIdEmpresaPersona);
                        IdEmpresaPersona = lIdEmpresaPersona;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        //Procedimiento para modificar empresas de la persona
        public bool Modificar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ModEmpresaPersonaRegistro", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEmpresaPersona", IdEmpresaPersona);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iidGrupoBeneficio", idGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iTipoTramite", IdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdEmpresa", IdEmpresa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombreEmpresaDeclarada", NombreEmpresaDeclarada);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservacion", Observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoInicio", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoFin", PeriodoFin);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mMonto", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMoneda", IdMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bEstadoRegistro", EstadoRegistro);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNroPatronalRucAlt", NroPatronalRucAlt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSector", IdSector);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocSalario", IdTipoDocSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", Version);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", Componente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoSalario", PeriodoSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMonedaSalario", IdMonedaSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMotivo", Motivo);
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

        //Procedimiento para obtener datos empresas
        public bool ObtenerLista()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_EmpresaPersonaRegistro", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iidGrupoBeneficio", idGrupoBeneficio);

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