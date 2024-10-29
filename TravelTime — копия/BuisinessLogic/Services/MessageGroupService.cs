using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class MessageGroupService : IMessageGroupService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessageGroupService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MessageGroup>> GetAll()
        {
            return await _repositoryWrapper.MessageGroup.FindAll();
        }

        public async Task<MessageGroup> GetByIdMessage(int idGroup, int idMess)
        {
            var user = await _repositoryWrapper.MessageGroup.FindByCondition(x => (x.Idgroup == idGroup && x.Idmessage == idMess));
            return user.First();
        }
        public async Task<List<MessageGroup>> GetByIdAllMessageGroup(int id)
        {
            var user = await _repositoryWrapper.MessageGroup.FindByCondition(x => x.Idgroup == id);
            return user;
        }
        public async Task Create(MessageGroup model)
        {
            await _repositoryWrapper.MessageGroup.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(MessageGroup model)
        {
            _repositoryWrapper.MessageGroup.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task DeleteMessage(int idGroup, int idMess)
        {
            var user = await _repositoryWrapper.MessageGroup.FindByCondition(x => (x.Idgroup == idGroup && x.Idmessage == idMess));

            _repositoryWrapper.MessageGroup.Delete(user.First());
            _repositoryWrapper.Save();
        }

        public async Task DeleteCleanChat(int id)
        {
            var user = await _repositoryWrapper.MessageGroup.FindByCondition(x => x.Idgroup == id);

            _repositoryWrapper.MessageGroup.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
