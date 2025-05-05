using Microsoft.AspNetCore.Mvc;
using MessangerServerApp.Services.Data;
using MessangerServerApp.Services.Interfaces;
using AutoMapper;
using MessangerServerApp.DTOs.User;
using Microsoft.CodeAnalysis;

namespace MessangerServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(CreateUserDTO createUserDTO)
        {
            try
            {
                var userDTO = await _userService.CreateUserAsync(createUserDTO);
                return CreatedAtAction(
                    actionName: nameof(GetByIdAsync),
                    routeValues: new {id = userDTO.Id},
                    value: userDTO
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetByIdAsync(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            return userDto == null ? NotFound() : Ok(userDto);
        }
    }
}
