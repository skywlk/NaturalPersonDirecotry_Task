using NPD.Domain.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NPD.Infrastructure.Services
{
    public class ImageManager
    {
        protected string Path = Directory.GetCurrentDirectory() + @"\Images";
        private readonly IImageStoreage _imageStoreage;

        public ImageManager(IImageStoreage imageStoreage)
        {
            _imageStoreage = imageStoreage;
        }

        public async Task<string> SaveBase64EncodedImageAsync(string base64String, int idForIdentification)
        {
            var data = base64String.Split(',');
            var imageBuffer = DecodeBase64Image(data[1]);
            var imageFormat = GetImageFormat(data[0]);
            var imageName = GenerateImageName(imageFormat, idForIdentification);

            if (!_imageStoreage.FolderExistsCheck(Path))
            {
                throw new Exception("exception, can't locate or create image directory");
            }

            await _imageStoreage.StoreImageAsync(imageBuffer, Path, imageName);
            return $"{Path}{imageName}";
        }

        private string GenerateImageName(string imageFormat, int idForIdentification)
        {
            return @$"\{Guid.NewGuid()}_{idForIdentification.ToString()}.{imageFormat}";
        }

        protected byte[] DecodeBase64Image(string image)
        {
            return Convert.FromBase64String(image);
        }

        protected string GetImageFormat(string base64StringHeader)
        {
            return base64StringHeader.Split("/")[1].Split(';')[0];
        }
    }
}
