using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IRatingNewsUserService
    {
        Task<List<RatingNewsUser>> GetAll();
        Task<RatingNewsUser> GetById(int id);
        Task Create(RatingNewsUser model);
        Task Update(RatingNewsUser model);
        Task Delete(int id);
    }
}