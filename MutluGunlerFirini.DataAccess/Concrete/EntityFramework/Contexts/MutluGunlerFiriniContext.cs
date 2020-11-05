using Microsoft.EntityFrameworkCore;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.DataAccess.Concrete.EntityFramework.Contexts
{
    public class MutluGunlerFiriniContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-P86I936;Initial Catalog=MutluGunlerFirini;Persist Security Info=True;User ID=celil;Password=1980");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        

    }
}

