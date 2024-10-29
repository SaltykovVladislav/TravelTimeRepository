using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _repositoryWrapper.Role.FindAll();
        }

        public async Task<Role> GetById(int id)
        {
            var Role = await _repositoryWrapper.Role
                .FindByCondition(x => x.Idrole == id);
            return Role.First();
        }

        public async Task Create(Role model)
        {
            await _repositoryWrapper.Role.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Role model)
        {
            _repositoryWrapper.Role.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Role = await _repositoryWrapper.Role
                .FindByCondition(x => x.Idrole == id);

            _repositoryWrapper.Role.Delete(Role.First());
            _repositoryWrapper.Save();
        }
    }
}
