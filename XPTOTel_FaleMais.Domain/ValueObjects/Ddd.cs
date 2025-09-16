using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Domain.ValueObjects
{
    public class Ddd
    {
        public string Codigo { get; private set; }
        public Ddd(string codigo)
        {
            Codigo = codigo;
        }
    }
}
