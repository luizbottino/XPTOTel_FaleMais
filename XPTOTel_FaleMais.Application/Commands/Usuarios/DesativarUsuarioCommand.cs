using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Application.Commands.Usuarios
{
    public class DesativarUsuarioCommand : IRequest
    {
        public int Id { get; set; }
    }
}
