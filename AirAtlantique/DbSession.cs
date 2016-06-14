using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    class DbSession
    {


        public static List<Session> getSession()
        {

            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            List<Session> ListSes = (from ses in db.Sessions select ses).ToList();
            return ListSes;
        }

        public static Session AfficherDetail(string session)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var ses = (from item in db.Sessions
                       where item.Nom == session
                       select item).First();

            return ses;
        }

        public static List<Employe> EmplSess()
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            List<Employe> LEmp = (from s in db.Sessions
             join empl in db.Employes
             on s.ID equals empl.sessions.ID
             where empl.sessions == s
             select empl).ToList();

            return LEmp;
        }

        public static void Supprimer(string Session)
        {
            DBAirAtlantiqueContext db = new DBAirAtlantiqueContext();
            var ses = (from item in db.Sessions
                       where item.Nom == Session
                       select item).First();

            db.Sessions.Remove(ses);

            db.SaveChanges();
        }

        

    }
}
