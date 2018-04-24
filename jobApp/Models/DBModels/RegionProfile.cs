using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class Regionprofile
    {
        public uint Id { get; set; }
        public string ProfileId { get; set; }
        public uint? RegionProfileId { get; set; }
        public uint? RegionProfileNavigationRegionId { get; set; }
        public string RegionApplicationUserId { get; set; }

        public ApplicationUser Profile { get; set; }
        public Region RegionProfileNavigationRegion { get; set; }
    }
}
