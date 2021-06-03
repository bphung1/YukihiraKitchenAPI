using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Core;
using YukihiraKitchen.Domain;
using YukihiraKitchen.Persistence;

namespace YukihiraKitchen.Application.Recipes
{
    public class AddRecipeIngredient
    {
        public class Command : IRequest<Result<Unit>>
        { 
            public Guid Id { get; set; }
            public RecipeIngredientParam Param { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Param).SetValidator(new RecipeIngredientValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            /**
             *First check if recipe exist
             *Second get ingredient from Ingredient table
             *Third check if recipe contains this Recipe Ingredient
             *  if not, add the ingredient to the recipe 
             */
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var recipe = await _context.Recipes
                    .Include(r => r.RecipeIngredients)
                    .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (recipe == null) return null;

                var ingredient = await _context.Ingredients
                    .FirstOrDefaultAsync(x => x.IngredientName == request.Param.IngredientName);

                var containsIngredient = recipe.RecipeIngredients
                    .FirstOrDefault(ri => ri.Ingredient == ingredient);

                if (containsIngredient != null)
                    return Result<Unit>.Failure("Recipe already has this ingredient");

                if (containsIngredient == null)
                {
                    containsIngredient = new RecipeIngredient
                    {
                        Recipe = recipe,
                        Ingredient = ingredient,
                        IngredientQuantity = request.Param.Quantity,
                        IngredientMeasurement = request.Param.Measurement
                    };

                    recipe.RecipeIngredients.Add(containsIngredient);
                }

                var result = await _context.SaveChangesAsync() > 0;

                return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem adding ingredient to recipe");
            }
        }
    }
}
