using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MiskProgramTask.Helpers;

public class ExtensionMethods
{
    public static async Task<string> UploadFiles(IFormFile file, IConfiguration configuration,
        IHostEnvironment environment)
    {
        if (file.Length > 0)
        {
            string path = Path.Combine(environment.ContentRootPath, "wwwroot", "Attachment");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(path, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }

        return string.Empty;
    }
}