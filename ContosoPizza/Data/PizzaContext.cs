using ContosoPizza.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext() { }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Sauce> Sauces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString);
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=ContosoPizza;Trusted_Connection=True;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer(@"Server=EDUARDOLOZANO\SQLEXPRESS;Database=ContosoPizza;Trusted_Connection=True;TrustServerCertificate=True");

        }

    }
}
