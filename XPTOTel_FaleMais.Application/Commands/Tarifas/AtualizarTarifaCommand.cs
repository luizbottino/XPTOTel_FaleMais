using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Tarifas
{
    public class AtualizarTarifaCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string DddOrigem { get; set; }
        public string DddDestino { get; set; }
        public decimal ValorPorMinuto { get; set; }
    }
}
