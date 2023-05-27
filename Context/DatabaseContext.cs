using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YemekSiparis.Entities;

namespace YemekSiparis.Context
{
    public class DatabaseContext:DbContext
    {
        
        public DatabaseContext():base("SQL")
        {
            Database.SetInitializer(new Initilizer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ExtraMaterial> ExtraMaterials { get; set; }

        public DbSet<User> Users { get; set; }
    }
}