using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class PreferencesUserService : IPreferencesUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PreferencesUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PreferencesUser>> GetAll()
        {
            return await _repositoryWrapper.PreferencesUser.FindAll();
        }

        public async Task<PreferencesUser> GetById(int id)
        {
            var PreferencesUser = await _repositoryWrapper.PreferencesUser
                .FindByCondition(x => x.Idpreferences == id);
            return PreferencesUser.First();
        }

        public async Task Create(PreferencesUser model)
        {
            await _repositoryWrapper.PreferencesUser.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(PreferencesUser model)
        {
            _repositoryWrapper.PreferencesUser.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var PreferencesUser = await _repositoryWrapper.PreferencesUser
                .FindByCondition(x => x.Idpreferences == id);

            _repositoryWrapper.PreferencesUser.Delete(PreferencesUser.First());
            _repositoryWrapper.Save();
        }
    }
}

