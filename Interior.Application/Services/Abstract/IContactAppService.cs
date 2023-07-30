using Interior.DomainLayer.Concrete;
using Interior.DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interior.Application.Services.Abstract
{
    public interface IContactAppService: IRepositoryAppService<Contact>
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact entity);
        Task UpdateAsync(int id, Contact entity);
        Task DeleteAsync(int id);
    }
}
