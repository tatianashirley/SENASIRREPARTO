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
    public class clsControlEnvios
    {
        clsControlEnvioDA envio = new clsControlEnvioDA();
        //Inserta registro de envio en ControlEnvioCC
        //public Boolean RegistraEnvio(string IdEntidad, string IdEnvio, string Periodo, int NumeroEnvio, string IdEstado
        //                                , string CodigoSeguridad, string RutaEnvio, int CantidadRegistros)
        //{
        //    clsControlEnvioDA ins = new clsControlEnvioDA();
        //    return ins.RegistraEnvioCC(IdEntidad, IdEnvio, Periodo, NumeroEnvio, IdEstado, CodigoSeguridad, RutaEnvio
        //                                , CantidadRegistros);
        //}

        //Actualiza estado del envio en ControlEnvioCC
        //public Boolean ModificaEnvio(string Entidad, string TipoMedio, string Periodo, int NumeroEnvio, string Estado
        //                            , string CodigoSeguridad, int CantidadRegistros)
        //{
        //    clsControlEnvioDA ins = new clsControlEnvioDA();
        //    return ins.ModificaEnvioCC(Entidad, TipoMedio, Periodo, NumeroEnvio, Estado,CodigoSeguridad, CantidadRegistros);
        //}
        //obtiene datos de envio CC
        //public DataTable ObtieneEnvio(int IdEntidad, int IdEnvio, int Periodo)
        //{
        //    DataTable dt = new DataTable();
        //    clsControlEnvioDA val = new clsControlEnvioDA();
        //    IDataReader dr = val.ObtieneEnvio(IdEntidad, IdEnvio, Periodo);
        //    dt.Load(dr);
        //    return dt;
        //}
        //obtiene el tipo de Vista seleccionado
        //public DataTable ObtieneVista(string TipoVista, string Entidad, string TipoMedio, string Periodo, string Estado, int NumeroEnvio)
        //{
        //    DataTable dt = new DataTable();
        //    clsControlEnvioDA val = new clsControlEnvioDA();
        //    IDataReader dr = val.ObtieneVistas(TipoVista, Entidad, TipoMedio, Periodo, Estado,NumeroEnvio);
        //    dt.Load(dr);
        //    return dt;
        //}
        /***********con seguridad**********************/
        public DataTable ObtieneVista(int iIdConexion, string cOperacion, string TipoVista, string Entidad, string TipoMedio, string Periodo
                                        , string Estado, int NumeroEnvio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (envio.ObtieneVistas(iIdConexion, cOperacion, TipoVista, Entidad, TipoMedio, Periodo, Estado, NumeroEnvio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool RegistraEnvio(int iIdConexion, string cOperacion, string IdEntidad, string IdEnvio, string Periodo, int NumeroEnvio
                                , string IdEstado, string CodigoSeguridad, string RutaEnvio, int CantidadRegistros, ref string sMensajeError)
        {
            bool Respuesta = envio.RegistraEnvioCC(iIdConexion, cOperacion, IdEntidad, IdEnvio, Periodo, NumeroEnvio, IdEstado, CodigoSeguridad
                                                    , RutaEnvio, CantidadRegistros, ref sMensajeError);
            return (Respuesta);
        }

        public bool ModificaEnvio(int iIdConexion, string cOperacion, string Entidad, string TipoMedio, string Periodo, int NumeroEnvio
                                    , string Estado, string CodigoSeguridad, int CantidadRegistros, ref string sMensajeError)
        {
            bool Respuesta = envio.ModificaEnvioCC(iIdConexion, cOperacion, Entidad, TipoMedio, Periodo, NumeroEnvio, Estado, CodigoSeguridad
                                                    , CantidadRegistros, ref sMensajeError);
            return (Respuesta);
        }
    }
}