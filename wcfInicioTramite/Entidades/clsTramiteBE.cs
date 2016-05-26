using System;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Tramite.Entidades
{
    public class clsTramiteBE : clsBase
    {
        public long NUP { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdBeneficio { get; set; }
        public int IdSubBeneficio { get; set; }
        public int IdTipoTramite { get; set; }
        public int IdFlujoTramite { get; set; }
        public int IdClaseExpediente { get; set; }
        public int IdSector { get; set; }
        public int IdOficinaRegistro { get; set; }
        public long NUPIniciaTramite { get; set; }
        public int IdTipoIniciaTramite { get; set; }
        public string Observaciones { get; set; }
        public int IdEstadoTramite { get; set; }
        public int IdTipoProcesoRegistroTramite { get; set; }
        public int EstadoHabilitacion { get; set; }
        public string DocumentoHabilitacion { get; set; }

        public int IdClaseRenta { get; set; }
        public int IdTipoRenta { get; set; }
        public int IdOrigen { get; set; }
        public int IdOficinaNotificacion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaConclusion { get; set; }

        public string NumeroTramiteCRENTA { get; set; }
        public int RegistroActivo { get; set; }

        public long IdTramite { get; set; }
        public long IdObservado { get; set; }
        public string mensaje { get; set; }
        public string retorno_proc { get; set; }

        public int validoManual { get; set; }

        public long sesion { get; set; }
        //Validaciones
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Sexo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nua { get; set; }
        public string Matricula { get; set; }
        public string FechaNacimiento { get; set; }
        //Localidades 
        public string Pais { get; set; }
        public string Localidad { get; set; }
        public string Tipo { get; set; }
    }
}