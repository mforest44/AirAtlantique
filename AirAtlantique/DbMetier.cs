using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    
    class DbMetier
    {
        public static void AjouterMet(string nom)
        {
            bool existe = false;
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            
            var listmet = getMetier();
            foreach (var item in listmet)
            {
                if(item.Nom == nom)
                {
                    existe = true;
                }
            }
            if (existe == false)
            {
                var NMetier = new Metier()
                {
                    Nom = nom

                };

                db.Metiers.Add(NMetier);
                db.SaveChanges();

            }

        }

        public static List<Metier> getMetier()
        {

            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            List<Metier> ListMetier = (from met in db.Metiers select met).ToList();
            return ListMetier;
        }

        public static string Selection(object met)
        {

            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            string metier = (from item in db.Metiers where item.Nom==met.ToString() select item.Nom).First();
            return metier;
            
        }
    }
}
