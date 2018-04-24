using System;
using System.Collections.Generic;

namespace jobApp.Models.DBModels
{
    public partial class Kompetenceprofile
    {
        public uint Id { get; set; }
        public uint? KompetenceprofileId { get; set; }
        public string ProfilekompetenceId { get; set; }
        public string KompetenceApplicationUserId { get; set; }

        public Kompetence KompetenceprofileNavigation { get; set; }
        public ApplicationUser  Profilekompetence { get; set; }
    }
}
