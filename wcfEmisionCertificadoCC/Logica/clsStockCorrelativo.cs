using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEmisionCertificadoCC.Entidades;
using wcfEmisionCertificadoCC.Logica;
using wcfEmisionCertificadoCC.Datos;
using System.Data;

namespace wcfEmisionCertificadoCC.Logica
{
    public class clsStockCorrelativo: clsStockCorrelativoBE
    {
        clsStockCorrelativoDA correlativo = new clsStockCorrelativoDA();
        //Lista Tipos de Certificados manual - automatico
        public DataTable ListaCertificados(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            //correlativo.ListaCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp)
            if (correlativo.ListaCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
              return (null);
            }
        }

        //Lista bloques de stock por tipo y departamento
        public DataTable ListaStockCorrelativos(int IdConexion, string cOperacion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            //correlativo.ListaCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp)
            if (correlativo.ListaStockCorrelativos(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene datos en especifico de un Stock
        public DataTable ObtenerStockCorrelativos(int IdConexion, string cOperacion,Int32 Lote ,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            //correlativo.ListaCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp)
            if (correlativo.ObtenerStockCorrelativos(IdConexion, cOperacion,Lote ,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Verifica Stock Correlativos 02-06-2015
        public DataTable VerificarStockAsignaciones(int iIdConexion, string cOperacion, Int32 IdTipoCertificado, Int32 NumeroInicial, Int32 NumeroFinal, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            //correlativo.ListaCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp)
            if (correlativo.VerificarStockAsignaciones(iIdConexion, cOperacion, IdTipoCertificado,NumeroInicial,NumeroFinal, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Verifica ultimo Stock de Correlativos 03-06-2015
        public DataTable VerificarUltimoStockCorrelativos(int iIdConexion, string cOperacion, Int32 partida, Int32 IdTipoCertificado, Int32 cantidad, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            //correlativo.ListaCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp)
            if (correlativo.VerificarUltimoStockCorrelativos(iIdConexion, cOperacion,partida,IdTipoCertificado, cantidad, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        //Eliminacion logica del ultimo Stock Correlativos 03-06-2015
        public bool EliminarStockCorrelativos(int iIdConexion, string cOperacion, Int32 PartidaLote, ref string sMensajeError)
        {
            bool bAsignacionOK = correlativo.EliminaStockCorrelativos(iIdConexion, cOperacion,PartidaLote, ref sMensajeError);
            return (bAsignacionOK);

        }

        //Modificacion del ultimo Stock Correlativos 03-06-2015
        public bool ModificaStockCorrelativos(int iIdConexion, string cOperacion, Int32 PartidaLote, Int32 IdTipoCertificado, Int32 NumeroInicial, Int32 Cantidad, string Observacion, ref string sMensajeError)
        {
            bool bAsignacionOK = correlativo.ModificaStockCorrelativos(iIdConexion, cOperacion, PartidaLote,IdTipoCertificado,NumeroInicial,Cantidad,Observacion, ref sMensajeError);
            return (bAsignacionOK);

        }

        //Adiciona nuevo StockCorrelativo 02-06-2015
        public bool AdicionaStockCorrelativos(int iIdConexion, string cOperacion, Int32 IdTipoCertificado, Int32 Cantidad, string Observacion, ref string sMensajeError)
        {
            bool Respuesta = correlativo.AdicionarStockCorrelativos(iIdConexion, cOperacion,IdTipoCertificado,Cantidad,Observacion, ref sMensajeError);
            return (Respuesta);
        }

        // Adiciona StockCorrelativo PARA BORRAR
        public void AdicionarStockCorrelativo(int IdTipoCertificado, int Cantidad, string Observacion, int RegistroActivo)
        {
            try
            {
                clsStockCorrelativoDA adi = new clsStockCorrelativoDA();
                adi.AdicionarStockCorrelativo(IdTipoCertificado, Cantidad, Observacion, RegistroActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Elimina StockCorrelativo
        public Boolean EliminarStockCorrelativo(int PartidaLote)
        {
            clsStockCorrelativoDA eli = new clsStockCorrelativoDA();
            return eli.EliminarStockCorrelativo(PartidaLote);
        }
        // Modificar StockCorrelativo
        public void ModificarStockCorrelativo(int PartidaLote, int IdTipoCertificado, int NumeroInicial, int Cantidad, string Observacion, int RegistroActivo)
        {
            try
            {
                clsStockCorrelativoDA mod = new clsStockCorrelativoDA();
                mod.ModificarStockCorrelativo(PartidaLote, IdTipoCertificado, NumeroInicial, Cantidad, Observacion, RegistroActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Listar StockCorrelativo
        public List<clsStockCorrelativo> ListarStockCorrelativo()
        {
            clsStockCorrelativo p;
            clsStockCorrelativoDA permiso = new clsStockCorrelativoDA();
            List<clsStockCorrelativo> ListaClas = new List<clsStockCorrelativo>();
            using (IDataReader dr = permiso.ListarStockCorrelativo())
            {
                while (dr.Read())
                {
                    p = new clsStockCorrelativo();
                    p.PartidaLote = (int)dr["PartidaLote"];
                    p.Fecha = Convert.ToString((DateTime)dr["Fecha"]).Substring(0, 10);
                    //p.Fecha = (DateTime)dr["Fecha"];
                    //p.IdTipoCertificado = (int)dr["IdTipoCertificado"];
                    p.Certificado = (string)dr["DescripcionDetalleClasificador"];
                    p.NumeroInicial = (int)dr["NumeroInicial"];
                    p.NumeroFinal = (int)dr["NumeroFinal"];
                    p.Cantidad = (p.NumeroFinal - p.NumeroInicial)+1;
                    p.Saldo = (int)dr["Saldo"];
                    p.Observacion = (string)dr["Observacion"];
                    p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        // Listar StockCorrelativo   otro formulario web
        public List<clsStockCorrelativo> ListarStockCertificados() // PARA BORRAR
        {
            clsStockCorrelativo p;
            clsStockCorrelativoDA permiso = new clsStockCorrelativoDA();
            List<clsStockCorrelativo> ListaClas = new List<clsStockCorrelativo>();
            using (IDataReader dr = permiso.ListarStockCertificados())
            {
                while (dr.Read())
                {
                    p = new clsStockCorrelativo();
                  p.Certificado = (string)dr["DescripcionDetalleClasificador"];
                  p.Saldo = (int)dr["Saldo"];
             ListaClas.Add(p);
                }
            }
            return ListaClas;
        }



        // Verificar StockCorrelativo  otro formulario web
        public int VerificarStockCorrelativo(int IdTipoCertificado, int NumeroInicial)
        {
            int valor = 0;
            clsStockCorrelativoDA permiso = new clsStockCorrelativoDA();
            using (IDataReader dr = permiso.VerificarStockCorrelativo(IdTipoCertificado, NumeroInicial))
            {
                while (dr.Read())
                {
                    valor = (int)dr[existedatos];
                }
            }
            return valor;
        }
       
      public int VerificarultimoStockCorrelativo(int partida,int IdTipoCertificado, int Cantidad)
        {
            int valor = 0;
            clsStockCorrelativoDA permiso = new clsStockCorrelativoDA();
            using (IDataReader dr = permiso.VerificarultimoStockCorrelativo(partida,IdTipoCertificado, Cantidad))
            {
                while (dr.Read())
                {
                    valor = (int)dr[existedatos];
                }
            }
            return valor;
        }
           // Verificar StockCorrelativo
        public int VerificarAsignacionStockCorrelativo(int IdTipoCertificado, int NumeroInicial, int NumeroFinal)
        {
            int valor = 0;
            clsStockCorrelativoDA permiso = new clsStockCorrelativoDA();
          using (IDataReader dr = permiso.VerificarAsignacionStockCorrelativo(IdTipoCertificado, NumeroInicial, NumeroFinal))
            {
                while (dr.Read())
                {
                    valor = (int)dr[existedatos];
                }
            }
            return valor;
        }
        // Verificar Correlativos de los CertificadosEmitidos    otro formulario web
        public void VerificarCorrelativosCertificadosEmitidos()
        {
          try
            {
                clsStockCorrelativoDA ver = new clsStockCorrelativoDA();
                ver.VerificarCorrelativosCertificadosEmitidos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsStockCorrelativo> ObtenerStockCorrelativo(int Cod)
        {
            clsStockCorrelativo p;
            clsStockCorrelativoDA permiso = new clsStockCorrelativoDA();
            List<clsStockCorrelativo> ListaClas = new List<clsStockCorrelativo>();
            using (IDataReader dr = permiso.ObtenerStockCorrelativo(Cod))
            {
                while (dr.Read())
                {
                    p = new clsStockCorrelativo();
                    p.PartidaLote = (int)dr["PartidaLote"];
                    p.Fecha = Convert.ToString((DateTime)dr["Fecha"]).Substring(0, 10);
                    //p.Fecha = (DateTime)dr["Fecha"];
                    p.IdTipoCertificado = (int)dr["IdTipoCertificado"];
                    p.NumeroInicial = (int)dr["NumeroInicial"];
                    p.NumeroFinal = (int)dr["NumeroFinal"];
                    p.Cantidad = (p.NumeroFinal - p.NumeroInicial)+1;
                    p.Saldo = (int)dr["Saldo"];
                    p.Observacion = (string)dr["Observacion"];
                    p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }


    }
}