using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class WayService : IWayService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public WayService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Way>> GetAll()
        {
            return await _repositoryWrapper.Way.FindAll();
        }

        public async Task<Way> GetById(int id)
        {
            var Way = await _repositoryWrapper.Way
                .FindByCondition(x => x.Idway == id);
            return Way.First();
        }

        public async Task Create(Way model)
        {
            await _repositoryWrapper.Way.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Way model)
        {
            _repositoryWrapper.Way.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Way = await _repositoryWrapper.Way
                .FindByCondition(x => x.Idway == id);

            _repositoryWrapper.Way.Delete(Way.First());
            _repositoryWrapper.Save();
        }
    }
}

