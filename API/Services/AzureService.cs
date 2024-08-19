using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Function
{
    public static class AzureService
    {
        private static string CONTAINER_NAME = "documents";
        private static string CONNECTION_STRING = "DefaultEndpointsProtocol=https;AccountName=courtsystem;AccountKey=P3qxdujdU2LdidExlmG691TVnivqDb9f9ESWjrK/qS7+xFabD3Be31TcT+PuJR1fL71yoNLNQNBx+AStekVkbg==;EndpointSuffix=core.windows.net";
        public static string URL_PREFIX = "https://courtsystem.blob.core.windows.net/documents/";


        public static async Task<string> GetFile(string fileName)
        {
            BlobClient blobClient = GetContainerClient().GetBlobClient(fileName);

            BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();
            string content = string.Empty;

            using (var reader = new StreamReader(blobDownloadInfo.Content))
            {
                content = await reader.ReadToEndAsync();
            }

            return content;
        }

        public static async Task<List<DocumentObject>> GetBlobs()
        {
            BlobContainerClient containerClient = GetContainerClient();
            List<DocumentObject> documents = new List<DocumentObject>();

            try
            {
                await foreach (BlobItem blobItem in containerClient.GetBlobsAsync(BlobTraits.Metadata))
                {
                    string fileURL = $"{URL_PREFIX}{blobItem.Name}";
                    var id = blobItem.Metadata["id"];
                    var name = blobItem.Metadata["name"];

                    var documentObject = new DocumentObject();
                    documentObject.Id = id;
                    documentObject.Name = name;
                    documentObject.Url = fileURL;
                    
                    documents.Add(documentObject);
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Error listing blobs: {ex.Message}");
            }

            return documents;
        }
        

        public static async Task UploadImageToBlobAsync(string imageId, string imageName, byte[] byteArray)
        {
            BlobClient blobClient = GetContainerClient().GetBlobClient(imageId);

            BlobUploadOptions options = new BlobUploadOptions
            {
                Metadata = new Dictionary<string, string> {
                    { "id", imageId },
                    { "name", imageName },
                }
            };

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                // await blobClient.UploadAsync(stream, true);
                await blobClient.UploadAsync(stream, options);
                blobClient.Uri.ToString();
            }
        }


        private static BlobContainerClient GetContainerClient()
        {

            // Create a BlobServiceClient using the connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(CONNECTION_STRING);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(CONTAINER_NAME);

            return containerClient;
        }

        public static void DeleteFile(string receipt)
        {
            receipt = receipt.Split(URL_PREFIX)[1];

            BlobClient blobClient = GetContainerClient().GetBlobClient(receipt);

            blobClient.Delete();
        }
    
    
    }
}