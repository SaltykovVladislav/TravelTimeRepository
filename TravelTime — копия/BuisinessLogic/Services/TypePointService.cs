using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class TypePointService : ITypePointService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TypePointService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<TypePoint>> GetAll()
        {
            return await _repositoryWrapper.TypePoint.FindAll();
        }

        public async Task<TypePoint> GetById(int id)
        {
            var TypePoint = await _repositoryWrapper.TypePoint.FindByCondition(x => x.IdtypePoint == id);
            return TypePoint.First();
        }

        public async Task Create(TypePoint model)
        {
            await _repositoryWrapper.TypePoint.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(TypePoint model)
        {
            _repositoryWrapper.TypePoint.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var TypePoint = await _repositoryWrapper.TypePoint
                .FindByCondition(x => x.IdtypePoint == id);

            _repositoryWrapper.TypePoint.Delete(TypePoint.First());
            _repositoryWrapper.Save();
        }
    }
}

