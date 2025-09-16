using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Commands.Tarifas;

namespace XPTOTel_FaleMais.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarifasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CriarTarifa([FromBody] CriarTarifaCommand command)
        {
            await _mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AtualizarTarifa(int id, [FromBody] AtualizarTarifaCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
