using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class RegionProfile
    {
        public uint? RegionProfileId { get; set; }
        public string regionApplicationUserId { get; set; }
        public uint Id { get; set; }

        public ApplicationUser Profile { get; set; }
        public Region RegionProfileNavigation { get; set; }
    }
}
