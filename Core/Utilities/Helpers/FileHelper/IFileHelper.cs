using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {

        //FileHelper class’ının miras alacağı IFileHelper interface’ini oluşturuyorum.
        //Bu şekilde Business katmanımızda dependency injection yapma imkanım olup bağımlılığı minimize edeceğim.

        string Upload(IFormFile file, string root);
        void Delete(string path);
        string Update(IFormFile file, string imagePath, string root);
    }
}
