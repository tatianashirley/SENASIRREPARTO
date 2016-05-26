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
using wfcDoblePercepcion.Datos;

namespace wfcDoblePercepcion.Logica
{
    public  class clsInformacion
    {
        clsDatos doble = new clsDatos();

        public DataTable ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1
                             , string Nombre2, string NumeroDocumento, string Matricula, string CUA, Int64 NUP, int ID, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (doble.ObtieneDatos(iIdConexion, cOperacion, Tipo, Paterno, Materno, Nombre1, Nombre2, NumeroDocumento, Matricula, CUA, NUP, ID
                                        , ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public Boolean EliminarTemporal()
        {
            clsDatos eli = new clsDatos();
            return eli.EliminaTemporal();
        }


        public bool InsertaRegistro
        (
            int iIdConexion, string cOperacion, Int64 NUP, string GrupoBeneficio, string Beneficio,Int32 estado,Int32 norma,
            Int32 tdocumento, string nrodocuemento, string FechaDocumento, string Institucion, string PeriodoInicioInstitucion,
            string PeriodoFInInstitucion, string FechaSuspencion, string FechaRehabilitacion, string idusuario, string registro,
            string refencia, string observacion, string observacion1,int NroReferenciaSuspencion,int NroReferenciaRehabilitacion,
            
            ref string sMensajeError
          
            )

        {
            bool Respuesta = doble.InsertaRegistro(iIdConexion, cOperacion, NUP, GrupoBeneficio, Beneficio, estado, norma,
                tdocumento, nrodocuemento, FechaDocumento, Convert.ToInt32( Institucion), PeriodoInicioInstitucion, PeriodoFInInstitucion, FechaSuspencion, FechaRehabilitacion
                , idusuario, registro, refencia, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion
                ,ref sMensajeError);

              return (Respuesta);
        }


        public bool InsertaDocuementoExtra
        (
               int iIdConexion, string cOperacion, Int64 NUP, Int32 estado,Int32 idBeneficio, string documentoextra, string nrodocumentoextra, string fechadocumentoextra, string referenciadocumentoextra, string observaciondocumentoextra,
               ref string sMensajeError
       )
        {
            bool Respuesta = doble.InsertaDocuementoExtra(iIdConexion, cOperacion, NUP,estado,idBeneficio, documentoextra, nrodocumentoextra, fechadocumentoextra, referenciadocumentoextra, observaciondocumentoextra
                , ref sMensajeError);

            return (Respuesta);
        }


        public bool ModificaSuspencion
       (
           int iIdConexion, string cOperacion,  string IdSupencion, string norma,string FechaSuspencion,string FechaRehabilitacion,string observacion,
            string observacion1,int NroReferenciaSuspencion,int NroReferenciaRehabilitacion,

           ref string sMensajeError

        )
        {
            bool Respuesta = doble.ModificaSuspencion(iIdConexion, cOperacion, IdSupencion, norma, FechaSuspencion, FechaRehabilitacion, observacion,
                observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion
                , ref sMensajeError);

            return (Respuesta);
        }

        public bool ModificaDocumento
        (
            int iIdConexion, string cOperacion,   string IdSuspencion,string IdDocumento,string idTipoDocumento,string NroDocumento,string FechaDocumento,string ReferenciaDocumento,string ObservacionDocumento,
            ref string sMensajeError
         )
        {
            bool Respuesta = doble.ModificaDocumento(iIdConexion, cOperacion, IdSuspencion, IdDocumento, idTipoDocumento, NroDocumento, FechaDocumento,
            ReferenciaDocumento, ObservacionDocumento, ref sMensajeError);

            return (Respuesta);
        }


        public bool ModificaDocumentoSuspencionPreventiva
        (
            int iIdConexion, string cOperacion, string IdSuspencion, string IdDocumento, string idTipoDocumento, string NroDocumento, string FechaDocumento, string ReferenciaDocumento, string ObservacionDocumento,
            ref string sMensajeError
         )
        {
            bool Respuesta = doble.ModificaDocumentoSuspencionPreventiva(iIdConexion, cOperacion, IdSuspencion, IdDocumento, idTipoDocumento, NroDocumento, FechaDocumento,
            ReferenciaDocumento, ObservacionDocumento, ref sMensajeError);

            return (Respuesta);
        }

        public bool ModificaPeriodo
         (
        int iIdConexion, string cOperacion, string IdSuspencion, string IdInstitucion, string idinstitucionM,string PeriodoInicioInstitucion,string PeriodoFinInstucion,string ObservacionPeriodo
        ,ref string sMensajeError
         )
        {
            bool Respuesta = doble.ModificaPeriodo(iIdConexion, cOperacion, IdSuspencion, IdInstitucion, idinstitucionM, PeriodoInicioInstitucion,
                PeriodoFinInstucion, ObservacionPeriodo, ref sMensajeError);

            return (Respuesta);
        }



        public bool InsertarPreventivo
        (
               int iIdConexion, string cOperacion, Int64 NUP,  int norma,int NroReferenciaSuspencionSP, int NroReferenciaRehabilitacionSP, string PeriodoSuspencionSP,string PeriodoRehabilitacionSP,string InsitucionSP
            , string observacionSuspencionSP, string observacionRehabilitacionSP, string TipoDocumentoSP, string NroDocumentoSP, string FechaDocumentoSP, string ReferenciaDocumentoSP, string ObservacionDocumentoSP
            ,ref string sMensajeError
       )
        {
            bool Respuesta = doble.InsertarPreventivo(iIdConexion, cOperacion, NUP, norma, NroReferenciaSuspencionSP, NroReferenciaRehabilitacionSP,PeriodoSuspencionSP,PeriodoRehabilitacionSP,InsitucionSP ,observacionSuspencionSP, observacionRehabilitacionSP,
                 TipoDocumentoSP,NroDocumentoSP,FechaDocumentoSP,ReferenciaDocumentoSP,ObservacionDocumentoSP
                , ref sMensajeError);

            return (Respuesta);
        }

        public bool InsertaDocuementoExtraPreventivo
        (
       int iIdConexion, string cOperacion, Int64 NUP, Int32 grupo, string documentoextra, string nrodocumentoextra, string fechadocumentoextra, string referenciadocumentoextra, string observaciondocumentoextra,
       ref string sMensajeError
        )
        {
            bool Respuesta = doble.InsertaDocuementoExtraPreventivo(iIdConexion, cOperacion, NUP, grupo, documentoextra, nrodocumentoextra, fechadocumentoextra, referenciadocumentoextra, observaciondocumentoextra
                , ref sMensajeError);

            return (Respuesta);
        }

        public bool ModificaSuspencionPreventiva
         (
        int iIdConexion, string cOperacion, Int32 IdSuspencionPreventiva, Int32 InsitucionSPM, string PeriodoSuspencionSPM, string PeriodoDesactivacionSPM, Int32 NroReferenciaSupencionSPM, Int32 NroReferenciaRehabilitacionSPM,
        string ObservacionSuspencionSPM, string ObservacionDesactivacionSPM
        , ref string sMensajeError
         )
        {
            bool Respuesta = doble.ModificaSuspencionPreventiva(iIdConexion, cOperacion, IdSuspencionPreventiva, InsitucionSPM, PeriodoSuspencionSPM, PeriodoDesactivacionSPM,
                NroReferenciaSupencionSPM, NroReferenciaRehabilitacionSPM, ObservacionSuspencionSPM, ObservacionDesactivacionSPM, ref sMensajeError);

            return (Respuesta);
        }


        public bool RehabilitaPreventivo
        (
               int iIdConexion, string cOperacion, Int64 NUP,string id , int norma, int NroReferenciaRehabilitacionSP,  string PeriodoRehabilitacionSP
            ,  string observacionRehabilitacionSP, string TipoDocumentoSP, string NroDocumentoSP, string FechaDocumentoSP, string ReferenciaDocumentoSP, string ObservacionDocumentoSP
            , ref string sMensajeError
       )
        {
            bool Respuesta = doble.RehabilitaPreventivo(iIdConexion, cOperacion, NUP,id, norma, NroReferenciaRehabilitacionSP, PeriodoRehabilitacionSP, observacionRehabilitacionSP,
                 TipoDocumentoSP, NroDocumentoSP, FechaDocumentoSP, ReferenciaDocumentoSP, ObservacionDocumentoSP
                , ref sMensajeError);

            return (Respuesta);
        }

        public bool RegistraPeriodo(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string Observacion, string PeriodoInicio, string PeriodoFin, int Institucion, int Aguinaldo, ref string sMensajeError)
        {
            bool Respuesta = doble.RegistraPeriodo(iIdConexion, cOperacion, IdDeuda, NUP, Observacion, PeriodoInicio, PeriodoFin, Institucion, Aguinaldo, ref sMensajeError);
            return (Respuesta);
        }

        public bool BorraPeriodo(int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP,  ref string sMensajeError)
        {
            bool Respuesta = doble.BorraPeriodo(iIdConexion, cOperacion, IdDeuda, NUP, ref sMensajeError);
            return (Respuesta);
        }

    }
  
}