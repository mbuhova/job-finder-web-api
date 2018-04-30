namespace JobFinder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Companies")]
    public class Company : User
    {
        public Company()
        {
            this.BusinessSectors = new HashSet<SectorCompany>();
        }

        [Required]
        [MaxLength(13)]
        public string Bulstat { get; set; }

        [Required]
        [MaxLength(60)]
        public string CompanyName { get; set; }

        public virtual ICollection<SectorCompany> BusinessSectors { get; set; }

        public string Address { get; set; }

        public string WebSite { get; set; }

        public string AboutUs { get; set; }

        public bool IsApproved { get; set; }
    }
}
