using MessangerServerApp.DTOs.Message;
using MessangerServerApp.DTOs.User;
using MessangerServerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessangerServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MessagesController: ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(
            IMessageService messageService,
            ILogger<MessagesController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetMessageById")]
        [ProducesResponseType(typeof(MessageDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMessageAsync(int id)
        {
            try
            {
                var message = await _messageService.GetMessageByIdAsync(id);
                return Ok(message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении сообщения");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(MessageDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMessageAsync([FromBody] CreateMessageDTO createMessageDto)
        {
            try
            {
                var createdMessage = await _messageService.CreateMessageAsync(createMessageDto);
                return CreatedAtRoute(
                    "GetMessageById", // имя маршрута
                    new { id = createdMessage.Id }, // параметры
                    createdMessage);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении сообщения");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(MessageDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageDTO updateMessageDto)
        {
            try
            {
                var updatedMessage = await _messageService.UpdateMessageAsync(updateMessageDto);
                return Ok(updatedMessage);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении сообщения");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
                await _messageService.DeleteMessageAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении сообщения");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}
