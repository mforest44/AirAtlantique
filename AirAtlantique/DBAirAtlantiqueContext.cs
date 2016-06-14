using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    class DBAirAtlantiqueContext : DbContext
    {
        public DBAirAtlantiqueContext() : base("Airatlantique") { }

        public virtual DbSet<Employe> Employes { get; set; }

        public virtual DbSet<Formation> Formations { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<Metier> Metiers { get; set; }


    }
}
