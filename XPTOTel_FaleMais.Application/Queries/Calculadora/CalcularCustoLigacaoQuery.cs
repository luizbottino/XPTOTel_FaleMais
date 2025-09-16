using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.DTOs;
using MediatR;

namespace XPTOTel_FaleMais.Application.Queries.Calculadora
{
    public class CalcularCustoLigacaoQuery : IRequest<CalculadoraResultadoDto>
    {
        public string DddOrigem { get; set; }
        public string DddDestino { get; set; }
        public int TempoLigacao { get; set; }
        public int PlanoId { get; set; }
    }
}
