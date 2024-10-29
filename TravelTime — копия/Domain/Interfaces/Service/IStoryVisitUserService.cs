using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IStoryVisitUserService
    {
        Task<List<StoryVisitUser>> GetAll();
        Task<List<StoryVisitUser>> GetDostoprimechatelnostByIdUser(int id);
        Task<List<StoryVisitUser>> GetUsersByIdDostoprimechatelnost(int id);
        Task<StoryVisitUser> GetInfoById(int idThink, int idUser);
        Task Create(StoryVisitUser model);
        Task Update(StoryVisitUser model);
        Task Delete(int idThink, int idUser);
    }
}