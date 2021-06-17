using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace YukihiraKitchen.Application.Directions
{
    public class Add
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid RecipeId { get; set; }
            public DirectionParam Param { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Param).SetValidator(new DirectionValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var recipe = await _context.Recipes
                    .Include(r => r.Directions)
                    .FirstOrDefaultAsync(x => x.Id == request.RecipeId);

                if (recipe == null) return null;

                if (recipe.Directions.Count != 0)
                {
                    foreach (var dir in recipe.Directions)
                    {
                        if (dir.CookingStepNumber == request.Param.StepNumber)
                            return Result<Unit>.Failure("Step number already exist");
                    }
                }

                var direction = new Direction
                {
                    Recipe = recipe,
                    CookingStepNumber = request.Param.StepNumber,
                    CookingDirection = request.Param.CookingDirection
                };

                recipe.Directions.Add(direction);

                var result = await _context.SaveChangesAsync() > 0;

                return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem adding direction to recipe");
            }
        }
    }
}
