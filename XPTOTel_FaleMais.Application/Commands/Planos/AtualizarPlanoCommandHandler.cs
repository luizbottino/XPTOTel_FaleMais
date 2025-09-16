using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;

namespace XPTOTel_FaleMais.Application.Commands.Planos
{
    public class AtualizarPlanoCommandHandler : IRequestHandler<AtualizarPlanoCommand>
    {
        private readonly IPlanoRepository _planoRepository;
        public AtualizarPlanoCommandHandler(IPlanoRepository planoRepository) { _planoRepository = planoRepository; }

        public async Task Handle(AtualizarPlanoCommand request, CancellationToken cancellationToken)
        {
            var plano = await _planoRepository.GetByIdAsync(request.Id);
            if (plano == null) throw new Exception("Plano não encontrada.");

            plano.Atualizar(
                request.Nome,
                request.MinutosFranquia
                );

            await _planoRepository.UpdateAsync(plano);
        }
    }
}
