using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Point
{
    public int Idpoint { get; set; }

    public string NamePoint { get; set; } = null!;

    public double? Rating10 { get; set; }

    public virtual ICollection<StoryVisitUser> StoryVisitUsers { get; set; } = new List<StoryVisitUser>();

    public virtual ICollection<TypePoint> IdtypePoints { get; set; } = new List<TypePoint>();

    public virtual ICollection<Way> Idways { get; set; } = new List<Way>();
}
