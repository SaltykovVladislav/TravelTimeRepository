using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class MessageGroup
{
    public int Idgroup { get; set; }

    public int Idmessage { get; set; }

    public string? TiTleMessage { get; set; }

    public string Message { get; set; } = null!;

    public DateOnly DateOut { get; set; }

    public TimeOnly TimeOut { get; set; }

    public int Idaddressee { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Group IdgroupNavigation { get; set; } = null!;
}
