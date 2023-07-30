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
    public class ContactRepository : IContactRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-NOMRM5V\\SQLEXPRESS;Database=DbInterior;Trusted_Connection=true";
        public async Task AddAsync(Contact entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"Insert Into Contact (ContactName,ContactMail,ContactSubject,ContactMessage) Values ('{entity.ContactName}','{entity.ContactMail}','{entity.ContactSubject}','{entity.ContactMessage}')";
            await connection.ExecuteAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
           await using var connection = new SqlConnection(_connectionString);
            var sql = $"Delete From Contact Where ContactID={id}";
            await connection.ExecuteAsync(sql);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            return (await connection.QueryAsync<Contact>("Select * from Contact")).AsList();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var sql = $"Select * From Contact Where ContactID={id}";
            return (await connection.QueryFirstAsync<Contact>(sql));
        }

        public async Task UpdateAsync(int id,Contact entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            var sql = $"Update Contact SET ContactName='{entity.ContactName}',ContactMail='{entity.ContactMail}',ContactSubject='{entity.ContactSubject}',ContactMessage='{entity.ContactMessage}' Where ContactID='{id}'";
            await connection.ExecuteAsync(sql);
        }
    }
}
