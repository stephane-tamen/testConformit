using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Infrastructures
{
    public class Evenement
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Titre { get; set; }
        public string Description { get; set; }
        public string PersonneImplique { get; set; }

        public ICollection<Commentaire> Commentaires { get; set; } = new List<Commentaire>();


    }
}
