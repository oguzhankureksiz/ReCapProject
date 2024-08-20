using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string path)
        {
            // Dosyanın var olup olmadığını kontrol ediyoruz
            if (File.Exists(path))
            {
                File.Delete(path);      //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }

        //Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))      //Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);      //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);      // Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    fileStream.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }

        
}
