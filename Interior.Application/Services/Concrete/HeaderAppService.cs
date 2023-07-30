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
    public class HeaderAppService : IHeaderAppService
    {
        private readonly IHeaderRepository _headerRepository;

        public HeaderAppService(IHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }

        public async Task AddAsync(Header entity)
        {
            await _headerRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
           await _headerRepository.DeleteAsync(id);
        }

        public async Task<List<Header>> GetAllAsync()
        {
            var values = await _headerRepository.GetAllAsync();
            return values;
        }

        public async Task<Header> GetByIdAsync(int id)
        {
           var value = await _headerRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Header entity)
        {
            await _headerRepository.UpdateAsync(id, entity);
        }
    }
}
