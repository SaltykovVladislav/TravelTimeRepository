using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ContactListPmService : IContactListPmService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ContactListPmService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ContactListPm>> GetAll()
        {
            return await _repositoryWrapper.ContactListPm.FindAll();
        }

        public async Task<List<ContactListPm>> GetByIdin(int id)
        {
            var user = await _repositoryWrapper.ContactListPm.FindByCondition(x => x.Idusers == id);
            return user;
        }

        public async Task<List<ContactListPm>> GetByIdout(int id)
        {
            var user = await _repositoryWrapper.ContactListPm.FindByCondition(x => x.Idusers == id);
            return user;
        }

        public async Task Create(ContactListPm model)
        {
            await _repositoryWrapper.ContactListPm.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ContactListPm model)
        {
            _repositoryWrapper.ContactListPm.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id, int id2)
        {
            var user = await _repositoryWrapper.ContactListPm.FindByCondition(x => (x.Idusers == id && x.Idusers2 == id2));

            _repositoryWrapper.ContactListPm.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}