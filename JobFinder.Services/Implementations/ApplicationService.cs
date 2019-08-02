using JobFinder.Models;
using JobFinder.Repositories;
using JobFinder.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFinder.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
        }
    }
}
