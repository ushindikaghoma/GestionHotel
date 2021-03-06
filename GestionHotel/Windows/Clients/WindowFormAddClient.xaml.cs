using ClassLibraryGestionHotel.Clients;
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

namespace GestionHotel.Windows.Clients
{
    /// <summary>
    /// Interaction logic for WindowFormAddClient.xaml
    /// </summary>
    public partial class WindowFormAddClient : Window
    {
        public WindowFormAddClient()
        {
            InitializeComponent();
            ChargerComboACategorieClient();
        }

        public void ChargerComboACategorieClient()
        {
            CategorieClientDataAccessLayer categorieDataAccessLayer = new CategorieClientDataAccessLayer();

            IEnumerable<CategorieClientModel> items = categorieDataAccessLayer.GetCategorieClient();

            ObservableCollection<string> list_categorie_combo = new ObservableCollection<string>();

            foreach (CategorieClientModel item in items)
            {
                list_categorie_combo.Add(item.DesignationCategorieClient);
            }

            categorie_client_combo.ItemsSource = list_categorie_combo;
        }

        public void EnregistrerCLient()
        {
            ClientDataAccessLayer clientDataAccessLayer = new ClientDataAccessLayer();
            ClientModel clientModel = new ClientModel();

            clientModel.NomClient = NomClient_txt.Text;
            clientModel.PostnomClient = PostnomClient_txt.Text;
            clientModel.PrenomClient = PrenomClient_txt.Text;
            clientModel.TelephoneClient = TelephoneClient_txt.Text;
            clientModel.EmailClient = EmailClient_txt.Text;
            clientModel.CompteClient = "compte";
            clientModel.CategorieClient = categorie_client_combo.SelectedItem.ToString();

            int insertion = clientDataAccessLayer.SaveClient(clientModel);

            if (insertion == 1)
            {
                MessageBox.Show("Client enregistré avec succès");

                NomClient_txt.Text = "";
                PostnomClient_txt.Text = "";
                PrenomClient_txt.Text = "";
                TelephoneClient_txt.Text = "";
                EmailClient_txt.Text = "";

            }
            else
            {
                MessageBox.Show("Echec d'enregistrement");
            }
        }

        private void categorie_client_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void enregistrer_client_Click(object sender, RoutedEventArgs e)
        {
            EnregistrerCLient();
        }

        private void fermerWindowClient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
