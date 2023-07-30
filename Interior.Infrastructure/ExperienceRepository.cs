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
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";
        public async Task AddAsync(Experience entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Experience (ExperienceTitle,ExperienceSubtitle,ExperienceDescription,ExperienceVideo) Values ('{entity.ExperienceTitle}','{entity.ExperienceSubtitle}','{entity.ExperienceDescription}','{entity.ExperienceVideo}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Delete From Experience Where ExperienceID='{id}'";
            await connection.ExecuteAsync(query, connection);
        }

        public async Task<List<Experience>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = "Select * from Experience";
            return (await connection.QueryAsync<Experience>(query)).AsList();

        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Select * From Experience Where ExperienceID='{id}'";
            return (await connection.QueryFirstAsync<Experience>(query));
        }

        public async Task UpdateAsync(int id, Experience entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Update Experience SET ExperienceTitle='{entity.ExperienceTitle}',ExperienceSubtitle='{entity.ExperienceSubtitle}',ExperienceDescription='{entity.ExperienceDescription}',ExperienceVideo='{entity.ExperienceVideo}' Where ExperienceID='{id}'";
            await connection.ExecuteAsync(query);
        }
    }
}
