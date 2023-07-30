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
    public class ExperienceAppService : IExperienceAppService
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceAppService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task AddAsync(Experience entity)
        {
            await _experienceRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
           await _experienceRepository.DeleteAsync(id);
        }

        public async Task<List<Experience>> GetAllAsync()
        {
           var values =  await _experienceRepository.GetAllAsync();
            return values;
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            var value = await _experienceRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Experience entity)
        {
            await _experienceRepository.UpdateAsync(id, entity);
        }
    }
}
