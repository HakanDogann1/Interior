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
    public class TeamRepository : ITeamRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";
        public async Task AddAsync(Team entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Team (TeamName,TeamSurname,TeamDepartment) Values ('{entity.TeamName}','{entity.TeamSurname}','{entity.TeamDepartment}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Delete From Team Where TeamID='{id}'";
            await connection.ExecuteAsync(query);
        }

        public async Task<List<Team>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = "Select * From Team";
            return (await connection.QueryAsync<Team>(query)).AsList();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            await using var  connection = new SqlConnection(_connectionString);
            var query = $"Select * From Team Where TeamID='{id}'";
            return (await connection.QueryFirstAsync<Team>(query));
        }

        public async Task UpdateAsync(int id, Team entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Update Team SET TeamName='{entity.TeamName}',TeamSurname='{entity.TeamSurname}',TeamDepartment='{entity.TeamDepartment}' Where TeamID='{id}'";
            await connection.ExecuteAsync(query);
        }
    }
}
