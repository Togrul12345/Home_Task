using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace PurpleBuzzTask.Utilities
{
    public static class FileManager
    {
        public static bool CheckType(this IFormFile formFile) => formFile.ContentType.Contains("image");
        public static string UploadImage(this IFormFile formFile, string envPath, string folder)
        {
            string path = Path.Combine(envPath, folder);
            string fileName=ChangeFileName(formFile.FileName);
            using (FileStream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
               

            return fileName;
        }
        public static bool CheckSize(this IFormFile formFile, int size)
        {
            if (formFile.Length > size * 1024 * 1024)
            {
                return false;
            }
            return true;
        }
        private static string ChangeFileName(string oldFileName)
        {
            string fileName = Path.GetFileNameWithoutExtension(oldFileName);
           
            if (fileName.Length > 50)
            {
                fileName = fileName.Substring(0, 50);
            }

            return fileName + Guid.NewGuid().ToString() + Path.GetExtension(oldFileName);
        }
    }
}
