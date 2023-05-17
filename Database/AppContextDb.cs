using Microsoft.EntityFrameworkCore;
using Contoso.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Contoso.Database
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Pizzaria;Integrated Security=True;Trust Server Certificate=true");
        //}
        public DbSet<Pizza> Pizzas { get; set; }
        
    }

}
