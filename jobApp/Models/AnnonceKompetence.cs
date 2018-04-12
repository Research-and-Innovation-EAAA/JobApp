using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class AnnonceKompetence
    {
        public uint? AnnonceId { get; set; }
        public uint? KomptenceId { get; set; }
        public uint Id { get; set; }

        public Annonce Annonce { get; set; }
        public Kompetence Komptence { get; set; }
    }
}
