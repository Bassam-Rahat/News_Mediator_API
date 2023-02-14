using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Mediator_API.Authorization;
using News_Mediator_API.Commands.BookmarkCommands;
using News_Mediator_API.Entities;
using News_Mediator_API.Interfaces;
using News_Mediator_API.Models;
using News_Mediator_API.Pagination;
using News_Mediator_API.Queries.BookmarkQueries;

namespace News_Mediator_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookmarkNewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookmarkNewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Role.User)]
        [HttpPost]
        public async Task<ActionResult<string>> Save(int id)
        {
            var result = await _mediator.Send(new SaveCommand(id));

            if (result is null)
            {
                return NotFound("Enter the valid email or News ID");
            }
            return Ok(result);
        }

        [Authorize(Role.User)]
        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginationDTO<News>>> Get(int page, float pageSize)
        {
            var result = await _mediator.Send(new GetBookmarkPaginationQuery(page, pageSize));

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

        [Authorize(Role.User)]
        [HttpGet("Filter")]
        public async Task<ActionResult<PaginationDTO<News>>> GetFilterAndSorting([FromQuery] FilterData data)
        {
            var result = await _mediator.Send(new GetBMFilteringSortingQuery(data));
            return Ok(result);

        }

        [Authorize(Role.User)]
        [HttpGet]
        public async Task<ActionResult<List<News>>> GetAll()
        {
            var result = await _mediator.Send(new GetQuery());

            if (result is null)
            {
                return NotFound("No News Found");
            }
            return Ok(result);
        }

        [Authorize(Role.User)]
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCommand(id));

            if (result is null)
            {
                return NotFound("No News with such ID Found");
            }
            return Ok(result);
        }

        //private int GetCurrentUserId()
        //{
        //    var id=string.Empty;
        //    if (HttpContext.User.Identity is ClaimsIdentity identity)
        //    {
        //        id = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    }
        //    return int.Parse(id);
        //}
    }
}
