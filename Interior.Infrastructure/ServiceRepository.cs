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
    public class ServiceRepository : IServiceRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";

        public async Task AddAsync(Service entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Service (ServiceIcon,ServiceTitle,ServiceDescription) Values ('{entity.ServiceIcon}','{entity.ServiceTitle}','{entity.ServiceDescription}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Delete From Service Where ServiceID='{id}'";
            await connection.ExecuteAsync(query);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Select * From Service";
            return(await connection.QueryAsync<Service>(query)).AsList();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Select * From Service Where ServiceID='{id}'";
            return (await connection.QueryFirstAsync<Service>(query));
        }

        public async Task UpdateAsync(int id, Service entity)
        {
           await using var connection = new SqlConnection(_connectionString);
            var query = $"Update Service SET ServiceIcon='{entity.ServiceIcon}',ServiceTitle='{entity.ServiceTitle}',ServiceDescription='{entity.ServiceDescription}' Where ServiceID='{id}'";
            await connection.ExecuteAsync(query);
        }
    }
}
