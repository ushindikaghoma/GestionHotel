using System;
using System.Collections.Generic;
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
    /// Interaction logic for WindowDetailsClient.xaml
    /// </summary>
    public partial class WindowDetailsClient : Window
    {
        public WindowDetailsClient()
        {
            InitializeComponent();
        }

        private void btnquitterDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
