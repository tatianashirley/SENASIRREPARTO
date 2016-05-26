using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcfObservados.Entidades;
using wcfObservados.Datos;

namespace wcfObservados.Logica
{
   
    public class clsSeguimientoObservados : clsSeguimientoObservadosBE
    {   
        clsSeguimientoObservadosDA Datos = new clsSeguimientoObservadosDA();
        // Adiciona SeguimientoObservados
        public bool AdicionarSeguimientoObservados(int iIdConexion, string cOperacion, Int64 tram, int ben, int tipoaccion, int etapa, string nombreint, int hojaruta,string fechahruta, int IdAreaDestino, int fojas, string observacion, int RegistroActivo,Int32 TipoObs,string CodFicha ,ref string sMensajeError)
        {
            bool bAsignacionOK = Datos.AdicionarSeguimientoObservados(iIdConexion, cOperacion, tram, ben, tipoaccion, etapa, nombreint, hojaruta,fechahruta, IdAreaDestino, fojas, observacion, RegistroActivo,TipoObs,CodFicha, ref sMensajeError);
            return bAsignacionOK;
        }
        // Modificar SeguimientoObservados
        public bool ModificarSeguimientoObservados(int iIdConexion, string cOperacion, int form, Int64 tram, int ben, string nombreint, int fojas, string observacion, int RegistroActivo,int iIdTipoAccion, ref string sMensajeError)
        {
            bool bAsignacionOK = Datos.ModificarSeguimientoObservados(iIdConexion, cOperacion, form, tram, ben, nombreint, fojas, observacion, RegistroActivo,iIdTipoAccion, ref sMensajeError);
            return bAsignacionOK;
        }

        public bool ModificarFormularioDocumentos(int iIdConexion, string cOperacion, Int64 tram, int ben, int tipoaccion, int etapa, string nombreint, int hojaruta, string fechahruta, string IdAreaDestino, int fojas, string observacion, int RegistroActivo, Int32 TipoObs,Int32 IdForm, ref string sMensajeError)
        {
            bool bAsignacionOK = Datos.ModificarFormularioDocumentos(iIdConexion, cOperacion, tram, ben, tipoaccion, etapa, nombreint, hojaruta,fechahruta,IdAreaDestino,fojas,observacion,RegistroActivo,TipoObs,IdForm, ref sMensajeError);
            return bAsignacionOK;
        }
        // Elimina SeguimientoObservados
        public bool EliminarSeguimientoObservados(int iIdConexion, string cOperacion, int form, ref string sMensajeError)
        {
             bool bAsignacionOK = Datos.EliminarSeguimientoObservados(iIdConexion, cOperacion, form, ref sMensajeError);
            return bAsignacionOK;
        }
        // Listar SeguimientoObservados
        public List<clsSeguimientoObservados> ListarSeguimientoObservados(Int64 Tramite, int benefi)
        {
            clsSeguimientoObservados p;
            clsSeguimientoObservadosDA permiso = new clsSeguimientoObservadosDA();
            List<clsSeguimientoObservados> ListaClas = new List<clsSeguimientoObservados>();
            using (IDataReader dr = permiso.ListarSeguimientoObservados(Tramite,benefi))
            {
                while (dr.Read())
                {
                    p = new clsSeguimientoObservados();
                    p.IdFormulario = (int)dr["IdFormulario"];
                    p.IdTramite = (Int64)dr["IdTramite"];
                    p.IdGrupoBeneficio = (int)dr["IdGrupoBeneficio"];
                    p.IdTipoAccion = (int)dr["IdTipoAccion"];
                    p.TipoAccion = (string)dr["TipoAccion"];
                    p.IdEtapa = (int)dr["IdEtapa"];
                    p.FechaFormulario = (string)dr["FechaFormulario"];//);.Substring(0, 10);
                    p.NombreInteresado = (string)dr["NombreInteresado"];
                    p.HojaRuta = (int)dr["HojaRuta"];
                    p.Gestion = (string)dr["Gestion"];
                    p.IdAreaDestino = (int)dr["IdAreaDestino"];
                    p.NumeroFojas = (int)dr["NumeroFojas"];
                    p.TextoObservacion = (string)dr["TextoObservacion"];
                    p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }
        // verifica SeguimientoObservados
        public int VerificarSeguimientoObservados(DateTime Fecha, int Resolucion)
        {
            int valor = 0;

            clsSeguimientoObservadosDA permiso = new clsSeguimientoObservadosDA();

            using (IDataReader dr = permiso.VerificarSeguimientoObservados(Fecha, Resolucion))
            {
                while (dr.Read())
                {
                    valor = (int)dr[existedatos];
                }
            }
            return valor;
        }
        // obtener 
        public List<clsSeguimientoObservados> ObtenerSeguimientoObservados(int Cod)
        {
            clsSeguimientoObservados p;
            clsSeguimientoObservadosDA permiso = new clsSeguimientoObservadosDA();
            List<clsSeguimientoObservados> ListaClas = new List<clsSeguimientoObservados>();
            using (IDataReader dr = permiso.ObtenerSeguimientoObservados(Cod))
            {
                while (dr.Read())
                {
                    p = new clsSeguimientoObservados();
                    p.IdFormulario = (int)dr["IdFormulario"];
                    p.IdTramite = (Int64)dr["IdTramite"];
                    p.IdGrupoBeneficio = (int)dr["IdGrupoBeneficio"];
                    p.IdTipoAccion = (int)dr["IdTipoAccion"];
                 //   p.TipoAccion = (string)dr["TipoAccion"];
                    p.IdEtapa = (int)dr["IdEtapa"];
                    p.FechaFormulario = Convert.ToString((DateTime)dr["FechaFormulario"]).Substring(0, 10);
                    p.NombreInteresado = (string)dr["NombreInteresado"];
                    p.HojaRuta = (int)dr["HojaRuta"];
                    p.FechaHojaRuta = (string)dr["FechaHojaRuta"];
                    p.Gestion = (string)dr["Gestion"];
                    p.IdAreaDestino = (int)dr["IdAreaDestino"];
                    p.NumeroFojas = (int)dr["NumeroFojas"];
                //    p.DescripcionDoc = (string)dr["DescripcionDoc"];
                    p.TextoObservacion = (string)dr["TextoObservacion"];
                    p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }
        //Obtener Datos del Beneficiario
        public DataTable DatosBeneficiario(int IdConexion, string cOperacion, Int64 Tramite,Int32 GrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.DatosBeneficiario(IdConexion, cOperacion, Tramite, GrupoB,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable VerificaAcceso(int iIdConexion, string cOperacion, string NoCrentaTramite,int iIdGrupoBeneficio ,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.VerificaAcceso(iIdConexion, cOperacion, NoCrentaTramite,iIdGrupoBeneficio,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        /* LISTA DE ACCIONES */
        public DataTable ListarAcciones(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.ListarAcciones(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable BandejaObservados(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.BandejaObservados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        /* LISTA DE GESTIONES DE CORRESPONDENCIA */
        public DataTable Gestiones(int IdConexion, string cOperacion,  ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.Gestiones(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListaObservaciones(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.ListaObservaciones(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable ListaRegionales(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.ListaRegionales(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        /* LISTADO DE AREAS PARA DERIVACION */
        public DataTable AreasOficina(int IdConexion, string cOperacion,Int32 IdOficina,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.AreasOficina(IdConexion, cOperacion, IdOficina ,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        /* MUESTRA SI EXISTE HOJA DE RUTA */
        public DataTable HojaRutas(int IdConexion, string cOperacion, Int32 Hoja,Int32 Gestion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.HojaRutas(IdConexion, cOperacion, Hoja,Gestion ,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        /* Ver Datos para realizar Moficaciones */
        public DataTable DatosVer(int IdConexion, string cOperacion, Int32 Codigo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.DatosVer(IdConexion, cOperacion, Codigo, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        /* ddl de Tipos de Observaciones */
        public DataTable ddlObservados(int IdConexion, string cOperacion,  ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Datos.ddlObservados(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        
        /* PARA LA IMPRESION DE DATOS */
        public DataTable ImprimirDatos(Int64 IdTramite, Int32 IdGrupoB)
        {
            return Datos.ImprimirDatos(IdTramite, IdGrupoB);
        }

    }

}
