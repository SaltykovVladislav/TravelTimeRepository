using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PreferencesUser
{
    public int Idpreferences { get; set; }

    public string Preferences { get; set; } = null!;

    public virtual ICollection<User> Idusers { get; set; } = new List<User>();
}
