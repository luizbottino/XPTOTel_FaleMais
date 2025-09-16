using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaHashingService _hashingService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUsuarioRepository u, ISenhaHashingService h, ITokenService t)
        {
            _usuarioRepository = u; _hashingService = h; _tokenService = t;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email);
            if (usuario == null) throw new Exception("Usuário ou senha inválidos.");

            var senhaCorreta = _hashingService.VerificarSenha(request.Senha, usuario.SenhaHash);
            if (!senhaCorreta) throw new Exception("Usuário ou senha inválidos.");

            return _tokenService.GerarToken(usuario);
        }
    }
}
