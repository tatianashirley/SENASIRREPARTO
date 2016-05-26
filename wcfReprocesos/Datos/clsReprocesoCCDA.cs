using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using SQLSPExecuter;

using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace wcfReprocesos.Datos
{
    public class clsReprocesoCCDA : clsReprocesosBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public String iNumeroResolucion { get; set; }
        public DateTime? iFechaResolucion { get; set; }
        public Int64 iIdTramite { get; set; }
        public String sIdTramite { get; set; }
        public Int64 iNUP { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iNoFormularioCalculo { get; set; }
        public DateTime? fFechaCalculo { get; set; }
        public Decimal dMontoCCAceptado { get; set; }
        public Decimal dSalarioCotizableActualizadoTotal { get; set; }
        public Decimal dDensidadTotal { get; set; }
        public Int32 iSIP_impresion { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Boolean bCursoPago { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoCC { get; set; }
        public Int32 iIdTipoReproceso { get; set; }
        public Int32 iIdEstadoReproceso { get; set; }
        public Int32 iIdEstadoTramite { get; set; }
        public String cCodigoReproceso { get; set; }
        public Int32 iNroFormularioRepro { get; set; }
        public Boolean bBandejaTrabajo { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"

        Database db = null;
        public clsReprocesoCCDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        public DataTable ImprimeCertificadosDA()
        {
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DbCommand objCommand = db.GetSqlStringCommand("SELECT * FROM Reprocesos.FN_ImprimeCertificados(@IdConexion,@IdTramite,@IdGrupoBeneficio)");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            db.AddInParameter(objCommand, "@IdConexion", DbType.Int64, iIdConexion); //@IdConexion
            db.AddInParameter(objCommand, "@IdTramite", DbType.Int64, iIdTramite); //@IdTramite
            db.AddInParameter(objCommand, "@IdGrupoBeneficio", DbType.Int32, iIdGrupoBeneficio); //@IdGrupoTramite
            DataTable objDataTable = new DataTable();
            objDataTable.Load(db.ExecuteReader(objCommand));
            return objDataTable;
        }

        /// <summary>
        /// Lista Tipos de Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool ListaTiposReprocesosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "C");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "C");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Lista Estados de Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool ListaEstadosReprocesosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "D");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Inserta Formulario Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool InsertaFormularioReprocesoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroResolucion", iNumeroResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iFechaResolucion", iFechaResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", iNUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNoFormularioCalculo", iNoFormularioCalculo);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCalculo", fFechaCalculo);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dMontoCCAceptado", dMontoCCAceptado);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dSalarioCotizableActualizadoTotal", dSalarioCotizableActualizadoTotal);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dDensidadTotal", dDensidadTotal);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSIP_impresion", iSIP_impresion);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroAPS", bRegistroAPS);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bCursoPago", bCursoPago);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoCC", iIdTipoCC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_cCodigoReproceso", cCodigoReproceso);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int iNroFormularioReproTmp = 0;
                        DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@o_iNroFormularioRepro", ref iNroFormularioReproTmp);
                        iNroFormularioRepro = iNroFormularioReproTmp;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Cancela Formulario Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool CancelaFormularioReprocesoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "X");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "X");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Obtiene Detalle de un Formulario de Reproceso
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFormReproDetalleDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "O");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "O");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroFormularioRepro", iNroFormularioRepro);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Obtiene Formularios de Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFormulariosReprocesosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Busca Formularios de Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool BuscaFormulariosReprocesosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "B");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTramite", sIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEstadoReproceso", iIdEstadoReproceso);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoReproceso", iIdTipoReproceso);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bBandejaTrabajo", bBandejaTrabajo);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Obtiene un Formulario de Reproceso Específico
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFormularioReprocesoEspecificoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "R");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "R");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroFormularioRepro", iNroFormularioRepro);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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
        /// Obtiene Salario Cotizable Trámite de un Formulario de Reproceso Específico
        /// </summary>
        /// <returns></returns>
        public bool ObtieneSalarioCotizableDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "S");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroFormularioRepro", iNroFormularioRepro);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

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