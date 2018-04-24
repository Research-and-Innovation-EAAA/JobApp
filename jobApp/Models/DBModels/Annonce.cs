using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class Annonce
    {
        public Annonce()
        {
            AnnonceKompetence = new HashSet<AnnonceKompetence>();
        }

        public uint Id { get; set; }
        public byte[] Body { get; set; }
        public uint? RegionId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Title { get; set; }
        public string Checksum { get; set; }
        public string Url { get; set; }

        public Region Region { get; set; }
        public ICollection<AnnonceKompetence> AnnonceKompetence { get; set; }
    }
}
