using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobFinder.ViewModels;

namespace JobFinder.Services.Contracts
{
    public interface IOfferService
    {
        SearchCriteriaViewModel GetSearchCriteria();
        IQueryable<SearchResultOfferViewModel> SearchOffers(string keyword,
            int[] selectedBusinessSectors,
            int[] selectedTowns,
            bool isPermanent,
            bool isTemporary,
            bool isFullTime,
            bool isPartTime);

        void Add(CreateOfferViewModel offer, string companyId);
    }
}
