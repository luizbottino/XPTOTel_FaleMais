using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Commands.Planos;

namespace XPTOTel_FaleMais.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CriarPlano([FromBody] CriarPlanoCommand command)
        {
            await _mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AtualizarPlano(int id, [FromBody] AtualizarPlanoCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
