using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.DTOs;

namespace XPTOTel_FaleMais.Application.Queries.Usuarios
{
    public class GetAllUsuariosQuery : IRequest<IEnumerable<UsuarioDto>>
    {
    }
}
