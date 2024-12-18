using System;
using System.Collections.Generic;

namespace CourWork2024.Models;

public partial class Item
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public DateTime Date { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
