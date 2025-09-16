using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.Entities;

namespace XPTOTel_FaleMais.Infrastructure.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly string _connectionString;

        public PlanoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Plano> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sql = "SELECT Id, Nome, MinutosFranquia FROM Planos WHERE Id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {
                        if (await reader.ReadAsync())
                        {
                            var plano = new Plano(
                                id: (int)reader["Id"],
                                nome: reader["Nome"].ToString(),
                                minutosFranquia: (int)reader["MinutosFranquia"]
                            );
                            return plano;
                        }
                    }
                }
            }
            return null;
        }


        public async Task AddAsync(Plano plano)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sql = "INSERT INTO Planos (Nome, MinutosFranquia) VALUES (@Nome, @MinutosFranquia)";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", plano.Nome);
                    command.Parameters.AddWithValue("@MinutosFranquia", plano.MinutosFranquia);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Plano plano)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"UPDATE Planos 
                    SET Nome = @Nome, 
                        MinutosFranquia = @MinutosFranquia
                    WHERE Id = @Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", plano.Id);

                    command.Parameters.AddWithValue("@Nome", plano.Nome);
                    command.Parameters.AddWithValue("@MinutosFranquia", plano.MinutosFranquia);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}