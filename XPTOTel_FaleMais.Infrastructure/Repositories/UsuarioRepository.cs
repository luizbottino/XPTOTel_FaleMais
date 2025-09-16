using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.Enums;

namespace XPTOTel_FaleMais.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "INSERT INTO Usuarios (Nome, Email, SenhaHash, Ativo, Perfil, PlanoId) VALUES (@Nome, @Email, @SenhaHash, @Ativo, @Perfil, @PlanoId); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", usuario.Nome);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@SenhaHash", usuario.SenhaHash);
                    command.Parameters.AddWithValue("@Ativo", usuario.Ativo);
                    command.Parameters.AddWithValue("@Perfil", usuario.Perfil.ToString());
                    command.Parameters.AddWithValue("@PlanoId", usuario.Plano != null ? (object)usuario.Plano.Id : DBNull.Value);

                    var newId = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(newId);
                }
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"UPDATE Usuarios 
                    SET Nome = @Nome, 
                        Email = @Email, 
                        Perfil = @Perfil, 
                        Ativo = @Ativo,
                        SenhaHash = @SenhaHash,
                        PlanoId = @PlanoId 
                    WHERE Id = @Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", usuario.Nome);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Perfil", usuario.Perfil.ToString());
                    command.Parameters.AddWithValue("@Ativo", usuario.Ativo);
                    command.Parameters.AddWithValue("@SenhaHash", usuario.SenhaHash);
                    command.Parameters.AddWithValue("@Id", usuario.Id);

                    if (usuario.Plano != null)
                    {
                        command.Parameters.AddWithValue("@PlanoId", usuario.Plano.Id);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PlanoId", DBNull.Value);
                    }

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT Id, Nome, Email, SenhaHash, Perfil, Ativo FROM Usuarios WHERE Id = @Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        if (await reader.ReadAsync())
                        {
                            var usuario = new Usuario(
                                id: (int)reader["Id"],
                                nome: reader["Nome"].ToString(),
                                email: reader["Email"].ToString(),
                                senhaHash: reader["SenhaHash"].ToString(),
                                perfil: (Perfil)Enum.Parse(typeof(Perfil), reader["Perfil"].ToString()),
                                ativo: (bool)reader["Ativo"]
                            );
                            return usuario;
                        }
                    }
                }

                return null;
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT Id, Nome, Email, SenhaHash, Perfil, Ativo FROM Usuarios";

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            var usuario = new Usuario(
                                id: (int)reader["Id"],
                                nome: reader["Nome"].ToString(),
                                email: reader["Email"].ToString(),
                                senhaHash: reader["SenhaHash"].ToString(),
                                perfil: (Perfil)Enum.Parse(typeof(Perfil), reader["Perfil"].ToString()),
                                ativo: (bool)reader["Ativo"]
                            );

                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT Id, Nome, Email, SenhaHash, Perfil, Ativo FROM Usuarios WHERE Email = @Email";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        if (await reader.ReadAsync())
                        {
                            var usuario = new Usuario(
                                id: (int)reader["Id"],
                                nome: reader["Nome"].ToString(),
                                email: reader["Email"].ToString(),
                                senhaHash: reader["SenhaHash"].ToString(),
                                perfil: (Perfil)Enum.Parse(typeof(Perfil), reader["Perfil"].ToString()),
                                ativo: (bool)reader["Ativo"]
                            );
                            return usuario;
                        }
                    }
                }

                return null;
            }
        }
    }
}
