using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPD.Domain.Interfaces
{
    public interface IImageStoreage
    {
        bool FolderExistsCheck(string path);
        Task StoreImageAsync(byte[] imageBuffer, string path, string imageName);
        /// <summary>
        /// Reads image usiong recived image path
        /// </summary>
        /// <param name="path">local image path</param>
        /// <returns>base64 encoded image string</returns>
        Task<string> ReadImage(string path);
    }
}
