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
    /// Logique d'interaction pour Creation.xaml
    /// </summary>
    public partial class Creation : Window
    {
        public Creation()
        {
            InitializeComponent();
            using (var db = new DBAirAtlantiqueContext())
            {
                var form = from item in db.Formations
                           select item;
                foreach (var forma in form)
                {
                    Formation1.Items.Add(forma.Nom);
                }
            }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();

            var Nsession = new Session()
            {
                Nom = nom.Text,
                NbrPlaceTotal = int.Parse(Place.Text),
                Lieu = lieu.Text,
                Duree = int.Parse(duree.Text),
                Formation = (from f in db.Formations where f.Nom == Formation1.SelectedItem.ToString() select f).First(),
                Date = date.SelectedDate.Value,
            };

 
            db.Sessions.Add(Nsession);
            db.SaveChanges();

            //if (Nsession.Formation.Obligatoire == true)
            //{
            //    foreach (var emp in DbEmploye.getEmploye())
            //    {
            //        if (emp.Metier == metier.Text)
            //        {
            //            Nsession.Employes.Add((from empl in db.Employes select empl).First());
            //        }
            //    }
            //}


            Window w1 = new MainWindow();
            w1.Loaded += delegate { System.Console.WriteLine("Ouverture fenêtre principale + Création nouvelle formation"); };
            w1.Show();
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
    }
}
