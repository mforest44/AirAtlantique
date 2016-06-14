using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    public class Employe
    {
        [Key]
        public int ID { get; set; }

        public String Nom { get; set; }

        public string Prenom { get; set; }


        public virtual Session sessions{ get; set; }

        public  string Metier { get; set; }


    }
}
