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
using System.Data.SqlClient;
using System.Configuration;

namespace wfcDoblePercepcion.Datos
{

    public class clsDatos
    {

        Database db = null;

        public clsDatos()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
       
        public bool ObtieneDatos(int iIdConexion, string cOperacion, string Tipo, string Paterno, string Materno, string Nombre1, string Nombre2
                    , string NumeroDocumento, string Matricula, string CUA, Int64 NUP, int ID, ref string sMensajeError, ref DataSet DSetTmp)
        {

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_Busqueda", cOperacion);


            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Tipo", Tipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Paterno", Paterno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Materno", Materno);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre1", Nombre1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Nombre2", Nombre2);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CI", NumeroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@Matricula", Matricula);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@CUA", CUA);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@ID", ID);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSetTmp = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }


        public Boolean EliminaTemporal()
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("Beneficio.PR_EliminaTemporal", "PE", "0");
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }




        public bool InsertaRegistro
          (int iIdConexion, string cOperacion, Int64 NUP, string GrupoBeneficio, string Beneficio, Int32 estado, Int32 norma,
            Int32 tdocumento, string nrodocuemento, string FechaDocumento, Int32 Institucion, string PeriodoInicioInstitucion,
            string PeriodoFInInstitucion, string FechaSuspencion, string FechaRehabilitacion, string idusuario, string registro,
            string refencia, string observacion, string observacion1,int NroReferenciaSuspencion,int NroReferenciaRehabilitacion
            ,ref string sMensajeError
          )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_RegistraSuspencion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdGrupoBeneficio", GrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdBeneficioOtrorgado", Beneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idEstado", estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idNorma", norma);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idtdocumento", tdocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroDocumento", nrodocuemento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaDocumento", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idInstitucion", Institucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoInicioInstitucion", PeriodoInicioInstitucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoFInInstitucion", PeriodoFInInstitucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaSuspension", FechaSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaRehabilitacion", FechaRehabilitacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idusuario", idusuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@registro", registro);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_referencia", refencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observaciondocumento", observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observacionperiodo", observacion1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_nroreferenciasuspencion", NroReferenciaSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_nroreferenciarehabilitacion", NroReferenciaRehabilitacion);
                bAsignacionOK = true;

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }



        public bool InsertaDocuementoExtra
          (int iIdConexion, string cOperacion, Int64 NUP,Int32 estado,Int32 idBeneficio, string documentoextra, string nrodocumentoextra, string fechadocumentoextra, string referenciadocumentoextra, string observaciondocumentoextra,
             ref string sMensajeError
          )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_RegistraDocumentoExtra", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idEstado", estado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idBeneficio", idBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_documentoextra", documentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_nrodocumentoextra", nrodocumentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fechadocumentoextra", fechadocumentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_referenciadocumentoextra", referenciadocumentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observaciondocumentoextra", observaciondocumentoextra);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }


        public bool RegistraPeriodo
          (int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, string Observacion, string PeriodoInicio, string PeriodoFin, int Institucion, int Aguinaldo, ref string sMensajeError)
          
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_RegistraPeriodoExtra", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sObservaciones", Observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaSuspension", PeriodoInicio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaRehabilitacion", PeriodoFin);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Institucion", Institucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_Aguinaldo", Aguinaldo);
               
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }




        public bool ModificaSuspencion
         (int iIdConexion, string cOperacion, string IdSupencion, string norma, string FechaSuspencion, string FechaRehabilitacion, string observacion,
            string observacion1, int NroReferenciaSuspencion, int NroReferenciaRehabilitacion,
            ref string sMensajeError
         )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_ModificaSupencion", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdSupencion", IdSupencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idNorma", norma);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoInicioSuspencion", FechaSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoRehabilitacion", FechaRehabilitacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observacionSuspencion", observacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observacionRehabilitacion", observacion1);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_nroreferenciasuspencion", NroReferenciaSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_nroreferenciarehabilitacion", NroReferenciaRehabilitacion);
                bAsignacionOK = true;

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }



        public bool ModificaDocumento
         (
            int iIdConexion, string cOperacion, string IdSuspencion, string IdDocumento, string idTipoDocumento, string NroDocumento, string FechaDocumento, string ReferenciaDocumento, string ObservacionDocumento,
            ref string sMensajeError
         )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_ModificaDocumento", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdSupencion", IdSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idTipoDocumento", idTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaDocumento", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ReferenciaDocumento", ReferenciaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionDocumento", ObservacionDocumento);
                bAsignacionOK = true;

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }



        public bool ModificaDocumentoSuspencionPreventiva
         (
            int iIdConexion, string cOperacion, string IdSuspencion, string IdDocumento, string idTipoDocumento, string NroDocumento, string FechaDocumento, string ReferenciaDocumento, string ObservacionDocumento,
            ref string sMensajeError
         )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_ModificaDocumentoSuspencionPreventiva", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdSupencion", IdSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdDocumento", IdDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idTipoDocumento", idTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroDocumento", NroDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaDocumento", FechaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ReferenciaDocumento", ReferenciaDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionDocumento", ObservacionDocumento);
                bAsignacionOK = true;

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }



        public bool ModificaPeriodo
         (
         int iIdConexion, string cOperacion, string IdSuspencion, string IdInstitucion, string idinstitucionM, string PeriodoInicioInstitucion, string PeriodoFinInstucion, string ObservacionPeriodo
        , ref string sMensajeError
         )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_ModificaPeriodo", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdSupencion", IdSuspencion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdInstitucion", IdInstitucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_idinstitucionM", idinstitucionM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoInicioInstitucion", PeriodoInicioInstitucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoFinInstucion", PeriodoFinInstucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionPeriodo", ObservacionPeriodo);
                
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }




        public bool InsertarPreventivo
        (
             int iIdConexion, string cOperacion, Int64 NUP, int norma, int NroReferenciaSuspencionSP, int NroReferenciaRehabilitacionSP, string PeriodoSuspencionSP, string PeriodoRehabilitacionSP, string InsitucionSP
            , string observacionSuspencionSP, string observacionRehabilitacionSP, string TipoDocumentoSP, string NroDocumentoSP, string FechaDocumentoSP, string ReferenciaDocumentoSP, string ObservacionDocumentoSP
            , ref string sMensajeError
        )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_RegistraSuspencionPreventiva", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_norma", norma);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroReferenciaSuspencionSP", NroReferenciaSuspencionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroReferenciaRehabilitacionSP", NroReferenciaRehabilitacionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoSuspencionSP", PeriodoSuspencionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoRehabilitacionSP", PeriodoRehabilitacionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_InsitucionSP", InsitucionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observacionSuspencionSP", observacionSuspencionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observacionRehabilitacionSP", observacionRehabilitacionSP);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_TipoDocumentoSP", TipoDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroDocumentoSP", NroDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaDocumentoSP", FechaDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ReferenciaDocumentoSP", ReferenciaDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionDocumentoSP", ObservacionDocumentoSP);

                
                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        public bool InsertaDocuementoExtraPreventivo
          (int iIdConexion, string cOperacion, Int64 NUP, Int32 grupo, string documentoextra, string nrodocumentoextra, string fechadocumentoextra, string referenciadocumentoextra, string observaciondocumentoextra,
             ref string sMensajeError
          )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_RegistraDocumentoExtraPreventivo", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_documentoextra", documentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_grupodocumento", grupo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_nrodocumentoextra", nrodocumentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fechadocumentoextra", fechadocumentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_referenciadocumentoextra", referenciadocumentoextra);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observaciondocumentoextra", observaciondocumentoextra);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        public bool ModificaSuspencionPreventiva
         (
        int iIdConexion, string cOperacion, Int32 IdSuspencionPreventiva, Int32 InsitucionSPM, string PeriodoSuspencionSPM, string PeriodoDesactivacionSPM, Int32 NroReferenciaSupencionSPM, Int32 NroReferenciaRehabilitacionSPM,
        string ObservacionSuspencionSPM, string ObservacionDesactivacionSPM
        , ref string sMensajeError
         )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_ModificaSupencionPreventiva", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdSuspencionPreventiva", IdSuspencionPreventiva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_InsitucionSPM", InsitucionSPM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoSuspencionSPM", PeriodoSuspencionSPM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoDesactivacionSPM", PeriodoDesactivacionSPM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroReferenciaSupencionSPM", NroReferenciaSupencionSPM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroReferenciaRehabilitacionSPM", NroReferenciaRehabilitacionSPM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionSuspencionSPM", ObservacionSuspencionSPM);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionDesactivacionSPM", ObservacionDesactivacionSPM);
                bAsignacionOK = true;

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }



        public bool RehabilitaPreventivo
      (
           int iIdConexion, string cOperacion, Int64 NUP,string id , int norma, int NroReferenciaRehabilitacionSP, string PeriodoRehabilitacionSP
          , string observacionRehabilitacionSP, string TipoDocumentoSP, string NroDocumentoSP, string FechaDocumentoSP, string ReferenciaDocumentoSP, string ObservacionDocumentoSP
          , ref string sMensajeError
      )
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_RehabilitaPreventivo", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ID", id);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_norma", norma);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroReferenciaRehabilitacionSP", NroReferenciaRehabilitacionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_PeriodoRehabilitacionSP", PeriodoRehabilitacionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_observacionRehabilitacionSP", observacionRehabilitacionSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_TipoDocumentoSP", TipoDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NroDocumentoSP", NroDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_FechaDocumentoSP", FechaDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ReferenciaDocumentoSP", ReferenciaDocumentoSP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_ObservacionDocumentoSP", ObservacionDocumentoSP);


                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }


        public bool BorraPeriodo
        (int iIdConexion, string cOperacion, int IdDeuda, Int64 NUP, ref string sMensajeError)
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Beneficio.PR_BorraPeriodos", cOperacion);
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", cOperacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_IdDeuda", IdDeuda);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_NUP", NUP);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoNonQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }

                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
    }
}