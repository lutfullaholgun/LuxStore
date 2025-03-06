namespace LuxStore.Helpers
{
    public class FileHelper
    {
        public static async Task<string> FileUploader(IFormFile formFile, string filePath = "/Images/")
        {
            //Yüklenen dosyanın adını tutan bir değişken tanımla.
            string fileName = "";
            //eğer formFile boş değilse ve içinde veri varsa işlemleri başlat.
            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName.ToLower(); //Dosya adını küçük harfe çevir.
                // Uygulamanaın çalıştığı dizini bul ve hedef dosya yolunu oluştur.
                // /wwwrot/Images/
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName;
                //Dosyayı hedef dizine kopyala.
                using var stream = new FileStream(directory, FileMode.Create);
                //Dosyanın içeriğini stream'e kopyala(asenkron olarak).
                await formFile.CopyToAsync(stream);
            }
            return fileName;
        }

        public static bool FileDeleter(string fileName, string filePath = "/Images/")
        {
            string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName;
            if (File.Exists(directory))
            {
                File.Delete(directory);
                return true;
            }
            return false;
        }
    }
}