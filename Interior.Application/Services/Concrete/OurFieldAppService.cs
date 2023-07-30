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
    public class OurFieldAppService : IOurFieldAppService
    {
        private readonly IOurFieldRepository _ourFieldRepository;

        public OurFieldAppService(IOurFieldRepository ourFieldRepository)
        {
            _ourFieldRepository = ourFieldRepository;
        }

        public async Task AddAsync(OurField entity)
        {
            await _ourFieldRepository.AddAsync(entity); 
        }

        public async Task DeleteAsync(int id)
        {
          await _ourFieldRepository.DeleteAsync(id);
        }

        public async Task<List<OurField>> GetAllAsync()
        {
           var values = await _ourFieldRepository.GetAllAsync();    
            return values;
        }

        public async Task<OurField> GetByIdAsync(int id)
        {
            var value = await _ourFieldRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, OurField entity)
        {
            await _ourFieldRepository.UpdateAsync(id, entity);
        }
    }
}
