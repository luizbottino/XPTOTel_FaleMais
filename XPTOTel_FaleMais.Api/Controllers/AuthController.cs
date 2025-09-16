using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Commands.Tarifas;
using XPTOTel_FaleMais.Application.Commands.Usuarios;

namespace XPTOTel_FaleMais.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                var token = await _mediator.Send(command);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

    }
}