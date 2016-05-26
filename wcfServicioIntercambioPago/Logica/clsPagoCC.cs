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
using wcfServicioIntercambioPago.Datos;
using wcfServicioIntercambioPago.Entidades;

namespace wcfServicioIntercambioPago.Logica
{
    public class clsPagoCC
    {
        //dispara el proceso de revision basica ya en la temporales, devuelve tabla errores
        clsPagoCCDA PagosDA = new clsPagoCCDA();

        public DataTable Prevalida(string IdEntidad, string Periodo, string CodigoMedio, int NumeroEnvio, bool Continuo)
        {
            DataTable dt = new DataTable();
            clsPagoCCDA val = new clsPagoCCDA();
            IDataReader dr = val.Prevalida(IdEntidad, Periodo, CodigoMedio,NumeroEnvio,Continuo);
            dt.Load(dr);
            return dt;
        }
        //Obtiene datos segun el parametro Tipo
        //public DataTable ObtieneDatos(string Tipo, string Paterno, string Materno, string Nombre1, string Nombre2, string NumeroDocumento
        //                                , string Matricula, string CUA, Int64 NUP)
        //{
        //    DataTable dt = new DataTable();
        //    clsPagoCCDA val = new clsPagoCCDA();
        //    IDataReader dr = val.ObtieneDatos(Tipo,Paterno, Materno, Nombre1, Nombre2, NumeroDocumento, Matricula, CUA,NUP);
        //    dt.Load(dr);
        //    return dt;
        //}
        //Registra una excepción
        //public Boolean RegistraExcepcion(string CodigoError, Int64 NUP, Int64 IDHT, string Justificacion, string PeriodoInicio
        //                                , string PeriodoFinal)
        //{
        //    clsPagoCCDA ins = new clsPagoCCDA();
        //    return ins.RegistraExcepcion(CodigoError, NUP, IDHT, Justificacion, PeriodoInicio, PeriodoFinal);
        //}
        //Modifica o Desactiva una excepción
        //public Boolean ModificaExcepcion(string Tipo, int IdExcepcion, string CodigoError, string Justificacion, string PeriodoInicio
        //                                , string PeriodoFinal)
        //{
        //    clsPagoCCDA ins = new clsPagoCCDA();
        //    return ins.ModificaExcepcion(Tipo, IdExcepcion, CodigoError, Justificacion, PeriodoInicio, PeriodoFinal);
        //}
        //ejecuta la validacion central
        public DataTable ValidacionCentral(string TipoMedio, string Entidad, string Periodo, Int32 NumeroEnvio, bool Continuo)
        {
            DataTable dt = new DataTable();
            clsPagoCCDA val = new clsPagoCCDA();
            IDataReader dr = val.ValidacionCentral(TipoMedio, Entidad, Periodo, NumeroEnvio,Continuo);
            dt.Load(dr);
            return dt;
        }
        //Modifica o Desactiva una excepción
        public void CambiarEstadoRevision(string TipoMedio, Int64 CUA, int NumeroCertificado, string TipoCC, Int64 NumeroDocumento
                                            , string PeriodoPlanilla, string FechaInicio, int CodigoTransaccion, string Revision, decimal Monto)
        {
            clsPagoCCDA ins = new clsPagoCCDA();
            ins.CambiarEstadoRevision(TipoMedio, CUA, NumeroCertificado,TipoCC, NumeroDocumento, PeriodoPlanilla, FechaInicio, CodigoTransaccion, Revision,Monto);
        }
        //identifica las tran de convenio y las inserta en TPagosCC
        public Boolean GeneraConvenio(string TipoMedio, string Entidad)
        {
            clsPagoCCDA ins = new clsPagoCCDA();
            return ins.GeneraConvenios(TipoMedio,Entidad);
        }

        //analisa los medios finales PR,PF luego CR,CF,CT
        public DataTable RevisaMediosFinales(string TipoMedio, string Entidad)
        {
            DataTable dt = new DataTable();
            clsPagoCCDA val = new clsPagoCCDA();
            IDataReader dr = val.RevisaMediosFinales(TipoMedio, Entidad);
            dt.Load(dr);
            return dt;
        }

        public void GeneraConvenios(string Entidad)
        {
            clsPagoCCDA ins = new clsPagoCCDA();
            ins.GenerarConvenios(Entidad);
        }

        /****************CON SEGURIDAD*********************/
        public DataTable ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1
                                , string Nombre2, string NumeroDocumento, string Matricula, string CUA, Int64 NUP, string TipoCC, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (PagosDA.ObtieneDatos(iIdConexion, cOperacion, Tipo, Paterno, Materno, Nombre1, Nombre2, NumeroDocumento, Matricula, CUA, NUP
                                        , ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ModificaExcepcion(int iIdConexion, string cOperacion, string Tipo, int IdExcepcion, string CodigoError, string Justificacion
                                        , string PeriodoInicio, string PeriodoFinal, ref string sMensajeError)
        {
            bool Respuesta = PagosDA.ModificaExcepcion(iIdConexion, cOperacion, Tipo, IdExcepcion, CodigoError, Justificacion, PeriodoInicio
                                                        , PeriodoFinal, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraExcepcion(int iIdConexion, string cOperacion, string CodigoError, Int64 NUP, Int64 IDHT, string Justificacion
                                        , string PeriodoInicio, string PeriodoFinal, ref string sMensajeError)
        {
            bool Respuesta = PagosDA.RegistraExcepcion(iIdConexion, cOperacion, CodigoError, NUP, IDHT, Justificacion, PeriodoInicio
                                                        , PeriodoFinal, ref sMensajeError);
            return (Respuesta);
        }

        public DataTable ForzarError(int iIdConexion, string cOperacion, Int64 CUA, int NumeroCertificado, Int64 NumeroDocumento, int Transaccion
                                , string PeriodoPlanilla, string FechaInicio, string CodigoError, string Entidad, string TipoMedio
                                , string Periodo, int NumeroEnvio, string TipoCC, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (PagosDA.ForzarError(iIdConexion, cOperacion, CUA, NumeroCertificado, NumeroDocumento, Transaccion, PeriodoPlanilla, FechaInicio
                                                        , CodigoError, Entidad, TipoMedio, Periodo, NumeroEnvio, TipoCC, ref sMensajeError,ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }

            
        }

       /* public bool Consolida(int iIdConexion, string cOperacion,string TipoProceso,string Entidad, string Periodo,ref string sMensajeError)
        {
            bool Respuesta=false;
            //consolida todo el tipo de proceso
            try
            {
                if (TipoProceso == "P")
                {
                    Respuesta = PagosDA.ConsolidaTitulares(iIdConexion, cOperacion, "ATR", Entidad, ref sMensajeError);
                    Respuesta = PagosDA.ConsolidaTitulares(iIdConexion, cOperacion, "ATF", Entidad, ref sMensajeError);
                    Respuesta = PagosDA.ConsolidaBeneficiarios(iIdConexion, cOperacion, "ABR", Entidad, ref sMensajeError);
                    Respuesta = PagosDA.ConsolidaBeneficiarios(iIdConexion, cOperacion, "ABF", Entidad, ref sMensajeError);
                    string planilla = "";
                    for (int x = 0; x < 6; x++)
                    {
                        if (x == 0) planilla = "A";
                        if (x == 1) planilla = "B";
                        if (x == 2) planilla = "C";
                        if (x == 3) planilla = "D";
                        if (x == 4) planilla = "E";
                        if (x == 5) planilla = "F";
                        Respuesta = PagosDA.ConsolidaPagos(iIdConexion, cOperacion, "PR", Entidad, planilla, Periodo, ref sMensajeError);
                    }
                    planilla = "";
                    for (int x = 0; x < 6; x++)
                    {
                        if (x == 0) planilla = "A";
                        if (x == 1) planilla = "B";
                        if (x == 2) planilla = "C";
                        if (x == 3) planilla = "D";
                        if (x == 4) planilla = "E";
                        if (x == 5) planilla = "F";
                        Respuesta = PagosDA.ConsolidaPagos(iIdConexion, cOperacion, "PF", Entidad, planilla, Periodo, ref sMensajeError);
                    }
                }
                if (TipoProceso == "C")
                {
                    string planilla = "";
                    for (int x = 0; x < 6; x++)
                    {
                        if (x == 0) planilla = "A";
                        if (x == 1) planilla = "B";
                        if (x == 2) planilla = "C";
                        if (x == 3) planilla = "D";
                        if (x == 4) planilla = "E";
                        if (x == 5) planilla = "F";
                        Respuesta = PagosDA.ConsolidaConciliaciones(iIdConexion, cOperacion, "CR", Entidad, planilla, Periodo, ref sMensajeError);
                    }
                    planilla = "";
                    for (int x = 0; x < 6; x++)
                    {
                        if (x == 0) planilla = "A";
                        if (x == 1) planilla = "B";
                        if (x == 2) planilla = "C";
                        if (x == 3) planilla = "D";
                        if (x == 4) planilla = "E";
                        if (x == 5) planilla = "F";
                        Respuesta = PagosDA.ConsolidaConciliaciones(iIdConexion, cOperacion, "CF", Entidad, planilla, Periodo, ref sMensajeError);
                    }
                }
            }
            catch
            {
                //tratar de rollback toda la transaccion
                Respuesta = false;
            }

            //if (TipoMedio == "ATR" || TipoMedio == "ATF")
            //{
            //    Respuesta = PagosDA.ConsolidaTitulares(iIdConexion, cOperacion, TipoMedio, Entidad, ref sMensajeError);
            //}
            //if (TipoMedio == "ABR" || TipoMedio == "ABF")
            //{
            //    Respuesta = PagosDA.ConsolidaBeneficiarios(iIdConexion, cOperacion, TipoMedio, Entidad, ref sMensajeError);
            //}
            //if (TipoMedio == "PR" || TipoMedio == "PF")
            //{
            //    string planilla="";
            //    for (int x = 0; x < 6; x++)
            //    {
            //        if (x == 0) planilla = "A";
            //        if (x == 1) planilla = "B";
            //        if (x == 2) planilla = "C";
            //        if (x == 3) planilla = "D";
            //        if (x == 4) planilla = "E";
            //        if (x == 5) planilla = "F";
            //        Respuesta = PagosDA.ConsolidaPagos(iIdConexion, cOperacion, TipoMedio, Entidad, planilla, ref sMensajeError);
            //    }
            //}
            return (Respuesta);
        }*/
        public bool Consolida(int iIdConexion, string cOperacion, string TipoProceso, string Entidad, string Periodo
                                , ref string sMensajeError)
        {
            bool Respuesta = PagosDA.ConsolidaProceso(iIdConexion, cOperacion, TipoProceso, Entidad, Periodo, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraFormC31(int iIdConexion, string cOperacion, string Entidad, string Periodo, int FormC31
                                    , string Anio, string Mes, int IdFinanciera, int IdGrupoBeneficio, int IdBeneficio
                                    ,decimal Monto, string Observaciones, ref string sMensajeError)
        {
            bool Respuesta = PagosDA.RegistraFormC31(iIdConexion, cOperacion, Entidad, Periodo, FormC31, Anio, Mes
                                        , IdFinanciera, IdGrupoBeneficio, IdBeneficio, Monto, Observaciones, ref sMensajeError);
            return (Respuesta);
        }
        public bool ModificaFormC31(int iIdConexion, string cOperacion, string Entidad, string Periodo, int FormC31
                                    , string Anio, string Mes, int IdFinanciera, decimal Monto, string Observaciones
                                    , ref string sMensajeError)
        {
            bool Respuesta = PagosDA.ModificaFormC31(iIdConexion, cOperacion, Entidad, Periodo, FormC31
                                    , Anio, Mes, IdFinanciera, Monto, Observaciones, ref sMensajeError);
            return (Respuesta);
        }

        public bool RegistraIncremento(int iIdConexion, string cOperacion, int Gestion, int IdTipoCC, decimal MontoInferior
                                        , decimal MontoSuperior, decimal Incremento, decimal Porcentaje, ref string sMensajeError)
        {
            bool Respuesta = PagosDA.RegistraIncremento(iIdConexion, cOperacion,Gestion,IdTipoCC,MontoInferior,MontoSuperior
                                                        ,Incremento,Porcentaje, ref sMensajeError);
            return (Respuesta);
        }
        public bool ModificaIncremento(int iIdConexion, string cOperacion, string Tipo, int Gestion, int IdIntervalo, int IdTipoCC, decimal MontoInferior
                                        , decimal MontoSuperior, decimal Incremento, decimal Porcentaje, ref string sMensajeError)
        {
            bool Respuesta = PagosDA.ModificaIncremento(iIdConexion, cOperacion,Tipo,Gestion,IdIntervalo,IdTipoCC,MontoInferior
                                                        ,MontoSuperior,Incremento,Porcentaje, ref sMensajeError);
            return (Respuesta);
        }
    }
}