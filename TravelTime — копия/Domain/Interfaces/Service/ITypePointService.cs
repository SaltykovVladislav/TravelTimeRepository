using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ITypePointService
    {
        Task<List<TypePoint>> GetAll();
        Task<TypePoint> GetById(int id);
        Task Create(TypePoint model);
        Task Update(TypePoint model);
        Task Delete(int id);
    }
}