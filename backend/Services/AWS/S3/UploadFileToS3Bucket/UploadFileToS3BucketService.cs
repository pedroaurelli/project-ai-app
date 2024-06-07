using Amazon.S3;
using Amazon.S3.Model;

namespace Services.AWS.S3.UploadFileToS3Bucket;

public class UploadFileToS3BucketService : Service
{
    private IAmazonS3 awsS3Client;

    public UploadFileToS3BucketService(IAmazonS3 awsS3Client)
    {
        this.awsS3Client = awsS3Client;
    }

    public async Task<Guid> UploadToS3BucketAsync(
        UploadFileToS3BucketCommand command,
        CancellationToken cancellationToken = default)
    {
        var objectKey = command.ObjectKey;
        var bucketName = command.Bucket;
        var stream = command.Stream;
        var contentType = command.ContentType;

        var bucketToKebab = StringUtils.ToKebabCase(bucketName.ToString());
        var request = new PutObjectRequest
        {
            BucketName = bucketToKebab,
            Key = objectKey,
            CannedACL = S3CannedACL.Private,
            InputStream = stream,
            ContentType = contentType
        };

        await awsS3Client.PutObjectAsync(request, cancellationToken);

        var newAudio = new Audio
        {
            Key = objectKey,
            Bucket = bucketName,
            ContentType = contentType
        };

        DbContext.Audios.Add(newAudio);
        await DbContext.SaveChangesAsync(cancellationToken);

        return newAudio.Id;
    }
}
