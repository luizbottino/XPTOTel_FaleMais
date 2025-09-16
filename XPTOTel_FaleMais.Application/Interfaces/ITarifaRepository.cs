using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Entities;

namespace XPTOTel_FaleMais.Application.Interfaces
{
    public interface ITarifaRepository
    {
        Task AddAsync(Tarifa tarifa);
        Task<Tarifa> GetByIdAsync(int id);
        Task UpdateAsync(Tarifa tarifa);
        Task<Tarifa> GetByOrigemDestinoAsync(string dddOrigem, string dddDestino);
    }
}
