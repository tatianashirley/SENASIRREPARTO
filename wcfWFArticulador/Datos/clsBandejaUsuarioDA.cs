using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWFArticulador.Entidades;
using SQLSPExecuter;
using System.Data;

namespace wcfWFArticulador.Datos
{
    public class clsBandejaUsuarioDA : clsWFArticuladorBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public Int32 iIdRuta { get; set; }
        public Int64 iIdTramite { get; set; }
        public String sIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdUsuarioDestino { get; set; }
        public Int32 iIdAreaDestino { get; set; }
        public Int32 iIdUsuarioDestinoNew { get; set; }
        public Int32 iIdAreaDestinoNew { get; set; }
        public Int32 iIdRolNew { get; set; }
        public DateTime fFechaIngreso { get; set; }
        public Int32 iIdUsuarioOrigen { get; set; }
        public Int32 iIdAreaOrigen { get; set; }
        public DateTime fFechaSalida { get; set; }
        public String sObsSalidaArea { get; set; }
        public DateTime fFechaSalidaTentativa { get; set; }
        public Int32 iIdEstadoSeguimientoTramite { get; set; }
        public Int32 iIdUsuarioRegistro { get; set; }
        public DateTime fFechaRegistro { get; set; }
        public String Tipo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Int32 IdUsuarioOrigen { get; set; }
        public Int32 IdAreaOrigen { get; set; }
        public DateTime fFechaAsignacion { get; set; }
        public String sProvehido { get; set; }
        public Int32 iId430 { get; set; }
        public DateTime fFecha1 { get; set; }
        public DateTime fFecha2 { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"

        /// <summary>
        /// Lista Bandeja Entrada
        /// </summary>
        /// <returns></returns>
        public bool ListaBandejaDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Lista Usuario Destino Posible
        /// </summary>
        /// <returns></returns>
        public bool ListaUsuarioDestinoPosibleDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdAreaDestino", iIdAreaDestino);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdAreaDestinoNew", iIdAreaDestinoNew);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Lista Bandeja Entrada Detalle
        /// </summary>
        /// <returns></returns>
        public bool ListaBandejaDetalleDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Id430", iId430);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Busca Tramite en Bandeja
        /// </summary>
        /// <returns></returns>
        public bool BuscaTramiteBandejaDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", sIdTramite);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Lista Bandeja de Trabajo
        /// </summary>
        /// <returns></returns>
        public bool ListaBandejaTrabajoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Busca Tramite en Bandeja de Trabajo
        /// </summary>
        /// <returns></returns>
        public bool BuscaTramiteBandejaTrabajoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", sIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdAreaDestino", iIdAreaDestino);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdAreaDestinoNew", iIdAreaDestinoNew);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRolNew", iIdRolNew);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Historial de un Tramite
        /// </summary>
        /// <returns></returns>
        public bool HistorialTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "R");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "R");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", sIdTramite);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Seguimiento Tramites
        /// </summary>
        /// <returns></returns>
        public bool SeguimientoTramitesDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_ListarTramites", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha1", fFecha1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha2", fFecha2);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Flujo Tramite
        /// </summary>
        /// <returns></returns>
        public bool FlujoTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_FlujoTramite", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", sIdTramite);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        /// <summary>
        /// Asigna Tramite
        /// </summary>
        /// <returns></returns>
        public bool AsignaTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "WFArticulador.PR_FlujoTramite", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTramite", sIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdRuta", iIdRuta);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdAreaDestinoNew", iIdAreaDestinoNew);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaAsignacion", fFechaAsignacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ObsSalidaArea", sObsSalidaArea);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Provehido", sProvehido);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        #endregion
    }
}