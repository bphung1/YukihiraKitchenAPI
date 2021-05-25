using AutoMapper;
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
    public class Details
    {
        public class Query : IRequest<Result<Recipe>>
        { 
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Recipe>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Recipe>> Handle(Query request, CancellationToken cancellationToken)
            {
                var recipe = await _context.Recipes
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<Recipe>.Success(recipe);
            }
        }
    }
}
