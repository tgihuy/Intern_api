using System.Data;
using API2.Application.Entities;
using API2.Application.Repositories;
using Oracle.ManagedDataAccess.Client;

namespace API2.Application.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly string _connectionString;

        public BuyerService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Buyer> AddBuyer(Buyer buyer)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertBuyer";

                    command.Parameters.Add("id", OracleDbType.Int32).Value = buyer.Id;
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = buyer.Name;
                    command.Parameters.Add("PaymentMethod", OracleDbType.NVarchar2).Value = buyer.PaymentMethod;
                    await command.ExecuteNonQueryAsync();
                }
            }
            return buyer;
        }

        public async Task DeleteBuyer(int id)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteBuyer";

                    command.Parameters.Add("id", OracleDbType.Int32).Value = id;
                    //command.Parameters.Add("rs", OracleDbType.RefCursor).o

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyers()
        {
            var buyers = new List<Buyer>();
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Buyer";
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var buyer = new Buyer
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                PaymentMethod = reader.GetString(reader.GetOrdinal("PaymentMethod"))
                            };
                            buyers.Add(buyer);
                        }
                    }
                }
            }
            return buyers;
        }

        public async Task<Buyer> GetBuyerById(int id)
        {
            Buyer buyer = null;
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM Buyer WHERE Id = {id}";
                    command.Parameters.Add("id", OracleDbType.Int32).Value = id;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            buyer = new Buyer
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                PaymentMethod = reader.GetString(reader.GetOrdinal("PaymentMethod"))
                            };
                        }
                    }
                }
            }
            return buyer;
        }

        public async Task UpdateBuyer(Buyer buyer)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateBuyer";

                    command.Parameters.Add("id", OracleDbType.Int32).Value = buyer.Id;
                    command.Parameters.Add("Name", OracleDbType.NVarchar2).Value = buyer.Name;
                    command.Parameters.Add("PaymentMethod", OracleDbType.NVarchar2).Value = buyer.PaymentMethod;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    
    }
}
