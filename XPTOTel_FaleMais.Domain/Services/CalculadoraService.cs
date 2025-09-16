using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Domain.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        private const decimal AcrescimoExcedente = 1.10m;

        public ResultadoCalculo Calcular(Tarifa tarifa, Plano plano, int tempoLigacao)
        {
            if (tarifa == null)
            {
                throw new ArgumentNullException(nameof(tarifa), "A tarifa não pode ser nula.");
            }

            decimal custoSemPlano = tempoLigacao * tarifa.ValorPorMinuto;
            decimal custoComPlano = 0;

            if (plano == null)
            {
                custoComPlano = custoSemPlano;
            }
            else
            {
                if (tempoLigacao <= plano.MinutosFranquia)
                {
                    custoComPlano = 0;
                }
                else
                {
                    int minutosExcedentes = tempoLigacao - plano.MinutosFranquia;
                    decimal tarifaExcedente = tarifa.ValorPorMinuto * AcrescimoExcedente;
                    custoComPlano = minutosExcedentes * tarifaExcedente;
                }
            }

            return new ResultadoCalculo
            {
                CustoSemPlano = custoSemPlano,
                CustoComPlano = custoComPlano
            };
        }
    }
}
