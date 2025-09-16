using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTOTel_FaleMais.Domain.Entities
{
    public class Plano
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int MinutosFranquia { get; private set; }

        private Plano() { }
        
        public Plano(int id, string nome, int minutosFranquia)
        {
            Id = id;
            Nome = nome;
            MinutosFranquia = minutosFranquia;
        }

        public Plano(string nome, int minutosFranquia)
        {
            Nome = nome;
            MinutosFranquia = minutosFranquia;
        }

        public void Atualizar(string nome, int minutosFranquia)
        {
            Nome = nome;
            MinutosFranquia = minutosFranquia;
        }
    }
}
