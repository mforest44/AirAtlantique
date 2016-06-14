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
    /// Logique d'interaction pour ListeForm.xaml
    /// </summary>
    public partial class ListeForm : Window
    {
        public ListeForm()
        {
            InitializeComponent();
            
                foreach (var item in DbFormation.getFormation())
                {
                    listForm.Items.Add(item.Nom);
                }
            
        }


        
        private void listForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Formation forma = DbFormation.AfficherDetail(listForm.SelectedItem.ToString());
            nom.Text = forma.Nom;
            duree.Text = forma.Duree.ToString();
            dv.Text = forma.DureeDeValidation.ToString();
            description.Text = forma.Description;
            metier.Text = forma.Metier;
            Supprimer.IsEnabled = true;

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            Window w5 = new Creation();
            w5.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre création formation"); };
            w5.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            DbFormation.Supprimer(listForm.SelectedItem.ToString());

            Window w2 = new form.ListeForm();
            w2.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre formations"); };
            w2.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }
    }
}
