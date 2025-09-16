using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Entities;

namespace XPTOTel_FaleMais.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<int> AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByEmailAsync(string email);
    }
}
