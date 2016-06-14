using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    public class Formation
    {
        [Key]
        public int ID { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public int Duree { get; set; }

        public int DureeDeValidation { get; set; }

        public bool Obligatoire { get; set; }


        public virtual ICollection<Session> Sessions { get; set; }

        public string Metier { get; set; }


    }
}
