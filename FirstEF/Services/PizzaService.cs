using FirstEF.Abstraction;
using FirstEF.DAL;
using FirstEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirstEF.Services
{
    internal class PizzaService : IService<Pizza>
    {
        public void Create(Pizza model)
        {
            Pizza pizza = new Pizza()
            { 
                Name = model.Name,
                Price = model.Price,
            };
            using (AppDbContext context = new AppDbContext())
            {
                context.Add(pizza);
                context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            Pizza pizza;
            using (AppDbContext context = new AppDbContext())
            {
                pizza = context.Pizzas.FirstOrDefault(x => x.Id == Id);
                if (pizza != null) 
                {
                    context.Pizzas.Remove(pizza);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Bele bir pizza yoxdur");
                    return;
                }
            }
        }

        public List<Pizza> GetAll()
        {
            List<Pizza> pizzas = new List<Pizza>();
            using (AppDbContext context = new AppDbContext()) 
            {
                pizzas = context.Pizzas.ToList();
            }
            return pizzas;
        }

        public Pizza GetById(int Id)
        {
            Pizza pizza= new Pizza();
            using (AppDbContext context = new AppDbContext())
            {
                pizza = context.Pizzas.FirstOrDefault(p=>p.Id == Id);
            }
            return pizza;
        }

        public void Update(Pizza model)
        {
            Pizza pizza = new Pizza();
            using (AppDbContext context = new AppDbContext())
            {
                context.Pizzas.FirstOrDefault(p=>p.Id == model.Id);
                pizza.Name = model.Name;
                pizza.Price = model.Price;
                context.SaveChanges();
            }
        }
    }
}
