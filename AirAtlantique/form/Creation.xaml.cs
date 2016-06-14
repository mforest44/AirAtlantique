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

namespace AirAtlantique.form
{
    /// <summary>
    /// Logique d'interaction pour Creation.xaml
    /// </summary>
    public partial class Creation : Window
    {
        public Creation()
        {
            InitializeComponent();
            foreach (var item in DbMetier.getMetier())
            {
                metier.Items.Add(item.Nom);
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            DbFormation.AjouterForm(Nom.Text, int.Parse(Duree.Text), Description.Text, int.Parse(Validite.Text),Obligatoire.IsChecked.Value, DbMetier.Selection(metier.SelectedItem));

            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }
    }
}
