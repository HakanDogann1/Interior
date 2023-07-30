using Dapper;
using Interior.DomainLayer.Concrete;
using Interior.DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interior.Infrastructure
{
    public class OurFieldRepository : IOurFieldRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";
        public async Task AddAsync(OurField entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into OurField (OurFieldName,OurFieldImage) Values('{entity.OurFieldName}','{entity.OurFieldImage}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
           await using var connection = new SqlConnection(_connectionString);
            var query = $"Delete From OurField Where OurFieldID='{id}'";
            await connection.ExecuteAsync(query);
        }

        public async Task<List<OurField>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = "Select * From OurField";
            return (await connection.QueryAsync<OurField>(query)).AsList();
        }

        public async Task<OurField> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Select * From OurField Where OurFieldID='{id}'";
            return (await connection.QueryFirstAsync<OurField>(query));
        }

        public async Task UpdateAsync(int id, OurField entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Update OurField Set OurFieldName='{entity.OurFieldName}',OurFieldImage='{entity.OurFieldImage}' Where OurFieldID='{id}'";
            await connection.ExecuteAsync(query);
        }
    }
}
