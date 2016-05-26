using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace wcfEjemplo.Logica
{
    public class clsFormatoFecha
    {
        private static void VerificaFormatoExtracted()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
        }

        public DateTime FechaHora(DateTime FechaOriginal)
        {
            VerificaFormatoExtracted();
            String sNuevaFecha = FechaOriginal.ToString("dd/MM/yyyy hh:mm:ss");
            DateTime NuevaFecha = Convert.ToDateTime(sNuevaFecha);
            return NuevaFecha;
        }
        public DateTime FechaHoraBD(DateTime FechaOriginal)
        {
            VerificaFormatoExtracted();
            String sNuevaFecha = FechaOriginal.ToString("MM/dd/yyyy hh:mm:ss");
            DateTime NuevaFecha = Convert.ToDateTime(sNuevaFecha);
            return NuevaFecha;
        }

        public string Fecha(DateTime FechaOriginal)
        {
            VerificaFormatoExtracted();
            String sNuevaFecha = "";
            if (FechaOriginal != DateTime.MinValue)
                sNuevaFecha = FechaOriginal.ToString("dd/MM/yyyy");
            return sNuevaFecha;
        }

        public string FechaBD(DateTime FechaOriginal)
        {
            VerificaFormatoExtracted();
            String sNuevaFecha = "";
            if (FechaOriginal != DateTime.MinValue)
                sNuevaFecha = FechaOriginal.ToString("MM/dd/yyyy");
            return sNuevaFecha;
        }

        public bool VerificaFormatoMDY(string Fecha)
        {
            int Mes = Convert.ToInt16(Fecha.Substring(0, 2));
            int Dia = Convert.ToInt16(Fecha.Substring(3, 2));
            int Anio = Convert.ToInt16(Fecha.Substring(6, 4));

            try
            {
                DateTime Fecha1 = new DateTime(Anio, Mes, Dia);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerificaFormatoDMY(string Fecha)
        {
            int Dia = Convert.ToInt16(Fecha.Substring(0, 2));
            int Mes = Convert.ToInt16(Fecha.Substring(3, 2));
            int Anio = Convert.ToInt16(Fecha.Substring(6, 4));

            try
            {
                DateTime Fecha1 = new DateTime(Anio, Mes, Dia);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DateTime GeneraFechaMDY(string Fecha)
        {
            if (Fecha != "")
            {
                int Mes = Convert.ToInt16(Fecha.Substring(0, 2));
                int Dia = Convert.ToInt16(Fecha.Substring(3, 2));
                int Anio = Convert.ToInt16(Fecha.Substring(6, 4));

                DateTime Fecha1 = new DateTime(Anio, Mes, Dia);
                return Fecha1;
            }
            else
                return DateTime.MinValue;
        }

        public DateTime GeneraFechaDMY(string Fecha)
        {
            if (Fecha != "")
            {
                int Dia = Convert.ToInt16(Fecha.Substring(0, 2));
                int Mes = Convert.ToInt16(Fecha.Substring(3, 2));
                int Anio = Convert.ToInt16(Fecha.Substring(6, 4));

                DateTime Fecha1 = new DateTime(Anio, Mes, Dia);
                return Fecha1;
            }
            else
                return DateTime.MinValue;
        }


    }
}