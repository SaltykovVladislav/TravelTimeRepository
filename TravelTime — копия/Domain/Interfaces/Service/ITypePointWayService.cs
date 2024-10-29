using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ITypePointWayService
    {
        Task<List<TypePointWay>> GetAll();
        Task<TypePointWay> GetById(int id);
        Task Create(TypePointWay model);
        Task Update(TypePointWay model);
        Task Delete(int id);
    }
}