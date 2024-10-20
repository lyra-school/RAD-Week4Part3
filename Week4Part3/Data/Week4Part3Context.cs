using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductModel;

namespace Week4Part3.Data
{
    public class Week4Part3Context : DbContext
    {
        public Week4Part3Context (DbContextOptions<Week4Part3Context> options)
            : base(options)
        {
        }

        public DbSet<ProductModel.Category> Category { get; set; } = default!;
        public DbSet<ProductModel.Product> Product { get; set; } = default!;
        public DbSet<ProductModel.Supplier> Supplier { get; set; } = default!;
    }
}
