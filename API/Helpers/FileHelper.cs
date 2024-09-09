using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;

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

        public static async Task<List<DocumentObject>> GetFiles(string caseID)
        {
            var allFiles = await AzureService.GetBlobs();

            return allFiles.Where(f => f.Id.Contains(caseID)).ToList();
        }

        public static async Task<List<DocumentObject>> GetMultipleFiles(IEnumerable<string> ids)
        {
            var allFiles = await AzureService.GetBlobs();

            return allFiles.Where(f => ids.Any(i => f.Id == i)).ToList();
        }

        public static async Task UploadFile(DocumentObject documentObject)
        {
            var fileProperties = GetFileData(documentObject.Id, documentObject.File);

            var fileId = fileProperties.Item1;
            var fileData = fileProperties.Item2;

            await AzureService.UploadImageToBlobAsync(documentObject.Id, documentObject.Name, fileData);

            // var text = FileHelper.ExtractTextFromFile(fileData);

            // documentObject.Content = text;

            // ElasticsearchHelper.CreateIndex(documentObject);
            // await ElasticsearchHelper.GetDocument(id);
        }

        private static string ExtractTextFromFile(byte[] pdfBytes)
        {
            // byte[] pdfBytes = Convert.FromBase64String(data);
            using (MemoryStream stream = new MemoryStream(pdfBytes))
            using (PdfReader reader = new PdfReader(stream))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            {
                string text = string.Empty;
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    text += GetTextFromPage(pdfDoc, i);
                }

                return text;
            }
        }

        private static string GetTextFromPage(PdfDocument pdfDoc, int pageNumber)
        {
            var page = pdfDoc.GetPage(pageNumber);
            return iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(page);
        }

        public static bool ShouldUploadFile(string file)
        {
            return !string.IsNullOrEmpty(file) && !file.Contains(AzureService.URL_PREFIX);
        }

        public static async Task DeleteImage(string fileId)
        {
            AzureService.DeleteFile($"{fileId}.pdf");

            await ElasticsearchHelper.DeleteDocument(fileId);
        }
    }
}