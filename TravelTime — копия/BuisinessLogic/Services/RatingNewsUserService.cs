using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class RatingNewsUserService : IRatingNewsUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RatingNewsUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<RatingNewsUser>> GetAll()
        {
            return await _repositoryWrapper.RatingNewsUser.FindAll();
        }

        public async Task<RatingNewsUser> GetById(int id)
        {
            var RatingNewsUser = await _repositoryWrapper.RatingNewsUser
                .FindByCondition(x => x.Idnews == id);
            return RatingNewsUser.First();
        }

        public async Task Create(RatingNewsUser model)
        {
            await _repositoryWrapper.RatingNewsUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(RatingNewsUser model)
        {
            _repositoryWrapper.RatingNewsUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var RatingNewsUser = await _repositoryWrapper.RatingNewsUser
                .FindByCondition(x => x.Idnews == id);

            _repositoryWrapper.RatingNewsUser.Delete(RatingNewsUser.First());
            _repositoryWrapper.Save();
        }
    }
}

