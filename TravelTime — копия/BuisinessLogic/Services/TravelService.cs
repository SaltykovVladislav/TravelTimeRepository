using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class TravelService : ITravelService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TravelService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Travel>> GetAll()
        {
            return await _repositoryWrapper.Travel.FindAll();
        }

        public async Task<Travel> GetById(int id)
        {
            var Travel = await _repositoryWrapper.Travel
                .FindByCondition(x => x.Idtravel == id);
            return Travel.First();
        }

        public async Task Create(Travel model)
        {
            await _repositoryWrapper.Travel.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Travel model)
        {
            _repositoryWrapper.Travel.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Travel = await _repositoryWrapper.Travel
                .FindByCondition(x => x.Idtravel == id);

            _repositoryWrapper.Travel.Delete(Travel.First());
            _repositoryWrapper.Save();
        }
    }
}

