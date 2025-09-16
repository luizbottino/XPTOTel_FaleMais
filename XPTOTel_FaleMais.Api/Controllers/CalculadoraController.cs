using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Commands.Tarifas;
using XPTOTel_FaleMais.Application.Commands.Usuarios;
using XPTOTel_FaleMais.Application.Queries.Calculadora;

namespace XPTOTel_FaleMais.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculadoraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular([FromBody] CalcularCustoLigacaoQuery query)
        {
            try
            {
                var resultado = await _mediator.Send(query);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}