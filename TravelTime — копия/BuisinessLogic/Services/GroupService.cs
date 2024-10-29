using Domain.Interfaces;
using Domain.Interfaces.Service;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GroupService : IGroupService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Group>> GetAll()
        {
            return await _repositoryWrapper.Group.FindAll();
        }

        public async Task<Group> GetById(int id)
        {
            var user = await _repositoryWrapper.Group.FindByCondition(x => x.Idgroup == id);
            return user.First();
        }

        public async Task Create(Group model)
        {
            await _repositoryWrapper.Group.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Group model)
        {
            _repositoryWrapper.Group.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Group.FindByCondition(x => x.Idgroup == id);

            _repositoryWrapper.Group.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<User>> GetAll()
        {
            return _repositoryWrapper.User.FindAll().ToListAsync();
        }

        public Task<User> GetById(int id)
        {
            var user = _repositoryWrapper.User
                .FindByCondition(x => x.Idusers == id).First();
            return Task.FromResult(user);
        }

        public Task Create(User model)
        {
            _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var user = _repositoryWrapper.User
                .FindByCondition(x => x.Idusers == id).First();

            _repositoryWrapper.User.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}*/