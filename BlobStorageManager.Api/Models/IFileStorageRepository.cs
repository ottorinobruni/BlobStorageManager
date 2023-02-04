using BlobStorageManager.Models.Entity;

namespace BlobStorageManager.Api.Models
{
    public interface IFileStorageRepository
    {
        /// <summary>
        /// Adds a new File record to the database.
        /// </summary>
        /// <param name="fileStorage">The data to be added.</param>
        /// <returns>Return the operation result.</returns>
        Task<bool> AddFile(FileStorage fileStorage);

        /// <summary>
        /// Retrieves all File records from the database.
        /// </summary>
        /// <returns>Return a list of FileStorage.</returns>
        Task<List<FileStorage>> GetFiles();
    }
}
