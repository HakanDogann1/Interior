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
    public class ProjectAppService : IProjectAppService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectAppService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task AddAsync(Project entity)
        {
            await _projectRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var values =await _projectRepository.GetAllAsync();
            return values;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var value = await _projectRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Project entity)
        {
            await _projectRepository.UpdateAsync(id, entity);
            
        }
    }
}
