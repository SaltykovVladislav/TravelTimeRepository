using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataAccess.Models;
using Domain.Interfaces.Repository;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private TravelTimeContext _repoContext;

        private IUserRepository _user;
        
        public IUserRepository User 
        { 
            get 
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user; 
            } 
        }

        private ICategoryRepository _Category;

        public ICategoryRepository Category
        {
            get
            {
                if (_Category == null)
                {
                    _Category = new CategoryRepository(_repoContext);
                }
                return _Category;
            }
        }

        private IContactListPmRepository _ContactListPm;

        public IContactListPmRepository ContactListPm
        {
            get
            {
                if (_ContactListPm == null)
                {
                    _ContactListPm = new ContactListPmRepository(_repoContext);
                }
                return _ContactListPm;
            }
        }

        private IGroupRepository _Group;

        public IGroupRepository Group
        {
            get
            {
                if (_Group == null)
                {
                    _Group = new GroupRepository(_repoContext);
                }
                return _Group;
            }
        }

        private IMessageGroupRepository _MessageGroup;

        public IMessageGroupRepository MessageGroup
        {
            get
            {
                if (_MessageGroup == null)
                {
                    _MessageGroup = new MessageGroupRepository(_repoContext);
                }
                return _MessageGroup;
            }
        }

        private INewsRepository _News;

        public INewsRepository News
        {
            get
            {
                if (_News == null)
                {
                    _News = new NewsRepository(_repoContext);
                }
                return _News;
            }
        }
        private IPointRepository _Point;

        public IPointRepository Point
        {
            get
            {
                if (_Point == null)
                {
                    _Point = new PointRepository(_repoContext);
                }
                return _Point;
            }
        }

        private IPreferencesUserRepository _PreferencesUser;

        public IPreferencesUserRepository PreferencesUser
        {
            get
            {
                if (_PreferencesUser == null)
                {
                    _PreferencesUser = new PreferencesUserRepository(_repoContext);
                }
                return _PreferencesUser;
            }
        }

        private IRatingNewsUserRepository _RatingNewsUser;

        public IRatingNewsUserRepository RatingNewsUser
        {
            get
            {
                if (_RatingNewsUser == null)
                {
                    _RatingNewsUser = new RatingNewsUserRepository(_repoContext);
                }
                return _RatingNewsUser;
            }
        }

        private IRoleRepository _Role;

        public IRoleRepository Role
        {
            get
            {
                if (_Role == null)
                {
                    _Role = new RoleRepository(_repoContext);
                }
                return _Role;
            }
        }

        private IStoryVisitUserRepository _StoryVisitUser;

        public IStoryVisitUserRepository StoryVisitUser
        {
            get
            {
                if (_StoryVisitUser == null)
                {
                    _StoryVisitUser = new StoryVisitUserRepository(_repoContext);
                }
                return _StoryVisitUser;
            }
        }

        private ITravelRepository _Travel;

        public ITravelRepository Travel
        {
            get
            {
                if (_Travel == null)
                {
                    _Travel = new TravelRepository(_repoContext);
                }
                return _Travel;
            }
        }

        private ITypePointRepository _TypePoint;

        public ITypePointRepository TypePoint
        {
            get
            {
                if (_TypePoint == null)
                {
                    _TypePoint = new TypePointRepository(_repoContext);
                }
                return _TypePoint;
            }
        }
        /*
        private ITypePointWayRepository _TypePointWay;

        public ITypePointWayRepository TypePointWay
        {
            get
            {
                if (_TypePointWay == null)
                {
                    _TypePointWay = new TypePointWayRepository(_repoContext);
                }
                return _TypePointWay;
            }
        }
        */

        private IUsersGroupRepository _UsersGroup;

        public IUsersGroupRepository UsersGroup
        {
            get
            {
                if (_UsersGroup == null)
                {
                    _UsersGroup = new UsersGroupRepository(_repoContext);
                }
                return _UsersGroup;
            }
        }

        private IWayRepository _Way;

        public IWayRepository Way
        {
            get
            {
                if (_Way == null)
                {
                    _Way = new WayRepository(_repoContext);
                }
                return _Way;
            }
        }

        public RepositoryWrapper(TravelTimeContext repositoryContext) 
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
