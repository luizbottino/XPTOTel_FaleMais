using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Domain.Services
{
    public interface ICalculadoraService
    {
        ResultadoCalculo Calcular(Tarifa tarifa, Plano plano, int tempoLigacao);
    }
}
