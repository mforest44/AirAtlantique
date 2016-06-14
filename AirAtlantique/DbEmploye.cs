using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    public class DbEmploye
    {
        
        public static List<Employe> getEmploye()
        {

            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            List<Employe> ListEmp = (from emp in db.Employes select emp).ToList();
            return ListEmp;
        }

        public static Employe AfficherDetail(string employe)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var emp = (from item in db.Employes
                       where item.Nom == employe
                       select item).First();

            return emp;
        }

        public static void Supprimer(string NEmploye)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var emp = (from item in db.Employes
                       where item.Nom == NEmploye
                       select item).First();

            db.Employes.Remove(emp);

            db.SaveChanges();
        }

        public static void AjouterEmp (string nom, string prenom, string metier)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();

            var NEmploye = new Employe()
            {
                Nom = nom,
                Prenom = prenom,
                Metier = metier
            };

            db.Employes.Add(NEmploye);
            db.SaveChanges();
            
        }
    }
}



