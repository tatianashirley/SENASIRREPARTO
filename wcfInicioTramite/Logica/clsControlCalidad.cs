using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsControlCalidad : clsControlCalidadBE
    {
        clsControlCalidadDA ObjControlCalidadDA = new clsControlCalidadDA();

        //Registrar Control de Calidad
        public bool Registrar()
        {
            ObjControlCalidadDA.iIdConexion = this.iIdConexion;
            ObjControlCalidadDA.cOperacion = this.cOperacion;
            ObjControlCalidadDA.IdTramite = this.IdTramite;
            ObjControlCalidadDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            ObjControlCalidadDA.IdEstado = this.IdEstado;
            ObjControlCalidadDA.Observacion = this.Observacion;
            this.sRespuesta = ObjControlCalidadDA.Registrar();
            this.sMensajeError = ObjControlCalidadDA.sMensajeError;
            return (this.sRespuesta);
        }

        //Obtener Control de Calidad
        public bool Obtener()
        {
            ObjControlCalidadDA.iIdConexion = this.iIdConexion;
            ObjControlCalidadDA.cOperacion = this.cOperacion;
            ObjControlCalidadDA.IdTramite = this.IdTramite;
            ObjControlCalidadDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            this.sRespuesta = ObjControlCalidadDA.Obtener();
            this.IdEstado = ObjControlCalidadDA.IdEstado;
            this.sMensajeError = ObjControlCalidadDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}