using FirstEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEF.DAL
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=BRAZENCOBRA\\SQLEXPRESS;Database=PizzaMizza;Trusted_connection=true;Integrated Security=true;Encrypt=false");
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; } 
        public DbSet<Ingredient> Ingredients { get; set;}

    }
}
