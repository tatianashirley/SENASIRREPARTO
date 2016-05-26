using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using wcfSeguridad.Datos;
using System.Security.Cryptography;
using System.Text;

namespace wcfSeguridad.Logica
{
    public class clsOficinas
    {
        DataTable dt = new DataTable();
        clsSeguridadDA ObjSeguridadDA = new clsSeguridadDA();
        clsOficinasDA ObjOficinasDA = new clsOficinasDA();

        public DataTable DTNiveles { get; set;} 

        public DataTable OficinaLista(int iIdConexion,string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjOficinasDA.OficinaLista(iIdConexion,cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        public DataTable OficinaListaPorOficinaPrincipal(int iIdConexion,string cOperacion,int iIdOficinaPrincipal,ref string sMensajeError,ref string sNivelError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjOficinasDA.OficinaListaPorOficinaPrincipal( iIdConexion, cOperacion, iIdOficinaPrincipal,ref sMensajeError,ref sNivelError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        public DataTable LocalidadLista(int iIdConexion,string cOperacion,int iIdDepartamento, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjOficinasDA.LocalidadLista( iIdConexion, cOperacion, iIdDepartamento, ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool OficinaAdiciona(int iIdConexion,string cOperacion,string sOficina,int iIdOficinaSuperior,string sCodigo,string sNivel,string sDireccion,int iTelefono,int iLocalidad,int iIdTipoOficina,int iIdEstado,int iFlagCC, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjOficinasDA.OficinaAdiciona( iIdConexion, cOperacion, sOficina, iIdOficinaSuperior, sCodigo, sNivel, sDireccion, iTelefono, iLocalidad, iIdTipoOficina, iIdEstado, iFlagCC, ref sMensajeError);
            return (bAsignacionOK);
        }

        public bool OficinaModifica(int iIdConexion,string cOperacion,int iIdOficina,string sOficina,int iIdOficinaSuperior,string sCodigo,string sNivel,string sDireccion,int iTelefono,int iLocalidad,int iIdTipoOficina,int iIdEstado,int iFlagCC, ref string sMensajeError)
        {
            bool bAsignacionOK = ObjOficinasDA.OficinaModifica(iIdConexion, cOperacion, iIdOficina, sOficina, iIdOficinaSuperior, sCodigo, sNivel, sDireccion, iTelefono, iLocalidad, iIdTipoOficina, iIdEstado, iFlagCC, ref sMensajeError);
            return (bAsignacionOK);
        }


        public DataTable ListaOficinasxIdOficinas(int iIdConexion,string cOperacion,int  IdOficina, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjOficinasDA.ListaOficinasxIdOficinas(iIdConexion, cOperacion, IdOficina, ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }
        
        public DataTable UsuarioOficinaLista(int iIdConexion,string cOperacion,int  iIdUsuario, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjOficinasDA.UsuarioOficinaLista( iIdConexion, cOperacion,  iIdUsuario,  ref  sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public Boolean ObtieneNivelesDeOficina(int iIdConexion, ref string sMensajeError) {
            DataSet DSetTmp = new DataSet();
            if (ObjOficinasDA.ObtieneNivelesDeOficina(iIdConexion, ref  sMensajeError, ref DSetTmp)) {
                DTNiveles = new DataTable();
                DTNiveles = DSetTmp.Tables[0].Copy();
                return (true);
            } else {
                return (false);
            }
        }

    }
}