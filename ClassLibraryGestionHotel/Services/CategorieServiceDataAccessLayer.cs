using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Services
{
    public class CategorieServiceDataAccessLayer
    {
        //Add Cat service

        public int SaveCategorieService(CategorieServiceModel categorieServiceModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                connection.Open();

                string requette = "INSERT INTO tCategorieService" +
                            "(DesignationCategorieService)" +
                            "VALUES(@DesignationCategorieService)";
                SqlCommand commande = new SqlCommand(requette, connection);

                commande.Parameters.AddWithValue("@DesignationCategorieService", categorieServiceModel.DesignationCategorieService);

                return commande.ExecuteNonQuery();
            }
        }

        //Get list categorie service

        public List<CategorieServiceModel> GetListeCategorieService()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<CategorieServiceModel> _listeCatServices = new List<CategorieServiceModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tCategorieService";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        CategorieServiceModel objCust = new CategorieServiceModel();

                        objCust.IdCategorieService = Convert.ToInt32(_Reader["IdCategorieService"].ToString());
                        objCust.DesignationCategorieService = _Reader["DesignationCategorieService"].ToString();

                        _listeCatServices.Add(objCust);
                    }

                    return _listeCatServices;
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
