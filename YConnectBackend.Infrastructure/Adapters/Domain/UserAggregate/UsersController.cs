using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YConnectBackend.Domain.Commons.UserAggregates.Port;

namespace YConnectBackend.Infrastructure.Adapters.Domain.UserAggregate
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
            => _userRepository = userRepository;

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }
    }
}