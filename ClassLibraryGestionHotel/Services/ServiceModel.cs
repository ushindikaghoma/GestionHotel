using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.Services
{
    public class ServiceModel
    {
        public int IdService { get; set; }
        public string CodeService { get; set; }
        public string CategorieService { get; set; }
        public string DesignationService { get; set; }
        public string CompteService { get; set; }
        public double TarifService { get; set; }
    }
}
