using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Services.Contracts;
using JobFinder.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            this._offerService = offerService;
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public SearchCriteriaViewModel GetSearchCriteria()
        {
            return this._offerService.GetSearchCriteria();
        }

        [HttpGet("searchOffers")]
        [AllowAnonymous]
        public IQueryable<SearchResultOfferViewModel> SearchOffers(
            string keyword, 
            int[] selectedBusinessSectors, 
            int[] selectedTowns,
            bool isPermanent,
            bool isTemporary,
            bool isFullTime,
            bool isPartTime)
        {
            return this._offerService.SearchOffers(keyword, selectedBusinessSectors,
            selectedTowns, isPermanent, isTemporary, isFullTime, isPartTime);
        }
    }
}