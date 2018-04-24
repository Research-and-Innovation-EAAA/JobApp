using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class Region
    {
        public Region()
        {
            Annonce = new HashSet<Annonce>();
            Regionprofile = new HashSet<Regionprofile>();
        }

        public uint RegionId { get; set; }
        public string Name { get; set; }

        public ICollection<Annonce> Annonce { get; set; }
        public ICollection<Regionprofile> Regionprofile { get; set; }
    }
}
