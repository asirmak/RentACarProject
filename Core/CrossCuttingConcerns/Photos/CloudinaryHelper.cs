using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Photos
{
    public static class CloudinaryHelper
    {
        public static void UploadImage(IFormFile image, out string imageUrl, out string imagePublicId)
        {

            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;

            using (var stream = image.OpenReadStream())
            {
                // Create upload parameters
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, stream), // Pass the file name and stream
                    UseFilename = true,    // Use the original file name
                    UniqueFilename = true, // Make the filename unique
                    Overwrite = true       // Overwrite existing file with the same name
                };

                // Upload the image to Cloudinary
                var uploadResult = cloudinary.Upload(uploadParams);

                imageUrl = uploadResult.Url.ToString();
                imagePublicId = uploadResult.PublicId;
            }
        }

        public static bool DeleteImage(string publicId)
        {
            // Create an instance of the Cloudinary class with the Cloudinary URL from environment variables
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            cloudinary.Api.Secure = true;

            // Set up the deletion parameters using the public ID of the image
            var deletionParams = new DeletionParams(publicId);

            // Call the destroy method to delete the image
            var deletionResult = cloudinary.Destroy(deletionParams);

            // Check if the result indicates success (deleted)
            return deletionResult.Result == "ok";
        }

    }
}
