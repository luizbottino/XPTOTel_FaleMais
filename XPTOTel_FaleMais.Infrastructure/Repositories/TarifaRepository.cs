using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Domain.Entities;
using XPTOTel_FaleMais.Domain.ValueObjects;

namespace XPTOTel_FaleMais.Infrastructure.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly string _connectionString;

        public TarifaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddAsync(Tarifa tarifa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sql = "INSERT INTO Tarifas (DddOrigem, DddDestino, ValorPorMinuto) VALUES (@DddOrigem, @DddDestino, @ValorPorMinuto)";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DddOrigem", tarifa.DddOrigem.Codigo);
                    command.Parameters.AddWithValue("@DddDestino", tarifa.DddDestino.Codigo);
                    command.Parameters.AddWithValue("@ValorPorMinuto", tarifa.ValorPorMinuto);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Tarifa> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT Id, DddOrigem, DddDestino, ValorPorMinuto FROM Tarifas WHERE Id = @Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {

                        if (await reader.ReadAsync())
                        {
                            var tarifa = new Tarifa(
                                id: (int)reader["Id"],
                                dddOrigem: new Ddd(reader["DddOrigem"].ToString()),
                                dddDestino: new Ddd(reader["DddDestino"].ToString()),
                                valorPorMinuto: (decimal)reader["ValorPorMinuto"]
                            );
                            return tarifa;
                        }
                    }
                }

                return null;
            }
        }

        public async Task UpdateAsync(Tarifa tarifa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"UPDATE Tarifas 
                    SET DddOrigem = @DddOrigem, 
                        DddDestino = @DddDestino, 
                        ValorPorMinuto = @ValorPorMinuto
                    WHERE Id = @Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", tarifa.Id);

                    command.Parameters.AddWithValue("@DddOrigem", tarifa.DddOrigem.Codigo);
                    command.Parameters.AddWithValue("@DddDestino", tarifa.DddDestino.Codigo);
                    command.Parameters.AddWithValue("@ValorPorMinuto", tarifa.ValorPorMinuto);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Tarifa> GetByOrigemDestinoAsync(string dddOrigem, string dddDestino)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sql = "SELECT * FROM Tarifas WHERE DddOrigem = @DddOrigem AND DddDestino = @DddDestino";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@DddOrigem", dddOrigem);
                    command.Parameters.AddWithValue("@DddDestino", dddDestino);
                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow))
                    {

                        if (await reader.ReadAsync())
                        {
                            var tarifa = new Tarifa(
                                id: (int)reader["Id"],
                                dddOrigem: new Ddd(reader["DddOrigem"].ToString()),
                                dddDestino: new Ddd(reader["DddDestino"].ToString()),
                                valorPorMinuto: (decimal)reader["ValorPorMinuto"]
                            );
                            return tarifa;
                        }
                    }
                }
            }
            return null;
        }
    }
}
