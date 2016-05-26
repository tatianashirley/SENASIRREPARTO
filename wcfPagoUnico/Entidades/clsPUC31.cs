using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfPagoUnico.Entidades
{
    public class clsPUC31 : clsPUBase
    {
        public int C31 { get; set; }
	    public int Aniop { get; set; }
	    public int Anio { get; set; }
	    public string Ent { get; set; }
	    public int Dad { get; set; }
	    public int Ues { get; set; }
	    public int C31_Rev { get; set; }
	    public int Mes { get; set; }
	    public string Fte { get; set; }
	    public string Org { get; set; }
	    public string Glosa { get; set; }
	    public string Tip { get; set; }
	    public string Cpl { get; set; }
	    public string Cpd { get; set; }
	    public float Total { get; set; }
	    public float Retension { get; set; }
	    public string Ins { get; set; }
	    public string Tco { get; set; }
	    public string Seg { get; set; }
	    public int AnioProceso { get; set; }
	    public int MesProceso { get; set; }
        public string Seguros { get; set; }
        public string Codigo { get; set; }
    }
}