using System;
using System.Data;
using wcfWFArticulador.Entidades;
using wcfWFArticulador.Tramite.Datos;


namespace wcfWFArticulador.Logica
{
    public class clsSeguimientoTramite : clsSeguimientoTramiteBE
    {
        clsSeguimientoTramiteDA ObjTramiteDA = new clsSeguimientoTramiteDA();
        
        //Obtener datos del tramite
        public bool ObtenerDatosTramite()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            ObjTramiteDA.TipoConsulta = this.TipoConsulta;
            this.sRespuesta = ObjTramiteDA.ObtenerDatosTramite();
            this.sMensajeError = ObjTramiteDA.sMensajeError;
            this.DSetTmp = ObjTramiteDA.DSetTmp;    
            return sRespuesta;
        }
    }
}