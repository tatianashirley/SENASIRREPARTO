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

using wcfPersonal.Entidades;
using wcfPersonal.Datos;

namespace wcfPersonal.Logica
{
    public class clsPrueba : clsPruebaBE
    {
        public List<clsPrueba> _ListarTodos()
        {
            clsPrueba p;
            clsPruebaDA permiso = new clsPruebaDA();
            List<clsPrueba> ListaPermiso = new List<clsPrueba>();
            using (IDataReader dr = permiso._ListarTodos())
            {
                while (dr.Read())
                {
                    p = new clsPrueba();

                    p.carnet = (string)dr["carnet"];
                    p.complementoSEGIP = (string)dr["complementoSEGIP"];
                    p.nua = (string)dr["nua"];
                    p.paterno = (string)dr["paterno"];
                    p.materno = (string)dr["materno"];
                    p.nombres = (string)dr["nombres"];
                    p.casada = (string)dr["casada"];
                    p.fechanacimiento = (DateTime)dr["fechanacimiento"];
                    p.habilitado = (string)dr["habilitado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }


        public List<clsPrueba> _ListarPorDatos(string paterno, string materno, string nombre1, string nombre2, string carnet, string fechanac, string presicion)
        {
            clsPrueba p;
            clsPruebaDA permiso = new clsPruebaDA();
            List<clsPrueba> ListaPermiso = new List<clsPrueba>();
            using (IDataReader dr = permiso._ListarPorDatos(paterno, materno, nombre1, nombre2, carnet, fechanac, presicion))
            {
                while (dr.Read())
                {
                    p = new clsPrueba();

                    p.carnet = (string)dr["carnet"];

                    if (p.complementoSEGIP == null)
                    {
                        p.complementoSEGIP = "";
                    }
                    else
                    { 
                        p.complementoSEGIP = (string)dr["complementoSEGIP"];
                    }

                    if (p.nua == null)
                    {
                        p.nua = "";
                    }
                    else
                    { 
                        p.nua = (string)dr["nua"];
                    }

                    p.paterno = (string)dr["paterno"];
                    p.materno = (string)dr["materno"];
                    p.nombres = (string)dr["nombres"];

                    if (p.casada == null)
                    {
                        p.casada = "";
                    }
                    else
                    {
                        p.casada = (string)dr["casada"];
                    }

                    if (p.fechanacimiento == null)
                    {
                        p.fechanacimiento = Convert.ToDateTime("10/10/2010");
                    }
                    else
                    {
                        p.fechanacimiento = (DateTime)dr["fechanacimiento"];
                    }

                    p.habilitado = (string)dr["habilitado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public List<clsPrueba> _ListarPorCI(string CI)
        {
            clsPrueba p;
            clsPruebaDA permiso = new clsPruebaDA();
            List<clsPrueba> ListaPermiso = new List<clsPrueba>();
            using (IDataReader dr = permiso._ListarPorCI(CI))
            {
                while (dr.Read())
                {
                    p = new clsPrueba();

                    p.carnet = (string)dr["carnet"];
                    if (p.complementoSEGIP == null)
                    {
                        p.complementoSEGIP = "";
                    }
                    else
                    {
                        p.complementoSEGIP = (string)dr["complementoSEGIP"];
                    }

                    if (p.nua == null)
                    {
                        p.nua = "";
                    }
                    else
                    {
                        p.nua = (string)dr["complementoSEGIP"];
                    }
                    p.paterno = (string)dr["paterno"];
                    p.materno = (string)dr["materno"];
                    p.nombres = (string)dr["nombres"];

                    if (p.casada == null)
                    {
                        p.casada = "";
                    }
                    else
                    {
                        p.casada = (string)dr["casada"];
                    }

                    if (p.fechanacimiento == null)
                    {
                        p.fechanacimiento = Convert.ToDateTime("10/10/2010");
                    }
                    else
                    {
                        p.fechanacimiento = (DateTime)dr["fechanacimiento"];
                    }

                    p.habilitado = (string)dr["habilitado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

    }


 }