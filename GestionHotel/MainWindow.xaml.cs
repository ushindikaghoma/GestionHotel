using ClassLibraryGestionHotel.Utilisateur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionHotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void Connecter()
        {
            UtilisateurDataAccessLayer utilisateurDataAccessLayer = new UtilisateurDataAccessLayer();
            UtilisateurModel utilisateurModel = new UtilisateurModel();


            utilisateurModel.NomUtilisateur = txt_UserName.Text;
            utilisateurModel.MotdepasseUtilisateur = txt_UserPassword.Text;

            int  connecter = utilisateurDataAccessLayer.GetUserLogin(txt_UserName.Text.ToString(), txt_UserPassword.Text.ToString());

            if (connecter == 1)
            {
                this.Close();
                MainWindowMenu mainMenu = new MainWindowMenu();
                mainMenu.Show();

            }
            else
            {
                MessageBox.Show("Echec de connection");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindowMenu mainMenu = new MainWindowMenu();
            mainMenu.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
