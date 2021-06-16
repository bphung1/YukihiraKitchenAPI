using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Core;
using YukihiraKitchen.Application.Interfaces;
using YukihiraKitchen.Domain;
using YukihiraKitchen.Persistence;

namespace YukihiraKitchen.Application.Photos
{
    public class Replace
    {
        public class Command : IRequest<Result<Photo>>
        {
            public IFormFile File { get; set; }
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Photo>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IPhotoAccessor photoAccessor, IMapper mapper)
            {
                _context = context;
                _photoAccessor = photoAccessor;
                _mapper = mapper;
            }

            public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
            {
                var recipe = await _context.Recipes
                    .Include(r => r.Photo)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                var photo = recipe.Photo;

                if (recipe == null || photo == null || request.File == null) return null;

                var tempRecipe = recipe;

                var result = await _photoAccessor.DeletePhoto(photo.Id);

                if (result == null) return Result<Photo>.Failure("Problem deleting photo from Cloudinary");

                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var newPhoto = new Photo
                {
                    Recipe = recipe,
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                tempRecipe.Photo = newPhoto;

                _mapper.Map(tempRecipe, recipe);

                var newPhotoResult = await _context.SaveChangesAsync() > 0;

                if (newPhotoResult) return Result<Photo>.Success(newPhoto);

                return Result<Photo>.Failure("Problem adding photo");

            }
        }
    }
}
