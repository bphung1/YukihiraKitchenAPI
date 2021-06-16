using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.Application.Recipes
{
    public class RecipeIngredientValidator: AbstractValidator<RecipeIngredientParam>
    {
        public RecipeIngredientValidator()
        {
            RuleFor(x => x.IngredientName).NotEmpty();
            RuleFor(x => x.IngredientName).NotNull();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.Quantity).NotNull();
            RuleFor(x => x.Measurement).NotEmpty();
            RuleFor(x => x.Measurement).NotNull();

        }
    }
}
