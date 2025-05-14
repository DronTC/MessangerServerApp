using MessangerServerApp.DTOs.Chat;
using MessangerServerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessangerServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly ILogger<ChatsController> _logger;

        public ChatsController(
            IChatService chatService,
            ILogger<ChatsController> logger)
        {
            _chatService = chatService;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetChatById")]
        [ProducesResponseType(typeof(ChatDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetChatAsync(int id)
        {
            try
            {
                var chat = await _chatService.GetChatByIdAsync(id);
                return Ok(chat);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении чата");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ChatDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateChatAsync([FromBody] CreateChatDTO createChatDTO)
        {
            try
            {
                var createdChat = await _chatService.CreateChatAsync(createChatDTO);
                return CreatedAtRoute(
                    "GetChatById",
                    new { id = createdChat.Id },
                    createdChat);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании чата");
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ChatDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateChatAsync([FromBody] UpdateChatDTO updateChatDTO)
        {
            try
            {
                var updatedChat = await _chatService.UpdateChatAsync(updateChatDTO);
                return Ok(updatedChat);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении чата");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteChatAsync(int id)
        {
            try
            {
                await _chatService.DeleteChatAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении чата");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPost("{chatId}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUsersToChatAsync(int chatId, [FromBody] IEnumerable<int> userIds)
        {
            try
            {
                await _chatService.AddUsersToChatAsync(chatId, userIds);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении пользователей в чат");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpDelete("{chatId}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveUsersFromChatAsync(int chatId, [FromBody] IEnumerable<int> userIds)
        {
            try
            {
                await _chatService.RemoveUsersFromChatAsync(chatId, userIds);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении пользователей из чата");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}
