using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Domain.Entities
{
    public class Tarifa
    {
        public int Id { get; private set; }
        public Ddd DddOrigem { get; private set; }
        public Ddd DddDestino { get; private set; }
        public decimal ValorPorMinuto { get; private set; }

        public Tarifa(int id, Ddd dddOrigem, Ddd dddDestino, decimal valorPorMinuto)
        {
            Id = id;
            DddOrigem = dddOrigem;
            DddDestino = dddDestino;
            ValorPorMinuto = valorPorMinuto;
        }
        public Tarifa(Ddd dddOrigem, Ddd dddDestino, decimal valorPorMinuto)
        {
            DddOrigem = dddOrigem;
            DddDestino = dddDestino;
            ValorPorMinuto = valorPorMinuto;
        }

        public void Atualizar(Ddd dddOrigem, Ddd dddDestino, decimal valorPorMinuto)
        {
            DddOrigem = dddOrigem;
            DddDestino = dddDestino;
            ValorPorMinuto = valorPorMinuto;
        }
    }
}
