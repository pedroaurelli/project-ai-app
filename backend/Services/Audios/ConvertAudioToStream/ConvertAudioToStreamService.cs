using Microsoft.AspNetCore.Http;
using Services.AWS.S3.UploadFileToS3Bucket;

namespace Services.Audios.ConvertAudioToStream;

public class ConvertAudioToStreamService : Service
{
    private readonly UploadFileToS3BucketService _uploadFileToS3BucketService;

    public ConvertAudioToStreamService(
        UploadFileToS3BucketService uploadFileToS3BucketService)
    {
        this._uploadFileToS3BucketService = uploadFileToS3BucketService;
    }

    public async Task<Stream> ConvertAudioToStreamAsync(
        IFormFile file,
        CancellationToken cancellationToken = default)
    {
        if (file == null || file.Length == 0)
        {
            throw new Exception("File is empty");
        }

        var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken);
        stream.Position = 0;

        var clonedStream = new MemoryStream();
        await stream.CopyToAsync(clonedStream, cancellationToken);
        clonedStream.Position = 0;

        using (var reader = new StreamReader(stream, leaveOpen: true))
        {
            var content = await reader.ReadToEndAsync(cancellationToken);
        }

        Console.WriteLine($"stream lenght: {stream.Length}");

        var contentToAws = new UploadFileToS3BucketCommand
        {
            Bucket = "audios",
            ObjectKey = file.FileName,
            Stream = stream,
            ContentType = file.ContentType
        };

        await _uploadFileToS3BucketService.UploadToS3BucketAsync(contentToAws, cancellationToken);

        return clonedStream;
    }
}

