using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class SectorCompany
    {
        public int BusinessSectorId { get; set; }
        public BusinessSector BusinessSector { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
