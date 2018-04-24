using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace jobApp.Models.DBModels
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()

        {

            KompetenceProfile = new HashSet<Kompetenceprofile>();

            RegionProfile = new HashSet<Regionprofile>();

        }

        public ICollection<Kompetenceprofile> KompetenceProfile { get; set; }

        public ICollection<Regionprofile> RegionProfile { get; set; }

    }
}

