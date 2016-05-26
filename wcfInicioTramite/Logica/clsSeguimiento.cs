using System;
using System.Data;
using wcfInicioTramite.Entidades;
using wcfInicioTramite.Tramite.Datos;


namespace wcfInicioTramite.Logica
{
    public class clsSeguimiento : clsSeguimientoTramiteBE
    {
        clsSeguimientoTramiteDA ObjTramiteDA = new clsSeguimientoTramiteDA();
        
        //Actualizar observaciones
        public bool ActualizarObservaciones()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            ObjTramiteDA.TipoConsulta = this.TipoConsulta;
            ObjTramiteDA.Observaciones = this.Observaciones;
            this.sRespuesta = ObjTramiteDA.ActualizarObservaciones();
            this.sMensajeError = ObjTramiteDA.sMensajeError;
            return sRespuesta;
        }
    }
}