using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class AtribuirPlanoCommand : IRequest
    {
        [JsonIgnore]
        public int UsuarioId { get; set; }
        public int PlanoId { get; set; }
    }
}
