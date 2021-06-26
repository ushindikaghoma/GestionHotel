using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Services
{
    public class ServiceDataAccessLayer
    {
        // Add Service

        public int SaveService(ServiceModel serviceModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                connection.Open();

                string requette = "INSERT INTO tService"+
                         "(CodeService, CategorieService, DesignationService, CompteService, TarifService)"+
                         "VALUES(@CodeService, @CategorieService, @DesignationService, @CompteService, @TarifService)";

                SqlCommand commande = new SqlCommand(requette, connection);

                commande.Parameters.AddWithValue("@CodeService", serviceModel.CodeService );
                commande.Parameters.AddWithValue("@CategorieService", serviceModel.CategorieService );
                commande.Parameters.AddWithValue("@DesignationService", serviceModel.DesignationService );
                commande.Parameters.AddWithValue("@CompteService", serviceModel.CompteService );
                commande.Parameters.AddWithValue("@TarifService", serviceModel.TarifService );

                return commande.ExecuteNonQuery();

            }
        }

        // Get Services

        public List<ServiceModel> GetListeService()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<ServiceModel> _listeServices = new List<ServiceModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tService";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ServiceModel objCust = new ServiceModel();

                        objCust.IdService = Convert.ToInt32(_Reader["IdService"].ToString());
                        objCust.CodeService = _Reader["CodeService"].ToString();
                        objCust.CategorieService = _Reader["CategorieService"].ToString();
                        objCust.DesignationService = _Reader["DesignationService"].ToString();
                        objCust.CompteService = (_Reader["CompteService"].ToString());
                        objCust.TarifService = Convert.ToDouble((_Reader["TarifService"].ToString()));

                        _listeServices.Add(objCust);
                    }

                    return _listeServices;
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

        // Get service suivant le la categorie 

        public List<ServiceModel> GetListeServiceParCategorie(string categorieService)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<ServiceModel> _listeServices = new List<ServiceModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tService where CategorieService = @categorieService";

                    SqlCommand objCommand = new SqlCommand(requette, connection);
                    objCommand.Parameters.AddWithValue("@categorieService", categorieService);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ServiceModel objCust = new ServiceModel();

                        objCust.IdService = Convert.ToInt32(_Reader["IdService"].ToString());
                        objCust.CodeService = _Reader["CodeService"].ToString();
                        objCust.CategorieService = _Reader["CategorieService"].ToString();
                        objCust.DesignationService = _Reader["DesignationService"].ToString();
                        objCust.CompteService = (_Reader["CompteService"].ToString());
                        objCust.TarifService = Convert.ToDouble((_Reader["TarifService"].ToString()));

                        _listeServices.Add(objCust);
                    }

                    return _listeServices;
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

        // Get tarif service suivant le service 

        public List<ServiceModel> GetTarifService(string service)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<ServiceModel> _listeChambre = new List<ServiceModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT TarifService FROM tService where (DesignationService = @service)";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    objCommand.Parameters.AddWithValue("@service", service);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ServiceModel objCust = new ServiceModel();


                        objCust.TarifService = Convert.ToDouble(_Reader["TarifService"].ToString());

                        _listeChambre.Add(objCust);
                    }

                    return _listeChambre;
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
