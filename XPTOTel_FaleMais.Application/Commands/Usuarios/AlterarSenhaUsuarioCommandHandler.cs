using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class AlterarSenhaUsuarioCommandHandler : IRequestHandler<AlterarSenhaUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHashingService _senhaHashingService;

        public AlterarSenhaUsuarioCommandHandler(IUsuarioRepository usuarioRepository, ISenhaHashingService senhaHashingService)
        {
            _usuarioRepository = usuarioRepository;
            _senhaHashingService = senhaHashingService;
        }

        public async Task Handle(AlterarSenhaUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var senhaCorreta = _senhaHashingService.VerificarSenha(request.SenhaAtual, usuario.SenhaHash);
            if (!senhaCorreta)
            {
                throw new Exception("A senha atual está incorreta.");
            }

            var novaSenhaHash = _senhaHashingService.HashSenha(request.NovaSenha);

            usuario.AlterarSenha(novaSenhaHash);

            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
