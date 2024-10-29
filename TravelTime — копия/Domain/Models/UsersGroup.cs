using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UsersGroup
{
    public int Idgroup { get; set; }

    public int Idusers { get; set; }

    public string? Position { get; set; }

    public virtual Group IdgroupNavigation { get; set; } = null!;

    public virtual User IdusersNavigation { get; set; } = null!;
}
