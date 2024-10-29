using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Group
{
    public int Idgroup { get; set; }

    public string NameGroup { get; set; } = null!;

    public int Number { get; set; }

    public int? Maxnumber { get; set; }

    public int? Minnumber { get; set; }

    public bool IsComplected { get; set; }

    public int Idcreator { get; set; }

    public virtual ICollection<MessageGroup> MessageGroups { get; set; } = new List<MessageGroup>();

    public virtual ICollection<Travel> Travels { get; set; } = new List<Travel>();

    public virtual ICollection<UsersGroup> UsersGroups { get; set; } = new List<UsersGroup>();
}
