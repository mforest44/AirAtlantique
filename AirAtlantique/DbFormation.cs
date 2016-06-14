using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    class DbFormation
    {
        public static List<Formation> getFormation()
        {

            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            List<Formation> ListEmp = (from form in db.Formations select form).ToList();
            return ListEmp;
        }

        public static Formation AfficherDetail(string formation)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var form = (from item in db.Formations
                       where item.Nom == formation
                       select item).First();

            return form;
        }

        public static void AjouterForm(string nom, int duree, string description, int dureeV, bool obligatoire, string metier)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var Nform = new Formation()
            {
                Nom = nom,
                Description = description,
                Duree = duree,
                DureeDeValidation = dureeV,
                Obligatoire = obligatoire,
                Metier = metier
            };


            db.Formations.Add(Nform);
            db.SaveChanges();

        }

        public static void Supprimer(string form)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var formation = (from item in db.Formations
                       where item.Nom == form
                       select item).First();

            db.Formations.Remove(formation);

            db.SaveChanges();
        }

        public static List<Employe> EmpMetier(string session)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            List<Employe> ListEmp = (from item in db.Employes
                                     join met in db.Metiers on item.Metier equals met.Nom
                                     join form in db.Formations on met.Nom equals form.Metier
                                     join sessions in db.Sessions on form.Nom equals sessions.Formation.Nom
                                     where item.Metier == form.Metier && session == sessions.Nom
                                     select item).ToList();

            return ListEmp;
        }
    }
}
