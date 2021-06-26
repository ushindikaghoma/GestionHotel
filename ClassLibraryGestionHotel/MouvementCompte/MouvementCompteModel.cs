using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.MouvementCompte
{
    public class MouvementCompteModel
    {
        public int IdMouvement { get; set; }
        public string NumCompte { get; set; }
        public string CodeLibele { get; set; }

        public string NumOperation { get; set; }
        public string Details { get; set; }
        public double Qte { get; set; }
        public double Entree { get; set; }
        public double Sortie { get; set; }
    }
}
