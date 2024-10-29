using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class PointService : IPointService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PointService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Point>> GetAll()
        {
            return await _repositoryWrapper.Point.FindAll();
        }

        public async Task<Point> GetById(int id)
        {
            var Point = await _repositoryWrapper.Point.FindByCondition(x => x.Idpoint == id);
            return Point.First();
        }

        public async Task Create(Point model)
        {
            await _repositoryWrapper.Point.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Point model)
        {
            _repositoryWrapper.Point.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Point = await _repositoryWrapper.Point
                .FindByCondition(x => x.Idpoint == id);

            _repositoryWrapper.Point.Delete(Point.First());
            _repositoryWrapper.Save();
        }
    }
}

