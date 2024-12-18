using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourWork2024.Models;

namespace CourWork2024.Data
{
    public class CourWork2024Context : DbContext
    {
        public CourWork2024Context (DbContextOptions<CourWork2024Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CourWork2024.Models.Car> Cars { get; set; } = default!;
        public DbSet<CourWork2024.Models.Model> Models { get; set; } = default!;
        public DbSet<CourWork2024.Models.Picture> Pictures { get; set; } = default!;
        public DbSet<CourWork2024.Models.BodyT> BodyTs { get; set; } = default!;
        public DbSet<CourWork2024.Models.Brand> Brands { get; set; } = default!;
        public DbSet<CourWork2024.Models.Item> Items { get; set; } = default!;
        public DbSet<CourWork2024.Models.GearBox> GearBoxes { get; set; } = default!;
        public DbSet<CourWork2024.Models.Customer> Customers { get; set; } = default!;
        public DbSet<CourWork2024.Models.Color> Colors { get; set; } = default!;
    }
}
