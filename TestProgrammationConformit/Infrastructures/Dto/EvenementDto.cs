using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Infrastructures.Dto
{
    public class EvenementDto
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string PersonneImplique { get; set; }

        public ICollection<CommentaireDto> Commentaires { get; set; }
    }
}
