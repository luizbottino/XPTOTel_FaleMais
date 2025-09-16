using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Application.Commands.Tarifas
{
    public class AtualizarTarifaCommandHandler : IRequestHandler<AtualizarTarifaCommand>
    {
        private readonly ITarifaRepository _tarifaRepository;
        public AtualizarTarifaCommandHandler(ITarifaRepository tarifaRepository) { _tarifaRepository = tarifaRepository; }

        public async Task Handle(AtualizarTarifaCommand request, CancellationToken cancellationToken)
        {
            var tarifa = await _tarifaRepository.GetByIdAsync(request.Id);
            if (tarifa == null)
                throw new Exception("Tarifa não encontrada.");

            tarifa.Atualizar(
                new Ddd(request.DddOrigem),
                new Ddd(request.DddDestino),
                request.ValorPorMinuto
                );

            await _tarifaRepository.UpdateAsync(tarifa);
        }
    }
}
