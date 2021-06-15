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

            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
            {
                var recipe = await _context.Recipes
                    .Include(r => r.Photo)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (recipe == null) return null;

                var photo = recipe.Photo;

                if (photo == null) return null;

                var result = await _photoAccessor.DeletePhoto(photo.Id);

                if (result == null) return Result<Photo>.Failure("Problem deleting photo from Cloudinary");

                _context.Remove(photo);

                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var newPhoto = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                recipe.Photo = newPhoto;

                var newPhotoResult = await _context.SaveChangesAsync() > 0;

                if (newPhotoResult) return Result<Photo>.Success(newPhoto);

                return Result<Photo>.Failure("Problem adding photo");

            }
        }
    }
}
