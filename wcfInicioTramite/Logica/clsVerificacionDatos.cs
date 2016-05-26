using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsVerificacionDatos : clsVerificacionDatosBE
    {
        clsVerificacionDatosDA objVerificacionDatosDA = new clsVerificacionDatosDA();

        //Registrar Salario Cotizable
        public bool Registrar()
        {
            objVerificacionDatosDA.iIdConexion = this.iIdConexion;
            objVerificacionDatosDA.cOperacion = this.cOperacion;
            objVerificacionDatosDA.IdTramite = this.IdTramite;
            objVerificacionDatosDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objVerificacionDatosDA.IdTipoInconsistencia = this.IdTipoInconsistencia;
            objVerificacionDatosDA.Observacion = this.Observacion;
            this.sRespuesta = objVerificacionDatosDA.Registrar();
            this.sMensajeError = objVerificacionDatosDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}