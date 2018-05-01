using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class SectorCompany : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int BusinessSectorId { get; set; }
        public BusinessSector BusinessSector { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
