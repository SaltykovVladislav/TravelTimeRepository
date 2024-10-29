using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IWayService
    {
        Task<List<Way>> GetAll();
        Task<Way> GetById(int id);
        Task Create(Way model);
        Task Update(Way model);
        Task Delete(int id);
    }
}