using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Tarifas
{
    public class CriarTarifaCommand : IRequest
    {
        public string DddOrigem { get; set; }
        public string DddDestino { get; set; }
        public decimal ValorPorMinuto { get; set; }
    }
}
