using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.Operation
{
    public class OperationModel
    {
        public int NumOpSource { get; set; }
        public string NumOperation { get; set; }
        public string CodeClient { get; set; }
        public string CodeLibele { get; set; }
        public string CodeSourceFinacement { get; set; }
        public string Libelle { get; set; }
        public DateTime DateOperation { get; set; }
        public string NomUtilisateur { get; set; }
        public DateTime DateSysteme { get; set; }
    }
}
