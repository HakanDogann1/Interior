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
    public class ServiceAppService : IServiceAppService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceAppService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task AddAsync(Service entity)
        {
            await _serviceRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _serviceRepository.DeleteAsync(id);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            var values = await _serviceRepository.GetAllAsync();
            return values;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            var value = await _serviceRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Service entity)
        {
            await _serviceRepository.UpdateAsync(id,entity);
        }
    }
}
