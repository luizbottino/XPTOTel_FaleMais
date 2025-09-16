using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTOTel_FaleMais.Application.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace XPTOTel_FaleMais.Application.Services
{
    public class SenhaHashingService : ISenhaHashingService
    {
        public string HashSenha(string senha)
        {
            return BCryptNet.HashPassword(senha);
        }

        public bool VerificarSenha(string senha, string hashSenha)
        {
            return BCryptNet.Verify(senha, hashSenha);
        }
    }
}
