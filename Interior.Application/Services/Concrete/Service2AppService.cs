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
    public class Service2AppService : IService2AppService
    {
        private readonly IService2Repository _service2Repository;

        public Service2AppService(IService2Repository service2Repository)
        {
            _service2Repository = service2Repository;
        }

        public async Task AddAsync(Service2 entity)
        {
            await _service2Repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _service2Repository.DeleteAsync(id);
        }

        public async Task<List<Service2>> GetAllAsync()
        {
            var values = await _service2Repository.GetAllAsync();
            return values;
        }

        public async Task<Service2> GetByIdAsync(int id)
        {
            var value = await _service2Repository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Service2 entity)
        {
            await _service2Repository.UpdateAsync(id,entity);
        }
    }
}
