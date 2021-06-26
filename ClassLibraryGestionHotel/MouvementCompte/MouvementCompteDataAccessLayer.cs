using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.MouvementCompte
{
    public class MouvementCompte
    {
        public int AjouterMvtCompte(MouvementCompteModel MvtC)
        {
            try
            {
                string s = " INSERT INTO tMvtCompte " +
                "(NumCompte, NumOperation, Details, Qte, Entree, Sortie,CodeLibele) " +
                "VALUES(@a, @b, @c, @d, @e, @f,@g)";

                string[] r = { MvtC.NumCompte, MvtC.NumOperation, MvtC.Details.ToString(),
                MvtC.Qte.ToString(), MvtC.Entree.ToString(), MvtC.Sortie.ToString(),MvtC.CodeLibele };

                DateTime[] d = { };
                ClasseRequette req = new ClasseRequette();

                req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnection(), s, r, d);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;

            }
        }

        public int DernierMvtCompte()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    Conn.Open();
                    int dernier_mvt_compte = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "select max(IdMouvement) as IdMouvement from tMvtCompte";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    dernier_mvt_compte = int.Parse(objCommand.ExecuteScalar().ToString()) + 1;

                    return dernier_mvt_compte;
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
