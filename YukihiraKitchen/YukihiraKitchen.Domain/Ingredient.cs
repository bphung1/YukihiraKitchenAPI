using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
