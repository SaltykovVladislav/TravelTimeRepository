using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int Idusers { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? FaterNameUou { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<ContactListPm> ContactListPmIdusers2Navigations { get; set; } = new List<ContactListPm>();

    public virtual ICollection<ContactListPm> ContactListPmIdusersNavigations { get; set; } = new List<ContactListPm>();

    public virtual ICollection<MessageListPm> MessageListPmIdaddresseeNavigations { get; set; } = new List<MessageListPm>();

    public virtual ICollection<MessageListPm> MessageListPmIdaddresserNavigations { get; set; } = new List<MessageListPm>();

    public virtual ICollection<RatingNewsUser> RatingNewsUsers { get; set; } = new List<RatingNewsUser>();

    public virtual ICollection<StoryVisitUser> StoryVisitUsers { get; set; } = new List<StoryVisitUser>();

    public virtual ICollection<UsersGroup> UsersGroups { get; set; } = new List<UsersGroup>();

    public virtual ICollection<Way> Ways { get; set; } = new List<Way>();

    public virtual ICollection<PreferencesUser> Idpreferences { get; set; } = new List<PreferencesUser>();

    public virtual ICollection<Role> Idroles { get; set; } = new List<Role>();
}
