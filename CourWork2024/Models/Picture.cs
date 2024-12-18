using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourWork2024.Models;

public  class Picture
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public int? CarId { get; set; }
    [ForeignKey(nameof(CarId))]
    public virtual Car? Car { get; set; }
}
