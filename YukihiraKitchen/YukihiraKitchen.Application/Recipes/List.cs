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
    public class List
    {
        public class Query : IRequest<Result<List<Recipe>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Recipe>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Recipe>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Recipe>>.Success(await _context.Recipes.ToListAsync());
            }
        }
    }
}
