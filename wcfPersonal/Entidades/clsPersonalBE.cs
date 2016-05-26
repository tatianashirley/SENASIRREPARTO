using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfPersonal.Entidades
{
    public class clsPersonalBE
    {
        public int Carnet { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string EstadoFuncionario { get; set; }
        public string Funcionario { get; set; }

        public int TotalR { get; set; }
     }
}