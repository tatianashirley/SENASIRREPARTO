﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfServicioIntercambioPago.Entidades
{
    public class clsCargaMediosBE
    {
        public int Fila { get; set; }
        public string Campo { get; set; }
        public string DetalleError { get; set; }
    }
}