using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using wcfServicioIntercambioPago.Datos;
using System.Data;
using System.Globalization;

namespace wcfServicioIntercambioPago.Logica
{
    public class clsManejoArchivo
    {
        public bool ControlEnvio(int iIdConexion, string TipoControl,string TipoMedio,string NombreArchivo,string Estado
                                    , ref string sMensajeError)
        {
            clsServicioIntercambioDA envio = new clsServicioIntercambioDA();
            bool Respuesta = false;
            if (TipoControl == "Registro")
            {
                //envio.RegistrarEnvio(TipoMedio, EstadoEnvio, NombreArchivo);
                Respuesta = envio.RegistraArchivoIntercambio(iIdConexion, "I", TipoMedio, Estado, NombreArchivo, ref sMensajeError);
            }
            if (TipoControl != "Registro")
            {
                //envio.ModificarEnvio(NombreArchivo, Estado);
                Respuesta = envio.ModificaArchivoIntercambio(iIdConexion, "U", NombreArchivo, Estado, ref sMensajeError);
            }
            return (Respuesta);
        }

        public void CrearArchivo(DataTable TablaArchivo, string RutaNomArchivo)
        {
            StreamWriter sw = new StreamWriter(RutaNomArchivo, false, Encoding.Default);
            string Linea = "";
            foreach (DataRow r in TablaArchivo.Rows)
            {
                Linea = "";
                foreach (DataColumn c in TablaArchivo.Columns)
                {
                    Linea += r.ItemArray[c.Ordinal].ToString() + "|";
                }
                Linea = Linea.Remove(Linea.LastIndexOf("|"));
                sw.WriteLine(Linea);
            }
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        public string GenerarCRC(string RutaCompleta)
        {
            string LineaCRC;
            string ArchivoCRC;
            CRC32 c = new CRC32();
            UInt32 crc = 0;
            HiRes h = new HiRes();
            Console.WriteLine("{0} {1}", h.HasHiResCounter, h.Frequency);
            h.Start();
            FileStream f = new FileStream(RutaCompleta, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
            crc = c.GetCrc32(f);
            f.Close();
            h.Stop();
            f = new FileStream(RutaCompleta, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
            LineaCRC = String.Format("{0:X8}", crc);
            ArchivoCRC = RutaCompleta.Replace(".TXT", "_CRC.TXT");
            StreamWriter DatosCRC = File.CreateText(ArchivoCRC);
            DatosCRC.WriteLine(LineaCRC);
            DatosCRC.Flush();
            DatosCRC.Close();
            f.Flush();
            f.Close();
            f.Dispose();
            return LineaCRC;
        }

    }
}