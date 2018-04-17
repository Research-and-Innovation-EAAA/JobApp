using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class KompetenceKategorisering
    {
        public uint? Superkompetence { get; set; }
        public uint? Subkompetence { get; set; }
        public uint Id { get; set; }

        public Kompetence SubkompetenceNavigation { get; set; }
        public Kompetence SuperkompetenceNavigation { get; set; }
    }
}
