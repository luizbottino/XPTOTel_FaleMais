using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Application.Queries.Calculadora;
using XPTOTel_FaleMais.Application.DTOs;
using XPTOTel_FaleMais.Domain.Services;

public class CalcularCustoLigacaoQueryHandler : IRequestHandler<CalcularCustoLigacaoQuery, CalculadoraResultadoDto>
{
    private readonly ITarifaRepository _tarifaRepository;
    private readonly IPlanoRepository _planoRepository;
    private readonly ICalculadoraService _calculadoraService;

    public CalcularCustoLigacaoQueryHandler(ITarifaRepository tr, IPlanoRepository pr, ICalculadoraService cs)
    {
        _tarifaRepository = tr;
        _planoRepository = pr;
        _calculadoraService = cs;
    }

    public async Task<CalculadoraResultadoDto> Handle(CalcularCustoLigacaoQuery request, CancellationToken cancellationToken)
    {
        var tarifa = await _tarifaRepository.GetByOrigemDestinoAsync(request.DddOrigem, request.DddDestino);
        if (tarifa == null)
        {
            throw new Exception("Não existe tarifa para a rota de origem e destino informada.");
        }

        var plano = await _planoRepository.GetByIdAsync(request.PlanoId);
        if (plano == null)
        {
            throw new Exception("Plano informado não foi encontrado.");
        }

        var resultado = _calculadoraService.Calcular(tarifa, plano, request.TempoLigacao);

        return new CalculadoraResultadoDto
        {
            CustoComPlano = resultado.CustoComPlano,
            CustoSemPlano = resultado.CustoSemPlano
        };
    }
}
