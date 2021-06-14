using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Core;
using YukihiraKitchen.Domain;
using YukihiraKitchen.Persistence;

namespace YukihiraKitchen.Application.Ingredients
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        { 
            public Ingredient Ingredient { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Ingredients.Add(request.Ingredient);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) Result<Unit>.Failure("Failed to create ingredient");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
