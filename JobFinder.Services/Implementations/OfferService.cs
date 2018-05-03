using JobFinder.Repositories;
using JobFinder.Services.Contracts;
using JobFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace JobFinder.Services.Implementations
{
    public class OfferService : IOfferService
    {
        private ITownRepository _townRepository;

        private IBusinessSectorRepository _businessSectorRepository;
        
        public OfferService(ITownRepository townRepository, IBusinessSectorRepository businessSectorRepository)
        {
            this._townRepository = townRepository;
            this._businessSectorRepository = businessSectorRepository;
        }

        public SearchCriteriaViewModel GetSearchCriteria()
        {
            IEnumerable<TownViewModel> towns = this._townRepository.All().OrderBy(x => x.Name).ProjectTo<TownViewModel>().ToList();
            IEnumerable<BusinessSectorViewModel> businessSectors = this._businessSectorRepository.All().OrderBy(x => x.Name).ProjectTo<BusinessSectorViewModel>().ToList();

            return new SearchCriteriaViewModel()
            {
                Towns = towns,
                BusinessSectors = businessSectors
            };
        }
    }
}
