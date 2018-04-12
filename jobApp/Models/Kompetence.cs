using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class Kompetence
    {
        public Kompetence()
        {
            AnnonceKompetence = new HashSet<AnnonceKompetence>();
            KompetenceKategoriseringSubkompetenceNavigation = new HashSet<KompetenceKategorisering>();
            KompetenceKategoriseringSuperkompetenceNavigation = new HashSet<KompetenceKategorisering>();
            KompetenceProfile = new HashSet<KompetenceProfile>();
        }

        public uint Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string ConceptUri { get; set; }
        public byte[] Description { get; set; }

        public ICollection<AnnonceKompetence> AnnonceKompetence { get; set; }
        public ICollection<KompetenceKategorisering> KompetenceKategoriseringSubkompetenceNavigation { get; set; }
        public ICollection<KompetenceKategorisering> KompetenceKategoriseringSuperkompetenceNavigation { get; set; }
        public ICollection<KompetenceProfile> KompetenceProfile { get; set; }
    }
}
