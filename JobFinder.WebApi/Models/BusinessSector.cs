namespace JobFinder.WebApi.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BusinessSector
    {
        public BusinessSector()
        {
            this.Companies = new HashSet<SectorCompany>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public virtual ICollection<SectorCompany> Companies { get; set; }

        public bool IsDeleted { get; set; }
    }
}
