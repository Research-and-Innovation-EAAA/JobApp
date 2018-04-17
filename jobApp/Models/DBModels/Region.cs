using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class Region
    {
        public Region()
        {
            Annonce = new HashSet<Annonce>();
            RegionProfile = new HashSet<RegionProfile>();
        }

        public uint RegionId { get; set; }
        public string Name { get; set; }

        public ICollection<Annonce> Annonce { get; set; }
        public ICollection<RegionProfile> RegionProfile { get; set; }
    }
}
