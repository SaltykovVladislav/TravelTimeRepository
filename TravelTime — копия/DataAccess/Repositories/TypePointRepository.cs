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
    public class TypePointRepository : RepositoryBase<TypePoint>, ITypePointRepository
    {
        public TypePointRepository (TravelTimeContext repositoryContext)
            : base(repositoryContext) 
        { 
        }
    }
}
