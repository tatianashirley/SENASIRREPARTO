using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Resources;
using SQLSPExecuter;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace wcfCertificacionCC.Datos
{
    public class clsParametrizacionDA
    {
        string sMensajeError = "";
        Database db = null;
        public clsParametrizacionDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }
        public IDataReader ListaParametrizacion(int TipoCertificacion, int EstadoCertificacion, int IdParametrizadion,string inicio,string fin)
        {
            DbCommand cmd = db.GetStoredProcCommand("CertificacionCC.PR_ListaParametrizacion", TipoCertificacion, EstadoCertificacion, IdParametrizadion,inicio,fin);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        
       
    }


}