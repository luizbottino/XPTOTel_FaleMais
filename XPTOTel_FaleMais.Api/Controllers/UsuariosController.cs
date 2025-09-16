using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Commands.Usuarios;
using XPTOTel_FaleMais.Application.Queries.Usuarios;

namespace XPTOTel_FaleMais.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand command)
        {
            var novoUsuarioId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUsuarioPorId), new { id = novoUsuarioId }, command);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AtualizarDadosUsuario(int id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id:int}/alterar-senha")]
        public async Task<IActionResult> AlterarSenha(int id, [FromBody] AlterarSenhaUsuarioCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DesativarUsuario(int id)
        {
            var command = new DesativarUsuarioCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{usuarioId:int}/atribuir-plano")]
        public async Task<IActionResult> AtribuirPlano(int usuarioId, [FromBody] AtribuirPlanoCommand command)
        {
            command.UsuarioId = usuarioId;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var query = new GetAllUsuariosQuery();

            var usuarios = await _mediator.Send(query);

            return Ok(usuarios);
        }

        [HttpGet("{id:int}", Name = "GetUsuarioPorId")]
        public async Task<IActionResult> GetUsuarioPorId(int id)
        {
            var query = new GetUsuarioByIdQuery { Id = id };

            var usuario = await _mediator.Send(query);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

    }
}
