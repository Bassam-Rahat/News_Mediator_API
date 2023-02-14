using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Mediator_API.Authorization;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Entities;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.NewsQueries;

namespace News_Mediator_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("GetPaginatedNews")]
        public async Task<ActionResult<PaginationDTO<News>>> Get(int page)
        {
            var result = await _mediator.Send(new GetPaginationQuery(page));
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet("GetFiltering&Sorting")]
        public async Task<ActionResult<PaginationDTO<News>>> GetFilterAndSorting(int page, string columnName, string find, string sortOrder)
        {
            var result = await _mediator.Send(new GetFilteringSortingQuery(page, columnName, find, sortOrder));
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet("GetAllNews")]
        public async Task<ActionResult<List<News>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllQuery());

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);

        }

        [Authorize(Role.Admin, Role.User)]
        [HttpGet("GetById")]
        public async Task<ActionResult<News>> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdQuery(id));

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

        [Authorize(Role.Admin)]
        [HttpPost("PostNews")]
        public async Task<ActionResult<string>> Add(News news)
        {
            var result = await _mediator.Send(new AddCommand(news));
            return Ok(result);
        }

        [Authorize(Role.Admin)]
        [HttpPut("UpdateNews")]
        public async Task<ActionResult<News>> Update(int id, News updateRequest)
        {
            var result = await _mediator.Send(new UpdateCommand(id, updateRequest));

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("DeleteNews")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCommand(id));

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

    }
}
