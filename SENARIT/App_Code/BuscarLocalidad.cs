using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class BuscarLocalidad : System.Web.Services.WebService {

    //constructor
    public BuscarLocalidad () 
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public string[] wsBuscarLocalidad(string prefixText, int count)
    {
        string connstring = ConfigurationManager.ConnectionStrings["cnnGeo"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connstring))
        {
            //SqlCommand comando = new SqlCommand("SELECT TOP(50) NombreLocalidad FROM Geografico.Localidad WHERE NombreLocalidad LIKE '%' + @param + '%' ", con);
            //comando.Parameters.AddWithValue("@param", prefixText.ToUpper());
            
            con.Open();
            SqlCommand comando = new SqlCommand("Seguridad.PR_ListaLocalidad", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@param", prefixText.ToUpper()));
            SqlDataReader dr = default(SqlDataReader);            
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();
            while (dr.Read())
            {
                items.Add(dr["NombreLocalidad"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hola a todos";
    //}
}
