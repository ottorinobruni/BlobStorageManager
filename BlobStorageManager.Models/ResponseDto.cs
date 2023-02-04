using System;
namespace BlobStorageManager.Models
{
	public class ResponseDto
	{
        public string Status { get; set; }

        public bool Error { get; set; }

        public ResponseDto()
        {
            Status = string.Empty;
        }
    }
}

