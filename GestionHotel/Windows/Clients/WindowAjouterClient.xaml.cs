using ClassLibraryGestionHotel.Clients;
using GestionHotel.Windows.Clients;
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

namespace GestionHotel.Windows
{
    /// <summary>
    /// Interaction logic for WindowAjouterClient.xaml
    /// </summary>
    public partial class WindowAjouterClient : Window
    {
        int position = -1;
        string code_client = "";
        IEnumerable<ClientModel> liste_clients;
        public WindowAjouterClient()
        {
            InitializeComponent();
            ChargerListeDesClients();
        }


        

        public void ChargerListeDesClients()
        {
            ClientDataAccessLayer chambreDataAccessLayer = new ClientDataAccessLayer();
            liste_clients = chambreDataAccessLayer.GetListeClient();
            listeview_clients.ItemsSource = liste_clients;
            listeview_clients.Items.Refresh();

        }

        private void enregistrer_client_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void fermerWindowClient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listeview_clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //if (listeview_clients.SelectedItems.Count > 0)
            //{
            //    position = listeview_clients.Items.IndexOf(listeview_clients.SelectedItems[0]);

            //    ClientModel client_selectionne = liste_clients.ToList()[position];

            //    code_client = client_selectionne.CodeClient;
            //}

            //WindowAffectation windowAffectation = new WindowAffectation();
            //windowAffectation.txt_displayCodeClient.Text = code_client;
            //windowAffectation.Show();
        }

        private void btn_ajouterClient_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowFormAddClient windowFormAddClient = new WindowFormAddClient();
            windowFormAddClient.Show();
        }

        private void btn_affecter_client_Click(object sender, RoutedEventArgs e)
        {

            if (listeview_clients.SelectedItems.Count > 0)
            {
                position = listeview_clients.Items.IndexOf(listeview_clients.SelectedItems[0]);

                ClientModel client_selectionne = liste_clients.ToList()[position];

                WindowAffectation affectation = new WindowAffectation();
                affectation.txt_displayCodeClient.Text = client_selectionne.CodeClient;
                affectation.Show();
            }
            else
            { 
                MessageBox.Show("Vous devez d'abord selectionner un client");
            }
        }
    }
}
