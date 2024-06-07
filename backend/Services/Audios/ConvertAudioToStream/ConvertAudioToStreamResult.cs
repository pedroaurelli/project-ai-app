namespace Services.Audios.ConvertAudioToStream;

public class ConvertAudioToStreamResult
{
    public Guid AudioId { get; set; }

    public required Stream Stream { get; set; }
}
