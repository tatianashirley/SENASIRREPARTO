using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEjemplo.Entidades
{
    public class clsSalarioReferencialBE
    {
        public Int64 Matricula { get; set; }
        public Int64 num_empleador { get; set; }
        public Int64 periodo { get; set; }
        public Int64 salario { get; set; }
        public Int64 origen { get; set; }
    }
}