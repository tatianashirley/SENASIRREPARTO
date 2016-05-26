using SQLSPExecuter;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Datos
{
    public class clsSalarioDA : clsSalarioBE
    {
        //Procedimiento para registrar tramite salario 
        public bool Registrar()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Tramite.PR_SalarioCotizable", cOperacion);

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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", IdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iVersion", Version);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sRUC", Ruc);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iComponente", Componente);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocSalario", IdTipoDocSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fPeriodoSalario", PeriodoSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mSalarioCotizable", SalarioCotizable);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdMonedaSalario", IdMonedaSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iEstadoSalario", IdEstadoSalario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", RegistroActivo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdSector", IdSector);

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