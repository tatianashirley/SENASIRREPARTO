using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace wcfPagoUnico.Logica
{
    public class clsPUFormatoFecha
    {
        public string nuevaFechaBD(DateTime FechaOriginal)
        {
            VerificaFormatoExtracted();
            String sNuevaFecha = "";
            if (FechaOriginal != DateTime.MinValue)
                sNuevaFecha = FechaOriginal.ToString("dd/MM/yyyy");
            return sNuevaFecha;
        }

        private static void VerificaFormatoExtracted()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
        }
    }
}