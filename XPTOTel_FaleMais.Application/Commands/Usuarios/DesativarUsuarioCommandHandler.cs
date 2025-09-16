using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class DesativarUsuarioCommandHandler : IRequestHandler<DesativarUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DesativarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Handle(DesativarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

            if (usuario == null)
            {
                throw new Exception($"Usuário com Id {request.Id} não encontrado.");
            }

            usuario.Desativar();

            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
