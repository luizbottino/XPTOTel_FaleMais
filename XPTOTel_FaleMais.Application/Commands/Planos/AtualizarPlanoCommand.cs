using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Planos
{
    public class AtualizarPlanoCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MinutosFranquia { get; set; }
    }
}
