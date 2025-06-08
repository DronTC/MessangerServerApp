using Microsoft.AspNetCore.Mvc;
using MessangerServerApp.Services.Interfaces;
using MessangerServerApp.DTOs.User;

namespace MessangerServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService) => _userService = userService;

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {   
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO createUserDto)
        {
            try
            {
                var createdUser = await _userService.CreateUserAsync(createUserDto);
                Console.WriteLine(createdUser.Login);
                return CreatedAtRoute(
                    "GetUserById", // имя маршрута
                    new { id = createdUser.Id }, // параметры
                    createdUser);
            }
            catch (ArgumentException ex)
            {
                //_logger.LogWarning(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Ошибка при создании пользователя");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDto)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(updateUserDto);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException ex)
            {
               // _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Ошибка при обновлении пользователя");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                //_logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Ошибка при удалении пользователя");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}
