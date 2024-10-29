using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class StoryVisitUserService : IStoryVisitUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StoryVisitUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<StoryVisitUser>> GetAll()
        {
            return await _repositoryWrapper.StoryVisitUser.FindAll();
        }

        public async Task<List<StoryVisitUser>> GetDostoprimechatelnostByIdUser(int id)
        {
            var StoryVisitUser = await _repositoryWrapper.StoryVisitUser.FindByCondition(x => x.Idusers == id);
            return StoryVisitUser;
        }
        public async Task<List<StoryVisitUser>> GetUsersByIdDostoprimechatelnost(int id)
        {
            var StoryVisitUser = await _repositoryWrapper.StoryVisitUser.FindByCondition(x => x.Idpoint == id);
            return StoryVisitUser;
        }
        public async Task<StoryVisitUser> GetInfoById(int idThink, int idUser)
        {
            var StoryVisitUser = await _repositoryWrapper.StoryVisitUser.FindByCondition(x => (x.Idpoint == idThink && x.Idusers == idUser));
            return StoryVisitUser.First();
        }

        public async Task Create(StoryVisitUser model)
        {
            await _repositoryWrapper.StoryVisitUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(StoryVisitUser model)
        {
            _repositoryWrapper.StoryVisitUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idThink, int idUser)
        {
            var StoryVisitUser = await _repositoryWrapper.StoryVisitUser.FindByCondition(x => (x.Idpoint == idThink && x.Idusers == idUser));

            _repositoryWrapper.StoryVisitUser.Delete(StoryVisitUser.First());
            _repositoryWrapper.Save();
        }
    }
}

