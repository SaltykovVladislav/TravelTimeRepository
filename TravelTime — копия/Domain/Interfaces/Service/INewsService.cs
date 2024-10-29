using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface INewsService
    {
        Task<List<News>> GetAll();
        Task<News> GetById(int id);
        Task Create(News model);
        Task Update(News model);
        Task Delete(int id);
    }
}