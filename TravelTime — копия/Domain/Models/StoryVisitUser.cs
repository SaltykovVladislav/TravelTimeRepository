using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class StoryVisitUser
{
    public int Idusers { get; set; }

    public int Idpoint { get; set; }

    public DateTime? DatetimeVisit { get; set; }

    public int? Rating10 { get; set; }

    public virtual Point IdpointNavigation { get; set; } = null!;

    public virtual User IdusersNavigation { get; set; } = null!;
}
