using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Interior.DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interior.Application.Services.Concrete
{
    public class ContactAppService : IContactAppService
    {
        private readonly IContactRepository _contactRepository;

        public ContactAppService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddAsync(Contact entity)
        {
            await _contactRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var values = await _contactRepository.GetAllAsync();
            return values;
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            var value = await _contactRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Contact entity)
        {
            await _contactRepository.UpdateAsync(id, entity);
        }

       
    }
}
