using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using wcfEjemplo.Datos;
using wcfEjemplo.Documentos.Entidades;

namespace wcfEjemplo.Logica
{
    public class clsDocumentos : clsDocumentosBE
    {
        public void VerificarPrestacion(Int64 s_iIdConexion,string s_cOperacion,int s_iSesionTrabajo, string s_sSSN, int i_iSecuencia,int i_iIdHisInstancia,string i_sIdTipoTramite,string i_sIdConcepto,
               string i_sTipoDato,bool i_bFlagInicio,int i_iValorInt,decimal i_mValorMoney,decimal i_dValorFloat,string i_sValorChar,DateTime i_fValorDate, int i_iValorCatalog,bool i_bValorBoolean)
        {
            clsDocumentosDA permiso = new clsDocumentosDA();
            permiso.VerificarPrestacion(s_iIdConexion, s_cOperacion, s_iSesionTrabajo, s_sSSN,  i_iSecuencia, i_iIdHisInstancia, i_sIdTipoTramite, i_sIdConcepto,
                i_sTipoDato, i_bFlagInicio, i_iValorInt, i_mValorMoney, i_dValorFloat, i_sValorChar, i_fValorDate, i_iValorCatalog, i_bValorBoolean);
        }

        public List<clsDocumentos> ListarDocumentos(Int64 s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, string i_sIdTipoTramite)
        {
            clsDocumentos p;
            clsDocumentosDA permiso = new clsDocumentosDA();
            List<clsDocumentos> ListaPermiso = new List<clsDocumentos>();


            using (IDataReader dr = permiso.ListarDocumentos(s_iIdConexion,s_cOperacion,s_iSesionTrabajo,s_sSSN,i_sIdTipoTramite))
            {
                while (dr.Read())
                {
                    p = new clsDocumentos();

                    if (!DBNull.Value.Equals(dr["IdRestriccion"]))
                        p.IdRestriccion = (int)dr["IdRestriccion"];
                    else
                        p.IdRestriccion = 0;

                    if (!DBNull.Value.Equals(dr["CptoTDOc"]))
                        p.CptoTDOc = (int)dr["CptoTDOc"];
                    else
                        p.CptoTDOc = 0;

                    if (!DBNull.Value.Equals(dr["Descripcion"]))
                        p.Descripcion = (string)dr["Descripcion"];
                    else
                        p.Descripcion = "";

                    if (!DBNull.Value.Equals(dr["Comentarios"]))
                        p.Comentarios = (string)dr["Comentarios"];
                    else
                        p.Comentarios = "";

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public void InsertarDocumento(int idTipodocumento, string Descripcion, string Resumen, int IdEstadoDocumento, string NumeroDocumento, DateTime FechaDocumento,
                                        string Ruta, bool Digital, bool RegistroActivo,int s_iIdConexion, string s_cOperacion, Int64 s_iSesionTrabajo, string s_sSSN, string o_sMensajeError, int i_iIdHisInstancia,
                                        string i_sIdTipoTramite, int i_iIdTipoDocumento)
        {
            clsDocumentosDA permiso = new clsDocumentosDA();
            permiso.InsertarDocumento(idTipodocumento, Descripcion, Resumen, IdEstadoDocumento, NumeroDocumento, FechaDocumento, Ruta, Digital, RegistroActivo,
                s_iIdConexion, s_cOperacion, s_iSesionTrabajo, s_sSSN, o_sMensajeError, i_iIdHisInstancia,i_sIdTipoTramite ,i_iIdTipoDocumento );
        }

        public string[] SolicitudGrabarTramite(Int64 s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, string i_sIdTipoTramite, int i_iIdHisInstancia,
            int i_iIdRol, int i_iIdUsuario, DateTime i_fFechaHoraRegistro, DateTime i_fFechaHoraInicio, DateTime i_fFechaHoraTermino, int i_sEstado, int o_iIdSolicitud, string i_sCodigoTramite, string i_sDescripcion)
        {
            clsDocumentosDA permiso = new clsDocumentosDA();
            string[] s = new string[2];
            s=permiso.SolicitudGrabarTramite(s_iIdConexion, s_cOperacion,s_iSesionTrabajo,s_sSSN,i_sIdTipoTramite,i_iIdHisInstancia,
            i_iIdRol, i_iIdUsuario, i_fFechaHoraRegistro, i_fFechaHoraInicio, i_fFechaHoraTermino, i_sEstado, o_iIdSolicitud, i_sCodigoTramite, i_sDescripcion);

            return s;
        }

        public void GrabarTramite(Int64 s_iIdConexion, string s_cOperacion, int s_iSesionTrabajo, string s_sSSN, int i_iIdInstancia, int i_iIdHisInstancia, string i_iIdTipoTramite,
            int i_iIdFlujo, DateTime i_fFechaHoraInicio, DateTime i_fFechaHoraFin, int i_iIdOficina, int i_iIdRol, int i_iIdUsuario, int o_iIdSolicitud, int i_sEstado,
            DateTime i_fCambioEstadoFechaHora, string i_sCancelaJustificacion, int i_sCancelaIdOficina, int i_sCancelaIdRol, int i_sCancelaIdUsuario)
        {
            clsDocumentosDA permiso = new clsDocumentosDA();
            permiso.IntanciarTramite(s_iIdConexion, s_cOperacion, s_iSesionTrabajo, s_sSSN, i_iIdInstancia, i_iIdHisInstancia, i_iIdTipoTramite,
            i_iIdFlujo, i_fFechaHoraInicio, i_fFechaHoraFin, i_iIdOficina, i_iIdRol, i_iIdUsuario, o_iIdSolicitud, i_sEstado,
            i_fCambioEstadoFechaHora, i_sCancelaJustificacion, i_sCancelaIdOficina, i_sCancelaIdRol, i_sCancelaIdUsuario);
        }

    }
}