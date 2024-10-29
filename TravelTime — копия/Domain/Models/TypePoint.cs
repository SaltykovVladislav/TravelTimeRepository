using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TypePoint
{
    public int IdtypePoint { get; set; }

    public string? TypePoint1 { get; set; }

    public virtual ICollection<Point> Idpoints { get; set; } = new List<Point>();
}
