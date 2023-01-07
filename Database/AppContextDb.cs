using Microsoft.EntityFrameworkCore;
using Contoso.Models;

namespace Contoso.Database
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Pizzaria;Integrated Security=True;Trust Server Certificate=true");
        }
        public DbSet<Pizza> Pizzas { get; set; }
        
    }

}
