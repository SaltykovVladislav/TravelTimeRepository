using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ITravelService
    {
        Task<List<Travel>> GetAll();
        Task<Travel> GetById(int id);
        Task Create(Travel model);
        Task Update(Travel model);
        Task Delete(int id);
    }
}