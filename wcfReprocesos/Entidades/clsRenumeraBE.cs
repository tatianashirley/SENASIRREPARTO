using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfReprocesos.Entidades
{
    public class clsRenumeraBE : clsReprocesosBaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public Int32 iNroFormularioRepro { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Int64 iIdTramite { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdOficinaArea { get; set; }
        public Int32 iNroAsignacion { get; set; }
        public Int32 iIdUsuarioImpresion { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iNuevoNumeroCertificado { get; set; }
        #endregion
    }
}