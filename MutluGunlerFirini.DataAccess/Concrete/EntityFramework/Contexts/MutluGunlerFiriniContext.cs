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
            optionsBuilder.UseSqlServer(@"Server=mutlugunlerfirini.com.tr.\MSSQLSERVER2019;Initial Catalog=MutluGunlerFirini;Persist Security Info=True;User ID=jestaramutlu;Password=5nnhwq08911980__");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Gallery> Galleries{ get; set; }
    }
}

