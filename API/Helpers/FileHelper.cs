using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Function
{
    public static class FileHelper
    {
        private static (string, byte[]) GetFileData(string id, string data)
        {
            string[] stringParts = data.Split(',');

            string imageType = stringParts[0].Split('/')[1].Split(';')[0];

            string base64String = stringParts[1];

            byte[] dataBytes = Convert.FromBase64String(base64String);

            string fileName = $"{id}.{imageType}";


            return (fileName, dataBytes);
        }


        public static async Task<List<string>> GetImages()
        {
            return await AzureService.GetBlobs();
        }


        public static async void UploadImage(string id, string data)
        {
            var fileProperties = GetFileData(id, data);

            var fileName = fileProperties.Item1;
            var fileData = fileProperties.Item2;

            await AzureService.UploadImageToBlobAsync(fileName, fileData);
        }

        public static bool ShouldUploadFile(string receipt)
        {
            return !string.IsNullOrEmpty(receipt) && !receipt.Contains(AzureService.URL_PREFIX);
        }

        public static void DeleteImage(string receiptUrl)
        {
            AzureService.DeleteFile(receiptUrl);
        }
    }
}