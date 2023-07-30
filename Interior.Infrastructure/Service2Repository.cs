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
    public class Service2Repository : IService2Repository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";
        public async Task AddAsync(Service2 entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Service2 (Service2Icon,Service2Image,Service2Title,Service2Description) Values ('{entity.Service2Icon}','{entity.Service2Image}','{entity.Service2Title}','{entity.Service2Description}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Delete From Service2 Where Service2ID='{id}'";
            await connection.ExecuteAsync(query);
        }

        public async Task<List<Service2>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = "Select * From Service2";
            return (await connection.QueryAsync<Service2>(query)).AsList();
        }

        public async Task<Service2> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Select * From Service2 Where Service2ID='{id}'";
            return (await connection.QueryFirstAsync<Service2>(query));
        }

        public async Task UpdateAsync(int id,Service2 entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Update Service2 SET Service2Icon='{entity.Service2Icon}',Service2Image='{entity.Service2Image}',Service2Title='{entity.Service2Title}',Service2Description='{entity.Service2Description}' Where Service2ID='{id}'";
            await connection.ExecuteAsync(query);
        }
    }
}
