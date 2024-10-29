using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IMessageGroupService
    {
        Task<List<MessageGroup>> GetAll();
        Task<MessageGroup> GetByIdMessage(int idGroup, int idMess);
        Task<List<MessageGroup>> GetByIdAllMessageGroup(int id);
        Task Create(MessageGroup model);
        Task Update(MessageGroup model);
        Task DeleteMessage(int idGroup, int idMess);
        Task DeleteCleanChat(int id);
    }
}