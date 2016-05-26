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
public class BuscarPersonas : System.Web.Services.WebService {

    //constructor
    public BuscarPersonas () 
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public string[] wsBuscarPersonas(string prefixText)
    {
        //string connstring = ConfigurationManager.ConnectionStrings["cnnPersonal"].ConnectionString;
        string connstring = ConfigurationManager.ConnectionStrings["cnnstr"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connstring))
        {
            //SqlCommand comando = new SqlCommand("SELECT TOP(50) NombreCompleto FROM vPersonal WHERE NombreCompleto LIKE '%' + @param + '%'", con);
            SqlCommand comando = new SqlCommand("SELECT TOP(50) NombrePersona FROM vUsuario WHERE NombrePersona LIKE '%' + @param + '%'", con);
            comando.Parameters.AddWithValue("@param", prefixText.ToUpper());
            SqlDataReader dr = default(SqlDataReader); comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();
            while (dr.Read())
            {
                //items.Add(dr["NombreCompleto"].ToString());
                items.Add(dr["NombrePersona"].ToString());
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
