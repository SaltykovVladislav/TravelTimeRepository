using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IPointService
    {
        Task<List<Point>> GetAll();
        Task<Point> GetById(int id);
        Task Create(Point model);
        Task Update(Point model);
        Task Delete(int id);
    }
}