using System;
using System.Data;
using System.Data.SqlClient;  
using System.Collections.Generic;
using System.Text;
using System.Configuration; 

namespace conexion
{
    public class conexion1
    {
        //  declaracion de Atributos
        private string _cnxCadena;
        //-------------------------
        public String cnxCadena
        {
            get
            {
                return _cnxCadena;
            }
            set
            {
                _cnxCadena = value;
            }
        }
        //-------------------------
        //  Definiendo el constructor
        public conexion1()
        {

            cnxCadena = ConfigurationManager.ConnectionStrings["cnnstr"].ToString();
            
        }
       
        //---------------------------------
        #region Management Methods

        /// <summary>
        /// return an Open SqlConnection
        /// </summary>
        public SqlConnection openConnection(string connectionString)
        {
            try
            {
                SqlConnection mySqlConnection = new SqlConnection(connectionString);
                mySqlConnection.Open();
                return mySqlConnection;
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        /// <summary>
        /// close an SqlConnection
        /// </summary>
        public void closeConnection(SqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        #endregion
    }
}
