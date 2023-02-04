using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageManager.Models.Entity
{
    public class FileStorage : EntityBase
    {
        public string? FileName { get; set; }

        public string? Uri { get; set; }

        public string? ContentType { get; set; }

        public DateTime? UploadDateTime { get; set; }
    }
}
