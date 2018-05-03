using JobFinder.Models;
using JobFinder.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFinder.Repositories
{
    public class BusinessSectorRepository : BaseRepository<BusinessSector, int>, IBusinessSectorRepository
    {
        public BusinessSectorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
