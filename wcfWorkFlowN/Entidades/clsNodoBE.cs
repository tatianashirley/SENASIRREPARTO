using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades
{
    public class clsNodoBE
    {
        public int IdInstancia { get; set; }
        public int Secuencia { get; set; }
        public int IdTipoTramite { get; set; }
        public int IdGrupoBeneficio{ get; set; }

        public int IdTramite { get; set; }
        public int IdFlujo { get; set; }
        public string DescFlujo { get; set; }
        public int IdNodo{ get; set; }

        public string Descripcion { get; set; }
        public int Contador { get; set; }
        public DateTime FechaHRInicio { get; set; }
        public DateTime FechaHRFin { get; set; }
        public string Comentarios{ get; set; }
        public bool FlagCbteTrasladoDoc{ get; set; }

    }

}