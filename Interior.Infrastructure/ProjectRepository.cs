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
    public class ProjectRepository : IProjectRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";
        public async Task AddAsync(Project entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Project (ProjectTitle,ProjectDescription,ProjectImage) Values ('{entity.ProjectTitle}','{entity.ProjectDescription}','{entity.ProjectImage}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Delete From Project Where ProjectID='{id}'";
            await connection.ExecuteAsync(query);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = "Select * From Project";
            return (await connection.QueryAsync<Project>(query)).AsList();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Select * From Project Where ProjectID='{id}'";
            return (await connection.QueryFirstAsync<Project>(query));
        }

        public async Task UpdateAsync(int id, Project entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Update Project SET ProjectTitle='{entity.ProjectTitle}',ProjectDescription='{entity.ProjectDescription}',ProjectImage='{entity.ProjectImage}' Where ProjectID='{id}'";
            await connection.ExecuteAsync(query);
        }
    }
}
