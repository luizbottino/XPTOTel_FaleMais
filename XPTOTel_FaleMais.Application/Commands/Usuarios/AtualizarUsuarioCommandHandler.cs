using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            usuario.AtualizarNome(request.Nome);
            usuario.AtualizarEmail(request.Email);

            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
