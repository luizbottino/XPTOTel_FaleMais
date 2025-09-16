using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.DTOs;
using XPTOTel_FaleMais.Application.Interfaces;

namespace XPTOTel_FaleMais.Application.Queries.Usuarios
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public GetAllUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var usuariosDto = usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Perfil = u.Perfil,
                Ativo = u.Ativo
            });

            return usuariosDto;
        }
    }
}