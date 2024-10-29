using System;
using System.Collections.Generic;

namespace TravelTimeDatabasses.Models;

public partial class ContactListPm
{
    public int Idusers2 { get; set; }

    public int Idusers { get; set; }

    public DateTime? LastContact { get; set; }

    public bool OnlineStatus { get; set; }

    public virtual User Idusers2Navigation { get; set; } = null!;

    public virtual User IdusersNavigation { get; set; } = null!;
}
