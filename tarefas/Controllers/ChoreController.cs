using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Services.Interfaces;
using tarefas.Models;

namespace tarefas.Controllers
{
    [ApiController]
    [Route("api/")]

    public class ChoreController : ControllerBase
    {

        private readonly IChoreService _service;

        public ChoreController(IChoreService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ChoreModel>), 200)]
        [HttpGet("tarefas/{sessionId}")]
        public async Task<IActionResult> GetChores(long sessionId)
        {
            try
            {
                var response = await _service.GetChores(sessionId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPost("tarefas")]
        public async Task<IActionResult> CreateChore([FromBody] ChoreFormData formData)
        {
            try
            {
                await _service.CreateChore(formData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [AllowAnonymous]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(404)]
        [HttpPut("tarefas/{id}")]
        public async Task<IActionResult> UpdateChore(long id)
        {
            try
            {
                await _service.UpdateChore(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("tarefas/{id}")]
        public async Task<IActionResult> DeleteChore(long id)
        {
            try
            {
                await _service.DeleteChore(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

