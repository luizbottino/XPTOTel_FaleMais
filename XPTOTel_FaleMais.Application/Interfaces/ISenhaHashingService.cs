namespace XPTOTel_FaleMais.Application.Interfaces
{

    public interface ISenhaHashingService
    {
        string HashSenha(string senha);
        bool VerificarSenha(string senha, string hashSenha);
    }

}
