using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Entities;

namespace XPTOTel_FaleMais.Application.Interfaces
{
    public interface IPlanoRepository
    {
        Task<Plano> GetByIdAsync(int id);
        Task AddAsync(Plano plano);
        Task UpdateAsync(Plano plano);
    }
}