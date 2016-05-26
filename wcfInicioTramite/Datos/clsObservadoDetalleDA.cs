using SQLSPExecuter;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Datos
{
    public class clsObservadoDetalleDA : clsObservadoDetalleBE
    {
        //Procedimiento para registrar el detalle del tramite observado
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_ObservadoDetalle", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdObservado", IdObservado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTramite", Tramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sTipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iCUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sPrimerApellido", PrimeroApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSegundoApellido", SegundoApellido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNombres", Nombres);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaNacimiento", FechaNacimiento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sSector", Sector);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sDHMatricula", DHMatricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sEstadoObservado", EstadoObservado);

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