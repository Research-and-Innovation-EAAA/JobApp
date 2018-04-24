using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class Kompetence
    {
        public Kompetence()
        {
            AnnonceKompetence = new HashSet<AnnonceKompetence>();
            KompetenceKategoriseringSubkompetenceNavigation = new HashSet<KompetenceKategorisering>();
            KompetenceKategoriseringSuperkompetenceNavigation = new HashSet<KompetenceKategorisering>();
            Kompetenceprofile = new HashSet<Kompetenceprofile>();
        }

        public uint Id { get; set; }
        public string AltLabels { get; set; }
        public string ConceptUri { get; set; }
        public byte[] Description { get; set; }
        public string Name { get; set; }
        public string PrefferredLabel { get; set; }
        public string Kompetencecol { get; set; }

        public ICollection<AnnonceKompetence> AnnonceKompetence { get; set; }
        public ICollection<KompetenceKategorisering> KompetenceKategoriseringSubkompetenceNavigation { get; set; }
        public ICollection<KompetenceKategorisering> KompetenceKategoriseringSuperkompetenceNavigation { get; set; }
        public ICollection<Kompetenceprofile> Kompetenceprofile { get; set; }
    }
}
