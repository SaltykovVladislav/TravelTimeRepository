using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        IContactListPmRepository ContactListPm { get; }
        IGroupRepository Group { get; }
        IMessageGroupRepository MessageGroup { get; }
        INewsRepository News { get; }
        IPointRepository Point { get; }
        IPreferencesUserRepository PreferencesUser { get; }
        IRatingNewsUserRepository RatingNewsUser { get; }//!!!Тут была серьезная проблема!!!  IRatingNewsUserRepository UseRatingNewsUserr { get; }
        IRoleRepository Role { get; }
        IStoryVisitUserRepository StoryVisitUser { get; }
        ITravelRepository Travel { get; }
        ITypePointRepository TypePoint { get; }
        IUserRepository User { get; }
        IUsersGroupRepository UsersGroup { get; }
        IWayRepository Way { get; }
        Task Save();
    }
}
