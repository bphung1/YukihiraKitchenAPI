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

namespace YukihiraKitchen.Application.Ingredients
{
    public class List
    {
        public class Query : IRequest<Result<List<Ingredient>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Ingredient>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Ingredient>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await _context.Ingredients.ToListAsync();

                return Result<List<Ingredient>>.Success(query);
            }
        }
    }
}
