namespace Services.AWS.S3.UploadFileToS3Bucket;

public class UploadFileToS3BucketCommand
{
    public required string Bucket { get; set; }

    public required string ObjectKey { get; set; } = string.Empty;

    public required string ContentType { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public required Stream Stream { get; set; }
}
