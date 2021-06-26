using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Operation
{
    public class OperationDataAccessLayer
    {
        public int GetDerniereOperation()
        {
            int ID = 1;
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    Conn.Open();

                    if (Conn.State != ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT MAX(NumOpSource) + 1 AS NumOpSource FROM tOperation";
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ID = Convert.ToInt32(_Reader["NumOpSource"]);
                    }

                    return ID;
                }
                catch
                {
                    //throw;
                    return 1;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
                    }

                }
        }

        public int EnregistrerOperation(OperationModel tbl)
        {
            using (SqlConnection con = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                con.Open();

                string query = "INSERT INTO tOperation(NumOperation,CodeEleve,CodeLibele,Libelle,DateOp,NomUt,CodeAnnee,DateSysteme) VALUES (@a,@b,@c,@d,@e,@f,@g,@h)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@a", tbl.NumOperation);
                cmd.Parameters.AddWithValue("@b", tbl.CodeClient);
                cmd.Parameters.AddWithValue("@c", tbl.CodeLibele);
                cmd.Parameters.AddWithValue("@d", tbl.Libelle);
                cmd.Parameters.AddWithValue("@e", tbl.DateOperation);
                cmd.Parameters.AddWithValue("@f", tbl.NomUtilisateur);
                cmd.Parameters.AddWithValue("@h", tbl.DateSysteme);
                return cmd.ExecuteNonQuery();
            }
        }

        public int AjouterOperation(OperationModel Op)
        {
            try
            {
                string s = "INSERT INTO tOperation" +
                                " (NumOperation, Libelle,  CodeEleve,CodeLibele,NomUt,CodeAnnee,CodeSourceFinacement,DateOp, DateSysteme) " +
                                " VALUES(@a, @b, @c, @d,@e,@f,@g, @da, @db)";

                string[] r = { Op.NumOperation, Op.Libelle, Op.CodeClient, Op.CodeLibele, Op.NomUtilisateur, Op.CodeSourceFinacement };

                DateTime[] d = { Op.DateOperation, DateTime.Now };
                ClasseRequette req = new ClasseRequette();

                req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnection(), s, r, d);
                return 1;
            }

            catch
            {
                return 0;
            }



        }


        public int SupprimmeerOperation(string Op)
        {
            string s = "delete FROM tOperation " +
                " WHERE NumOperation=@a  ";


            string[] r = { Op };


            DateTime[] d = { DateTime.Now };
            ClasseRequette req = new ClasseRequette();

            req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnection(), s, r, d);
            return 1;
        }

        public int DernierOperation()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    Conn.Open();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    int dernier_operation = 0;
                    string s = "select ISNULL(max(NumOpSource), 0) as NumOpSource from tOperation";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    //SqlDataReader _Reader = objCommand.ExecuteReader();

                    //while (_Reader.Read())
                    //{
                    //            dernier_operation = Convert.ToInt32(_Reader["dernierOperation"]);
                    //}
                    dernier_operation = int.Parse(objCommand.ExecuteScalar().ToString()) + 1;

                    return dernier_operation;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
                    }
                }
        }



        public List<DetailsOperationModel> DetailleDuneOperation(string NumeOP)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    Conn.Open();
                    List<DetailsOperationModel> _list = new List<DetailsOperationModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();


                    String s1 = "SELECT tCompte.NumCompte, tCompte.DesignationCompte, tOperation.NumOperation," +
                        " tMvtCompte.Qte, tMvtCompte.Entree, tMvtCompte.Sortie, tCompte.Solde " +
                         " FROM tMvtCompte INNER JOIN " +
                         " tOperation ON tMvtCompte.NumOperation = tOperation.NumOperation INNER JOIN " +
                         " tCompte ON tMvtCompte.NumCompte = tCompte.NumCompte " +
                            " WHERE(tOperation.NumOperation = @a)";

                    SqlCommand objCommand = new SqlCommand(s1, Conn);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.Parameters.AddWithValue("@a", NumeOP);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        DetailsOperationModel objCust = new DetailsOperationModel();
                        objCust.NumCompte = Convert.ToInt32(_Reader["NumCompte"]);

                        objCust.NumOperation = _Reader["NumOperation"].ToString();
                        objCust.DesignationCompte = _Reader["DesignationCompte"].ToString();


                        objCust.Debit = Convert.ToDouble(_Reader["Entree"]);
                        objCust.Credit = Convert.ToDouble(_Reader["Sortie"]);


                        //objCust.Autre = _Reader["Autre"].ToString();

                        _list.Add(objCust);
                    }

                    return _list;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
                    }
                }
        }
    }
}
