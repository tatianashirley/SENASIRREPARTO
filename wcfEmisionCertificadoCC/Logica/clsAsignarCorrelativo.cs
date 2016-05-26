using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEmisionCertificadoCC.Entidades;
using wcfEmisionCertificadoCC.Datos;
using System.Data;
    

namespace wcfEmisionCertificadoCC.Logica
{
    public class clsAsignarCorrelativo: clsAsignarCorrelativoBE
    {
        // Adiciona StockCorrelativo
        clsAsignarCorrelativoDA ObjAsignacion = new clsAsignarCorrelativoDA();

        //Grilla de datos de un area o de todas a la vez
        public DataTable ListaAsignacionStockCorrelativos(int iIdConexion, string cOperacion, Int32 idOficina, Int32 Agotado, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ListaAsignacionStockCorrelativos(iIdConexion, cOperacion,idOficina,Agotado,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //// PARA BORRAR
        //public void AdicionarStockCorrelativo(int IdOficina,int IdTipoCertificado, DateTime FechaAsignacion, DateTime FechaEnvio, int Cantidad, string Observacion, int RegistroActivo)
        //{
        //    try
        //    {
        //        clsAsignarCorrelativoDA adi = new clsAsignarCorrelativoDA();
        //        adi.AdicionarStockCorrelativo(IdOficina, IdTipoCertificado, FechaAsignacion, FechaEnvio, Cantidad,  Observacion, RegistroActivo);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //Adicionar una asignacion de correlativos
        public bool AdicionarNuevaAsignacion(int iIdConexion, string cOperacion, Int32 IdOficinaArea, Int32 IdTipoTramite, DateTime FechaAsignacion, DateTime FechaEnvio, Int32 Pedido, string Observacion, ref string sMensajeError)
        {
            bool Respuesta = ObjAsignacion.AdicionarNuevaAsignacion(iIdConexion, cOperacion,IdOficinaArea, IdTipoTramite, FechaAsignacion, FechaEnvio,Pedido,Observacion, ref sMensajeError);
            return (Respuesta);
        }
        //Elimina la ultima Asignacion
        public bool EliminarAsignacionCorrelativos(int iIdConexion, string cOperacion, Int32 NumeroAsignacion, Int32 IdTipoCertificado, Int32 Cantidad, ref string sMensajeError)
        {
            bool Respuesta = ObjAsignacion.EliminarAsignacionCorrelativos(iIdConexion, cOperacion, NumeroAsignacion, IdTipoCertificado, Cantidad, ref sMensajeError);
            return (Respuesta);
        }
        //Modificacion de Asignacion de correlativos CASO 1 15-06-2015
        public bool ModificarAsignacionArea(int iIdConexion, string cOperacion, Int32 IdAsignacion, Int32 IdOficinaArea, Int32 IdTipoTramite, string FechaAsignacion, string FechaEnvio, Int32 Pedido, string Observacion, ref string sMensajeError)
        {
            bool Respuesta = ObjAsignacion.ModificarAsignacionArea(iIdConexion, cOperacion,IdAsignacion, IdOficinaArea, IdTipoTramite, FechaAsignacion, FechaEnvio, Pedido, Observacion, ref sMensajeError);
            return (Respuesta);
        }

        //Modificacion de Asignacion de correlativos CASO 2 16-06-2015
        public bool ModificarAsignacionCantMayor(int iIdConexion, string cOperacion, Int32 IdAsignacion, Int32 IdOficinaArea, Int32 IdTipoTramite, Int32 Pedido, string Observacion, ref string sMensajeError)
        {
            bool Respuesta = ObjAsignacion.ModificarAsignacionCantMayor(iIdConexion, cOperacion, IdAsignacion, IdOficinaArea, IdTipoTramite, Pedido, Observacion, ref sMensajeError);
            return (Respuesta);
        }

        //Modificacion de Asignacion de correlativos CASO 3 16-06-2015
        public bool ModificarAsignacionCantMenor(int iIdConexion, string cOperacion, Int32 IdAsignacion, Int32 IdOficinaArea, Int32 IdTipoTramite, Int32 Pedido, string Observacion, ref string sMensajeError)
        {
            bool Respuesta = ObjAsignacion.ModificarAsignacionCantMenor(iIdConexion, cOperacion, IdAsignacion, IdOficinaArea, IdTipoTramite, Pedido, Observacion, ref sMensajeError);
            return (Respuesta);
        }

        ///Obtiene si existe stock para su redistribucion 07-06-2015
        public DataTable ObtenerCantidadStockCorrelativos(int iIdConexion, string cOperacion, Int32 TipoCert, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ObtenerCantidadStockCorrelativos(iIdConexion, cOperacion, TipoCert, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Verifica si se emitio certificados de la asignacion a eliminar
        public DataTable VerificarCertificadosEmitidos(int iIdConexion, string cOperacion, Int32 IdTipoCertificado, Int32 NumeroInicial, Int32 NumeroFinal, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.VerificarCertificadosEmitidos(iIdConexion, cOperacion,IdTipoCertificado,NumeroInicial,NumeroFinal, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        //Obtiene los datos de 1 asignacion en especifico
        public DataTable ObtieneDatosAsignacion(int iIdConexion, string cOperacion, Int32 numAsig, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ObtieneDatosAsignacion(iIdConexion, cOperacion, numAsig, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Para Obtener Ultimos Numeros aplicados por regional
        public DataTable UltimoNumeroAplicadoX(int iIdConexion, string cOperacion, Int32 IdArea, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.UltimoNumeroAplicadoX(iIdConexion, cOperacion, IdArea, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene los datos de 1 asignacion en especifico
        public DataTable VerificaUltimoNumeroAsignacion(int iIdConexion, string cOperacion, Int32 IdTipoTramite, Int32 numAsignacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.VerificaUltimoNumeroAsignacion(iIdConexion, cOperacion, IdTipoTramite, numAsignacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Verifica si es la ultima Asignacion 07-06-2015
        public DataTable VerificarUltimaAsignacion(int iIdConexion, string cOperacion ,Int32 numeroasignacion, Int32 IdTipoCertificado, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.VerificarUltimaAsignacionCorrelativo(iIdConexion,cOperacion,numeroasignacion,IdTipoCertificado,ref sMensajeError,ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene los registros de asignacion vigente para emisión de certificados
        public DataTable UltimosNumerosCertificados(int iIdConexion, string cOperacion, Int64 IdTramite,Int32 IdGrupobeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.UltimosNumerosCertificados(iIdConexion, cOperacion, IdTramite, IdGrupobeneficio,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene el Numero de certificado
        public DataTable ObtenerNumeroCertificado(int IdConexion, string cOperacion, Int32 Oficina, Int32 Tipocc,Int64 iIdTramite,Int32 iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ObtenerNumeroCertificado(IdConexion, cOperacion, Oficina, Tipocc, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene el Numero de certificado X
        public DataTable ObtenerNumeroCertificadoX(int IdConexion, string cOperacion, Int32 IdArea, Int32 TipoTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ObtenerNroCertificadoX(IdConexion, cOperacion, IdArea, TipoTramite, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene el saldo de la  ultima Asignacion 16-06-2015
        public DataTable ObtenerSaldoUltimaAsignacion(int iIdConexion, string cOperacion, Int32 NumInicial, Int32 IdTipoTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ObtenerSaldoUltimaAsignacion(iIdConexion, cOperacion, NumInicial, IdTipoTramite, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //OBTIENE EL SALDO Y EL TIPO DE CERTIFICADO 03-06-2015
        public DataTable ListaSaldoCertificados(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.ListaSaldoCertificados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        //Listado de las Areas que estan habilitadas para impresion de certificados (para su distribucion de certificados)
        public DataTable AreasImpresion(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjAsignacion.AreasImpresion(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
      
     }

}
