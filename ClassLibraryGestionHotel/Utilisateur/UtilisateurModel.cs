using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.Utilisateur
{
    public class UtilisateurModel
    {
        public int IdUtilisareur { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotdepasseUtilisateur { get; set; }
        public string FonctionUtilisateur { get; set; }
        public string ServiceaffecteUtilisateur { get; set; }
    }
}
