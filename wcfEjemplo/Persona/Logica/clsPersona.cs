using System;
using System.Data;
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

using wcfEjemplo.Entidades;
using wcfEjemplo.Datos;
using System.Text.RegularExpressions;

namespace wcfEjemplo.Logica
{
    public class clsPersona : clsPersonaBE
    {
        public List<clsPersona> ListarPersona(string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, int Pagina, int Rango)
        {
            clsPersona p;
            clsPersonaDA persona = new clsPersonaDA();
            List<clsPersona> ListaPersona = new List<clsPersona>();

            using (IDataReader dr = persona.ListarPersona())
            {
                while (dr.Read())
                {
                    p = new clsPersona();
                    
                    //p.NUP = (Int64)dr["NUP"];
                    //p.NUPReferencia = (Int64)dr["NUPReferencia"];
                    //p.IdTipoDocumento = (Int64)dr["IdTipoDocumento"];
                    //p.IdEstadoCivil = (Int64)dr["IdEstadoCivil"];
                    //p.IdEntidadGestora = (Int64)dr["IdEntidadGestora"];
                    //p.IdRegional = (Int64)dr["IdRegional"];
                    //p.IdSexo = (Int64)dr["IdSexo"];
                    //p.CUA = (Int64)dr["CUA"];
                    //p.Matricula = (string)dr["Matricula"];
                    //p.NUB = (Int64)dr["NUB"];

                    //p.NumeroDocumento = (string)dr["NumeroDocumento"];
                    //p.ComplementoSEGIP = (string)dr["ComplementoSEGIP"];
                    //p.DocumentoExpedido = (string)dr["DocumentoExpedido"];
                    
                    p.PrimerNombre = (string)dr["PrimerNombre"];
                    p.SegundoNombres = (string)dr["SegundoNombres"];
                    p.PrimerApellido = (string)dr["PrimerApellido"];
                    p.SegundoApellido = (string)dr["SegundoApellido"];
                    p.ApellidoCasada = (string)dr["ApellidoCasada"];
                    
                    //p.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                    //p.FechaFallecimiento = (DateTime)dr["FechaFallecimiento"];
                    //p.Huellas = (string)dr["Huellas"];
                    
                    //p.Usuario = (string)dr["Usuario"];
                    //p.FechaCreacion = (DateTime)dr["FechaCreacion"];
                    //p.UsuarioOperacion = (string)dr["UsuarioOperacion"];
                    //p.FechaOperacion = (DateTime)dr["FechaOperacion"];
                    //p.EstadoRegistro = (bool)dr["EstadoRegistro"];

                    ListaPersona.Add(p);
                }
            }
            return ListaPersona;
        }

        public void AdicionarPersona(int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
        {
            try
            {
                clsPersonaDA adi = new clsPersonaDA();
                adi.AdicionarPersona(IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EliminarPersona(int Cod)
        {
            clsPersonaDA eliR = new clsPersonaDA();
            return eliR.EliminarPersona(Cod);
        }

        public void ModificarPersona(int Cod, int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
        {
            try
            {
                clsPersonaDA cb = new clsPersonaDA();
                cb.ModificarPersona(Cod, IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Obtiene los datos de las personas mediante el NUP, que dependiendo el caso, será NUP, CUA ó Matrícula
        public List<clsPersona> ObtenerPersona(Int64 NUP, string Tipo, string Matricula)
        {
            clsPersonaDA permiso = new clsPersonaDA();
            List<clsPersona> ListaPersona = new List<clsPersona>();
            using (IDataReader dr = permiso.ObtenerPersona(NUP, Tipo, Matricula))
            {
                ListaPersona = VerificarCargar(dr);                
            }
            return ListaPersona;
        }


        private List<clsPersona> VerificarCargar(IDataReader dr)
        {
            List<clsPersona> ListaPersona = new List<clsPersona>();
            clsPersona p;
            while (dr.Read())
            {
                p = new clsPersona();

                if (!DBNull.Value.Equals(dr["NUP"]))
                    p.NUP = (Int64)dr["NUP"];
                else
                    p.NUP = 0;

                if (!DBNull.Value.Equals(dr["IdTipoDocumento"]))
                    p.IdTipoDocumento = (int)dr["IdTipoDocumento"];
                else
                    p.IdTipoDocumento = 0;

                if (!DBNull.Value.Equals(dr["IdEstadoCivil"]))
                    p.IdEstadoCivil = (int)dr["IdEstadoCivil"];
                else
                    p.IdEstadoCivil = 0;

                if (!DBNull.Value.Equals(dr["IdEntidadGestora"]))
                    p.IdEntidadGestora = (int)dr["IdEntidadGestora"];
                else
                    p.IdEntidadGestora = 0;

                //if (!DBNull.Value.Equals(dr["IdRegional"]))
                //    p.IdRegional = (int)dr["IdRegional"];
                //else
                //    p.IdRegional = 0;

                if (!DBNull.Value.Equals(dr["IdSexo"]))
                    p.IdSexo = (int)dr["IdSexo"];
                else
                    p.IdSexo = 0;

                if (!DBNull.Value.Equals(dr["CUA"]))
                    p.CUA = (Int64)dr["CUA"];
                else
                    p.CUA = 0;

                if (!DBNull.Value.Equals(dr["Matricula"]))
                    p.Matricula = (string)dr["Matricula"];
                else
                    p.Matricula = "";

                if (!DBNull.Value.Equals(dr["NUB"]))
                    p.NUB = (Int64)dr["NUB"];
                else
                    p.NUB = 0;

                if (!DBNull.Value.Equals(dr["NumeroDocumento"]))
                    p.NumeroDocumento = (string)dr["NumeroDocumento"];
                else
                    p.NumeroDocumento = "";

                if (!DBNull.Value.Equals(dr["ComplementoSEGIP"]))
                    p.ComplementoSEGIP = (string)dr["ComplementoSEGIP"];
                else
                    p.ComplementoSEGIP = "";

                //if (!DBNull.Value.Equals(dr["DocumentoExpedido"]))
                //    p.DocumentoExpedido = (Int64)dr["DocumentoExpedido"];
                //else
                //    p.DocumentoExpedido = 0;

                if (!DBNull.Value.Equals(dr["PrimerNombre"]))
                {
                    p.PrimerNombre = (string)dr["PrimerNombre"];
                    if (p.PrimerNombre.LastIndexOf(" ") > 0)
                    {

                        if (!DBNull.Value.Equals(dr["SegundoNombres"]))
                            p.SegundoNombres = (string)dr["SegundoNombres"];
                        else
                            p.SegundoNombres = String.Empty;

                        int espacio = p.PrimerNombre.LastIndexOf(" ");
                        int longitud = p.PrimerNombre.Length;
                        if (espacio + 2 < longitud)
                        {
                            p.SegundoNombres = p.SegundoNombres + ' ' + p.PrimerNombre.Substring(espacio + 1, longitud - (espacio + 1));
                            p.PrimerNombre = p.PrimerNombre.Substring(0, espacio);
                        }
                    }
                    else
                    {
                        if (!DBNull.Value.Equals(dr["SegundoNombre"]))
                            p.SegundoNombres = (string)dr["SegundoNombre"];
                        else
                            p.SegundoNombres = String.Empty;
                    }

                }
                else
                {
                    p.PrimerNombre = String.Empty;
                    p.SegundoNombres = String.Empty;
                }

                if (!DBNull.Value.Equals(dr["PrimerApellido"]))
                    p.PrimerApellido = (string)dr["PrimerApellido"];
                else
                    p.PrimerApellido = "";

                if (!DBNull.Value.Equals(dr["SegundoApellido"]))
                    p.SegundoApellido = (string)dr["SegundoApellido"];
                else
                    p.SegundoApellido = "";

                if (!DBNull.Value.Equals(dr["ApellidoCasada"]))
                    p.ApellidoCasada = (string)dr["ApellidoCasada"];
                else
                    p.ApellidoCasada = "";

                if (!DBNull.Value.Equals(dr["FechaNacimiento"]))
                    p.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                else
                    p.FechaNacimiento = DateTime.MinValue;

                if (!DBNull.Value.Equals(dr["FechaFallecimiento"]))
                    p.FechaFallecimiento = (DateTime)dr["FechaFallecimiento"];
                else
                    p.FechaFallecimiento = DateTime.MinValue;

                ListaPersona.Add(p);
            }
            return ListaPersona;
        }

        public List<clsPersona> EncontrarPersona(string Nombre1, string Nombre2, string PrimerApellido, string SegundoApellido,
           string NumeroDocumento, string FechaNacimiento, string Presicion)
        {
            clsPersonaDA permiso = new clsPersonaDA();
            string[] datos = new string[7];
            datos[0] = PrimerApellido;
            datos[1] = SegundoApellido;
            datos[2] = Nombre1;
            datos[3] = Nombre2;
            datos[4] = NumeroDocumento;
            datos[5] = FechaNacimiento;
            datos[6] = Presicion;
            IDataReader dr = permiso.EncontrarPersona(datos);
            List<clsPersona> ListaPersona1 = new List<clsPersona>();
            List<clsPersona> ListaPersona = GeneraListado(dr, ListaPersona1);
            return ListaPersona;
        }

        public List<clsPersona> EncontrarPersonaCI(string NumeroDocumento)
        {
            clsPersonaDA permiso = new clsPersonaDA();
            IDataReader dr = permiso.EncontrarPersonaCI(NumeroDocumento);
            List<clsPersona> ListaPersona1 = new List<clsPersona>();
            List<clsPersona> ListaPersona = GeneraListado(dr, ListaPersona1);            
            return ListaPersona;
        }

        public List<clsPersona> ValidarRepetidos(string Nombre1, string Nombre2, string PrimerApellido, string SegundoApellido,
           string NumeroDocumento, string FechaNacimiento, string Presicion, string Matricula, string CUA, string Tabla)
        {
            clsFormatoFecha f = new clsFormatoFecha();
            clsPersonaDA permiso = new clsPersonaDA();
            string[] datos = new string[9];
            datos[0] = PrimerApellido;
            datos[1] = SegundoApellido;
            datos[2] = Nombre1;
            datos[3] = Nombre2;
            datos[4] = NumeroDocumento;
            datos[5] = f.FechaBD(Convert.ToDateTime(FechaNacimiento));
            datos[6] = Presicion;
            datos[7] = Matricula;
            datos[8] = CUA;
            List<clsPersona> ListaPersonaCC = new List<clsPersona>();

            IDataReader dr = permiso.ValidarReparto(datos);
            List<clsPersona> ListaPersonaReparto = GeneraListado(dr, ListaPersonaCC);

            IDataReader drCC = permiso.ValidarCC(datos);
            ListaPersonaCC = GeneraListado(drCC, ListaPersonaReparto);

            IDataReader drRep = permiso.ValidarRepartoAprox(datos);
            List<clsPersona> ListaPersona1 = GeneraListado(drRep, ListaPersonaCC);

            IDataReader drAutomatico = permiso.AutomaticoRepetido(Matricula);
            List<clsPersona> ListaPersonaAutomatico = GeneraListado(drAutomatico, ListaPersona1);

            IDataReader drPermisoManual = permiso.PermisoManual(Matricula);
            List<clsPersona> ListaPersonaFinal = GeneraListado(drPermisoManual, ListaPersonaAutomatico);

            return ListaPersonaFinal;            
        }

        private List<clsPersona> GeneraListado(IDataReader dr, List<clsPersona> ListaPersonaRecibido)
        {
            clsPersona p;
            List<clsPersona> ListaPersona;
            if (ListaPersonaRecibido.Count > 0)
                ListaPersona = ListaPersonaRecibido;
            else
                ListaPersona = new List<clsPersona>();

            using (dr)
            {
                while (dr.Read())
                {
                    p = new clsPersona();

                    if (!DBNull.Value.Equals(dr["nua"]))
                    {

                        if (!DBNull.Value.Equals(dr["matricula"]))
                            p.Matricula = (string)dr["matricula"];
                        else
                            p.Matricula = String.Empty;

                        if (dr["nua"] != "")
                        {
                            string NUA = (string)dr["nua"];
                            if(NUA.Contains("R") == false)
                            //Regex reg = new Regex("[0-9]");
                            //if (reg.IsMatch(NUA) == true)
                                p.CUA = Convert.ToInt64(NUA);
                            else
                            {
                                string Cadena = string.Empty;
                                Cadena = NUA.Substring(1);
                                p.CUA = Convert.ToInt64(Cadena);
                            }
                        }
                        else
                            p.CUA = 0;
                    }
                    else
                        p.CUA = 0;

                    if (!DBNull.Value.Equals(dr["carnet"]))
                        p.NumeroDocumento = (string)(dr["carnet"]);
                    else
                        p.NumeroDocumento = String.Empty;

                    if (!DBNull.Value.Equals(dr["nombres"]))
                    {
                        p.PrimerNombre = (string)dr["nombres"];
                        if (p.PrimerNombre.LastIndexOf(" ") > 0)
                        {
                            int espacio = p.PrimerNombre.LastIndexOf(" ");
                            int longitud = p.PrimerNombre.Length;
                            if (espacio + 2 < longitud)
                            {
                                p.SegundoNombres = p.SegundoNombres + ' ' + p.PrimerNombre.Substring(espacio + 1, longitud - (espacio + 1));
                                p.PrimerNombre = p.PrimerNombre.Substring(0, espacio);
                            }
                            else
                                p.SegundoNombres = String.Empty;
                        }
                        else
                            p.SegundoNombres = String.Empty;

                    }

                    if (!DBNull.Value.Equals(dr["paterno"]))
                        p.PrimerApellido = (string)dr["paterno"];
                    else
                        p.PrimerApellido = String.Empty;

                    if (!DBNull.Value.Equals(dr["materno"]))
                        p.SegundoApellido = (string)dr["materno"];
                    else
                        p.SegundoApellido = String.Empty;

                    if (!DBNull.Value.Equals(dr["casada"]))
                        p.ApellidoCasada = (string)dr["casada"];
                    else
                        p.ApellidoCasada = String.Empty;

                    if (!DBNull.Value.Equals(dr["fechanacimiento"]))
                        p.FechaNacimiento = (DateTime)dr["fechanacimiento"];
                    else
                        p.FechaNacimiento = DateTime.MinValue;

                    if (!DBNull.Value.Equals(dr["complementoSEGIP"]))
                        p.ComplementoSEGIP = (string)dr["complementoSEGIP"];
                    else
                        p.ComplementoSEGIP = String.Empty;

                    if (!DBNull.Value.Equals(dr["Habilitado"]))
                    {
                        p.PrestacionHabilitada = (string)dr["Habilitado"];
                        if (p.PrestacionHabilitada.Contains("AUTOMÁTICO"))
                            p.Color = "Red";
                        else
                            p.Color = "Blue";
                    }
                    else
                        p.PrestacionHabilitada = String.Empty;

                    if (!DBNull.Value.Equals(dr["Tabla"]))
                        p.Tabla = (string)dr["Tabla"];
                    else
                        p.Tabla = String.Empty;

                    if (!DBNull.Value.Equals(dr["Igualdad"]))
                        p.Igualdad = (string)dr["Igualdad"];
                    else
                        p.Igualdad = String.Empty;


                    ListaPersona.Add(p);
                }
            }
            return ListaPersona;
        }

        public List<clsPersona> EncontrarAutomaticoCI(string NumeroDocumento)
        {
            clsPersonaDA permiso = new clsPersonaDA();
            List<clsPersona> ListaPersona = new List<clsPersona>();
            using (IDataReader dr = permiso.EncontrarAutomaticoCI(NumeroDocumento))
            {
                ListaPersona = VerificarCargar(dr);
            }
            return ListaPersona;
        }

        public List<clsPersona> EncontrarAutomatico(string Nombre1, string Nombre2, string PrimerApellido, string SegundoApellido, string NumeroDocumento, string FechaNacimiento, string Presicion)
        {
            clsPersonaDA permiso = new clsPersonaDA();
            string[] datos = new string[7];
            datos[0] = PrimerApellido;
            datos[1] = SegundoApellido;
            datos[2] = Nombre1;
            datos[3] = Nombre2;
            datos[4] = NumeroDocumento;
            datos[5] = FechaNacimiento;
            datos[6] = Presicion;
            List<clsPersona> ListaPersona = new List<clsPersona>();
            using (IDataReader dr = permiso.EncontrarAutomatico(datos))
            {
                ListaPersona = VerificarCargar(dr);
            }
            return ListaPersona;
        }

        public void RenunciaAutomatico(string NUP)
        {
            clsPersonaDA p = new clsPersonaDA();
            p.RenunciaAutomatico(NUP);
        }
    }
}