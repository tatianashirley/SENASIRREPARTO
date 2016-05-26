using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEjemplo.Entidades
{
    public class clsClasificadorEmpresaBE
    {
        public int RUC { get; set; }
        public string NombreEmpresa { get; set; }
        public int NroPatronal { get; set; }
        public string DescripcionSector { get; set; }
    }
}