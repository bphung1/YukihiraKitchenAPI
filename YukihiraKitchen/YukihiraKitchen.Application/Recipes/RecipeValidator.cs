using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Domain;


namespace YukihiraKitchen.Application.Recipes
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.RecipeName).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CookingDuration).NotEmpty();
            RuleFor(x => x.Temperature).NotEmpty();
        }
    }
}
