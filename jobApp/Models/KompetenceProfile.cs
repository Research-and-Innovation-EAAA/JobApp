using System;
using System.Collections.Generic;

namespace jobApp.Models
{
    public partial class KompetenceProfile
    {
        public string kompetenceApplicationUserId { get; set; }
        public uint? KompetenceprofileId { get; set; }
        public uint Id { get; set; }

        public Kompetence Kompetenceprofile { get; set; }
        public ApplicationUser Profilekompetence { get; set; }
    }
}
