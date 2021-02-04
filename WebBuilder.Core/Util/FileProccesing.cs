using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace WebBuilder.Core.Util
{
    public class FileProccesing
    {
        
        public async Task<string>  WriteFile(string location, IFormFile formFile)
        {

            try
            {
                FileInfo fileInfo = new FileInfo(formFile.FileName);
                var fileExtension = fileInfo.Extension;
                string newFileName = Guid.NewGuid().ToString()+fileExtension;
                if (!Directory.Exists(location)) Directory.CreateDirectory(location);
                var fullFileLocation = location +"\\" + newFileName ;
                using (var stream = System.IO.File.Create(fullFileLocation))
                {
                    await formFile.CopyToAsync(stream);
                }
                return newFileName;
            }
            catch (Exception ex)
            {

                return null;
            }

        }
        public async Task<bool>   DeleteFile(string location)
        {
            try
            {
                File.Delete(location);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
