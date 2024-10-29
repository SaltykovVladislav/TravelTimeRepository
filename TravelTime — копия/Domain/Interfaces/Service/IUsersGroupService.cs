using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IUsersGroupService
    {
        Task<List<UsersGroup>> GetAll();
        Task<List<UsersGroup>> GetGroupByIdUsers(int idUsers);
        Task<List<UsersGroup>> GetUsersByIdGroup(int idGroup);
        Task<UsersGroup> GetById(int idGroup,int idUsers);
        Task Create(UsersGroup model);
        Task Update(UsersGroup model);
        Task Delete(int idGroup,int idUsers);
    }
}