using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsAsignacion : clsAsignacionBE
    {
        clsAsignacionDA objAsignacion = new clsAsignacionDA();

        //Obtener datos asignacion
        public bool Obtener()
        {
            objAsignacion.iIdConexion = this.iIdConexion;
            objAsignacion.cOperacion = this.cOperacion;
            objAsignacion.IdTramite = this.IdTramite;
            objAsignacion.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objAsignacion.TipoConsulta = this.TipoConsulta;
            objAsignacion.IdUsuarioDestino = this.IdUsuarioDestino;
            objAsignacion.IdGrupoTramite = this.IdGrupoTramite;
            this.sRespuesta = objAsignacion.Obtener();
            this.sMensajeError = objAsignacion.sMensajeError;
            this.DSetTmp = objAsignacion.DSetTmp;
            return (this.sRespuesta);
        }

        //Registrar datos asignacion
        public bool Registrar()
        {
            objAsignacion.iIdConexion = this.iIdConexion;
            objAsignacion.cOperacion = this.cOperacion;
            objAsignacion.IdTramite = this.IdTramite;
            objAsignacion.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objAsignacion.IdAreaDestino = this.IdAreaDestino;
            objAsignacion.IdAreaOrigen = this.IdAreaOrigen;
            objAsignacion.IdUsuarioDestino = this.IdUsuarioDestino;
            objAsignacion.IdUsuarioOrigen = this.IdUsuarioOrigen;
            objAsignacion.Observacion = this.Observacion;
            objAsignacion.IdGrupoTramite= this.IdGrupoTramite;            
            this.sRespuesta = objAsignacion.Registrar();
            this.sMensajeError = objAsignacion.sMensajeError;
            this.IdGrupoTramite = objAsignacion.IdGrupoTramite;
            return (this.sRespuesta);
        }

        //Actualizar datos asignacion
        public bool Actualizar()
        {
            objAsignacion.iIdConexion = this.iIdConexion;
            objAsignacion.cOperacion = this.cOperacion;
            objAsignacion.IdTramite = this.IdTramite;
            objAsignacion.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objAsignacion.IdUsuarioDestino = this.IdUsuarioDestino;
            objAsignacion.IdGrupoTramite = this.IdGrupoTramite;
            this.sRespuesta = objAsignacion.Actualizar();
            this.sMensajeError = objAsignacion.sMensajeError;
            this.IdGrupoTramite = objAsignacion.IdGrupoTramite;
            return (this.sRespuesta);
        }
    }
}