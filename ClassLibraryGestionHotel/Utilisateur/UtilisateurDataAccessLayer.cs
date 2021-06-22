using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Utilisateur
{
    public class UtilisateurDataAccessLayer
    {
        // Methode enregistrer utilisateur

        public int SaveUtilisateur(UtilisateurModel utilisateurModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                connection.Open();

                string requette = "INSERT INTO tUtilisateur"+
                         "(NomUtilisateur, MotdepasseUtilisateur, FonctionUtilisateur, ServiceaffecteUtilisateur)"+
                          "VALUES(@NomUtilisateur, @MotdepasseUtilisateur, @FonctionUtilisateur, @ServiceaffecteUtilisateur)";

                SqlCommand commande = new SqlCommand(requette, connection);

                commande.Parameters.AddWithValue("@NomUtilisateur", utilisateurModel.NomUtilisateur );
                commande.Parameters.AddWithValue("@MotdepasseUtilisateur", utilisateurModel.MotdepasseUtilisateur );
                commande.Parameters.AddWithValue("@FonctionUtilisateur", utilisateurModel.FonctionUtilisateur );
                commande.Parameters.AddWithValue("@ServiceaffecteUtilisateur", utilisateurModel.ServiceaffecteUtilisateur );

                return commande.ExecuteNonQuery();
            }
        }

        // Methode pour selectionner tous les utilisateurs

        public List<UtilisateurModel> GetListeUtilisateur()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<UtilisateurModel> _listeUtilisateur = new List<UtilisateurModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tUtilisateur";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        UtilisateurModel objCust = new UtilisateurModel();

                        objCust.IdUtilisareur = Convert.ToInt32(_Reader["IdUtilisareur"].ToString());
                        objCust.NomUtilisateur = _Reader["NomUtilisateur"].ToString();
                        objCust.MotdepasseUtilisateur = _Reader["MotdepasseUtilisateur"].ToString();
                        objCust.FonctionUtilisateur = _Reader["FonctionUtilisateur"].ToString();
                        objCust.ServiceaffecteUtilisateur = (_Reader["ServiceaffecteUtilisateur"].ToString());

                        _listeUtilisateur.Add(objCust);
                    }

                    return _listeUtilisateur;
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

        // Methode pour se connecter 

        // 
        public int GetUserLogin(string userName, string userPassword)
        {

            SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection());
            connection.Open();



            try
            {
                int result = 0;
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                string requette = "SELECT COUNT(1) FROM tUtilisateur where" +
                                    " (NomUtilisateur = @userName and MotdepasseUtilisateur = @userPassword)";

                SqlCommand objCommand = new SqlCommand(requette, connection);
                objCommand.CommandType = CommandType.Text;
                objCommand.Parameters.AddWithValue("@userName", userName);
                objCommand.Parameters.AddWithValue("@userPassword", userPassword);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 1;
                }

                //return objCommand.ExecuteNonQuery();
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
