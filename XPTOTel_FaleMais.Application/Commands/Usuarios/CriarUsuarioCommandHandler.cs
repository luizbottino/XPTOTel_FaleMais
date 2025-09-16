using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.Entities;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHashingService _senhaHashingService;

        public CriarUsuarioCommandHandler(
            IUsuarioRepository usuarioRepository,
            ISenhaHashingService senhaHashingService)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHashingService = senhaHashingService;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _senhaHashingService.HashSenha(request.Senha);

            var usuario = new Usuario(request.Nome, request.Email, senhaHash, request.Perfil);

            return await _usuarioRepository.AddAsync(usuario);
        }

    }
}
