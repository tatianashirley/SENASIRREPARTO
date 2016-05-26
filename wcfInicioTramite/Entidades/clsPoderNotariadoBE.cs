using System;

namespace wcfInicioTramite.Entidades
{
    public class clsPoderNotariadoBE : clsBase
    {
        public int IdTipoDocumento { get; set; }
        public int IdRegional { get; set; }
        public int IdEstado { get; set; }

        public string NumeroDocumento { get; set; }
        public string ComplementoSEGIP { get; set; }
        public Int64 DocumentoExpedido { get; set; }

        public string PrimerNombre { get; set; }
        public string SegundoNombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ApellidoCasada { get; set; }

        public int IdPaisResidencia { get; set; }
        public string CorreoElectronico { get; set; }
        public string Celular { get; set; }
        public string CelularReferencia { get; set; }
        public string Direccion { get; set; }
        public int IdLocalidad { get; set; }
        public string Telefono { get; set; }

        public int NroPoder { get; set; }
        public string Administracion { get; set; }
        public string VigenciaDesde { get; set; }
        public string VigenciaHasta { get; set; }
        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }

        public string Observacion { get; set; }
    }
}