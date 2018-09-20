using JobFinder.Models;
using JobFinder.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFinder.Repositories
{
    public class JobOfferRepository : BaseRepository<JobOffer, int>, IJobOfferRepository
    {
        public JobOfferRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
