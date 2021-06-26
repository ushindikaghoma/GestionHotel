using ClassLibraryGestionHotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionHotel.Windows.Paiement
{
    /// <summary>
    /// Interaction logic for WindowValiderPaiement.xaml
    /// </summary>
    public partial class WindowValiderPaiement : Window
    {
        public WindowValiderPaiement()
        {
            InitializeComponent();
            ChargerComboCategorieService();
            combo_paiment_service.SelectedIndex = 0;
        }

        public void ChargerComboCategorieService()
        {
            CategorieServiceDataAccessLayer categorieServiceDataAccessLayer = new CategorieServiceDataAccessLayer();

            IEnumerable<CategorieServiceModel> items = categorieServiceDataAccessLayer.GetListeCategorieService();

            ObservableCollection<string> list_combo_categorie_service = new ObservableCollection<string>();

            foreach (CategorieServiceModel item in items)
            {
                list_combo_categorie_service.Add(item.DesignationCategorieService);
            }

            combo_paiment_categorie_service.ItemsSource = list_combo_categorie_service;
        }

        private void btnquitterDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValiderPaiement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void combo_paiment_categorie_service_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_paiment_categorie_service.SelectedIndex >= 0)
            {
                ServiceDataAccessLayer serviceDataAccessLayer = new ServiceDataAccessLayer();

                IEnumerable<ServiceModel> items = serviceDataAccessLayer.GetListeServiceParCategorie(combo_paiment_categorie_service.SelectedItem.ToString());

                ObservableCollection<string> list_combo_service = new ObservableCollection<string>();

                foreach (ServiceModel item in items)
                {
                    list_combo_service.Add(item.DesignationService);
                }

                combo_paiment_service.ItemsSource = list_combo_service;
            }
        }

        private void combo_paiment_service_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_paiment_service.SelectedIndex >=0)
            {
                ServiceDataAccessLayer serviceDataAccessLayer = new ServiceDataAccessLayer();

                IEnumerable<ServiceModel> items = serviceDataAccessLayer.GetTarifService(combo_paiment_service.SelectedItem.ToString());


                foreach (ServiceModel item in items)
                {
                    txt_paiement_tarif_service.Text = item.TarifService.ToString() + "$";
                }
            }
        }
    }
}
