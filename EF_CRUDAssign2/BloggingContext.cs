using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CRUDAssign2
{
    public class BloggingContext : DbContext
    {
            public DbSet<User> Users { get; set; }
            public string DbPath { get; set; }
            public BloggingContext()
            {
                var path = AppContext.BaseDirectory;
                DbPath = Path.Join(path, "EF_CRUDAssign2.db");
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }
}
