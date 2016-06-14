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
    /// Logique d'interaction pour ListeEmp.xaml
    /// </summary>
    public partial class ListeEmp : Window
    {
        public ListeEmp()
        {
            InitializeComponent();
            List<Employe> Employes = DbEmploye.getEmploye();
            foreach (var item in Employes)
            {
                listEmp.Items.Add(item.Nom);
            }


        }


        private void listEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Supprimer.IsEnabled = true;
            
            Employe employe = DbEmploye.AfficherDetail(listEmp.SelectedItem.ToString());
            nom.Text = employe.Nom;
            prenom.Text = employe.Prenom;
            metier.Text = employe.Metier;
            //if (employe.sessions != null)
            //{
            //    Detail.Items.Add(employe.sessions.Nom);
            //    Detail.Items.Add(employe.sessions.Formation.Nom);
            //}


        }

       

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            DbEmploye.Supprimer(listEmp.SelectedItem.ToString());

            Window w2 = new emp.ListeEmp();
            w2.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre formations"); };
            w2.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void creation_Click(object sender, RoutedEventArgs e)
        {
            Window w6 = new creation();
            w6.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre formations"); };
            w6.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }
    }
}
