using System;
using System.Collections.Generic;
using System.Text;
using JobFinder.ViewModels;

namespace JobFinder.Services.Contracts
{
    public interface IOfferService
    {
        SearchCriteriaViewModel GetSearchCriteria();
    }
}
