using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Resources;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using SQLSPExecuter;

namespace wcfConvenios.Datos
{
    public class clsInformacionDA
    {
        Database db = null;

        public clsInformacionDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        public bool ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1, string Nombre2
                            , string NumeroDocumento, string Matricula, string CUA, Int64 NUP, int ID, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_Busquedas", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Paterno", Paterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Materno", Materno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre1", Nombre1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre2", Nombre2);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CI", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Matricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ID", ID);

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

        public bool RegistraDeuda(int iIdConexion, string cOperacion, Int64 NUP, string GrupoBeneficio, string Beneficio, string Sector
                                  , string NumeroLiquidacion, string Oficina, string Moneda, decimal Monto, DateTime FechaCambio, string TipoDeuda
                                  , int Cuotas, bool Descuento, decimal Porcentaje, decimal MontoDescuento, decimal MontoDeposito, string PeriodoInicio
                                  , string PeridoFinal, string Observaciones, string EstadoDeuda, ref int IdDeuda, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_RegistraDeuda", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@GrupoBeneficio", GrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@BeneficioOtorgado", Beneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Sector", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroLiquidacion", NumeroLiquidacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Oficina", Oficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMoneda", Moneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoDeuda", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaTipoCambio", FechaCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoDeuda", TipoDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCuotas", Cuotas);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@AplicaDescuento", Descuento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PorcentajeDescuento", Porcentaje);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoFijoDescuento", MontoDescuento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoFijoDeposito", MontoDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoInicioDeduda", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoFinDeduda", PeridoFinal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observaciones", Observaciones);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@EstadoDeuda", EstadoDeuda);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        ObjSPExec.ObtenerValorParametro("@IdDeuda", ref IdDeuda);
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool RegistraDocumento(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string TipoDocumento, string NumeroDocumento
                                        , DateTime FechaDocumento, string ReferenciaDocumento, string Observaciones, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_RegistraDocDeuda", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoDocumentoDeuda", TipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaDocumento", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ReferenciaDocumento", ReferenciaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observaciones", Observaciones);

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
        public bool RegistraCuotaPlan(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, int IdCuota, string TipoRecuperacion
                          , string Periodo, decimal MontoDebe, decimal MontoHaber, decimal Porcentaje, bool Ejecutado, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_RegistraPlanPagos", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdCuota", IdCuota);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoRecuperacion", TipoRecuperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoDebe", MontoDebe);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoHaber", MontoHaber);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Porcentaje", Porcentaje);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Ejecutado", Ejecutado);


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
        public bool ModificaCuotaPlan(int iIdConexion, string cOperacion, string Tipo, int IdDeuda, int IdCuota, string TipoRecuperacion
                          , string Periodo, decimal MontoDebe, decimal MontoHaber, decimal Porcentaje, bool Ejecutado, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_ModificaPlanPagos", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdCuota", IdCuota);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoRecuperacion", TipoRecuperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoDebe", MontoDebe);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoHaber", MontoHaber);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Porcentaje", Porcentaje);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Ejecutado", Ejecutado);

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
        public bool RegistraTipoCambio(int iIdConexion, string cOperacion, string Fecha, int IdTipoMoneda, decimal TasaCambio, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_RegistraTipoCambio", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Fecha", Fecha);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdMoneda", IdTipoMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TasaCambio", TasaCambio);

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
        public bool RegistraDeposito(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string NumeroDepositoBanco
                                    , string TipoMoneda, decimal Monto, DateTime FechaDeposito, int IdEntidadFinanciera, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_RegistraDeposito", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDepositoBanco", NumeroDepositoBanco);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoMoneda", TipoMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Monto", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaDeposito", FechaDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdEntidadFinanciera", IdEntidadFinanciera);

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
        public bool ModificaDeposito(int iIdConexion, string cOperacion, int IdDeposito, int IdDeuda, string NumeroDepositoBanco
                                    , int IdMonedaDeposito, decimal MontoDeposito, DateTime FechaDeposito, int IdEntidadFinanciera, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_ModificaDeposito", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeposito", IdDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDepositoBanco", NumeroDepositoBanco);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdMonedaDeposito", IdMonedaDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoDeposito", MontoDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaDeposito", FechaDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdCuenta", IdEntidadFinanciera);

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
        public bool ModificaDeuda(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string NumeroLiquidacion, int IdOficina
                                  , int IdTipoMoneda, decimal Monto, DateTime FechaCambio, int IdTipoDeuda, int Cuotas, bool Descuento
                                  , decimal Porcentaje, decimal MontoDescuento, decimal MontoDeposito, string PeriodoInicio
                                  , string PeridoFinal, string Observaciones, int IdEstadoDeuda, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_ModificaDeuda", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroLiquidacion", NumeroLiquidacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdOficina", IdOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoMoneda", IdTipoMoneda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoDeuda", Monto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaTipoCambio", FechaCambio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoDeuda", IdTipoDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroCuotas", Cuotas);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@AplicaDescuento", Descuento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PorcentajeDescuento", Porcentaje);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoFijoDescuento", MontoDescuento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@MontoFijoDeposito", MontoDeposito);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoInicioDeduda", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PeriodoFinDeduda", PeridoFinal);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observaciones", Observaciones);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdEstadoDeuda", IdEstadoDeuda);

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
        public bool ModificaDocDeuda(int iIdConexion, string cOperacion, int IdDeuda, int IdDocumento, Int64 NUP, int IdTipoDocumento, string NumeroDocumento
                                        , DateTime FechaDocumento, string ReferenciaDocumento, string Observaciones, string Tipo, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_ModificaDocDeuda", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdTipoDocumentoDeuda", IdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NumeroDocumento", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaDocumento", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ReferenciaDocumento", ReferenciaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Observaciones", Observaciones);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);

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

        public bool ActualizaEstados(int iIdConexion, string cOperacion, int parte, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_ModificaEstados", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Parte", parte);

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

        public bool EliminaConvenio(int iIdConexion, string cOperacion, int IdDeuda, string justificacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_EliminaConvenio", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Justificacion", justificacion);

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

        public bool Pagos(int iIdConexion, string cOperacion, string Periodo,string TipoDeuda, Int64 NUP, string FechaInicio, string FechaFin, int ID, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_PagosPendientes", cOperacion);

            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Periodo", Periodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@TipoDeuda", TipoDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDeuda", ID);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaInicio", FechaInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@FechaFin", FechaFin);

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
        public bool ModificaDatosPersona(int iIdConexion, string cOperacion, Int64 NUP, string Direccion, string Celular, string CelularReferencia, string Telefono, string IdDocumentoExpedido, int IdLocalidad, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Convenio.PR_ModificaDatosPersona", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Direccion", Direccion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Celular", Celular);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CelularReferencia", CelularReferencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Telefono", Telefono);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdDocumentoExpedido", IdDocumentoExpedido);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@IdLocalidad", IdLocalidad);

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
    }
}