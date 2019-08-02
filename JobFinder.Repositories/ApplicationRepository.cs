using JobFinder.Models;
using JobFinder.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFinder.Repositories
{
    public class ApplicationRepository : BaseRepository<Application, int>, IApplicationRepository
    {
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
