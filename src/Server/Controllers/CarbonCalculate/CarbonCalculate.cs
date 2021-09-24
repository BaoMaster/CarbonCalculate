using BlazorHero.CleanArchitecture.Application.Features.Brands.Commands.AddEdit;
using BlazorHero.CleanArchitecture.Application.Features.Brands.Queries.GetAll;
using BlazorHero.CleanArchitecture.Application.Features.CarbonCalculate.Commands.AddCarbonCalculateSet;
using BlazorHero.CleanArchitecture.Application.Interfaces.Services.Identity;
using BlazorHero.CleanArchitecture.Application.Requests.Identity;
using BlazorHero.CleanArchitecture.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Server.Controllers.CarbonCalculate
{
    [Route("api/identity/carbonCalculate")]
    //[ApiController]
    public class CarbonCalculate : BaseApiController<CarbonCalculate>
    {
        private readonly IUserService _userService;

        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <returns>Status 200 OK</returns>

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Users.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetAsync(id);
            return Ok(user);
        }
        [HttpPost("AddEditCarbonCalculateSet")]
        public async Task<IActionResult> AddEditCarbonCalculateSet(AddCarbonCalculateSetCommand request)
        {
            return Ok(await _mediator.Send(request));
        }


    }
}