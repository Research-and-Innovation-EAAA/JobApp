using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace jobApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            KompetenceProfile = new HashSet<KompetenceProfile>();
            RegionProfile = new HashSet<RegionProfile>();
        }
        public ICollection<KompetenceProfile> KompetenceProfile { get; set; }
        public ICollection<RegionProfile> RegionProfile { get; set; }
    }
}
