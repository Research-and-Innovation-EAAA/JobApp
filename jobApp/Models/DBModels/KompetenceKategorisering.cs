using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class KompetenceKategorisering
    {
        public uint Id { get; set; }
        public uint? Subkompetence { get; set; }
        public uint? Superkompetence { get; set; }

        public Kompetence SubkompetenceNavigation { get; set; }
        public Kompetence SuperkompetenceNavigation { get; set; }
    }
}
