namespace Services.Audios.ConvertAudioToStream;

public class ConvertAudioToStreamResult
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long StreamLength { get; set; }
}
