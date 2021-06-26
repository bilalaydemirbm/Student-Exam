using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace twitterClone.Models
{
    public class Upload
    {
        public string ImageUpload(List<IFormFile> files, IWebHostEnvironment environment,
                   out bool imgResult)
        {
            imgResult = false;

            var uploads = Path.Combine(environment.WebRootPath, "uploads");

            foreach (var file in files)
            {
                if (file.ContentType.Contains("image"))
                {
                    if (file.Length <= 2097152)
                    {
                        string uniqueName = $"{Guid.NewGuid().ToString().Replace("-", "_").ToLower()}." +
                            $"{file.ContentType.Split("/")[1]}";

                        var filePath = Path.Combine(uploads, uniqueName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);

                            imgResult = true;
                            return filePath.Substring(filePath.IndexOf("\\uploads\\"));
                        }
                    }
                    else
                    {
                        return $"2MB'dan büyük resim yüklenemez.";
                    }
                }
                else
                {
                    return $"Image dışında bir dosya yüklenemez.";
                }
            }
            return "Dosya bulunamadı. Lütfen en az bir dosya seçin.";
        }
    }
}

