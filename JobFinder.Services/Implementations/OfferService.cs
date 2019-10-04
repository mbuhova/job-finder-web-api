using JobFinder.Repositories;
using JobFinder.Services.Contracts;
using JobFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.QueryableExtensions;
using System.Linq;
using JobFinder.Models;

namespace JobFinder.Services.Implementations
{
    public class OfferService : IOfferService
    {
        private ITownRepository _townRepository;
        private IBusinessSectorRepository _businessSectorRepository;
        private IJobOfferRepository _jobOfferRepository;

        public OfferService(ITownRepository townRepository, IBusinessSectorRepository businessSectorRepository, IJobOfferRepository jobOfferRepository)
        {
            this._townRepository = townRepository;
            this._businessSectorRepository = businessSectorRepository;
            this._jobOfferRepository = jobOfferRepository;
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

        public IQueryable<SearchResultOfferViewModel> SearchOffers(string keyword,
            int[] selectedBusinessSectors,
            int[] selectedTowns,
            bool isPermanent,
            bool isTemporary,
            bool isFullTime,
            bool isPartTime)
        {
            var result = this._jobOfferRepository.All().Where(o => o.IsActive);

            if (selectedBusinessSectors != null && selectedBusinessSectors.Length > 0)
            {
                result = result.Where(o => selectedBusinessSectors.Contains(o.BusinessSectorId));
            }

            if (selectedTowns != null && selectedTowns.Length > 0)
            {
                result = result.Where(o => selectedTowns.Contains(o.TownId));
            }

            if (isPermanent)
            {
                result = result.Where(o => o.IsPermanent == true);
            }

            if (isFullTime)
            {
                result = result.Where(o => o.IsFullTime == true);
            }

            if (keyword != null && keyword != string.Empty)
            {
                result = result.Where(o => o.Title.Contains(keyword) || o.Description.Contains(keyword));
            }
            
            return result.OrderByDescending(o => o.DateCreated).ProjectTo<SearchResultOfferViewModel>();
        }

        public IQueryable<JobOffer> GetCompanyOffers(string companyId)
        {
            return this._jobOfferRepository
                .All()
                .Where(o => o.CompanyId == companyId)
                .OrderByDescending(o => o.DateCreated);
        }

        public JobOffer GetOfferById(int offerId)
        {
           return this._jobOfferRepository.GetById(offerId);
        }

        public void Add(CreateOfferViewModel model, string companyId)
        {
            JobOffer offer = new JobOffer();
            offer.Title = model.Title;
            offer.Description = model.Description;
            offer.DateCreated = DateTime.Now;
            offer.TownId = model.TownId;
            offer.IsActive = true;
            offer.CompanyId = companyId;
            offer.BusinessSectorId = model.BusinessSectorId;
            offer.IsPermanent = model.IsPermanent;
            offer.IsFullTime = model.IsFullTime;
            _jobOfferRepository.Add(offer);
            _jobOfferRepository.SaveChanges();
        }
    }
}
