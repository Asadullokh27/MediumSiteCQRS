using MediatR;
using MediumSite.Application.UseCases.Commands;
using MediumSite.Application.UseCases.Queries;
using MediumSite.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok("Ma'lumot yaratildi !!!");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersCommandQuery());

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetByIdUser(Guid Id)
        {
            var result = await _mediator.Send(new GetByIdUserCommandQuery()
            {
                Id = Id
            });

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            await _mediator.Send(new DeleteUserCommand()
            {
                Id = Id
            });

            return Ok("Delete User");
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
