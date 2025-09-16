using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class AlterarSenhaUsuarioCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
    }
}
