using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfCertificacionCC.Datos;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfCertificacionCC.Logica
{
    public class clsTramiteAsignado
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsTramiteAsignadoDA ObjTramiteAsignadoDA = new clsTramiteAsignadoDA();
        Int32 iIdConexion = 0;
        string sMensajeError = null;


        
        public DataTable ListarTramitesNoAsigna(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento,int CUA, string Tramite, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListarTramitesNoAsignados(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError, 
			FechaInicio, FechaFin, clasinicio, clasfin, numregistros,NumeroDocumento, CUA, Tramite,	ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarTramitesAsignados(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListarTramitesAsignados(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
            FechaInicio, FechaFin, clasinicio, clasfin, numregistros, NumeroDocumento, CUA, Tramite, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarTramitesAsignados_ParaAT(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListarTramitesAsignados_ParaAT(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
            FechaInicio, FechaFin,clasinicio,clasfin, numregistros, NumeroDocumento, CUA, Tramite, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarTramitesReasigna(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            DateTime FechaInicio, DateTime FechaFin, int clasinicio, int clasfin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListarTramitesReasigna(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
            FechaInicio, FechaFin, clasinicio, clasfin, numregistros, NumeroDocumento, CUA, Tramite, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListarTramitesEnAT(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,
            DateTime FechaInicio, DateTime FechaFin, int numregistros, string NumeroDocumento, int CUA, string Tramite, ref string sMensajeError, ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListarTramitesEnAT(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
            FechaInicio, FechaFin, numregistros, NumeroDocumento, CUA, Tramite, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListaParametrosWF(int iIdConexion, string cOperacion, int iIdTramite,int iIdGrupoBeneficio,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListaParametrosWF(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        public DataTable ListaEquiposDeTrabajoOPersonalizada(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.ListaEquiposDeTrabajoOPersonalizada(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool AsignaTramite(int iIdConexion, string cOperacion,int IdUsuario, int IdRol,int IdTramiteClasificado,string sObservaciones, ref string sMensajeError)
        {
            //bool bAsignacionOK = ObjTramiteAsignadoDA.AsignaTramite(iIdConexion, cOperacion, IdUsuario,IdRol,IdTramiteClasificado,sObservaciones, ref  sMensajeError);
            bool bAsignacionOK = ObjTramiteAsignadoDA.AsignarTramite_Usuario_Articulador(iIdConexion, cOperacion, IdUsuario, IdRol, IdTramiteClasificado, sObservaciones, ref  sMensajeError);
            return (bAsignacionOK);
        }

        public bool AsignaTramitePorTramite(int iIdConexion, string cOperacion, int IdTramite, int IdGrupoBeneficio, int IdUsuarioAsignado, string sObservaciones, ref string sMensajeError)
        {
            //bool bAsignacionOK = ObjTramiteAsignadoDA.AsignaTramite(iIdConexion, cOperacion, IdUsuario,IdRol,IdTramiteClasificado,sObservaciones, ref  sMensajeError);
            bool bAsignacionOK = ObjTramiteAsignadoDA.AsignaTramitePorTramite(iIdConexion, cOperacion, IdTramite, IdGrupoBeneficio, IdUsuarioAsignado, sObservaciones, ref sMensajeError);
            return (bAsignacionOK);
        }
        public bool AsignaTramite_Revisor(int iIdConexion, string cOperacion, int IdUsuarioRevisor, int IdRol, int IdTramiteClasificado, string sObservaciones, ref string sMensajeError)
        {
            //bool bAsignacionOK = ObjTramiteAsignadoDA.AsignaTramite_Revisor(iIdConexion, cOperacion, IdUsuarioRevisor, IdRol, IdTramiteClasificado, sObservaciones, ref  sMensajeError);
            bool bAsignacionOK = ObjTramiteAsignadoDA.AsignaTramite_Revisor_Articulador(iIdConexion, cOperacion, IdUsuarioRevisor, IdRol, IdTramiteClasificado, sObservaciones, ref  sMensajeError);
            return (bAsignacionOK);
        }

        public bool DevuelveTramite_AT(int iIdConexion, string cOperacion, int IdTramiteAsignado, DateTime FechaDevolucion, string @ObservacionDevolucion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTramiteAsignadoDA.DevuelveTramite_AT(iIdConexion, cOperacion, IdTramiteAsignado, FechaDevolucion, @ObservacionDevolucion, ref sMensajeError);
            return (bAsignacionOK);
        }

        public DataTable UsuariosAsignaPorTipo(int iIdConexion, string cOperacion, string TipoUsuario,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteAsignadoDA.UsuariosAsignaPorTipo(iIdConexion, cOperacion, TipoUsuario,ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool AsignaTramite_DesdeAT(int iIdConexion, int IdTramiteAsignado, int IdRolUsuarioAsignado, string ObservacionDevolucion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTramiteAsignadoDA.AsignaTramite_DesdeAT(iIdConexion, IdTramiteAsignado, IdRolUsuarioAsignado, ObservacionDevolucion, ref sMensajeError);
            return (bAsignacionOK);
        }

        public bool ReAsignaTramite_DesdeAT(int iIdConexion, int IdTramiteAsignado, int IdRolUsuarioAsignado, string ObservacionDevolucion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTramiteAsignadoDA.ReAsignaTramite_DesdeAT(iIdConexion, IdTramiteAsignado, IdRolUsuarioAsignado, ObservacionDevolucion, ref sMensajeError);
            return (bAsignacionOK);
        }

        public bool ReAsignaTramite(int iIdConexion, int IdTramiteAsignado, int IdRolUsuarioAsignado, string ObservacionDevolucion, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjTramiteAsignadoDA.ReAsignaTramite(iIdConexion, IdTramiteAsignado, IdRolUsuarioAsignado, ObservacionDevolucion, ref sMensajeError);
            return (bAsignacionOK);
        }
    }
}