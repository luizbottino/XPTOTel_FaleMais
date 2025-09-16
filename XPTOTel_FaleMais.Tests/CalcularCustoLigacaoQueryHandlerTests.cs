using Moq;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Application.Queries.Calculadora;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.Services;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Tests
{
    public class CalcularCustoLigacaoQueryHandlerTests
    {
        [Fact]
        public async Task Handle_DeveCalcularCustosCorretamente()
        {
            // Arrange
            var tarifaRepository = new Mock<ITarifaRepository>();
            var planoRepository = new Mock<IPlanoRepository>();
            var calculadoraService = new Mock<ICalculadoraService>();

            var query = new CalcularCustoLigacaoQuery
            {
                DddOrigem = "011",
                DddDestino = "017",
                TempoLigacao = 80,
                PlanoId = 2
            };

            var tarifa = new Tarifa(new Ddd("011"), new Ddd("017"), 1.70m);
            var plano = new Plano("FaleMais 60", 60);
            var resultadoEsperado = new ResultadoCalculo
            {
                CustoComPlano = 37.40m,
                CustoSemPlano = 136.00m
            };

            tarifaRepository
                .Setup(r => r.GetByOrigemDestinoAsync(query.DddOrigem, query.DddDestino))
                .ReturnsAsync(tarifa);

            planoRepository
                .Setup(r => r.GetByIdAsync(query.PlanoId))
                .ReturnsAsync(plano);

            calculadoraService
                .Setup(s => s.Calcular(tarifa, plano, query.TempoLigacao))
                .Returns(resultadoEsperado);

            var handler = new CalcularCustoLigacaoQueryHandler(
                tarifaRepository.Object,
                planoRepository.Object,
                calculadoraService.Object);

            var resultado = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(resultado);
            Assert.Equal(resultadoEsperado.CustoComPlano, resultado.CustoComPlano);
            Assert.Equal(resultadoEsperado.CustoSemPlano, resultado.CustoSemPlano);

            calculadoraService.Verify(
                s => s.Calcular(tarifa, plano, query.TempoLigacao),
                Times.Once);
        }
    }
}