using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
   public class Session
    {
        [Key]
        public int ID { get; set; }

        public string Nom { get; set; }

        public int NbrPlaceTotal { get; set; }

        public String Lieu { get; set; }

        public int Duree { get; set; }


        public DateTime Date { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }

        public virtual Formation Formation { get; set; }

    }
}
