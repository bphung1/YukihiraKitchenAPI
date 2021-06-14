using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Photos;

namespace YukihiraKitchen.Application.Interfaces
{
    public interface IPhotoAccessor
    {
        /*
         * these two are not touching the DB at all
         * it is purely used for uploading and deleting photos
         * from cloudinary
        **/
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}
