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

namespace AirAtlantique.ses
{
    /// <summary>
    /// Logique d'interaction pour ListeSes.xaml
    /// </summary>
    public partial class ListeSes : Window
    {
        public ListeSes()
        {
            InitializeComponent();
            foreach (var item in DbSession.getSession())
            {
                listSes.Items.Add(item.Nom);
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

        private void Creation_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new Creation();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void listSes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employe.Items.Clear();
            employe.Items.Clear();
            Supprimer.IsEnabled = true;
            Session session = DbSession.AfficherDetail(listSes.SelectedItem.ToString());
            nom.Text = session.Nom;
            lieu.Text = session.Lieu;
            nbr.Text = session.NbrPlaceTotal.ToString();
            duree.Text = session.Duree.ToString();
            date.Text = session.Date.ToString();
            List<Employe> Employes = DbSession.EmplSess();
            foreach (var item in Employes)
            {
                if(item.sessions.Nom == listSes.SelectedItem.ToString())
                employe.Items.Add(item.Nom);
            }

            foreach (var item in DbFormation.EmpMetier(listSes.SelectedItem.ToString()))
            {

                Employe.Items.Add(item.Nom);
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            DbSession.Supprimer(listSes.SelectedItem.ToString());

            Window w2 = new ses.ListeSes();
            w2.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre formations"); };
            w2.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
     
            var emp = (from s in db.Sessions
                       where s.Nom == listSes.SelectedItem.ToString()
                       select s).First();
            
            emp.Employes.Add((from empl in db.Employes where empl.Nom == Employe.SelectedItem.ToString() select empl).First());
            db.SaveChanges();

            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
            System.Console.WriteLine("Fenêtre ouverte");
            this.Close();
        }

        private void Employe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ajouter.IsEnabled = true;
        }
    }
}
