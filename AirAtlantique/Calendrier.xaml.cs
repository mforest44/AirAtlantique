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

namespace AirAtlantique
{
    /// <summary>
    /// Logique d'interaction pour Calendrier.xaml
    /// </summary>
    public partial class Calendrier : Window
    {
        public Calendrier()
        {
            var listeSes = DbSession.getSession();
            DateTime Date = DateTime.Now;
            InitializeComponent();

            foreach (var item in listeSes)
            {
                if (item.Date == Date.Date)
                {
                    date.Items.Add(item.Date);
                    Nom.Items.Add(item.Nom);
                    foreach (var emp in item.Employes)
                    {
                        Emp.Items.Add(emp.Nom + emp.Prenom);
                        date.Items.Add("");
                        Nom.Items.Add("");
                    }

                    
                }
                
                for (int i = 1; i < 7; i++)
                {

                    if (item.Date == Date.Date.AddDays(i))
                    {
                        date.Items.Add(item.Date);
                        Nom.Items.Add(item.Nom);
                        foreach (var emp in item.Employes)
                        {
                            Emp.Items.Add(emp.Nom + emp.Prenom);
                            date.Items.Add("");
                            Nom.Items.Add("");
                        }
                    }
                }

            }

        }
    }
}
