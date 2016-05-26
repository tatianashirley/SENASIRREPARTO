using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wcfGeo.Logica;

public partial class BusquedaParametrica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarComboDepartamentos();
            CargarComboProvincias();
            CargarComboSecciones();
            CargarComboLocalidades();
        }
    }

    protected void CargarComboDepartamentos()
    {
        clsGeo admi = new clsGeo();
        ddlDep.DataSource = admi.ListarDepartamentosV();
        ddlDep.DataValueField = "IdDepartamento";
        ddlDep.DataTextField = "NombreDepartamento";
        ddlDep.DataBind();
    }

    protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarComboProvincias();
        CargarComboSecciones();
        CargarComboLocalidades();
    }

    protected void CargarComboProvincias()
    {
        clsGeo admi = new clsGeo();
        ddlProv.DataSource = admi.ListarProvinciasV(Convert.ToInt32(ddlDep.SelectedValue));
        ddlProv.DataValueField = "IdProvincia";
        ddlProv.DataTextField = "NombreProvincia";
        ddlProv.DataBind();
    }

    protected void ddlProv_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarComboSecciones();
        CargarComboLocalidades();
    }

    protected void CargarComboSecciones()
    {
        clsGeo admi = new clsGeo();
        ddlSec.DataSource = admi.ListarSeccionesV(Convert.ToInt32(ddlDep.SelectedValue), Convert.ToInt32(ddlProv.SelectedValue));
        ddlSec.DataValueField = "IdSeccion";
        ddlSec.DataTextField = "NombreSeccionMunicipal";
        ddlSec.DataBind();
    }
    protected void ddlSec_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarComboLocalidades();
    }
    protected void CargarComboLocalidades()
    {
        clsGeo admi = new clsGeo();
        ddlLoc.DataSource = admi.ListarLocalidadesV(Convert.ToInt32(ddlDep.SelectedValue), Convert.ToInt32(ddlProv.SelectedValue), Convert.ToInt32(ddlSec.SelectedValue));
        ddlLoc.DataValueField = "IdLocalidad";
        ddlLoc.DataTextField = "NombreLocalidad";
        ddlLoc.DataBind();
    }
}