﻿using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Services.Interfaces;

namespace tarefas.Controllers
{
    [ApiController]
    [Route("api/tarefas/")]
    public class SessionController : Controller
    {

        private readonly ISessionService _service;

        public SessionController(ISessionService service)
        {
            _service = service;
        }

        [HttpPost("createSession")]
        public async Task<IActionResult> CreateSession()
        {
            var session = await _service.CreateSession();

            Response.Cookies.Append("SessionId", session.SessionId.ToString());

            return Ok(session);
        }

        [HttpGet("checkSessionValidity")]
        public async Task<IActionResult> CheckSessionValidity()
        {
            if (Request.Cookies.ContainsKey("SessionId"))
            {
                var sessionId = Request.Cookies["SessionId"];
                var session = await _service.CheckSessionValidity(long.Parse(sessionId));

                return Ok(session);
            }

            return NotFound("Sessão não encontrada.");
        }

        [HttpDelete("removeSession")]
        public async Task<IActionResult> ExcluirSessao()
        {
            if (Request.Cookies.ContainsKey("SessionId"))
            {
                var sessionId = Request.Cookies["SessionId"];
                await _service.EndSession(long.Parse(sessionId));

                Response.Cookies.Delete("SessionId");
                return Ok("Sessão excluída com sucesso.");
            }

            return NotFound("Sessão não encontrada.");
        }
    }
}
