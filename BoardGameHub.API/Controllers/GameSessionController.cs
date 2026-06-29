using AutoMapper;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Application.Models;
using BoardGameHub.Application.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameSessionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGameSessionService _gameSessionService;

        public GameSessionController(IGameSessionService gameSessionService, IMapper mapper)
        {
            _gameSessionService = gameSessionService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GameSessionListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            var sessions = await _gameSessionService.ListAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GameSessionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _gameSessionService.GetAsync(id);
            var sessionDto = _mapper.Map<GameSessionResponse>(session);
            return Ok(sessionDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GameSessionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateGameSessionModel sessionRequest)
        {
            if (sessionRequest == null)
            {
                return BadRequest();
            }

            var createdSession = await _gameSessionService.CreateAsync(sessionRequest);
            var createdSessionResponse = _mapper.Map<GameSessionResponse>(createdSession);

            return CreatedAtAction(nameof(Get), new { id = createdSession.Id }, createdSessionResponse);
        }
    }
}
