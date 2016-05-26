using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Configuration;

namespace wcfSeguridad.Logica
{
    public class clsSeguridad
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        Int32 iIdConexion = 0;

        public DataTable privilegiosUsuario(string nick)
        {

            return ObjSeguridadDA.privilegiosUsuario(nick);
            

        }
        public void UsrReporte(out string ServRep,out string ServApl,out string UsrRep,out string PassUsrRep,out string DomRep)
        {
            ServRep = ConfigurationManager.AppSettings["ServRep"].ToString();
            ServApl = ConfigurationManager.AppSettings["ServApl"].ToString();  
            UsrRep = ConfigurationManager.AppSettings["UsrRep"].ToString();
            PassUsrRep = ConfigurationManager.AppSettings["PassUsrRep"].ToString();
            DomRep = ConfigurationManager.AppSettings["DomRep"].ToString();
            
        }

        #region MODULO_SEGURIDAD
        public DataTable menuprivilegiosUsuario(int IdConexion, string Operacion, string SesionTrabajo, string SSN)
        {
            return ObjSeguridadDA.menuprivilegiosUsuario(IdConexion, Operacion, SesionTrabajo, SSN);
        }
        public DataTable ListaOficinasUsuario(int IdUser)
        {
            return ObjSeguridadDA.ListaOficinasUsuario(IdUser);
        }
        public DataTable ListaModulosUsuario(int IdUser)
        {
            return ObjSeguridadDA.ListaModulosUsuario(IdUser);
        }
        public DataTable ListaRolesUsuario(int IdUser, int IdOficina)
        {
            return ObjSeguridadDA.ListaRolesUsuario(IdUser, IdOficina);
        }
        public DataTable ListaProcedimientoconParametro(int IdModulo)
        {
            return ObjSeguridadDA.ListaProcedimientoconParametro(IdModulo);
        }
        public Int32 Conexion(string iIdConexion, string sOperacion, string sSSN,string NombreEstacion,string IpAddres,string MacAddress, int iIdUsuario, string sCuentaUsuario, int iIdRol, int iIdOficina, int iIdModulo)
        {
            try
            {
                return ObjSeguridadDA.Conexion(iIdConexion, sOperacion, sSSN, NombreEstacion, IpAddres, MacAddress, iIdUsuario, sCuentaUsuario, iIdRol, iIdOficina, iIdModulo);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public void CerrarConexion(int iIdConexion, string sOperacion)
        {
            ObjSeguridadDA.CerrarConexion(iIdConexion, sOperacion);
        }
        public string ObtenerFecha()
        {
            string fecha;
            fecha = "";
            string Dia = System.DateTime.Now.Day.ToString();
            string Mes = System.DateTime.Now.Month.ToString();
            string Anio = System.DateTime.Now.Year.ToString();

            string strMes = "";

            switch (Mes)
            {
                case "1":
                    strMes = "Enero";
                    break;
                case "2":
                    strMes = "Febrero";
                    break;
                case "3":
                    strMes = "Marzo";
                    break;
                case "4":
                    strMes = "Abril";
                    break;
                case "5":
                    strMes = "Mayo";
                    break;
                case "6":
                    strMes = "Junio";
                    break;
                case "7":
                    strMes = "Julio";
                    break;
                case "8":
                    strMes = "Agosto";
                    break;
                case "9":
                    strMes = "Septiembre";
                    break;
                case "10":
                    strMes = "Octubre";
                    break;
                case "11":
                    strMes = "Noviembre";
                    break;
                case "12":
                    strMes = "Diciembre";
                    break;
                default:
                    strMes = "";
                    break;
            }
                      return fecha = Convert.ToString((Dia + " de " + strMes + " de " + Anio));

        }
        public Int32 PermisosUrl(int IdConexion, string URL)
        {
            try
            {
                return ObjSeguridadDA.PermisosUrl(IdConexion, URL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 HabilitaTransaccion(String iIdConexion, string Operacion, string iSesionTrabajo, string sSSN, string iIdRol, int IdTransaccion)
        {
            try
            {
                return ObjSeguridadDA.HabilitaTransaccion(iIdConexion, Operacion, iSesionTrabajo, sSSN, iIdRol, IdTransaccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region USUARIO
        //public DataTable ContarUsuario()
        //{
        //    return ObjSeguridadDA.ContarUsuario();
        //}
        //public DataTable ListarUsuariosV(int Pagina, int Rango)
        //{
        //    return ObjSeguridadDA.ListarUsuariosV(Pagina, Rango);
        //}
        //public DataTable ObtenerUsuarioV(int CodUsuario)
        //{
        //    return ObjSeguridadDA.ObtenerUsuarioV(CodUsuario);
        //}
        //public void ModificarUsuario(int CodUsuario, int IdEstado)
        //{
        //    ObjSeguridadDA.ModificarUsuario(CodUsuario, IdEstado);
        //}
        //public void EliminarUsuario(int CodUsuario)
        //{
        //    ObjSeguridadDA.EliminarUsuario(CodUsuario);
        //}
        public DataTable BusquedaUsuario(String Parametro, int Opcion)
        {
            return ObjSeguridadDA.BusquedaUsuario(Parametro, Opcion);
        }
        //public DataTable BusquedaUsuarioRRHH(int iCi)
        //{
        //    return ObjSeguridadDA.BusquedaUsuarioRRHH(iCi);
        //}
        //
        public DataTable UsuarioLista(string Operacion,string Usuario,string LoginUsuario)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.UsuarioLista(Operacion,Usuario,LoginUsuario);
            dt.Load(dr);
            return dt;
        }
        //public void UsuarioObtenerId(int Carnet,string ClaveUsuario,int IdOficina,int IdArea, out int IdUsuario, out string Mensaje)
        //{
        //    try
        //    {
        //        ObjSeguridadDA.UsuarioObtenerId(Carnet, ClaveUsuario,IdOficina, IdArea, out IdUsuario, out Mensaje);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool UsuarioObtenerId(int iIdConexion,string cOperacion,int iIdUsuario,int Carnet, string ClaveUsuario,int IdOficina,int  IdArea, ref int IdUsuario, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.UsuarioObtenerId(iIdConexion, cOperacion,iIdUsuario, Carnet, ClaveUsuario, IdOficina, IdArea, ref IdUsuario, ref sMensajeError);
            return (bAsignacionOK);
        }
  
        public bool UsuarioRol(int iIdConexion, string cOperacion, int IdRol, int IdUsuario, string sFechaExpiracion,ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.UsuarioRol(iIdConexion, cOperacion, IdRol, IdUsuario,sFechaExpiracion, ref sMensajeError);
            return (bAsignacionOK);
        }

        public DataTable UsuarioListaModuloRol(int IdUsuario)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.UsuarioListaModuloRol(IdUsuario);
            dt.Load(dr);
            return dt;
        }

        public bool UsuarioRestauraPassword(int iIdConexion, string cOperacion,string sSessionTrabajo,string sSNN,int iIdUsuario,string sClaveUsuario,ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.UsuarioRestauraPassword(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdUsuario, sClaveUsuario, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool UsuarioRolBaja(int iIdConexion, string cOperacion,string  sSessionTrabajo,string sSNN,int iIdRolUsuario,int  iIdRol,int iIdUsuario,ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.UsuarioRolBaja(iIdConexion, cOperacion, sSessionTrabajo, sSNN,iIdRolUsuario, iIdRol, iIdUsuario,ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool UsuarioSa(int iIdUsuario)
        {
            bool bAsignacionOK = ObjSeguridadDA.UsuarioSa(iIdUsuario);
            return (bAsignacionOK);
        }

        #endregion
        #region ROL

        public DataTable ListaRol()
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaRol();
            dt.Load(dr);
            return dt;
        }
        public DataTable  ListaRolActualizar(int iIdConexion,string cOperacion,string sSessionTrabajo,string sSNN,int IdRol,string sIdTransaccion,string sIdMenuSuperior)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjSeguridadDA.ListaRolActualizar(iIdConexion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            return (null);
        }
        public bool TransaccionAutorizadaElimina(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, int iIdRol, int iIdTransaccion, string sIdMenuSuperior,ref string sMensajeError)
            {
                bool bAsignacionOK = ObjSeguridadDA.TransaccionAutorizadaElimina(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdRol, iIdTransaccion, sIdMenuSuperior, ref sMensajeError);
                return (bAsignacionOK);
            }
        public bool TransaccionAutorizadaInserta(int iIdConexion, string cOperacion, string sSessionTrabajo,string  sSNN,int iIdRol, int iIdTransaccion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.TransaccionAutorizadaInserta(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdRol, iIdTransaccion,ref sMensajeError);
            return (bAsignacionOK);
        }

        public DataTable ListaRolconParametro(int IdModulo)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaRolconParametro(IdModulo);
            dt.Load(dr);
            return dt;
        }
        //public void InsertarRol(string DetalleRol, int IdModulo, int IdEstado,int IdMenuSuperior,out int IdRol,out string Mensaje )
        //{
        //    try
        //    {
        //      ObjSeguridadDA.InsertarRol(DetalleRol,IdModulo,IdEstado,IdMenuSuperior,out IdRol,out Mensaje);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool InsertarRol(int iIdConexion,string cOperacion,string DetalleRol,int iIdModulo,int iIdEstado,int IdMenuSuperior,string DetRol, ref int iIdRol, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.InsertarRol(iIdConexion, cOperacion, DetalleRol, iIdModulo, iIdEstado, IdMenuSuperior,DetRol, ref iIdRol, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool RolActualiza(int iIdConexion, string cOperacion, string sSessionTrabajo,string  sSNN, int iIdRol, string sDetalleRol,int iIdModulo,int iIdEstadoRol,string sDetRol, ref String sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.RolActualiza(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdRol, sDetalleRol,iIdModulo,iIdEstadoRol,sDetRol, ref sMensajeError);
            return (bAsignacionOK);
        }
        
    
        public bool InsertarTransaccionAutorizada(int iIdConexion, string cOperacion, int IdRol, int CodTransaccion,ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.InsertarTransaccionAutorizada(iIdConexion, cOperacion, IdRol, CodTransaccion, ref sMensajeError);
            return (bAsignacionOK);
        }

        #endregion
        #region MODULOS
        
        public DataTable ListaModulos(int IdConexion,string Operacion) {
            DataSet DSetTmp = new DataSet();
            if (ObjSeguridadDA.ListaModulos(IdConexion,Operacion,ref DSetTmp)) {
                return (DSetTmp.Tables[0]);
            }
            return (null);
        }

        //public DataTable InsertarModulo(string DetalleModulo, string Abreviatura,int Tipo)
        //{
        //    DataTable dt = new DataTable();
        //    IDataReader dr = ObjSeguridadDA.InsertarModulo(DetalleModulo, Abreviatura,Tipo);
        //    dt.Load(dr);
        //    return dt;
        //}
        public bool InsertarModulo(int iIdConexion, string cOperacion, string sDetalleModulo, string sAbreviatura, int iTipo, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.InsertarModulo(iIdConexion, cOperacion,sDetalleModulo, sAbreviatura,  iTipo, ref sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable ListaModulosconParametro(int iIdConexion,string cOperacion,int iIdModulo)
        {
            
            DataSet DSetTmp = new DataSet();
            if (ObjSeguridadDA.ListaModulosconParametro(iIdConexion, cOperacion,iIdModulo, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            return (null);            
        }
       
        public bool ActualizarModulo(int iIdConexion, string cOperacion, int IdModulo, string DetalleModulo, string Abreviatura, int Estado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.ActualizarModulo(iIdConexion, cOperacion, IdModulo, DetalleModulo, Abreviatura, Estado, ref sMensajeError);
            return (bAsignacionOK);
        }
        #endregion
        #region OFICINA_AREA
        public DataTable ListaOficinas()
        {
            return ObjSeguridadDA.ListaOficinas();
        }
        public DataTable ListaArea(int IdOficina)
        {
            return ObjSeguridadDA.ListaAreas(IdOficina);
        }
        #endregion
        #region Encriptacion
        public string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            string key = "53NA51R";
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }
        public string Desencriptar(string textoEncriptado)
        {
            string key = "53NA51R";
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public string URLEncode(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            string key = "53NA51R";
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena

            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }
        public string URLDecode(string textoEncriptado)
        {
            string key = "53NA51R";
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        //public string URLEncode(string cadena)
        //{
        //    byte[] cadenaByte = new byte[cadena.Length];
        //    cadenaByte = System.Text.Encoding.UTF8.GetBytes(cadena);
        //    string encodedCadena = Convert.ToBase64String(cadenaByte);
        //    return encodedCadena;
        //}

        //public string URLDecode(string cadena)
        //{
        //    var encoder = new System.Text.UTF8Encoding();
        //    var utf8Decode = encoder.GetDecoder();

        //    byte[] cadenaByte = Convert.FromBase64String(cadena);
        //    int charCount = utf8Decode.GetCharCount(cadenaByte, 0, cadenaByte.Length);
        //    char[] decodedChar = new char[charCount];
        //    utf8Decode.GetChars(cadenaByte, 0, cadenaByte.Length, decodedChar, 0);
        //    string result = new String(decodedChar);
        //    return result;
        //}
        //public static TripleDES CrearDES(string clave)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    TripleDES des = new TripleDESCryptoServiceProvider();
        //    des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(clave));
        //    des.IV = new byte[des.BlockSize / 8];
        //    return des;
        //}
        //public string Encriptar(string textoPlano)
        //{
        //    string contrasegnia = "senasir";
        //    // Primero debemos convertir el texto plano en `textoPlano`
        //    // en un arreglo de bytes:
        //    byte[] textoPlanoBytes = Encoding.Unicode.GetBytes(textoPlano);

        //    // Uso de un flujo de memoria para la contención de los bytes:
        //    MemoryStream flujoMemoria = new MemoryStream();

        //    // Creación de la clave de protección y el vector de inicialización:
        //    TripleDES des = CrearDES(contrasegnia);

        //    // Creación del codificador para la escritura al flujo de memoria:
        //    CryptoStream flujoEncriptacion = new CryptoStream(flujoMemoria, des.CreateEncryptor(), CryptoStreamMode.Write);

        //    // Escritura del arreglo de bytes sobre el flujo de memoria:
        //    flujoEncriptacion.Write(textoPlanoBytes, 0, textoPlanoBytes.Length);
        //    flujoEncriptacion.FlushFinalBlock();

        //    // Retorna representación legible de la cadena encriptada:
        //    return Convert.ToBase64String(flujoMemoria.ToArray());
        //}
        //public string Desencriptar(string textoEncriptado)
        //{
        //    string contrasegnia = "senasir";
        //    // Primero debemos convertir el texto plano en `textoPlano`
        //    // en un arreglo de bytes:
        //    byte[] bytesEncriptados = Convert.FromBase64String(textoEncriptado);

        //    // Uso de un flujo de memoria para la contención de los bytes:
        //    MemoryStream flujoMemoria = new MemoryStream();

        //    // Creación de la clave de protección y el vector de inicialización:
        //    TripleDES des = CrearDES(contrasegnia);

        //    // Creación de decodificador:
        //    CryptoStream flujoDesencriptacion = new CryptoStream(flujoMemoria, des.CreateDecryptor(), CryptoStreamMode.Write);

        //    // Escritura del arreglo de bytes sobre el flujo de memoria:
        //    flujoDesencriptacion.Write(bytesEncriptados, 0, bytesEncriptados.Length);
        //    flujoDesencriptacion.FlushFinalBlock();

        //    // Conversión del flujo de datos en una cadena de caracteres:
        //    return Encoding.Unicode.GetString(flujoMemoria.ToArray());

        //}



        #endregion
        #region MENU
        public DataTable ListaMenu(string sBMenuSuperior,string sBMenu)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaMenu(sBMenuSuperior,sBMenu);
            dt.Load(dr);
            return dt;
        }
        public DataTable ListaMenuconParametro(int IdTransaccion)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaMenuconParametro(IdTransaccion);
            dt.Load(dr);
            return dt;
        }
        public DataTable ListaMenuSuperior()
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaMenuSuperior();
            dt.Load(dr);
            return dt;
        }
        public DataTable ListaMenuPadre()
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaMenuPadre();
            dt.Load(dr);
            return dt;
        }        
        //public String InsertarMenu(string DetalleMenu, int IdMenuSuperior, int Orden, string URL, int IdEstado)
        //{
        //    try
        //    {
        //        return ObjSeguridadDA.InsertarMenu(DetalleMenu,IdMenuSuperior,Orden,URL,IdEstado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool InsertarMenu(int iIdConexion,string cOperacion,string DetalleMenu,int IdMenuSuperior,int Orden,string URL,int IdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.InsertarMenu(iIdConexion, cOperacion, DetalleMenu, IdMenuSuperior, Orden, URL, IdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        public DataTable ListaMenuxIdMenu(int IdMenu)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjSeguridadDA.ListaMenuxIdMenu(IdMenu);
            dt.Load(dr);
            return dt;
        }
        //public void ActualizarMenu(int IdMenu,string DetalleMenu,int IdMenuSuperior,int Orden,string URL,int IdEstado, out int Semaforo, out string Mensaje)
        //{
        //    try
        //    {
        //        ObjSeguridadDA.ActualizarMenu(IdMenu,DetalleMenu,IdMenuSuperior,Orden,URL,IdEstado,out Semaforo,out Mensaje);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool ActualizarMenu(int iIdConexion, string cOperacion,int iIdMenu, string sDetalleMenu, int iIdMenuSuperior, int iOrden, string sURL, int iIdEstado, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjSeguridadDA.ActualizarMenu(iIdConexion, cOperacion, iIdMenu, sDetalleMenu, iIdMenuSuperior, iOrden, sURL, iIdEstado, ref sMensajeError);
            return (bAsignacionOK);
        }
        #endregion
        public DataTable ListaDatosConexion(int iIdConexion)
        {
            return ObjSeguridadDA.ListaDatosConexion(iIdConexion);
        }
        public DataTable Version()
        {
            return ObjSeguridadDA.Version();
        }

       

    }
}