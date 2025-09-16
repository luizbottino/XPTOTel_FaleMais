using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Enums;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class CriarUsuarioCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }
    }
}
