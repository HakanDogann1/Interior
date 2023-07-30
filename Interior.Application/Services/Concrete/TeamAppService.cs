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
    public class TeamAppService : ITeamAppService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamAppService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task AddAsync(Team entity)
        {
            await _teamRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
        }

        public async Task<List<Team>> GetAllAsync()
        {
            var values = await _teamRepository.GetAllAsync();
            return values;
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            var value = await _teamRepository.GetByIdAsync(id);
            return value;
        }

        public async Task UpdateAsync(int id, Team entity)
        {
            await _teamRepository.UpdateAsync(id, entity);
        }
    }
}
