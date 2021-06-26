using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.Operation
{
    public class DetailsOperationModel
    {
        public int NumCompte { get; set; }
        public string DesignationCompte { get; set; }
        public string NumOperation { get; set; }
        public double Qte { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
    }
}
