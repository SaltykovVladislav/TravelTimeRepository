using System;
using System.Collections.Generic;

namespace TravelTimeDatabasses.Models;

public partial class Category
{
    public int Idcategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
