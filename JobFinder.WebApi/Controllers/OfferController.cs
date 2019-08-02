using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JobFinder.Models;
using JobFinder.Services.Contracts;
using JobFinder.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Offer")]
    public class OfferController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOfferService _offerService;

        public OfferController(
            UserManager<ApplicationUser> userManager,
            IOfferService offerService)
        {
            _offerService = offerService;
            _userManager = userManager;
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public SearchCriteriaViewModel GetSearchCriteria()
        {
            return _offerService.GetSearchCriteria();
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
            return _offerService.SearchOffers(keyword, selectedBusinessSectors,
            selectedTowns, isPermanent, isTemporary, isFullTime, isPartTime);
        }

        [HttpPost]
        [Authorize(Policy = "Company")]
        public ActionResult CreateOffer(CreateOfferViewModel model)
        {
            if (ModelState.IsValid)
            {
                string companyId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _offerService.Add(model, companyId);
                return Ok();
            }

            return BadRequest(model);
        }
    }
}