using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RatingNewsUser
{
    public int Idnews { get; set; }

    public int? Rating { get; set; }

    public int Idusers { get; set; }

    public virtual User IdusersNavigation { get; set; } = null!;

    public virtual News? News { get; set; }
}
