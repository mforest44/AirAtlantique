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
using System.Windows.Shapes;

namespace AirAtlantique.emp
{
    /// <summary>
    /// Logique d'interaction pour creation.xaml
    /// </summary>
    public partial class creation : Window
    {
        public creation()
        {
            InitializeComponent();
            foreach (var item in DbMetier.getMetier())
            {
                listMetier.Items.Add(item.Nom);
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Window w6 = new MainWindow();
            w6.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre formations"); };
            w6.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            
            DbEmploye.AjouterEmp(Nom.Text, Prenom.Text, DbMetier.Selection(listMetier.SelectedItem));
            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }
    }
}
