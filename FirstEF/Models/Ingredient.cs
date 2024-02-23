using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEF.Models
{
    internal class Ingredient
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int PizzaId { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
