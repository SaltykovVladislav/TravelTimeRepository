using System;
using System.Collections.Generic;

namespace TravelTimeDatabasses.Models;

public partial class Travel
{
    public int Idtravel { get; set; }

    public string NameTravel { get; set; } = null!;

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public int Idgroup { get; set; }

    public int Idway { get; set; }

    public virtual Group IdgroupNavigation { get; set; } = null!;

    public virtual Way IdwayNavigation { get; set; } = null!;
}
