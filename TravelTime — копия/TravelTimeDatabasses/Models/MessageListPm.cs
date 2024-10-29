using System;
using System.Collections.Generic;

namespace TravelTimeDatabasses.Models;

public partial class MessageListPm
{
    public int Idmessage { get; set; }

    public int Idaddresser { get; set; }

    public int Idaddressee { get; set; }

    public string? TiTle { get; set; }

    public string Message { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public bool IsRead { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User IdaddresseeNavigation { get; set; } = null!;

    public virtual User IdaddresserNavigation { get; set; } = null!;
}
