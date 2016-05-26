using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using wfcInventario.Datos;

namespace wfcInventario.Logica
{    
    public class clsLogicaI
    {
        clsDatosI inventario = new clsDatosI();

        public DataTable ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1
                             , string NumeroDocumento, string Matricula, string NroTramite,string CUA,  Int64 NUP,Int32 Nave, Int32 Estante ,int ID, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            
            if (inventario.ObtieneDatos(iIdConexion, cOperacion, Tipo, Paterno, Materno, Nombre1, NumeroDocumento, Matricula, NroTramite,CUA, NUP,Nave,Estante,ID, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool InsertaRegistro
        (
            int iIdConexion, string cOperacion, string GrupoBeneficio, string NroTramite, Int32 NroDocumento,  
            string matricula, Int32 Nave, Int32 Estante , Int32 CodigoCaja ,string CodigoCajaHistorica,
            Int64 CodigoDigitalizacion , string Observacion,ref string sMensajeError
        )
        {
            bool Respuesta = inventario.InsertaRegistro(iIdConexion, cOperacion, GrupoBeneficio, NroTramite, NroDocumento
                , matricula, Nave, Estante, CodigoCaja, CodigoCajaHistorica, CodigoDigitalizacion,Observacion
                , ref sMensajeError);
                return (Respuesta);
        }

        public bool ModificaRegistro
        (
             int iIdConexion, string cOperacion, Int32 Nave, Int32 Estante, Int32 CodigoCaja, string NroTramite,
            string matricula,
            string CodigoCajaHistorica, Int64 CodigoDigitalizacion,
            string Observacion, ref string sMensajeError
        )
        {
            bool Respuesta = inventario.ModificaRegistro(iIdConexion, cOperacion,  Nave,  Estante, 
                CodigoCaja,NroTramite,matricula,CodigoCajaHistorica, CodigoDigitalizacion,Observacion
                , ref sMensajeError);
            return (Respuesta);
        }

        public bool RehubicacionRegistro
        (
         int iIdConexion, string cOperacion, Int32 Nave, Int32 Estante, Int32 CodigoCaja, string NroTramite,
            string matricula,
            string CodigoCajaHistorica, Int64 CodigoDigitalizacion,
            string Observacion, string IdGrupoBeneficio,ref string sMensajeError
        )
        {
            bool Respuesta = inventario.RehubicacionRegistro(iIdConexion, cOperacion, Nave, Estante,
                CodigoCaja, NroTramite, matricula, CodigoCajaHistorica, CodigoDigitalizacion, Observacion,IdGrupoBeneficio
                , ref sMensajeError);
            return (Respuesta);
        }
        public bool InsertaRegistroAsignacion
        (
        int iIdConexion, string cOperacion, string tramite,string matricula, Int32 idUsuario,
            ref string sMensajeError
        )
        {
            bool Respuesta = inventario.InsertaRegistroAsignacion(iIdConexion, cOperacion, tramite, matricula,idUsuario, ref sMensajeError);
            return (Respuesta);
        }
        public bool InsertaRegistroDevolucion
        (
            int iIdConexion, string cOperacion, Int32 IdTramite,
            ref string sMensajeError
        )
        {
            bool Respuesta = inventario.InsertaRegistroDevolucion(iIdConexion, cOperacion,IdTramite, ref sMensajeError);
            return (Respuesta);
        }

    }
}