using Azure.Core;
using FirstEF.Abstraction;
using FirstEF.DAL;
using FirstEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEF.Services
{
    internal class SizeService : IService<Size>
    {
        public void Create(Size model)
        {
            Size size = new Size
            {
                Name = model.Name,
                PizzaId = model.PizzaId,
            };
            using (AppDbContext context = new AppDbContext()) 
            {
                context.Add(size);
                context.SaveChanges();  
            }
        }

        public void Delete(int Id)
        {
            Size size = new Size();
            using (AppDbContext context = new AppDbContext()) 
            {
                size = context.Sizes.FirstOrDefault(x => x.Id == Id);
                if (size != null)
                {
                    context.Sizes.Remove(size);
                    context.SaveChanges();
                }
                else {Console.WriteLine("Bele bir olcu yoxdur"); } 
            }
        }

        public List<Size> GetAll()
        {
            List<Size> list = new List<Size>();
            using (AppDbContext context = new AppDbContext())
            {
                list = context.Sizes.ToList();
            }
            return list;
        }

        public Size GetById(int Id)
        {
            Size size = new Size();
            using (AppDbContext context = new AppDbContext())
            {
                size = context.Sizes.FirstOrDefault(x=>x.Id == Id);
            }
            return size;
        }

        public void Update(Size model)
        {
            Size size = new Size();
            using (AppDbContext context = new AppDbContext())
            {
                context.Sizes.FirstOrDefault(x=>x.Id == model.Id);
                size.Name = model.Name;
                size.PizzaId = model.PizzaId;
                context.SaveChanges();
            }
        }
    }
}
