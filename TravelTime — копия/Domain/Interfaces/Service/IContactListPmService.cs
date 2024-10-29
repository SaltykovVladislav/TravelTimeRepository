using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IContactListPmService
    {
        Task<List<ContactListPm>> GetAll();
        Task<List<ContactListPm>> GetByIdin(int id);
        Task<List<ContactListPm>> GetByIdout(int id);
        Task Create(ContactListPm model);
        Task Update(ContactListPm model);
        Task Delete(int id ,int id2);
    }
}