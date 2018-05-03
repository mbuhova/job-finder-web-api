using JobFinder.Models;
using JobFinder.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFinder.Repositories
{
    public class TownRepository : BaseRepository<Town, int>, ITownRepository
    {
        public TownRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
