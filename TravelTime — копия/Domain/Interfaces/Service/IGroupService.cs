﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IGroupService
    {
        Task<List<Group>> GetAll();
        Task<Group> GetById(int id);
        Task Create(Group model);
        Task Update(Group model);
        Task Delete(int id);
    }
}