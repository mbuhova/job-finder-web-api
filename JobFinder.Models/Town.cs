namespace JobFinder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town : IEntity<int>
    {
        public Town()
        {
            this.JobOffers = new HashSet<JobOffer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }

        public bool IsDeleted { get; set; }
    }
}
