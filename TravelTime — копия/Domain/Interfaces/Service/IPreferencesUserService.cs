using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IPreferencesUserService
    {
        Task<List<PreferencesUser>> GetAll();
        Task<PreferencesUser> GetById(int id);
        Task Create(PreferencesUser model);
        Task Update(PreferencesUser model);
        Task Delete(int id);
    }
}