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

namespace GestionHotel.Windows.Paiement
{
    /// <summary>
    /// Interaction logic for WindowPaiementForm.xaml
    /// </summary>
    public partial class WindowPaiementForm : Window
    {
        IEnumerable<AffectationModel> liste_clients_paiement;
        int position = -1;
        public WindowPaiementForm()
        {
            InitializeComponent();
            ChargerClientsAffectes();
        }

        public void ChargerClientsAffectes()
        {
            AffectationDataAccessLayer affectationDataAccessLayer = new AffectationDataAccessLayer();
            liste_clients_paiement = affectationDataAccessLayer.GetListeAffectation();
            listeview_paiement_client.ItemsSource = liste_clients_paiement;
            listeview_paiement_client.Items.Refresh();
        }

        private void listeview_paiement_client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (listeview_paiement_client.SelectedItems.Count > 0)
            {
                position = listeview_paiement_client.Items.IndexOf(listeview_paiement_client.SelectedItems[0]);

                AffectationModel client_selectionne = liste_clients_paiement.ToList()[position];

                WindowValiderPaiement windowValiderPaiement = new WindowValiderPaiement();

                windowValiderPaiement.txt_details_code_client.Text = client_selectionne.CodeClient.ToString();
                

                windowValiderPaiement.Show();
            }
            else
            {
                MessageBox.Show("Vous devez d'abord selectionner un client");
            }
            
        }

        private void fermerWindowclientaffectes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
