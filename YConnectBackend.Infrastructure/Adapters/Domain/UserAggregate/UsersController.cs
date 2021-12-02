using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YConnectBackend.Domain.Commons.UserAggregates;
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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return (await _userRepository.GetUsers()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(uint id)
        {
            try
            {
                User? result = await _userRepository.GetUserAsync(id);
                if (result is null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest();
                }

                User? createdUser = await _userRepository.AddUserAsync(user);

                return CreatedAtAction(nameof(GetUser),
                    new {id = createdUser.Id}, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating user from database");
            }
        }
    }
}