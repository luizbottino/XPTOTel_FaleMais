using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.DTOs;
using MediatR;

namespace XPTOTel_FaleMais.Application.Queries.Usuarios
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioDto>
    {
        public int Id { get; set; }
    }
}
