using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Role
{
    public int Idrole { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Idusers { get; set; } = new List<User>();
}
