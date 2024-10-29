using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Way
{
    public int Idway { get; set; }

    public string WayName { get; set; } = null!;

    public string? ContentWay { get; set; }

    public double? Rating { get; set; }

    public int IduserCreator { get; set; }

    public virtual User IduserCreatorNavigation { get; set; } = null!;

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();

    public virtual ICollection<Point> Idpoints { get; set; } = new List<Point>();
}
