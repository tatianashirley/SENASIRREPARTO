using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using wcfConvenios.Datos;

namespace wcfConvenios.Logica
{
    public class clsInformacionLO
    {
        clsInformacionDA Convenio = new clsInformacionDA();
        public DataTable ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1
                                , string Nombre2, string NumeroDocumento, string Matricula, string CUA, Int64 NUP, int ID, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Convenio.ObtieneDatos(iIdConexion, cOperacion, Tipo, Paterno, Materno, Nombre1, Nombre2, NumeroDocumento, Matricula, CUA, NUP, ID
                                        , ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ActualizaEstados(int iIdConexion, string cOperacion, int parte, ref string sMensajeError)
        {
            bool Respuesta = Convenio.ActualizaEstados(iIdConexion, cOperacion, parte, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraDeuda(int iIdConexion, string cOperacion, Int64 NUP, string GrupoBeneficio, string Beneficio, string Sector
                                  , string NumeroLiquidacion, string Oficina, string Moneda, decimal Monto, DateTime FechaCambio
                                  , string TipoDeuda, int Cuotas, bool Descuento, decimal Porcentaje, decimal MontoDescuento, decimal MontoDeposito
                                  , string PeriodoInicio, string PeridoFinal, string Observaciones, string EstadoDeuda, ref int IdDeuda, ref string sMensajeError)
        {
            bool Respuesta = Convenio.RegistraDeuda(iIdConexion, cOperacion, NUP, GrupoBeneficio, Beneficio, Sector, NumeroLiquidacion
                                    , Oficina, Moneda, Monto, FechaCambio, TipoDeuda, Cuotas, Descuento, Porcentaje, MontoDescuento, MontoDeposito
                                    , PeriodoInicio, PeridoFinal, Observaciones, EstadoDeuda, ref IdDeuda, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraDocumento(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string TipoDocumento, string NumeroDocumento
                                        , DateTime FechaDocumento, string ReferenciaDocumento, string Observaciones, ref string sMensajeError)
        {
            bool Respuesta = Convenio.RegistraDocumento(iIdConexion, cOperacion, IdDeuda, NUP, TipoDocumento, NumeroDocumento
                                        , FechaDocumento, ReferenciaDocumento, Observaciones, ref sMensajeError);
            return (Respuesta);
        }
        public bool RegistraCuotaPlan(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, int IdCuota, string TipoRecuperacion
                          , string Periodo, decimal MontoDebe, decimal MontoHaber, decimal Porcentaje, bool Ejecutado, ref string sMensajeError)
        {
            bool Respuesta = Convenio.RegistraCuotaPlan(iIdConexion, cOperacion, IdDeuda, NUP, IdCuota, TipoRecuperacion
                                        , Periodo, MontoDebe, MontoHaber, Porcentaje, Ejecutado, ref sMensajeError);
            return (Respuesta);
        }
        public bool ModificaCuotaPlan(int iIdConexion, string cOperacion, string Tipo, int IdDeuda, int IdCuota, string TipoRecuperacion
                          , string Periodo, decimal MontoDebe, decimal MontoHaber, decimal Porcentaje, bool Ejecutado, ref string sMensajeError)
        {
            bool Respuesta = Convenio.ModificaCuotaPlan(iIdConexion, cOperacion, Tipo, IdDeuda, IdCuota, TipoRecuperacion, Periodo
                                                        , MontoDebe, MontoHaber, Porcentaje, Ejecutado, ref sMensajeError);
            return (Respuesta);
        }
        public bool RegistraTipoCambio(int iIdConexion, string cOperacion,/*DateTime*/ string Fecha, int IdTipoMoneda, decimal TasaCambio, ref string sMensajeError)
        {
            bool Respuesta = Convenio.RegistraTipoCambio(iIdConexion, cOperacion, Fecha, IdTipoMoneda, TasaCambio, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraDeposito(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string NumeroDepositoBanco
                                  , string TipoMoneda, decimal Monto, DateTime FechaDeposito, int IdEntidadFinanciera, ref string sMensajeError)
        {
            bool Respuesta = Convenio.RegistraDeposito(iIdConexion, cOperacion, IdDeuda, NUP, NumeroDepositoBanco, TipoMoneda, Monto
                                                        , FechaDeposito, IdEntidadFinanciera, ref sMensajeError);
            return (Respuesta);
        }
        public bool ModificaDeposito(int iIdConexion, string cOperacion, int IdDeposito, int IdDeuda, string NumeroDepositoBanco
                                    , int IdMonedaDeposito, decimal MontoDeposito, DateTime FechaDeposito, int IdEntidadFinanciera
                                    , ref string sMensajeError)
        {
            bool Respuesta = Convenio.ModificaDeposito(iIdConexion, cOperacion, IdDeposito, IdDeuda, NumeroDepositoBanco, IdMonedaDeposito
                                                       , MontoDeposito, FechaDeposito, IdEntidadFinanciera, ref sMensajeError);
            return (Respuesta);
        }
        public bool ModificaDeuda(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string NumeroLiquidacion, int IdOficina
                                  , int IdTipoMoneda, decimal Monto, DateTime FechaCambio, int IdTipoDeuda, int Cuotas, bool Descuento
                                  , decimal Porcentaje, decimal MontoDescuento, decimal MontoDeposito, string PeriodoInicio
                                  , string PeridoFinal, string Observaciones, int IdEstadoDeuda, ref string sMensajeError)
        {
            bool Respuesta = Convenio.ModificaDeuda(iIdConexion, cOperacion, IdDeuda, NUP, NumeroLiquidacion, IdOficina, IdTipoMoneda
                                                        , Monto, FechaCambio, IdTipoDeuda, Cuotas, Descuento, Porcentaje, MontoDescuento
                                                        , MontoDeposito, PeriodoInicio, PeridoFinal, Observaciones, IdEstadoDeuda
                                                        , ref sMensajeError);
            return (Respuesta);
        }
        public bool ModificaDocDeuda(int iIdConexion, string cOperacion, int IdDeuda, int IdDocumento, Int64 NUP, int IdTipoDocumento
                                    , string NumeroDocumento, DateTime FechaDocumento, string ReferenciaDocumento, string Observaciones
                                    , string Tipo, ref string sMensajeError)
        {
            bool Respuesta = Convenio.ModificaDocDeuda(iIdConexion, cOperacion, IdDeuda, IdDocumento, NUP, IdTipoDocumento, NumeroDocumento
                                                        , FechaDocumento, ReferenciaDocumento, Observaciones, Tipo, ref sMensajeError);
            return (Respuesta);
        }

        public bool EliminaConvenio(int iIdConexion, string cOperacion, int IdDeuda, string justificacion,ref string sMensajeError)
        {
            bool Respuesta = Convenio.EliminaConvenio(iIdConexion, cOperacion, IdDeuda, justificacion, ref sMensajeError);
            return (Respuesta);
        }

        public DataTable Pagos(int iIdConexion, string cOperacion, string Periodo,string TipoDeuda ,Int64 NUP, string FechaInicio, string FechaFin, int ID, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Convenio.Pagos(iIdConexion, cOperacion, Periodo, TipoDeuda, NUP, FechaInicio, FechaFin, ID, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ModificaDatosPersona(int iIdConexion, string cOperacion, Int64 NUP, string Direccion, string Celular, string CelularReferencia, string Telefono, string IdDocumentoExpedido, int IdLocalidad, ref string sMensajeError)   
       {
           bool Respuesta = Convenio.ModificaDatosPersona(iIdConexion, cOperacion, NUP, Direccion, Celular, CelularReferencia, Telefono, IdDocumentoExpedido, IdLocalidad, ref sMensajeError);
           return (Respuesta);
       }
		
    }
}