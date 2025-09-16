using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
