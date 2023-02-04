using System;
using BlobStorageManager.Api.Services;
using BlobStorageManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlobStorageController : ControllerBase
    {
        private readonly ILogger<BlobStorageController> logger;
        private readonly IBlobStorageService blobService;

        public BlobStorageController(ILogger<BlobStorageController> logger, IBlobStorageService blobService)
        {
            this.logger = logger;
            this.blobService = blobService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IEnumerable<IFormFile> files)
        {
            var file = files.First();
            ResponseDto response = await blobService.UploadFileAsync(file);

            if (!response.Error)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpGet]
        [Route("donwload/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            StorageDto? file = await blobService.DownloadFileAsync(fileName);

            if (file == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"File {fileName} could not be downloaded!");
            }
            return File(file.Content!, file.ContentType!, file.Name);
        }
    }
}

