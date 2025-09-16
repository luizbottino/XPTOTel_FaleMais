using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using XPTOTel_FaleMais.Domain.Enums;

namespace XPTOTel_FaleMais.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public bool Ativo { get; private set; } = true;
        public Perfil Perfil { get; private set; }
        public Plano? Plano { get; private set; }

        public Usuario(int id, string nome, string email, string senhaHash, Perfil perfil, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Perfil = perfil;
            Ativo = ativo;
        }

        public Usuario(string nome, string email, string senhaHash, Perfil perfil)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Perfil = perfil;
        }

        public void AtribuirPlano(Plano plano) => Plano = plano;
        public void AtualizarNome(string nome) => Nome = nome;
        public void AtualizarEmail(string email) => Email = email;
        public void AlterarSenha(string novaSenhaHash) => SenhaHash = novaSenhaHash;
        public void Desativar() => Ativo = false;

    }
}
