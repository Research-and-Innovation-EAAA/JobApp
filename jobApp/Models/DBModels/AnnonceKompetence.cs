using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class AnnonceKompetence
    {
        public uint Id { get; set; }
        public uint? AnnonceId { get; set; }
        public uint? KomptenceId { get; set; }

        public Annonce Annonce { get; set; }
        public Kompetence Komptence { get; set; }
    }
}
