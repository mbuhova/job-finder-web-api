using JobFinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFinder.Repositories
{
    public interface IJobOfferRepository : IBaseRepository<JobOffer, int>
    {
    }
}
