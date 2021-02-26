using Sat.Recruitment.Application.Business.Users;
using Sat.Recruitment.Application.Business.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [Route(ApiConstants.ApiBase + "/" + ApiConstants.Users)]
    [ApiVersion(ApiConstants.ApiVersion1)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create", Name = nameof(UsersController.CreateUser))]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}