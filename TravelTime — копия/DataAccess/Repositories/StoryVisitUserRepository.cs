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
    public class StoryVisitUserRepository : RepositoryBase<StoryVisitUser>, IStoryVisitUserRepository
    {
        public StoryVisitUserRepository(TravelTimeContext repositoryContext)
            : base(repositoryContext) 
        { 
        }
    }
}
