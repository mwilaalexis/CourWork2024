﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourWork2024.Models;

public partial class GearBox
{
    [Key]
    public int ID { get; set; }

    public string Name { get; set; }

    [InverseProperty("GearBox")]
    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}