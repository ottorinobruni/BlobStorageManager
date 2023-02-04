using System;
using System.Reflection.Metadata;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobStorageManager.Models;

namespace BlobStorageManager.Api.Services
{
    public class BlobStorageService
    {
        private readonly string? storageConnectionString;
        private readonly string? storageContainerName;
        private readonly ILogger<BlobStorageService> logger;

        public BlobStorageService(IConfiguration configuration, ILogger<BlobStorageService> logger)
        {
            this.storageConnectionString = configuration.GetValue<string>("BlobStorageConnectionString");
            this.storageContainerName = configuration.GetValue<string>("BlobContainerName");
            this.logger = logger;
        }

        // <summary>
        /// Asynchronously uploads a file to the Storage Account and returns a response object.
        /// </summary>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns>Returns a ResponseDto object.</returns>
        public async Task<ResponseDto> UploadFileAsync(IFormFile file)
        {
            var response = new ResponseDto();
            try
            {
                var containerClient = new BlobContainerClient(storageConnectionString, storageContainerName);
                await containerClient.CreateIfNotExistsAsync();
                var blobClient = containerClient.GetBlobClient(file.FileName);

                await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                await using (Stream? data = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(data);
                }

                response.Status = $"File {file.FileName} Uploaded!";
                response.Error = false;
            }
            catch (Exception ex)
            {
                logger.LogError($"Unhandled Exception. ID: {ex.StackTrace} - Message: {ex.Message}");
                response.Status = $"File {file.FileName} not imported. Message: {ex.Message}!";
                response.Error = true;
            }
            return response;
        }

        /// <summary>
        /// Asynchronously downloads a file from the Storage Account and returns the StorageDto object.
        /// </summary>
        /// <param name="fileName">The name of the file to be downloaded.</param>
        /// <returns>Returns a StorageDto object.</returns>
        public async Task<StorageDto?> DownloadFileAsync(string fileName)
        {
            try
            {
                var containerClient = new BlobContainerClient(storageConnectionString, storageContainerName);
                var blobClient = containerClient.GetBlobClient(fileName);

                if (await blobClient.ExistsAsync())
                {
                    Stream data = await blobClient.OpenReadAsync();
                    var content = await blobClient.DownloadContentAsync();

                    return new StorageDto { Name = fileName, ContentType = content.Value.Details.ContentType, Content = data };
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Unhandled Exception. ID: {ex.StackTrace} - Message: {ex.Message}");
            }
            return null;
        }
    }
}

