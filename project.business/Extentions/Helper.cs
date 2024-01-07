using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Extentions
{
    public static class Helper
    {
        public static string SaveFile(string rootpath,string foldername,IFormFile file)
        {
             string fileName = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64, 64) : file.FileName;

            fileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(rootpath, foldername, fileName);

            using (FileStream Stream = new FileStream(path, FileMode.Create))
            {
                 file.CopyTo(Stream);
            }

            return fileName;
        }
    }
}
