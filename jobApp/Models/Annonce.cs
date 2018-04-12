using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class Annonce
    {
        public Annonce()
        {
            AnnonceKompetence = new HashSet<AnnonceKompetence>();
        }

        public uint Id { get; set; }
        public string Title { get; set; }
        public byte[] Body { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? ExpiringDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public uint? RegionId { get; set; }

        public Region Region { get; set; }
        public ICollection<AnnonceKompetence> AnnonceKompetence { get; set; }
    }
}
