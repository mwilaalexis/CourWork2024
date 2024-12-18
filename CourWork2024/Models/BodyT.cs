using System;
using System.Collections.Generic;

namespace CourWork2024.Models;

public partial class BodyT
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
