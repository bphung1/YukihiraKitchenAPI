using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Domain
{
    public class RecipeIngredient
    {
        public Recipe Recipe { get; set; }
        public Guid RecipeId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
        public int IngredientQuantity { get; set; }
        public int IngredientMeasurement { get; set; }
    }
}
