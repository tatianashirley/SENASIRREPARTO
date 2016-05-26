using wcfInicioTramite.Datos;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Logica
{
    public class clsSalario : clsSalarioBE
    {
        clsSalarioDA objSalarioDA = new clsSalarioDA();

        //Registrar Salario Cotizable
        public bool Registrar()
        {
            objSalarioDA.iIdConexion = this.iIdConexion;
            objSalarioDA.cOperacion = this.cOperacion;
            objSalarioDA.IdTramite = this.IdTramite;
            objSalarioDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            objSalarioDA.Version = this.Version;
            objSalarioDA.Ruc = this.Ruc;
            objSalarioDA.Componente = this.Componente;
            objSalarioDA.IdTipoDocSalario = this.IdTipoDocSalario;
            objSalarioDA.PeriodoSalario = this.PeriodoSalario;
            objSalarioDA.SalarioCotizable = this.SalarioCotizable;
            objSalarioDA.IdMonedaSalario = this.IdMonedaSalario;
            objSalarioDA.IdEstadoSalario = this.IdEstadoSalario;
            objSalarioDA.RegistroActivo = this.RegistroActivo;
            objSalarioDA.IdSector = this.IdSector;
            this.sRespuesta = objSalarioDA.Registrar();
            this.sMensajeError = objSalarioDA.sMensajeError;
            return (this.sRespuesta);
        }
    }
}