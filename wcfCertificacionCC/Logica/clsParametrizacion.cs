using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfCertificacionCC.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfCertificacionCC.Logica
{
    public class clsParametrizacion
    {
        DataTable dt = new DataTable();
        clsParametrizacionDA ObjParametrizacionDA = new clsParametrizacionDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;

        public DataTable ListaParametrizacion(int TipoCertificacion, int EstadoCertificacion,int IdParametrizadion,string inicio,string fin)
        {
            DataTable dt = new DataTable();
            IDataReader dr = ObjParametrizacionDA.ListaParametrizacion(TipoCertificacion, EstadoCertificacion, IdParametrizadion,inicio,fin);
            dt.Load(dr);
            return dt;
        }
    }
}