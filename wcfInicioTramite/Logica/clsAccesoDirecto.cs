using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;
using wcfInicioTramite.Tramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsAccesoDirecto : clsAccesoDirectoBE
    {
        clsAccesoDirectoDA objAccesoDirecto = new clsAccesoDirectoDA();

        //Obtener Grilla Resoluciones
        public bool ObtenerResoluciones()
        {
            objAccesoDirecto.iIdConexion = this.iIdConexion;
            objAccesoDirecto.cOperacion = this.cOperacion;
            objAccesoDirecto.IdTramite = this.IdTramite;
            objAccesoDirecto.Matricula= this.Matricula;
            this.sRespuesta = objAccesoDirecto.ObtenerResoluciones();
            this.sMensajeError = objAccesoDirecto.sMensajeError;
            this.DSetTmp = objAccesoDirecto.DSetTmp;
            return (this.sRespuesta);
        }

        //Obtener Grilla Convenios
        public bool ObtenerConvenios()
        {
            objAccesoDirecto.iIdConexion = this.iIdConexion;
            objAccesoDirecto.cOperacion = this.cOperacion;
            objAccesoDirecto.IdTramite = this.IdTramite;
            objAccesoDirecto.Matricula = this.Matricula;
            this.sRespuesta = objAccesoDirecto.ObtenerConvenios();
            this.sMensajeError = objAccesoDirecto.sMensajeError;
            this.DSetTmp = objAccesoDirecto.DSetTmp;
            return (this.sRespuesta);
        }

        //Obtener datos reporte para el tramite
        public bool ObtenerDatosReporte()
        {
            objAccesoDirecto.iIdConexion = this.iIdConexion;
            objAccesoDirecto.cOperacion = this.cOperacion;
            objAccesoDirecto.IdTramite = this.IdTramite;
            objAccesoDirecto.Matricula = this.Matricula;
            objAccesoDirecto.TipoInformacion = this.TipoInformacion;
            this.sRespuesta = objAccesoDirecto.ObtenerDatosReporte();
            this.sMensajeError = objAccesoDirecto.sMensajeError;
            this.DSetTmp = objAccesoDirecto.DSetTmp;
            return (this.sRespuesta);
        }
    }
}