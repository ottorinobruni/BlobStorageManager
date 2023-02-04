using System;
namespace BlobStorageManager.Api.Services
{
    public interface IBlobStorageService
    {
        // <summary>
        /// Asynchronously uploads a file to the Storage Account and returns a response object.
        /// </summary>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns>Returns a ResponseDto object.</returns>
        Task<ResponseDto> UploadFileAsync(IFormFile file);

        /// <summary>
        /// Asynchronously downloads a file from the Storage Account and returns the StorageDto object.
        /// </summary>
        /// <param name="fileName">The name of the file to be downloaded.</param>
        /// <returns>Returns a StorageDto object.</returns>
        Task<StorageDto?> DownloadFileAsync(string fileName);
    }
}

