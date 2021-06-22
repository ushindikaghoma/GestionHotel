using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Clients
{
    public class CategorieClientDataAccessLayer
    {

        // Get les categories clients

        public List<CategorieClientModel> GetCategorieClient()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<CategorieClientModel> _listeCategorieClient = new List<CategorieClientModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tCategorieClient";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        CategorieClientModel objCust = new CategorieClientModel();

                        objCust.IdCategoireClient = Convert.ToInt32(_Reader["IdCategorieClient"].ToString());
                        objCust.DesignationCategorieClient = _Reader["DesignationCategorieClient"].ToString();

                        _listeCategorieClient.Add(objCust);
                    }

                    return _listeCategorieClient;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                    }
                }
        }
    }
}
