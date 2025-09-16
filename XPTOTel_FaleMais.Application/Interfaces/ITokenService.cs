using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.Entities;

namespace XPTOTel_FaleMais.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
