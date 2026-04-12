using AutoMapper;
using BoardGameHub.API.DTO;
using BoardGameHub.API.Filters;
using BoardGameHub.Application.Abstractions;
using BoardGameHub.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardGameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBoardGameService _boardGameService;

        public BoardGameController(IMapper mapper, IBoardGameService boardGameService)
        {
            _mapper = mapper;
            _boardGameService = boardGameService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BoardGameResponse),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateBoardGameRequest boardGameRequest)
        {
            if (boardGameRequest == null)
            {
                return BadRequest();
            }

            var boardGame = _mapper.Map<BoardGame>(boardGameRequest);
            var createdGame = await _boardGameService.AddAsync(boardGame);
            var createdGameResponse = _mapper.Map<BoardGameResponse>(createdGame);

            return CreatedAtAction(nameof(Create), new { id = createdGame.Id }, createdGameResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> List()
        {
            var games = await _boardGameService.ListAsync();
            var gamesDto = _mapper.Map<List<BoardGameResponse>>(games);
            var responseDto = new BoardGameListResponse() { BoardGames = gamesDto }    ;
            return Ok(responseDto);
        }
    }
}
