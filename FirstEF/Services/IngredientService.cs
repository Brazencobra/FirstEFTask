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
    internal class IngredientService : IService<Ingredient>
    {
        public void Create(Ingredient model)
        {
            Ingredient ingredient = new Ingredient { Name = model.Name , PizzaId = model.PizzaId };
            using (AppDbContext context = new AppDbContext())
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            Ingredient ingredient = new Ingredient();
            using (AppDbContext context = new AppDbContext())
            {
                ingredient = context.Ingredients.FirstOrDefault(x => x.Id == Id);
                context.Ingredients.Remove(ingredient);
                context.SaveChanges();
            }
        }

        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (AppDbContext context = new AppDbContext())
            {
                ingredients = context.Ingredients.ToList();
            }
            return ingredients;
        }

        public Ingredient GetById(int Id)
        {
            Ingredient ingredient;
            using (AppDbContext context = new AppDbContext())
            {
                ingredient = context.Ingredients.FirstOrDefault(x=>x.Id == Id);
            }
            return ingredient;
        }   

        public void Update(Ingredient model)
        {
            Ingredient ingredient = new Ingredient();
            using (AppDbContext context = new AppDbContext())
            {
                context.Ingredients.FirstOrDefault(x=>x.Id == model.Id);
                ingredient.Name = model.Name;
                context.SaveChanges();
            }
        }
    }
}
