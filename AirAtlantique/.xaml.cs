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

namespace AirAtlantique
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        

        private void Session_Click(object sender, RoutedEventArgs e)
        {
            Window w4 = new ses.ListeSes();
            w4.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre 2"); };
            w4.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }


        private void Formation_Click(object sender, RoutedEventArgs e)
        {
            Window w3 = new form.ListeForm();
            w3.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre 1"); };
            w3.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void employe_Click(object sender, RoutedEventArgs e)
        {
            Window w2 = new emp.ListeEmp();
            w2.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre 2"); };
            w2.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Metier_Click(object sender, RoutedEventArgs e)
        {
            Window w2 = new met.Creation();
            w2.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre 2"); };
            w2.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }
    }
}
