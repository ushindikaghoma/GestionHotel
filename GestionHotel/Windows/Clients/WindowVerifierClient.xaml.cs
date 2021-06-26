using ClassLibraryGestionHotel.Affectation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionHotel.Windows.Clients
{
    /// <summary>
    /// Interaction logic for WindowVerifierClient.xaml
    /// </summary>
    public partial class WindowVerifierClient : Window
    {
        IEnumerable<AffectationModel> liste_clients_affectes;
        int position = -1;
        public WindowVerifierClient()
        {
            InitializeComponent();
            ChargerClientsAffectes();
        }

        public void ChargerClientsAffectes()
        {
            AffectationDataAccessLayer affectationDataAccessLayer = new AffectationDataAccessLayer();
            liste_clients_affectes = affectationDataAccessLayer.GetListeAffectation();
            listeview_clients_affectes.ItemsSource = liste_clients_affectes;
            listeview_clients_affectes.Items.Refresh();
        }

        private void fermerWindowclientaffectes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listeview_clients_affectes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listeview_clients_affectes.SelectedItems.Count > 0)
            {
                position = listeview_clients_affectes.Items.IndexOf(listeview_clients_affectes.SelectedItems[0]);

                AffectationModel client_selectionne = liste_clients_affectes.ToList()[position];

                WindowDetailsClient detailsClient = new WindowDetailsClient();
                detailsClient.txt_details_date_affectation.Text = Convert.ToDateTime(client_selectionne.DateAffectation).ToString();
                detailsClient.txt_details_tarif_chambre.Text = Convert.ToDouble(client_selectionne.TarifChambre).ToString()+"$";
                //detailsClient.txt_details_cat_client.Text = client_selectionne.CategorieClient;

                detailsClient.Show();
            }
            else
            {
                MessageBox.Show("Vous devez d'abord selectionner un client");
            }
        }
    }
}
