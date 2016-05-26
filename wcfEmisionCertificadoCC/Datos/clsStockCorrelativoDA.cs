using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Linq;
using System.Data.Common;
using System.Web;
using wcfEmisionCertificadoCC.Entidades;
using SQLSPExecuter;
namespace wcfEmisionCertificadoCC.Datos
{
    public class clsStockCorrelativoDA
    {
        Database db = null;
        public clsStockCorrelativoDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        //obtiene los tipos de certificados 02-06-2015
        public bool ListaCertificados(int iIdConexion, string cOperacion,ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
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

        //obtiene los bloques de correlativos 02-06-2015
        public bool ListaStockCorrelativos(int iIdConexion, string cOperacion, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
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

        //obtiene datos de un Stock en especifico 02-06-2015
        public bool ObtenerStockCorrelativos(int iIdConexion, string cOperacion,Int32 Lote,ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PartidaLote", Lote);
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

        //Adiciona registro nuevo 02-06-2015
        public bool AdicionarStockCorrelativos(int iIdConexion, string cOperacion,  Int32 IdTipoCertificado, Int32 Cantidad, string  Observacion,ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@idtipocertificado", IdTipoCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@cantidad", Cantidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@obs", Observacion);
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

        //obtiene datos de Stock para verificacion 02-06-2015
        public bool VerificarStockAsignaciones(int iIdConexion, string cOperacion,Int32 IdTipoCertificado, Int32 NumeroInicial, Int32 NumeroFinal, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@idtipocertificado", IdTipoCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@numini", NumeroInicial);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@numfin", NumeroFinal);
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

        //verifica si es el ultimo stock de correlativos 03-06-2015
        public bool VerificarUltimoStockCorrelativos(int iIdConexion, string cOperacion, Int32 partida, Int32 IdTipoCertificado, Int32 cantidad, ref string sMensajeError, ref DataSet DSetTmp)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@idtipocertificado", IdTipoCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PartidaLote", partida);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@cantidad", cantidad);
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

        //Modifica el ultimo Stock Correlativos 03-06-2015
        public bool ModificaStockCorrelativos(int iIdConexion, string cOperacion, Int32 PartidaLote, Int32 IdTipoCertificado, Int32 NumeroInicial, Int32 Cantidad, string Observacion, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PartidaLote", PartidaLote);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@idtipocertificado", IdTipoCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@numini", NumeroInicial);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@cantidad", Cantidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@obs", Observacion);
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

        //Eliminacion logica del Ultimo Stock de Correlativo 03-06-2015
        public bool EliminaStockCorrelativos(int iIdConexion, string cOperacion, Int32 PartidaLote, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EmisionCC.PR_CorrelativosCertificadosCC", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@PartidaLote", PartidaLote);

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

        /* Adiciona un StockCorrelativo */ //PARA BORRAR
        public void AdicionarStockCorrelativo( int IdTipoCertificado, int Cantidad, string  Observacion ,  int RegistroActivo)
        {
            //string fec = Convert.ToString(FechaResolucion);
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCAdicionar",  IdTipoCertificado, Cantidad, Observacion, RegistroActivo); 
            db.ExecuteNonQuery(cmd);
        }
        /* Elimina logicamente un StockCorrelativo */
        public Boolean EliminarStockCorrelativo(int PartidaLote)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCEliminar", PartidaLote);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /* Modificar un StockCorrelativo */
        public void ModificarStockCorrelativo(int PartidaLote, int IdTipoCertificado, int NumeroInicial, int Cantidad, string Observacion, int RegistroActivo)
        {
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCModificar", PartidaLote, IdTipoCertificado, NumeroInicial, Cantidad, Observacion, RegistroActivo);
            db.ExecuteNonQuery(cmd);
        }
        /* ListaStockCorrelativo */ //PARA BORRAR 
        public IDataReader ListarStockCorrelativo()
        {
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCListar");
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

     
        /* ListaStock certificados*/
        public IDataReader ListarStockCertificados()//PARA BORRAR
        {
            DbCommand cmd = db.GetStoredProcCommand("EmisionCC.PR_TipoCertificadoListar");
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        /* Verificar StockCorrelativo*/
        public IDataReader VerificarStockCorrelativo(int IdTipoCertificado, int NumeroInicial)
           {
             //  string fec = Convert.ToString(Fecha);
               
               //string fec1 = fec.Substring(1, 10);
               DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCVerificar", IdTipoCertificado,  NumeroInicial);
               IDataReader dataReader = db.ExecuteReader(dbCommand);
               return dataReader;
           }
        
       /* Verificar que sea el ultimo registro de StockCorrelativo*/
        public IDataReader VerificarultimoStockCorrelativo(int partida,int IdTipoCertificado, int cantidad) //PARA BORRAR
           {
             //  string fec = Convert.ToString(Fecha);
               
               //string fec1 = fec.Substring(1, 10);
               DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCVerificarultimo", partida,IdTipoCertificado,  cantidad);
               IDataReader dataReader = db.ExecuteReader(dbCommand);
               return dataReader;
           }


        public IDataReader VerificarAsignacionStockCorrelativo(int IdTipoCertificado, int NumeroInicial, int NumeroFinal)//PARA BORRAR
           {
               DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCVerificarAsignaciones", IdTipoCertificado, NumeroInicial, NumeroFinal);
               IDataReader dataReader = db.ExecuteReader(dbCommand);
               return dataReader;
           }
        /* Verificar Correlativos de los CertificadosEmitidos*/
        public IDataReader VerificarCorrelativosCertificadosEmitidos()
           {

               DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCVerificarCantidad");
               IDataReader dataReader = db.ExecuteReader(dbCommand);
               return dataReader;
           }
        public IDataReader ObtenerStockCorrelativo(int Cod) //PARA BORRAR
        {
            DbCommand dbCommand = db.GetStoredProcCommand("EmisionCC.PR_CorrelativoCertificadoCCObtener", Cod);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
    }
}