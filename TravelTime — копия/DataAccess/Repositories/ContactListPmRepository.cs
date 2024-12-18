﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataAccess.Models;
using Domain.Interfaces.Repository;

namespace DataAccess.Repositories
{
    public class ContactListPmRepository : RepositoryBase<ContactListPm>, IContactListPmRepository
    {
        public ContactListPmRepository(TravelTimeContext repositoryContext)
            : base(repositoryContext) 
        { 
        }
    }
}
