using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.DbContexts
{
    public class ADbContexts : IdentityDbContext<IdentityUser>
    {
        public ADbContexts(DbContextOptions<ADbContexts> options)
            : base(options)
        { }
        /*public ADbContexts(){}*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-7A0URME;Database=ProductManagement;Trusted_Connection=true; connect timeout=500;");
        }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
