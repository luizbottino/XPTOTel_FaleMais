using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Enums;

namespace XPTOTel_FaleMais.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public bool Ativo { get; set; }
    }
}
