using NPD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NPD.Infrastructure.Services
{
    public class ImageStoreage : IImageStoreage
    {
        protected bool CreateStorageDirectory(string path)
        {
            var info = Directory.CreateDirectory(path);
            return info.Exists;
        }

        public bool FolderExistsCheck(string path)
        {
            if (!Directory.Exists(path))
            {
                return CreateStorageDirectory(path);
            }
            return true;
        }

        public async Task StoreImageAsync(byte[] imageBuffer, string path, string imageName)
        {
            await File.WriteAllBytesAsync(path + imageName, imageBuffer);
        }

        public async Task<string> ReadImage(string path)
        {
            var extension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension))
            {
                extension = "jpeg";
            }

            if (File.Exists(path))
            {
                var byteArray = await File.ReadAllBytesAsync(path);
                return $"data:image/{extension};base64," + Convert.ToBase64String(byteArray);
            }

            return "";
        }
    }
}
