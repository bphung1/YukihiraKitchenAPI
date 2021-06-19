using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Core;
using YukihiraKitchen.Application.DTOs;
using YukihiraKitchen.Domain;
using YukihiraKitchen.Persistence;

namespace YukihiraKitchen.Application.Recipes
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<RecipeDto>>> 
        {
            public PagingParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<RecipeDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<RecipeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Recipes
                    .OrderBy(n => n.RecipeName.ToUpper())
                    .ProjectTo<RecipeDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();
                return Result<PagedList<RecipeDto>>.Success(await PagedList<RecipeDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}
