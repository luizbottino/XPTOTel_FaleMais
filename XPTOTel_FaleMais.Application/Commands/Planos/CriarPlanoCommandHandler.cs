using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Application.Commands.Planos
{
    public class CriarPlanoCommandHandler : IRequestHandler<CriarPlanoCommand>
    {
        private readonly IPlanoRepository _planoRepository;
        public CriarPlanoCommandHandler(IPlanoRepository planoRepository) { _planoRepository = planoRepository; }

        public async Task Handle(CriarPlanoCommand request, CancellationToken cancellationToken)
        {
            var plano = new Plano(request.Nome, request.MinutosFranquia);
            await _planoRepository.AddAsync(plano);
        }
    }
}
