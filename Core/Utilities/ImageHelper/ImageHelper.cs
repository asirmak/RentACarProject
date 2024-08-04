using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.ImageHelper
{
    public class ImageHelper
    {
        public static string AddImageToPath(IFormFile image, string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
            var extension = Path.GetExtension(image.FileName);
            var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

            var fullPath = Path.Combine(filePath, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return fullPath;
        }

        public static void DeleteImageFromPath(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
