using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UsersGroupService : IUsersGroupService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UsersGroupService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UsersGroup>> GetAll()
        {
            return await _repositoryWrapper.UsersGroup.FindAll();
        }
        
        public async Task<List<UsersGroup>> GetGroupByIdUsers(int idUsers)
        {
            var UsersGroup = await _repositoryWrapper.UsersGroup.FindByCondition(x => x.Idusers == idUsers);
            return UsersGroup;
        }
        public async Task<List<UsersGroup>> GetUsersByIdGroup(int idGroup)
        {
            var UsersGroup = await _repositoryWrapper.UsersGroup.FindByCondition(x => x.Idgroup == idGroup);
            return UsersGroup;
        }
        public async Task<UsersGroup> GetById(int idUsers,int idGroup)
        {
            var UsersGroup = await _repositoryWrapper.UsersGroup.FindByCondition(x => (x.Idusers == idUsers && x.Idgroup == idGroup));
            return UsersGroup.First();
        }

        public async Task Create(UsersGroup model)
        {
            await _repositoryWrapper.UsersGroup.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(UsersGroup model)
        {
            _repositoryWrapper.UsersGroup.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int idUsers, int idGroup)
        {
            var UsersGroup = await _repositoryWrapper.UsersGroup.FindByCondition(x => (x.Idusers == idUsers && x.Idgroup == idGroup));

            _repositoryWrapper.UsersGroup.Delete(UsersGroup.First());
            _repositoryWrapper.Save();
        }
    }
}

