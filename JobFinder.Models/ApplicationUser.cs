using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobFinder.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public ApplicationUser()
        {
            this.BusinessSectors = new HashSet<SectorCompany>();
            this.FollowedOffers = new HashSet<PersonOffer>();
            this.Applications = new HashSet<Application>();
        }
        
        [MaxLength(13)]
        public string Bulstat { get; set; }
        
        [MaxLength(60)]
        public string CompanyName { get; set; }

        public virtual ICollection<SectorCompany> BusinessSectors { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public string Address { get; set; }

        public string WebSite { get; set; }

        public string AboutUs { get; set; }

        public bool IsApproved { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public virtual ICollection<PersonOffer> FollowedOffers { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

    }
}
