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
    public class HeaderRepository : IHeaderRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";

        public async Task AddAsync(Header entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Header (HeaderTitle,HeaderSubtitle,HeaderDescription,HeaderImage) Values('{entity.HeaderTitle}','{entity.HeaderSubtitle}','{entity.HeaderDescription}','{entity.HeaderImage}')";
            await connection.ExecuteAsync(query) ;
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString) ;
            var query = $"Delete From Header Where HeaderID='{id}'";
            await connection.ExecuteAsync(query) ;
        }

        public async Task<List<Header>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString) ;
            var query = "Select * From Header";
            return (await connection.QueryAsync<Header>(query)).AsList() ;
        }

        public async Task<Header> GetByIdAsync(int id)
        {
           await using var connection = new SqlConnection(_connectionString) ;
            var query = $"Select * From Header Where HeaderID='{id}'";
            return (await connection.QueryFirstAsync<Header>(query));
        }

        public async Task UpdateAsync(int id, Header entity)
        {
           await using var connection = new SqlConnection(_connectionString) ;
            var query = $"Update Header Set HeaderTitle='{entity.HeaderTitle}',HeaderSubtitle='{entity.HeaderSubtitle}',HeaderDescription='{entity.HeaderDescription}',HeaderImage='{entity.HeaderImage}' Where HeaderID='{id}'";
            await connection.ExecuteAsync(query) ;
        }
    }
}
