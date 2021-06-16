using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public int CookingDuration { get; set; }
        public int Temperature { get; set; }
        public Photo Photo { get; set; }

        public ICollection<Direction> Directions { get; set; } = new List<Direction>();
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}
