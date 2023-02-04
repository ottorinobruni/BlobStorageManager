namespace BlobStorageManager.Models;

public class StorageDto
{
    public string? Name { get; set; }

    public string? ContentType { get; set; }

    public Stream? Content { get; set; }
}

