using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.CreateRating;
using Movies.Application.SearchMovies;
using Movies.Application.TopRankedMovies;
using Movies.Application.TopRankedMoviesByUser;
using Movies.Dtos;
using Movies.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MoviesController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("search")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<MovieDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search(
            [FromQuery]string title, 
            [FromQuery]int? yearOfRelease, 
            [FromQuery]IEnumerable<string> genres, 
            CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new SearchMoviesQuery(title, yearOfRelease, genres), cancellationToken);

            if (!response.Movies.Any()) return NotFound("No movies found for the given criteria.");

            return Ok(_mapper.Map<IEnumerable<MovieDto>>(response.Movies));
        }

        [HttpGet("top5")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<MovieDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Top5(CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new GetTopRankedMoviesQuery(5), cancellationToken);

            if (!response.Movies.Any()) return NotFound("No movies found.");

            return Ok(_mapper.Map<IEnumerable<MovieDto>>(response.Movies));
        }

        [HttpGet("top5byuser/{userID}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<MovieDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Top5ByUser(
            [FromRoute]int userID,
            CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new GetTopRankedMoviesByUserQuery(5, userID), cancellationToken);

            if (!response.Movies.Any()) return NotFound($"No movies found for the user with id {userID}.");

            return Ok(_mapper.Map<IEnumerable<MovieDto>>(response.Movies));
        }

        [HttpPost("{movieID}/rate")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Rate(
            [FromRoute]int movieID,
            [FromBody]RateMovieRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new CreateRatingCommand(movieID, request.UserID, request.Rating), cancellationToken);

            if (response is ResourceNotFoundResponse resourceNotFoundResponse) return NotFound(resourceNotFoundResponse.Message);

            return Ok();
        }
    }
}