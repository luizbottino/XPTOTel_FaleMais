using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Application.Commands.Tarifas
{
    public class CriarTarifaCommandHandler : IRequestHandler<CriarTarifaCommand>
    {
        private readonly ITarifaRepository _tarifaRepository;
        public CriarTarifaCommandHandler(ITarifaRepository tarifaRepository) { _tarifaRepository = tarifaRepository; }

        public async Task Handle(CriarTarifaCommand request, CancellationToken cancellationToken)
        {
            var tarifa = new Tarifa(new Ddd(request.DddOrigem), new Ddd(request.DddDestino), request.ValorPorMinuto);
            await _tarifaRepository.AddAsync(tarifa);
        }
    }
}
