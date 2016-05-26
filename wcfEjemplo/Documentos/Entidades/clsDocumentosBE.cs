using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEjemplo.Documentos.Entidades
{
    public class clsDocumentosBE
    {
        public int IdRestriccion {get;set;}
        public int CptoTDOc {get;set;}
        public string Descripcion {get;set;}
        public string Comentarios { get; set; }
    }
}