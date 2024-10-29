using System;
using System.Collections.Generic;

namespace TravelTimeDatabasses.Models;

public partial class News
{
    public int Idnews { get; set; }

    public string NameNews { get; set; } = null!;

    public string ContentNews { get; set; } = null!;

    public int Idcreator { get; set; }

    public int? Idcategory { get; set; }

    public int? Rating10 { get; set; }

    public virtual Category? IdcategoryNavigation { get; set; }

    public virtual RatingNewsUser IdnewsNavigation { get; set; } = null!;
}
