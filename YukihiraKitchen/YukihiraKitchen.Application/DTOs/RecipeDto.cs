using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.Application.DTOs
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public int CookingDuration { get; set; }
        public int Temperature { get; set; }
        public Photo Photo { get; set; }

        public ICollection<Direction> Directions { get; set; }
        public ICollection<RecipeIngredientDto> RecipeIngredients { get; set; }
    }
}
