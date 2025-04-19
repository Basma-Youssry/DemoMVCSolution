using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.AttatchmentService
{
    public class AttachmentService : IAttachmentService
    {
        public string? Upload(IFormFile file, string FolderName)
        {
            List<string> allowedExtensions = [".png", ".jpg", ".Jpeg"];

            var maxSize = 2_097_152;

            //1.Check Extension

            var extension = Path.GetExtension(file.FileName); //.png

            if (!allowedExtensions.Contains(extension)) return null;

            //2.Check size
            if (file ==null || file.Length == 0 || file.Length > maxSize) return null;

            //3.Get located folder path
            //C:\MVC demos\Session03&04&05&06\DemoMVCSolution\Demo.presentation\wwwroot\Files\Images\
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);

            //4.Make attachment name Unique-- GUID
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            //5.Get File path
            var filePath = Path.Combine(folderPath, fileName);

            //6. Create file stream to copy file[Unmanaged]
            using FileStream fs = new FileStream(filePath, FileMode.Create);

            //7.Use stream to copy file
            file.CopyTo(fs);

            //8.Return fileName to store in Database
            return fileName;
        }

        public bool Delete(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            else
            {
                File.Delete(filePath);
                return true;
            }
        }   
    }
}
