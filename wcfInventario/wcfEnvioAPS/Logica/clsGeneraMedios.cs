using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using wcfEnvioAPS.Datos;
using System.Globalization;
using System.Threading;

using System.Data;
using System.IO;


namespace wcfEnvioAPS.Logica
{
    public class clsGeneraMedios : clsGeneraMediosBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"

        clsGeneraMediosDA ObjGeneraMediosDA = new clsGeneraMediosDA();

        /// <summary>
        /// Busca Certificado
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaDatosCertificado()
        {
            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            ObjGeneraMediosDA.iNroCertificado = iNroCertificado;
            ObjGeneraMediosDA.iIdTipoTramite = iIdTipoTramite;
            Boolean AnsOK = ObjGeneraMediosDA.BuscaDatosCertificado();
            DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Busca R.A. y Fecha R.A.
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaRAyFecha()
        {
            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            ObjGeneraMediosDA.sCodigoActualizacion = sCodigoActualizacion;
            Boolean AnsOK = ObjGeneraMediosDA.BuscaRAyFecha();
            DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene la Bandeja de EnviosAPS
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneBandejaEnviosAPS()
        {
            ObjGeneraMediosDA.iIdConexion = iIdConexion;

            //ObjGeneraMediosDA.iIdTramite = iIdTramite;
            //ObjGeneraMediosDA.fFechaDesde = fFechaDesde;
            //ObjGeneraMediosDA.fFechaHasta = fFechaHasta;
            //ObjGeneraMediosDA.sNombreAsegurado = sNombreAsegurado;

            Boolean AnsOK = ObjGeneraMediosDA.ObtieneBandejaEnviosAPS();
            DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Genera Datos para Archivo en Medios Magneticos de EnvioAPS
        /// </summary>
        /// <returns></returns>
        public Boolean AltaGeneraMediosMag()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            ObjGeneraMediosDA.sNumeroEnvio = sNumeroEnvio;
            ObjGeneraMediosDA.iIdEntidadGestora = iIdEntidadGestora;
            Boolean AnsOK = ObjGeneraMediosDA.AltaGeneraMediosMagDA();
            DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }
        
        /// <summary>
        /// Obtiene los datos de un Archivo en formato byte
        /// </summary>
        /// <returns></returns>
        public byte[] GetDataFile(string pathSource, ref int numBytesToRead)
        {
            // Specify a file to read from and to create. 
            //string pathSource = @"C:\Temp\Medios_Mag_" + envio + ".txt";
            try
            {
                using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array. 
                    byte[] fileData = new byte[fsSource.Length];
                    numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead. 
                        int n = fsSource.Read(fileData, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached. 
                        if (n == 0)
                            break;
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = fileData.Length;
                    //string contentType = "text/plain";
                    return fileData;
                }
            }
            catch (FileNotFoundException ioEx)
            {
                sMensajeError = ioEx.Message;
                byte[] fileData = new byte[0];
                return fileData;
            }
        }

        /// <summary>
        /// Adicionar Archivo de Envios y CRC para un Envio determinado
        /// </summary>
        /// <returns></returns>
        public Boolean SaveEnvioToDB2()
        {
            int size = 0;
            vArchivoEnvioDatos = GetDataFile(sArchivoEnvioNombre, ref size);
            iArchivoEnvioLongitud = size;

            int size2 = 0;
            vArchivoEnvioCRCDatos = GetDataFile(sArchivoEnvioCRCNombre, ref size2);

            sArchivoEnvioNombre = Path.GetFileName(sArchivoEnvioNombre);
            sArchivoEnvioCRCNombre = Path.GetFileName(sArchivoEnvioCRCNombre);
            
            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            ObjGeneraMediosDA.sNumeroEnvio = sNumeroEnvio;
            ObjGeneraMediosDA.iIdEntidadGestora = iIdEntidadGestora;

            ObjGeneraMediosDA.iNumeroCite = iNumeroCite;
            ObjGeneraMediosDA.fFechaCite = fFechaCite;
            ObjGeneraMediosDA.fFechaRecepcion = fFechaRecepcion;
            ObjGeneraMediosDA.sArchivoEnvioNombre = sArchivoEnvioNombre;
            ObjGeneraMediosDA.sArchivoEnvioContTipo = sArchivoEnvioContTipo;
            ObjGeneraMediosDA.iArchivoEnvioLongitud = iArchivoEnvioLongitud;
            ObjGeneraMediosDA.vArchivoEnvioDatos = vArchivoEnvioDatos;
            ObjGeneraMediosDA.sArchivoEnvioCRCNombre = sArchivoEnvioCRCNombre;
            ObjGeneraMediosDA.vArchivoEnvioCRCDatos = vArchivoEnvioCRCDatos;
            ObjGeneraMediosDA.sUsuario = sUsuario;
            ObjGeneraMediosDA.iRegistroActivo = iRegistroActivo;
            Boolean AnsOK = ObjGeneraMediosDA.AdicionaMedioEnvioAPS2DA();
            DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Adicionar Archivo de Envios y CRC para un Envio determinado
        /// </summary>
        /// <returns></returns>
        public Boolean SaveEnvioToDB()
        {
            int size = 0;
            vArchivoEnvioDatos = GetDataFile(sArchivoEnvioNombre, ref size);
            iArchivoEnvioLongitud = size;

            int size2 = 0;
            vArchivoEnvioCRCDatos = GetDataFile(sArchivoEnvioCRCNombre, ref size2);

            sArchivoEnvioNombre = Path.GetFileName(sArchivoEnvioNombre);
            sArchivoEnvioCRCNombre = Path.GetFileName(sArchivoEnvioCRCNombre);

            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            ObjGeneraMediosDA.sNumeroEnvio = sNumeroEnvio;
            ObjGeneraMediosDA.iIdEntidadGestora = iIdEntidadGestora;

            ObjGeneraMediosDA.iNumeroCite = iNumeroCite;
            ObjGeneraMediosDA.fFechaCite = fFechaCite;
            ObjGeneraMediosDA.fFechaRecepcion = fFechaRecepcion;
            ObjGeneraMediosDA.sArchivoEnvioNombre = sArchivoEnvioNombre;
            ObjGeneraMediosDA.sArchivoEnvioContTipo = sArchivoEnvioContTipo;
            ObjGeneraMediosDA.iArchivoEnvioLongitud = iArchivoEnvioLongitud;
            ObjGeneraMediosDA.vArchivoEnvioDatos = vArchivoEnvioDatos;
            ObjGeneraMediosDA.sArchivoEnvioCRCNombre = sArchivoEnvioCRCNombre;
            ObjGeneraMediosDA.vArchivoEnvioCRCDatos = vArchivoEnvioCRCDatos;
            ObjGeneraMediosDA.sUsuario = sUsuario;
            ObjGeneraMediosDA.iRegistroActivo = iRegistroActivo;
            ObjGeneraMediosDA.AdicionaMedioEnvioAPSDA();
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (true);
        }

        /// <summary>
        /// Establece si el Numero de Envio tiene generado el Medio
        /// </summary>
        /// <returns></returns>
        public Boolean NumeroEnvioTieneMedio(string NumeroEnvio)
        {
            return (ObjGeneraMediosDA.NumeroEnvioTieneMedioDA(NumeroEnvio));
        }

        /// <summary>
        /// Lista las Entidades Gestoras
        /// </summary>
        /// <returns></returns>
        public DataTable ObtieneEntidadesGestoras()
        {
            return (ObjGeneraMediosDA.ObtieneEntidadesGestorasDA());
        }

        /// <summary>
        /// Remite Altas
        /// </summary>
        /// <returns></returns>
        public Boolean RemiteAltas()
        {
            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            Boolean AnsOK = ObjGeneraMediosDA.RemiteAltasDA();
            //DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Obtiene Envios Cerrados pero no Remitidos
        /// </summary>
        /// <returns></returns>
        public Boolean ObtieneEnviosCerradosNoRemitidos()
        {
            ObjGeneraMediosDA.iIdConexion = iIdConexion;
            ObjGeneraMediosDA.sCodigoActualizacion = sCodigoActualizacion;
            Boolean AnsOK = ObjGeneraMediosDA.ObtieneEnviosCerradosNoRemitidosDA();
            DSet = ObjGeneraMediosDA.DSet;
            sMensajeError = ObjGeneraMediosDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}