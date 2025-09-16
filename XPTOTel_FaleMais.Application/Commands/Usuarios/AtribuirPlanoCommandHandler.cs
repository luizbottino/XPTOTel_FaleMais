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
    public class AtribuirPlanoCommandHandler : IRequestHandler<AtribuirPlanoCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPlanoRepository _planoRepository;

        public AtribuirPlanoCommandHandler(IUsuarioRepository usuarioRepository, IPlanoRepository planoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _planoRepository = planoRepository;
        }

        public async Task Handle(AtribuirPlanoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var plano = await _planoRepository.GetByIdAsync(request.PlanoId);
            if (plano == null)
            {
                throw new Exception("Plano não encontrado.");
            }

            usuario.AtribuirPlano(plano);

            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
