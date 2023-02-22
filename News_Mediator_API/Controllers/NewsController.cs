using MediatR;
using Microsoft.AspNetCore.Mvc;
using News_Mediator_API.Authorization;
using News_Mediator_API.Commands.NewsCommands;
using News_Mediator_API.Enums;
using News_Mediator_API.Queries.NewsQueries;
using News_Mediator_API.Repository.Models;
using News_Mediator_API.Repository.Pagination;

namespace News_Mediator_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class newsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public newsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationDTO<NewsDTO>>> Get(int page, float pageSize)
        {
            var result = await _mediator.Send(new GetPaginationQuery(page, pageSize));
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<ActionResult<PaginationDTO<NewsDTO>>> GetFilterAndSorting([FromQuery] FilterData data)
        {
            var result = await _mediator.Send(new GetNewsFilteringSortingQuery(data));
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<NewsDTO>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllQuery());

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);

        }

        [Authorize(Role.Admin, Role.User)]
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDTO>> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdQuery(id));

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<NewsDTO>> Add(AddCommand news)
        {
            var result = await _mediator.Send(news);
            return Ok(result);
        }

        [Authorize(Role.Admin)]
        [HttpPut]
        public async Task<ActionResult<NewsDTO>> Update(UpdateCommand updateRequest)
        {
            var result = await _mediator.Send(updateRequest);

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
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
