using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Models;
using JobFinder.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/application")]
    public class ApplicationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationService _applicationService;

        public ApplicationController(
            UserManager<ApplicationUser> userManager,
            IApplicationService applicationService)
        {
            _applicationService = applicationService;
            _userManager = userManager;
        }

        [HttpPost("create")]
        [Authorize(Policy = "Person")]
        public ActionResult CreateApplication(int offerId, [FromBody]Stream file)
        {
            return Ok();
        }
    }
}