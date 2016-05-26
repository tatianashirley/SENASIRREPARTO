using SQLSPExecuter;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Datos
{
    public class clsDocumentosAccesoDA : clsDocumentoAccesoBE
    {
        //Procedimiento para registrar documentos acceso
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_DocumentoAcceso", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTramite", IdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRequisito", IdRequisito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", IdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdCausa", IdCausa);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatricula", Matricula);

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