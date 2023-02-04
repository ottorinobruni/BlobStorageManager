using BlobStorageManager.Models.Entity;
using BlobStorageManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BlobStorageManager.Api.Models
{
    public class FileStorageRepository : IFileStorageRepository
    {
        private readonly AppDbContext appDbContext;

        public FileStorageRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Adds a new File record to the database.
        /// </summary>
        /// <param name="fileStorage">The data to be added.</param>
        /// <returns>Return the operation result.</returns>
        public async Task<bool> AddFile(FileStorage fileStorage)
        {
            var result = false;
            var file = appDbContext.FileStorages.SingleOrDefault(b => b.FileName == fileStorage.FileName);
            if (file == null)
            {
                await appDbContext.FileStorages.AddAsync(fileStorage);
            }
            else
            {
                file.UploadDateTime = fileStorage.UploadDateTime;
            }
            await appDbContext.SaveChangesAsync();
            result = true;
            return result;
        }

        /// <summary>
        /// Retrieves all File records from the database.
        /// </summary>
        /// <returns>Return a list of StorageDto.</returns>
        public async Task<List<FileStorage>> GetFiles()
        {
            return await appDbContext.FileStorages.OrderByDescending(e => e.UploadDateTime).ToListAsync();
        }
    }
}
