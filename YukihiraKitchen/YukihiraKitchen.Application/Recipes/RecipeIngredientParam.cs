using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Application.Recipes
{
    public class RecipeIngredientParam
    {
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
    }
}
