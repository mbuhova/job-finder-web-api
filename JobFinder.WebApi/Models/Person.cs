namespace JobFinder.WebApi.Models
{
    using JobFinder.WebApi.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("People")]
    public class Person : ApplicationUser
    {
        public Person()
        {
            this.FollowedOffers = new HashSet<PersonOffer>();
            this.Applications = new HashSet<Application>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<PersonOffer> FollowedOffers { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}
