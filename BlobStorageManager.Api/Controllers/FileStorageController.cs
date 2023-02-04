using BlobStorageManager.Api.Models;
using BlobStorageManager.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly ILogger<FileStorageController> logger;
        private readonly IFileStorageRepository fileStorageRepository;

        public FileStorageController(ILogger<FileStorageController> logger, IFileStorageRepository fileStorageRepository)
        {
            this.logger = logger;
            this.fileStorageRepository = fileStorageRepository;
        }

        [HttpGet("files")]
        public async Task<ActionResult<List<FileStorage>>> GetFiles()
        {
            return await fileStorageRepository.GetFiles();
        }
    }
}
