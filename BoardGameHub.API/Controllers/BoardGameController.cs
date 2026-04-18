using AutoMapper;
using BoardGameHub.API.DTO;
using BoardGameHub.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using BoardGameHub.Application.Models;

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
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateBoardGameRequest boardGameRequest)
        {
            if (boardGameRequest == null)
            {
                return BadRequest();
            }

            var boardGame = _mapper.Map<CreateBoardGameModel>(boardGameRequest);
            var createdGame = await _boardGameService.CreateAsync(boardGame);
            var createdGameResponse = _mapper.Map<BoardGameResponse>(createdGame);

            return CreatedAtAction(nameof(Get), new { id = createdGame.Id }, createdGameResponse);
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


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _boardGameService.GetAsync(id);
            var gameDto = _mapper.Map<BoardGameResponse>(game);
            return Ok(gameDto);
        }
    }
}
